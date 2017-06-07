using System;

namespace TP_Bibliotheque.Models.Data
{
    public class Book
    {
        public string Title { get; set; }
        public Author author { get; set; }
        public string Edition { get; set; }
        public DateTime publicationDate { get; set; }
        public int availableQuantity { get; set; }
        public string thematic { get; set; }

    }
}