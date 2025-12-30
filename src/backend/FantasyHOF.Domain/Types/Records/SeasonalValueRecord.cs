using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public class SeasonalValueRecord : SeasonalRecord, IValueRecord
    {
        public decimal Value { get; init; }
    }
}
