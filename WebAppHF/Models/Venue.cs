using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class Venue
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string InfoText { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}