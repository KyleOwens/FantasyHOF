using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyMember
    {
        public int Id { get; private set; }

        public required string ProviderMemberId { get; init; }
        public required string DisplayName { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; set; }
    }
}
