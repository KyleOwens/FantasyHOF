using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public class RecordMetadata
    {
        public RecordMetadata(RecordType type)
        {
            Type = type;
        }

        public RecordType Type { get; private set; }

        public string DisplayName => Type.GetMetadata().DisplayName;
        public string IconURI => Type.GetMetadata().IconURI;
        public string Metric => Type.GetMetadata().Metric;
        public RecordCategory Category => Type.GetMetadata().Category;
        public string CategoryDisplayName => Type.GetMetadata().Category.GetDisplayName();
        public RecordSentiment Sentiment => Type.GetMetadata().Sentiment;
        public bool IsPercentage => Type.GetMetadata().IsPercentage;
    }
}
