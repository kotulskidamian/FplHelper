using FplHelperApi.Messages.Contracts.GetDataFromFplServer;

namespace FplHelperApi.Messages.GetDataFromFplServer
{
    public class GetDataFromFplServerHandlerStartMsg : IGetDataFromFplServerHandlerStartMsg
    {
        public Guid CorrelationId { get; set; }
    }
}
