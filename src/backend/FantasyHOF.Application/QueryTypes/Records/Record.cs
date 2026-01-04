using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class Record(FantasyMember member)
    {
        public FantasyMember Member { get; private set; } = member;
    }
}
