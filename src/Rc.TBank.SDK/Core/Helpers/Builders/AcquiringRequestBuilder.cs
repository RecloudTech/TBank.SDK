using System.Text;
using Rc.TBank.SDK.Models;
using Rc.TBank.SDK.Models.Requests;

namespace Rc.TBank.SDK.Core.Helpers.Builders;

internal abstract class AcquiringRequestBuilder<T> where T : AcquiringRequest, new()
{
    #region Ctor

    protected AcquiringRequestBuilder(string password, string terminalKey)
    {
        _password = password;
        _terminalKey = terminalKey;

        Request = new T();
    }

    #endregion

    #region Properties

    protected T Request { get; }

    #endregion

    #region Public Members

    public T Build()
    {
        Validate();
        Request.TerminalKey = _terminalKey;
        Request.Token = MakeToken();
        return Request;
    }

    #endregion

    #region Protected Members

    protected abstract void Validate();

    #endregion

    #region Private Members

    private string MakeToken()
    {
        var dictionary = Request.ToDictionary();
        dictionary.Remove(Fields.TOKEN);
        dictionary.Add(Fields.PASSWORD, _password);
        var builder = new StringBuilder();
        foreach (var pair in dictionary.OrderBy(pair => pair.Key)) builder.Append(pair.Value);
        return CryptoUtils.ComputeSha256Hash(builder.ToString());
    }

    #endregion

    #region Fields

    private readonly string _password;
    private readonly string _terminalKey;

    #endregion
}