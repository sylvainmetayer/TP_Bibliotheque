using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class MembersModelView
    {
        private List<Member> Members;

        public MembersModelView(List<Member> Members)
        {
            this.Members = Members;
        }

        public List<Member> GetMembers()
        {
            return this.Members;
        }
    }
}