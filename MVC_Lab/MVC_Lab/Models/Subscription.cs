using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Lab.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public int ChatroomId { get; set; }

        public virtual User User { get; set; }
        public virtual Chatroom Chatroom { get; set; }
    }
}