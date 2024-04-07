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
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Group name must be less than 50 characters")]
        public string Name { get; set; }
        public byte[] CoverImage { get; set; }
        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }
        public Group()
        {
            Users = new();
            Messages = new();
        }

        public Group(string name, byte[] coverImage, List<User> users, List<Message> messages) : this()
        {
            Name = name;
            CoverImage = coverImage;
            Users = users;
            Messages = messages;
        }
    }
}
