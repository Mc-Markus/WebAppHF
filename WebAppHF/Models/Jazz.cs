﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class Jazz : Event
    {
        public string Hall { get; set; }
        public string Band { get; set; }
        public string IMGString { get; set; }
        
        //empty constructor needed for form
        public Jazz() { }
    }
}