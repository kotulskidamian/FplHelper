namespace FplHelperApi.Messages.Contracts
{
    public interface ISagaStartMessage
    {
        Guid CorrelationId { get; set; }
        Type SagaType { get; set; }
    }
}
