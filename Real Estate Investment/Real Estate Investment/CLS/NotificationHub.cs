using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RealEstateInvestment.CLS
{
    public class NotificationHub : Hub
    {
        public readonly static NotificationHub _instance = new NotificationHub(GlobalHost.ConnectionManager.GetHubContext<hubsignalr>());
        private IHubContext _context;

        private NotificationHub(IHubContext context)
        {
            _context = context;
        }
        public void addToGroup(string GroupName, string connectionId)
        {
            _context.Groups.Add(connectionId, GroupName);
        }
    }
}