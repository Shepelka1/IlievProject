using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public abstract class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SentDateTime { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public Message ()  
        {   

        }

        public Message(User sender, Group group)
        {
            SentDateTime = DateTime.Now;
            Sender = sender;
            Group = group;
        }
    }
}
