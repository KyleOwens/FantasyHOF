using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class PlayerRecord : Record
    {
        public int PlayerId { get; private set; }

        public decimal Value { get; init; }
        public Player player { get; private set; } = null!;
    }
}
