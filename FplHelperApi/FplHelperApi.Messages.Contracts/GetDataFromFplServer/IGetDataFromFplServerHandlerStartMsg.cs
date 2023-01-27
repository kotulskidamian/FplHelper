namespace FplHelperApi.Messages.Contracts.GetDataFromFplServer
{
    public interface IGetDataFromFplServerHandlerStartMsg
    {
        Guid CorrelationId { get; set; }
    }
}
