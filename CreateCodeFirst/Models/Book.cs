using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreateCodeFirst.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Ano")]
        public string Ano { get; set; }

        [Display(Name = "Autor")]
        public virtual ICollection<Author> Authors { get; set; }
    }
}