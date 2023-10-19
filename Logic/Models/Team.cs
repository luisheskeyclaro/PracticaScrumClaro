using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Team
    {

        public string Name { get; }
        public List<Member> Members { get; }

        public Team(string name)
        {
            Name = name;
            Members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }


    }
}
