﻿using FplHelperApi.Models;

namespace FplHelperApi.Messages.Contracts.GetDataFromFplServer
{
    public interface IGetDataFromFplServerSagaEndMsg
    {
        RootFplResponse RootFplResponse { get; set; }
    }
}
