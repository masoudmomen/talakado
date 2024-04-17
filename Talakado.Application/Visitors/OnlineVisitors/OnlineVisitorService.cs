using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Contexts;
using Talakado.Domain.Visitors;

namespace Talakado.Application.Visitors.OnlineVisitors
{
    public class OnlineVisitorService: IOnlineVisitorService
    {
        private readonly IMongoDbContext<OnlineVisitor> _mongoDbContext;
        private readonly IMongoCollection<OnlineVisitor> _onlineVisitors;
        public OnlineVisitorService(IMongoDbContext<OnlineVisitor> mongoDbContext) 
        {
            _mongoDbContext = mongoDbContext;
            _onlineVisitors = _mongoDbContext.GetCollection();
        }

        public void ConnectUser(string ClientId)
        {
            var exist = _onlineVisitors.AsQueryable().FirstOrDefault(p=>p.ClientId == ClientId);
            if(exist == null)
            {
                _onlineVisitors.InsertOne(new OnlineVisitor
                {
                    ClientId = ClientId,
                    Time = DateTime.Now
                });
            }
        }

        public void DisconnectUser(string ClientId)
        {
            _onlineVisitors.FindOneAndDelete(p => p.ClientId == ClientId);
        }

        public int GetCount()
        {
            return _onlineVisitors.AsQueryable().Count();
        }
    }
}
