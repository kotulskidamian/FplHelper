﻿namespace FplHelperApi.Messages.Contracts.GetDataFromFplServer
{
    public interface IGetDataFromFplServerSagaStartMsg
    {
        Guid CorrelationId { get; set; }
    }
}
