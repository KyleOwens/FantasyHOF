using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class Sport
    {
        public SportId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected Sport() { }

        public Sport(SportId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
