using FplHelperApi.Messages.Contracts;

namespace FplHelperApi.Messages
{
    public class SagaStartMessage : ISagaStartMessage
    {
        public Guid CorrelationId { get; set; }
        public Type SagaType { get; set; }
    }
}
