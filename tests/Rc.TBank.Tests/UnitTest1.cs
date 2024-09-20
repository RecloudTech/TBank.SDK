using Rc.TBank.SDK;
using Rc.TBank.SDK.Models;

namespace Rc.TBank.Tests;

public class Tests
{
    private AcquiringSdk _acquiringSdk;

    [SetUp]
    public void Setup()
    {
        var terminalKey = "";
        var password = "";
        var publicKey = "";

        _acquiringSdk = new AcquiringSdk(terminalKey, password, publicKey)
        {
            IsDeveloperMode = false
        };
    }

    [Test]
    public async Task InitTest()
    {
        var paymentId = await _acquiringSdk.Init(1000, Guid.NewGuid().ToString(), "RcPay-2024");
        var result = await _acquiringSdk.FinishAuthorize(paymentId, false, new DefaultCardData
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
        var paymentId = await _acquiringSdk.Tpay.InitPayAsync(1000, Guid.NewGuid().ToString(), "RcPay-2024");
        var qrCodeInfo = await _acquiringSdk.Tpay.GetPaymentInfoAsync(paymentId);
        var qrCode = await _acquiringSdk.Tpay.GetQRCodeAsync(paymentId);
    }

    [Test]
    public async Task InitPaymentBySbp()
    {
        var paymentId = await _acquiringSdk.FastPaymentSystem.InitPayAsync(1000, Guid.NewGuid().ToString(), "RcPay-2024");
        var qrCode = await _acquiringSdk.FastPaymentSystem.GetPaymentInfoAsync(paymentId);
    }
}