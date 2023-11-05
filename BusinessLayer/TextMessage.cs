using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TextMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime SentDateTime { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("Group")]
        public string GroupId { get; set; }
        public Group Group { get; set; }
        public TextMessage()
        {

        }

        public TextMessage(int id, string text, User sender, Group group)
        {
            Id = id;
            Text = text;
            SentDateTime = DateTime.Now;
            Sender = sender;
            Group = group;
        }
    }
}
