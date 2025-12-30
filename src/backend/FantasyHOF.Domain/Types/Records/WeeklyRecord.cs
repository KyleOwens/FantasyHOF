using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class WeeklyRecord : Record
    {
        public int Year { get; init; }
        public int Week { get; init; }
    }
}
