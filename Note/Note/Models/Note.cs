﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string NameNote { get; set;}
        public string Text { get; set; }

        public string UserName { get; set; }
        
        public string Icon { get; set; }


    }
}
