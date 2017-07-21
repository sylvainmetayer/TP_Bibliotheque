using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class EditMemberModelView
    {
        private List<Member> Members;
        public Member member { get; set; } // Pour récupérer l'entité du membre
        public int id;

        public List<Member> GetMembers()
        {
            return this.Members;
        }
    }
}