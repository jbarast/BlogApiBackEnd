using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApiBackEnd.Domain.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}