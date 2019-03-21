using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateInvestment.Models
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string MessageText { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; }

        public int ActorId { get; set; }

        public string ActorName { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}