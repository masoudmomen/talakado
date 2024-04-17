using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Application.Visitors.OnlineVisitors
{
    public interface IOnlineVisitorService
    {
        void ConnectUser(string ConnectionId);
        void DisconnectUser(string ConnectionId);
        int GetCount();
    }
}
