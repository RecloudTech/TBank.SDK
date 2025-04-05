using Rc.TBank.SDK;
using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Responses;

namespace Rc.TBank.Tests;

public class Tests
{
    private AcquiringSdk _acquiringSdk;

    [SetUp]
    public void Setup()
    {
        var terminalKey = "1743867090370DEMO";
        var password = "ZCzoD&_#VpFnCfx&";
        var publicKey = password;

        _acquiringSdk = new AcquiringSdk(terminalKey, password, publicKey)
        {
            IsDeveloperMode = false
        };
    }

    [Test]
    public async Task InitTest()
    {
        var payment = await _acquiringSdk.Init(1000, Guid.NewGuid().ToString(), "RcPay-2024");
        
        var status = await _acquiringSdk.GetState(payment.PaymentId);
        
        // var check3Ds = await _acquiringSdk.Check3DsVersion(paymentId, new DefaultCardData
        // {
        //     Pan = "0000000000000000",
        //     ExpiryDate = "1230",
        //     SecureCode = "111"
        // });
        
        var result = await _acquiringSdk.FinishAuthorize(payment.PaymentId, false, new DefaultCardData
        {
            Pan = "0000000000000000",
            ExpiryDate = "1230",
            SecureCode = "111"
        }, "support@recloud.tech");
        
        Assert.Pass();
    }

    [Test]
    public async Task StatusTest()
    {
        var status = await _acquiringSdk.GetState("5001551864");

        Assert.Pass();
    }

    [Test]
    public async Task GetCards()
    {
        var status = await _acquiringSdk.GetCardList("RcPay-2024");

        Assert.Pass();
    }

    [Test]
    public async Task Charge()
    {
        // ToDo: Test this method
        var status = await _acquiringSdk.Charge("0", "");

        Assert.Pass();
    }

    [Test]
    public async Task CheckPaymentByTBank()
    {
        Assert.That(await _acquiringSdk.Tpay.CanPayAsync(), Is.True);
    }

    [Test]
    public async Task InitPaymentByTBank()
    {
        var payment = await _acquiringSdk.Tpay.InitPayAsync(1000, Guid.NewGuid().ToString(), "RcPay-2024");
        var qrCodeInfo = await _acquiringSdk.Tpay.GetPaymentInfoAsync(payment.PaymentId);
        var qrCode = await _acquiringSdk.Tpay.GetQRCodeAsync(payment.PaymentId);
    }

    [Test]
    public async Task InitPaymentBySbp()
    {
        var payment = await _acquiringSdk.FastPaymentSystem.InitPayAsync(1000, Guid.NewGuid().ToString(), "RcPay-2024");
        var qrCode = await _acquiringSdk.FastPaymentSystem.GetPaymentInfoAsync(payment.PaymentId);
    }
}