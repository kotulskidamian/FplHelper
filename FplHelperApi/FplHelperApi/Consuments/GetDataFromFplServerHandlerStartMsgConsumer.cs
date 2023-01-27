using FplHelperApi.Handlers;
using FplHelperApi.Messages.Contracts.GetDataFromFplServer;
using FplHelperApi.Models;
using MassTransit;
using MassTransit.Clients;

namespace FplHelperApi.Consuments
{
    public class GetDataFromFplServerHandlerStartMsgConsumer : IConsumer<IGetDataFromFplServerHandlerStartMsg>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetDataFromFplServerHandlerStartMsgConsumer(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task Consume(ConsumeContext<IGetDataFromFplServerHandlerStartMsg> context)
        {
            var handler = new GetDataFromFplServerHandler(_clientFactory);
            var result = await handler.Handle();

            await context.Publish<IGetDataFromFplServerHandlerEndMsg>(new
            {
                CorrelationId = context.Message.CorrelationId,
                RootFplResponse = result
            });
        }
    }
}
