using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class Position
    {
        public PositionId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected Position() { }

        public Position(PositionId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
