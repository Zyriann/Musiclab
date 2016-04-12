using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.Models
{
    public class Genre
    {
        [Required(ErrorMessage = "Genre is required")]
        [MaxLength(20)]
        public int GenreID { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}