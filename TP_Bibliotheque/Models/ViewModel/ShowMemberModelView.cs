using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class ShowMemberModelView
    {
        private Member Member;

        public ShowMemberModelView(Member member)
        {
            this.Member = member;
        }

        public Member getMember()
        {
            return this.Member;
        }
    }
}