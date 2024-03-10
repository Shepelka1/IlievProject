using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FriendRequest
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public User Sender { get; set; }
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
        public User Receiver { get; set; }
        public Status Status { get; set; }
        public FriendRequest()
        {
            
        }
        public FriendRequest(User sender, User receiver, Status status)
        {
            Id = Guid.NewGuid().ToString();
            Sender = sender;
            Receiver = receiver;
            Status = status;
        }


    }
}
