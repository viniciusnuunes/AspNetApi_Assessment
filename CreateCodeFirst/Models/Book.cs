using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreateCodeFirst.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}