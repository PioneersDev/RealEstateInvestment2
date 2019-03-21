using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models.ViewModels
{
    public class NotificationViewModels
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MessageText { get; set; }
        public string Url { get; set; }
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public bool Seen { get; set; }
        public DateTime? SeenAt { get; set; }
    }
}