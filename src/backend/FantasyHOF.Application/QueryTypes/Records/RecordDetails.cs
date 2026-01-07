using FantasyHOF.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public class RecordDetails
    {
        public required int Rank { get; init; }
        public required decimal Value { get; init; }
        public required FantasyMember Member { get; init; }
    }
}
