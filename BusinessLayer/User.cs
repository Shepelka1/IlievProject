using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Username is too long")]
        public string Userame { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public int Password { get; set; }
        public Bitmap ProfilePicture { get; set; }
        public List<Group> Groups { get; set; }
        public List<TextMessage> TextMessages { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public User()
        {
            Groups = new();
            TextMessages = new();
        }

        public User(int id, string userame, int password, Bitmap profilePicture, Status status, List<Group> groups, List<TextMessage> textMessages)
        {
            Id = id;
            Userame = userame;
            Password = password;
            ProfilePicture = profilePicture;
            Status = status;
            Groups = groups;
            TextMessages = textMessages;
            CreatedDateTime = DateTime.Now;
        }
    }

}