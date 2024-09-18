using Rc.TBank.SDK.Models.Responses;

namespace Rc.TBank.SDK.Models.Exceptions;

public class AcquiringApiException(BaseAcquiringResponse? response) : AcquiringSdkException
{
    public readonly BaseAcquiringResponse? Response = response;
}