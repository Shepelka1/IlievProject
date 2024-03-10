using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }
        public byte[] ProfilePicture { get; set; }
        public List<Group> Groups { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> Friends { get; set; }
        public List<FriendRequest> FriendRequests { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Role Role { get; set; }
        public User()
        {
            Groups = new();
            Messages = new();
            Friends = new();
            FriendRequests = new();
        }

        public User(string id, string username, string password, byte[] profilePicture) : this()
        {
            Id = id;
            UserName = username;
            Password = password;
            ProfilePicture = profilePicture;
            CreatedDateTime = DateTime.Now;
        }
    }

}