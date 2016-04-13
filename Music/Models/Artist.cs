﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "Artist Name is Required")]
        public string Name { get; set; }
    }
}