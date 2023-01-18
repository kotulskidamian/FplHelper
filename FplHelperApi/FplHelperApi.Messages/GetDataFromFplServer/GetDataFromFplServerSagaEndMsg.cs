using FplHelperApi.Models;

namespace FplHelperApi.Messages.GetDataFromFplServer
{
    internal class GetDataFromFplServerSagaEndMsg
    {
        public RootFplResponse RootFplResponse { get; set; }
    }
}
