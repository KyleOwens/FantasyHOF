using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class Record(FantasyMember member, RecordType type, decimal value)
    {
        public RecordType Type { get; private set; } = type;
        public FantasyMember Member { get; private set; } = member;
        public decimal Value { get; private set; } = value;

        public string DisplayName => Type.GetMetadata().DisplayName;
        public string IconURI => Type.GetMetadata().IconURI;
        public string Metric => Type.GetMetadata().Metric;
        public RecordCategory Category => Type.GetMetadata().Category;
        public RecordSentiment Sentiment => Type.GetMetadata().Sentiment;
        public bool IsPercentage => Type.GetMetadata().IsPercentage;
    }
}
