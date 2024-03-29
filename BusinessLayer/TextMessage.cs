﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TextMessage : Message
    {
        [Required]
        public string Text { get; set; }
       
        public TextMessage()
        {

        }

        public TextMessage(string text, User sender, Group group) : base(sender, group)
        {   
            Text = text;
        }
    }
}
