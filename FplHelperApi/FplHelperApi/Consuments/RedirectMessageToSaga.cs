using FplHelperApi.Messages.Contracts;
using FplHelperApi.Messages.Contracts.GetDataFromFplServer;
using MassTransit;

namespace FplHelperApi.Consuments
{
    public class RedirectMessageToSaga : IConsumer<ISagaStartMessage>
    {
        public async Task Consume(ConsumeContext<ISagaStartMessage> context)
        {
            var sagaType = context.Message.SagaType;

            if (sagaType == typeof(IGetDataFromFplServerSagaStartMsg))
            {
                await context.Publish<IGetDataFromFplServerSagaStartMsg>(new
                {
                    CorrelationId = context.Message.CorrelationId
                }); ;
            }
        }
    }
}
