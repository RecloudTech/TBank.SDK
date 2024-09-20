using Rc.TBank.SDK.Core;
using Rc.TBank.SDK.Core.Helpers;
using Rc.TBank.SDK.Core.Helpers.Builders;
using Rc.TBank.SDK.Interfaces.Procedures;
using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Exceptions;
using Rc.TBank.SDK.Models.Responses;

namespace Rc.TBank.SDK;

public class AcquiringSdk
{
    private static readonly string API_URL_RELEASE = "https://securepay.tinkoff.ru/v2/";
    private static readonly string API_URL_DEBUG = "https://rest-api-test.tinkoff.ru/v2/";
    private readonly HttpClient _httpClient;
    private readonly string _password;
    private readonly StringKeyCreator _publicKeyCreator;
    private readonly string _terminalKey;
    public ITPayProcedures Tpay { get; set; }
    public IFastPaymentSystem FastPaymentSystem { get; set; }

    public AcquiringSdk(string terminalKey, string password, string publicKey, HttpClient? httpClient = null) : this(
        terminalKey, password, new StringKeyCreator(publicKey))
    {
        _httpClient = httpClient ?? new HttpClient();

        Tpay = new TPayProcedures(terminalKey, _httpClient, this);
        FastPaymentSystem = new FastPaymentSystem(password, terminalKey, _httpClient, this); 
    }


    public AcquiringSdk(string terminalKey, string password, StringKeyCreator publicKeyCreator,
        HttpClient? httpClient = null)
    {
        _terminalKey = terminalKey;
        _password = password;
        _publicKeyCreator = publicKeyCreator;

        _httpClient = httpClient ?? new HttpClient();
    }

    public string? CustomUrl { get; set; }
    public bool IsDeveloperMode { get; set; }

    /// <summary>
    ///     Инициирует платежную сессию.
    /// </summary>
    /// <param name="amount">Сумма в копейках.</param>
    /// <param name="orderId">Номер заказа в системе Продавца.</param>
    /// <param name="customerKey">
    ///     Идентификатор покупателя в системе Продавца. Если передается и Банком разрешена
    ///     автоматическая привязка карт к терминалу, то для данного покупателя будет осуществлена привязка карты.
    /// </param>
    /// <param name="description">Краткое описание.</param>
    /// <param name="payForm">Название шаблона формы оплаты продавца.</param>
    /// <param name="recurrent">Регистрирует платеж как рекуррентный.</param>
    /// <returns>Уникальный идентификатор транзакции в системе Банка.</returns>
    public async Task<string> Init(decimal amount, string orderId, string customerKey, string description = default!,
        string payForm = default!, bool recurrent = default)
    {
        var request = new InitRequestBuilder(_password, _terminalKey)
            .SetAmount(amount)
            .SetOrderId(orderId)
            .SetCustomerKey(customerKey)
            .SetDescription(description)
            .SetPayForm(payForm)
            .SetRecurrent(recurrent)
            .Build();

        try
        {
            var response = await GetApi(request.Operation).Init(request);
            if (response is { Success: true })
                return response.PaymentId;

            throw new AcquiringApiException(response);
        }
        catch (AcquiringApiException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AcquiringSdkException(ex.Message);
        }

        return string.Empty;
    }

    /// <summary>
    ///     Подтверждает инициированный платеж передачей карточных данных.
    /// </summary>
    /// <param name="paymentId">Уникальный идентификатор транзакции в системе Банка.</param>
    /// <param name="sendEmail">Параметр, который определяет отравлять email с квитанцией или нет.</param>
    /// <param name="cardData">Данные карты.</param>
    /// <param name="infoEmail">Email на который будет отправлена квитанция об оплате.</param>
    /// <returns>
    ///     Объект ThreeDsData. Если терминал требует прохождения, свойство IsThreeDsNeeded будет установлено в true.
    /// </returns>
    public async Task<ThreeDsData> FinishAuthorize(string paymentId, bool sendEmail, CardData cardData,
        string infoEmail)
    {
        var request = new FinishAuthorizeRequestBuilder(_password, _terminalKey)
            .SetPaymentId(paymentId)
            .SetSendEmail(sendEmail)
            .SetCardData(cardData.Encode(_publicKeyCreator.Create()))
            .SetInfoEmail(infoEmail)
            .Build();

        try
        {
            var response = await GetApi(request.Operation).FinishAuthorize(request);
            if (response is null or { Success: false })
                throw new AcquiringApiException(response);

            return response.Status == PaymentStatus.DS_CHECKING
                ? new ThreeDsData
                {
                    IsThreeDsNeed = true,
                    ACSUrl = response.ACSUrl,
                    MD = response.MD,
                    PaReq = response.PaReq
                }
                : new ThreeDsData
                {
                    IsThreeDsNeed = false
                };
        }
        catch (AcquiringApiException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AcquiringSdkException(ex.Message);
        }
    }

    /// <summary>
    ///     Возвращает статус платежа.
    /// </summary>
    /// <param name="paymentId">Уникальный идентификатор транзакции в системе Банка.</param>
    /// <returns>Статус платежа.</returns>
    public async Task<PaymentStatus> GetState(string paymentId)
    {
        var request = new GetStateRequestBuilder(_password, _terminalKey)
            .SetPaymentId(paymentId)
            .Build();

        try
        {
            var response = await GetApi(request.Operation).GetState(request);
            if (response is { Success: true }) return response.Status;
            throw new AcquiringApiException(response);
        }
        catch (AcquiringApiException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AcquiringSdkException(ex.Message);
        }
    }

    /// <summary>
    ///     Возвращает список привязанных карт.
    /// </summary>
    /// <param name="customerKey">Идентификатор покупателя в системе Продавца.</param>
    /// <returns>Список сохраненных карт.</returns>
    public async Task<GetCardListResponse[]> GetCardList(string customerKey)
    {
        var request = new GetCardListRequestBuilder(_password, _terminalKey)
            .SetCustomerKey(customerKey)
            .Build();
        try
        {
            var response = await GetApi(request.Operation).GetCardList(request);

            return response;
        }
        catch (AcquiringApiException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AcquiringSdkException(ex.Message);
        }
    }

    /// <summary>
    ///     <para>
    ///         Осуществляет рекуррентный (повторный) платеж — безакцептное списание денежных средств со счета банковской карты
    ///         Покупателя. Для возможности его использования Покупатель должен совершить хотя бы один платеж в пользу
    ///         Продавца, который должен быть указан как рекуррентный (см. параметр recurrent в методе <see cref="Init" />),
    ///         фактически являющийся первичным.
    ///     </para>
    ///     <list type="number">
    ///         <listheader>
    ///             <description>
    ///                 Другими словами, для использования рекуррентных платежей необходима следующая
    ///                 последовательность действий:
    ///             </description>
    ///         </listheader>
    ///         <item>
    ///             <description>
    ///                 Совершить родительский платеж путем вызова <see cref="Init" /> с указанием дополнительного параметра
    ///                 Recurrent=Y.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 2. Получить RebillId, предварительно вызвав метод <see cref="GetCardList" />
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 3. Спустя некоторое время для совершения рекуррентного платежа необходимо вызвать метод
    ///                 <see cref="Init" /> со стандартным набором параметров (параметр Recurrent здесь не нужен).
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 4. Получить в ответ на <see cref="Init" /> параметр PaymentId.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 5. Вызвать метод <see cref="Charge" /> с параметром <paramref name="rebillId" /> полученным в п.2 и
    ///                 параметром <paramref name="paymentId" /> полученным в п.4.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </summary>
    /// <param name="paymentId">Уникальный идентификатор транзакции в системе Банка.</param>
    /// <param name="rebillId">Идентификатор рекуррентного платежа. См. метод <see cref="GetCardList" />.</param>
    /// <returns>Информация о платеже.</returns>
    public async Task<PaymentInfo> Charge(string paymentId, string rebillId)
    {
        var request = new ChargeRequestBuilder(_password, _terminalKey)
            .SetPaymentId(paymentId)
            .SetRebillId(rebillId)
            .Build();
        try
        {
            var response = await GetApi(request.Operation).Charge(request);

            if (response is { Success: true })
                return new PaymentInfo
                {
                    OrderId = response.OrderId,
                    PaymentId = int.Parse(response.PaymentId),
                    Status = response.Status
                };
            throw new AcquiringApiException(response);
        }
        catch (AcquiringApiException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AcquiringSdkException(ex.Message);
        }
    }

    internal AcquiringApi GetApi(string operation)
    {
        return IsDeveloperMode
            ? new AcquiringApi(string.Concat(API_URL_DEBUG, operation), _httpClient)
            : new AcquiringApi(string.Concat(API_URL_RELEASE, operation), _httpClient);
    }
}