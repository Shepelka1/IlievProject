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
    public class ImageMessage : Message
    {
       
        [Required]
        public Bitmap Image { get; set; }
        public string Description { get; set; }
        
        public ImageMessage()  
        {

        }

        public ImageMessage(int id, Bitmap image, string description, User sender, Group group):base(id, sender, group)
        {
            Image = image;
            Description = description;
        }
    }
}
