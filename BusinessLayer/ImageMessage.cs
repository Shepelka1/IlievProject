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
    public class ImageMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Bitmap Image { get; set; }
        public string Description { get; set; }
        public DateTime SentDateTime { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("Group")]
        public string GroupId { get; set; }
        public Group Group { get; set; }
        public ImageMessage()
        {

        }

        public ImageMessage(int id, Bitmap image, string description, User sender, Group group)
        {
            Id = id;
            Image = image;
            Description = description;
            SentDateTime = DateTime.Now;
            Sender = sender;
            Group = group;
        }
    }
}
