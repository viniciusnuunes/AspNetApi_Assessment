using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreateCodeFirst.Web.Models
{
    public class Book
    {
        public int BookId { get; set; }
        
        [Required]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }
    }
}