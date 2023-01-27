using FplHelperApi.Models;

namespace FplHelperApi.Messages.Contracts.GetDataFromFplServer
{
    public interface IGetDataFromFplServerHandlerEndMsg
    {
        Guid CorrelationId { get; set; }
        RootFplResponse RootFplResponse { get; set; }
    }
}
