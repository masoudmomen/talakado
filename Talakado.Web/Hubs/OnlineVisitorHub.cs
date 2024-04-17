using Microsoft.AspNetCore.SignalR;
using Talakado.Application.Visitors.OnlineVisitors;

namespace Talakado.Web.Hubs
{
    public class OnlineVisitorHub:Hub
    {
        private readonly IOnlineVisitorService _onlineVisitorService;
        public OnlineVisitorHub(IOnlineVisitorService onlineVisitorService)
        {
            _onlineVisitorService = onlineVisitorService;
        }
        public override Task OnConnectedAsync()
        {
            string VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            _onlineVisitorService.ConnectUser(VisitorId);
            //var count = _onlineVisitorService.GetCount();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            _onlineVisitorService.DisconnectUser(VisitorId);
            //var count = _onlineVisitorService.GetCount();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
