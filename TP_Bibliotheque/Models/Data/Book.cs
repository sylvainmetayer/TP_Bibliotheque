using System;
using System.ComponentModel.DataAnnotations;

namespace TP_Bibliotheque.Models.Data
{
    public class Book
    {
        public static int IdMax { get; set; }
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Edition { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AvailableQuantity { get; set; }
        public string Thematic { get; set; }

    }
}