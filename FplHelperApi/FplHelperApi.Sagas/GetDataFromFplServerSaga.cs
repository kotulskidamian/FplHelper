using Automatonymous;
using FplHelperApi.Messages.Contracts.GetDataFromFplServer;
using FplHelperApi.Messages.GetDataFromFplServer;
using MassTransit;
using MassTransit.Saga;

namespace FplHelperApi.Sagas
{
    public class GetDataFromFplServerState : SagaStateMachineInstance, ISagaVersion
    {
        public Guid CorrelationId { get; set; }
        public int Version { get; set; }
        public string CurrentState { get; set; }
    }

    public class GetDataFromFplServerSaga : MassTransitStateMachine<GetDataFromFplServerState>
    {
        public State GettingDataFromFplServer { get; set; }

        public Event<IGetDataFromFplServerSagaStartMsg> InitEvent { get; private set; }
        public Event<IGetDataFromFplServerHandlerEndMsg> GetDataFromFplServerDoneEvent { get; private set; }

        public GetDataFromFplServerSaga()
        {
            InstanceState(x => x.CurrentState);

            Event(() => InitEvent, x => x.CorrelateById(context => context.Message.CorrelationId));
            Event(() => GetDataFromFplServerDoneEvent, x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(InitEvent).Then(context =>
                {
                    context.Instance.CorrelationId = context.Data.CorrelationId;
                    Console.WriteLine("Here!");
                }).TransitionTo(GettingDataFromFplServer)
                .Publish(context => new GetDataFromFplServerHandlerStartMsg { 
                    CorrelationId = context.Instance.CorrelationId,
                } as IGetDataFromFplServerHandlerStartMsg));

            During(GettingDataFromFplServer,
                When(GetDataFromFplServerDoneEvent)
                .RespondAsync(x => x.Init<IGetDataFromFplServerSagaEndMsg>(new
                {
                    RootFplResponse = x.Data.RootFplResponse
                })));

            During(GettingDataFromFplServer,
                Ignore(InitEvent));
        }

    }
}
