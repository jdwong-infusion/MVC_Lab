using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Lab.Models
{
    public class Chatroom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChatroomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string temp { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; } 
    }
}