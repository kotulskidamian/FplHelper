﻿using FplHelperApi.Messages.Contracts.GetDataFromFplServer;

namespace FplHelperApi.Messages.GetDataFromFplServer
{
    public class GetDataFromFplServerSagaStartMsg : IGetDataFromFplServerSagaStartMsg
    {
        public Guid CorrelationId { get; set; }
    }
}
