using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.CLS
{
    public class hubsignalr : Hub
    {
        public string GetCurrentUserConnectionId()
        {
            return Context.ConnectionId;
        }
        public void addToGroup(string GroupName)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<hubsignalr>();
            context.Groups.Add(Context.ConnectionId, GroupName);
        }
    }
}