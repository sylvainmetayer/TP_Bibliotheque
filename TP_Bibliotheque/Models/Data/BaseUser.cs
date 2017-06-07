﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_Bibliotheque.Models.Data
{
    public class BaseUser
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nom requis."), MinLength(5), MaxLength(80)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prenom requis")]
        public string Prenom { get; set; }
    }
}