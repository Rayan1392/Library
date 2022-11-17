using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class Book : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
