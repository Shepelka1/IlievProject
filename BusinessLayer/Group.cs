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
        public List<TextMessage> TextMessages { get; set; }
        public Group()
        {
            Users = new();
            TextMessages = new();
        }

        public Group(int id, string name, byte[] coverImage, List<User> users, List<TextMessage> textMessages)
        {
            Id = id;
            Name = name;
            CoverImage = coverImage;
            Users = users;
            TextMessages = textMessages;
        }
    }
}
