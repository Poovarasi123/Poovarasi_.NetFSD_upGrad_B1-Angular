using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnEFCodeFirstRelations.Entities
{
    internal class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}}
