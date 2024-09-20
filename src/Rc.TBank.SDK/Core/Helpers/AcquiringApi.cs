using System.Text;
using System.Text.Json;
using Rc.TBank.SDK.Models.Requests;
using Rc.TBank.SDK.Models.Responses;

namespace Rc.TBank.SDK.Core.Helpers;

/// <summary>
///     Содержит константы для создания запросов к Acquiring API.
/// </summary>
public class AcquiringApi
{
    public const string AddCardMethod = "AddCard";
    public const string AttachCardMethod = "AttachCard";
    public const string ChargeMethod = "Charge";
    public const string CancelMethod = "Cancel";
    public const string FinishAuthorizeMethod = "FinishAuthorize";
    public const string GetAddCardStateMethod = "GetAddCardState";
    public const string Check3dsVersionMethod = "Check3dsVersion";
    public const string GetCardListMethod = "GetCardList";
    public const string GetStateMethod = "GetState";
    public const string InitMethod = "Init";
    public const string ConfirmMethod = "Confirm";
    public const string RemoveCardMethod = "RemoveCard";
    public const string SubmitRandomAmountMethod = "SubmitRandomAmount";
    public const string GetQrMethod = "GetQr";
    public const string GetStaticQrMethod = "GetStaticQr";
    public const string Submit3dsAuthorization = "Submit3DSAuthorization";
    public const string Submit3dsAuthorizationV2 = "Submit3DSAuthorizationV2";
    public const string Complete3dsMethodV2 = "Complete3DSMethodv2";
    public const string GetTerminalPayMethods = "GetTerminalPayMethods";
    public const string MirPayGetDeeplinkMethod = "MirPay/GetDeepLink";

    public const string ApiErrorCode3dsV2NotSupported = "106";
    public const string ApiErrorCodeCustomerNotFound = "7";
    public const string ApiErrorCodeChargeRejected = "104";
    public const string ApiErrorCodeNoError = "0";

    public const string RecurringTypeKey = "recurringType";
    public const string RecurringTypeValue = "12";
    public const string FailMapiSessionId = "failMapiSessionId";

    internal const int StreamBufferSize = 4096;
    internal const string ApiRequestMethodPost = "POST";
    internal const string ApiRequestMethodGet = "GET";

    public const string Json = "application/json";
    internal const string FormUrlEncoded = "application/x-www-form-urlencoded";

    /// <summary>
    ///     Таймаут сетевых запросов в секундах.
    /// </summary>
    internal const long NetworkTimeoutSeconds = 40;

    internal const string ApiVersion = "v2";
    internal const string ApiUrlRelease = "https://securepay.tinkoff.ru/" + ApiVersion;
    internal const string ApiUrlDebug = "https://rest-api-test.tinkoff.ru/" + ApiVersion;
    internal const string ApiUrlPreprod = "https://qa-mapi.tcsbank.ru/" + ApiVersion;

    /// <summary>
    ///     Коды ошибок, сообщение которых можно показать конечным пользователям.
    /// </summary>
    public static readonly List<string> ErrorCodesForUserShowing = new()
    {
        "53", "206", "224", "225", "252", "99", "101", "1006", "1012", "1013", "1014", "1015", "1030", "1033",
        "1034", "1035", "1036", "1037", "1038", "1039", "1040", "1041", "1042", "1043", "1051", "1054", "1057",
        "1065", "1082", "1089", "1091", "1096"
    };

    /// <summary>
    ///     Коды ошибок, вызванные временными неполадками системы.
    /// </summary>
    public static readonly List<string> ErrorCodesFallback = new() { "9999", "231", "3", "3001" };

    /// <summary>
    ///     Коды ошибок при привязке карты.
    /// </summary>
    public static readonly List<string> ErrorCodesAttachedCard = new() { "3", "6" };

    private readonly string? _customUrl;
    private readonly HttpService _httpService;
    private readonly bool _isDeveloperMode;

    public AcquiringApi(string url, HttpClient httpClient)
    {
        Url = new Uri(url);
        _httpService = new HttpService(httpClient);
    }

    public Uri Url { get; set; }

    /// <summary>
    ///     Возвращает базовый URL.
    /// </summary>
    /// <returns>Базовый URL, зависящий от режима работы SDK и пользовательского URL.</returns>
    public string GetUrl()
    {
        return _isDeveloperMode && !string.IsNullOrEmpty(_customUrl)
            ? FixUrlEnding(_customUrl, ApiVersion)
            : _isDeveloperMode
                ? ApiUrlDebug
                : ApiUrlRelease;
    }

    private static string FixUrlEnding(string url, string ending)
    {
        return url.EndsWith(ending) ? url : $"{url}/{ending}";
    }

    internal Task<InitAcquiringResponse?> Init(InitRequest request)
    {
        return SendAsync<InitAcquiringResponse>(Url, request.ToDictionary());
    }


    internal Task<FinishAuthorizeAcquiringResponse?> FinishAuthorize(FinishAuthorizeRequest request)
    {
        return SendAsync<FinishAuthorizeAcquiringResponse>(Url, request.ToDictionary());
    }

    internal Task<ChargeAcquiringResponse?> Charge(ChargeRequest request)
    {
        return SendAsync<ChargeAcquiringResponse>(Url, request.ToDictionary());
    }

    internal Task<GetStateAcquiringResponse?> GetState(GetStateRequest request)
    {
        return SendAsync<GetStateAcquiringResponse>(Url, request.ToDictionary());
    }

    internal Task<FastPaymentSystemResponse?> GetFastPaymentSystemQrData(FastPaymentSystemQrRequest request)
    {
        return SendAsync<FastPaymentSystemResponse>(Url, request.ToDictionary());
    }

    internal async Task<GetCardListResponse[]> GetCardList(GetCardListRequest acquiringResponse)
    {
        var response = await SendAsync<GetCardListResponse[]>(Url, acquiringResponse.ToDictionary());

        return response ?? [];
    }

    internal Task<RemoveCardAcquiringResponse?> RemoveCard(RemoveCardRequest request)
    {
        return SendAsync<RemoveCardAcquiringResponse>(Url, request.ToDictionary());
    }

    private async Task<T?> SendAsync<T>(Uri uri, IDictionary<string, string> parameters)
    {
        var jsonString = JsonSerializer.Serialize(parameters);
        using (var content =
               new StringContent(jsonString, Encoding.UTF8, "application/json"))
        {
            var response = await _httpService.PostAsync(uri, content).ConfigureAwait(false);
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(value) ?? default;
        }
    }
}