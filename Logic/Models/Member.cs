using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Logic.Models
{

    public class Member
    {
        public string Name { get; set; }
        public Role Role { get; set; }

        public Member(string name, Role role)
        {
            Name = name;
            Role = role;
        }

    }
}
