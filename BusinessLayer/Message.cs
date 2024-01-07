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
        public int SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public Message ()  
        {   

        }

        public Message(int id, User sender, Group group)
        {
            Id = id;
            SentDateTime = DateTime.Now;
            Sender = sender;
            Group = group;
        }
    }
}
