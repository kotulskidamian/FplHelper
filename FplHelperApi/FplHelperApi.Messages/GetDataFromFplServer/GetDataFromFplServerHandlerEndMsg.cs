using FplHelperApi.Messages.Contracts.GetDataFromFplServer;
using FplHelperApi.Models;

namespace FplHelperApi.Messages.GetDataFromFplServer
{
    public class GetDataFromFplServerHandlerEndMsg : IGetDataFromFplServerHandlerEndMsg
    {
        public Guid CorrelationId { get; set; }
        public RootFplResponse RootFplResponse { get; set; }
    }
}
