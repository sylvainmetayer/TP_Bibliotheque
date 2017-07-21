using System;
using System.ComponentModel.DataAnnotations;

namespace TP_Bibliotheque.Models.Data
{
    public class BooksBorrowing
    {
        public static int IdMax { get; set; }
        [Required]
        public int Id { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime returnDate { get; set; }
        public Member user { get; set; }
        public Book book { get; set; }
        public Boolean isReturned { get; set; }
        public int daysRetard { get; set; }


    }
}