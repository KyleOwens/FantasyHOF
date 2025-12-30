using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class SeasonalRecord : Record
    {
        public int Year { get; init; }
    }
}
