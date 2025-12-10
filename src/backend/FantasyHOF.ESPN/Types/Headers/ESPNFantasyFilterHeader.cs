using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Headers
{
    public class ESPNFantasyFilterHeader
    {
        private static readonly JsonSerializerOptions _serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        
        public ScheduleFilter Schedule { get; set; } = new();

        public ESPNFantasyFilterHeader(int scoringPeriod)
        {
            Schedule.FilterMatchupPeriodIds.Value = [scoringPeriod]; 
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, _serializerOptions);
        }

        public class ScheduleFilter
        {
            public MatchupPeriodFilter FilterMatchupPeriodIds { get; set; } = new();
        }

        public class MatchupPeriodFilter
        {
            public int[] Value { get; set; } = [];
        }
    }
}
