using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace FantasyHOF.EntityFramework
{
    public class FantasyHOFDBContext(DbContextOptions<FantasyHOFDBContext> options) : DbContext(options)
    {
        public DbSet<League> Leagues => Set<League>();
        public DbSet<FantasyMember> FantasyMembers => Set<FantasyMember>();
        public DbSet<FantasyProvider> FantasyProviders => Set<FantasyProvider>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<LeagueSeason> LeagueSeasons => Set<LeagueSeason>();
        public DbSet<LeagueSeasonMember> LeagueSeasonMembers => Set<LeagueSeasonMember>();
        public DbSet<LeagueSeasonMemberTeam> LeagueSeasonMemberTeams => Set<LeagueSeasonMemberTeam>();
        public DbSet<LeagueSeasonSettings> LeagueSeasonSettings => Set<LeagueSeasonSettings>();
        public DbSet<LeagueSeasonScheduleSettings> LeagueSeasonScheduleSettings => Set<LeagueSeasonScheduleSettings>();
        public DbSet<LeagueSeasonScoringSettings> LeagueSeasonScoringSettings => Set<LeagueSeasonScoringSettings>();
        public DbSet<LeagueSeasonScoringItem> LeagueSeasonScoringItems => Set<LeagueSeasonScoringItem>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<TeamSeasonStats> TeamSeasonStats => Set<TeamSeasonStats>();
        public DbSet<TeamMatchup> TeamMatchups => Set<TeamMatchup>();
        public DbSet<MatchupRosterSpot> MatchupRosterSpots => Set<MatchupRosterSpot>();
        public DbSet<AccumulatedStat> AccumulatedStats => Set<AccumulatedStat>();
        public DbSet<Stat> Stats => Set<Stat>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<MatchupOutcome> MatchupOutcomes => Set<MatchupOutcome>();
        public DbSet<MatchupType> MatchupTypes => Set<MatchupType>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Sport> Sports => Set<Sport>();
        public DbSet<MatchupTeamDetails> MatchupTeamDetails => Set<MatchupTeamDetails>();
        public DbSet<LeagueMemberAggregatedStats> LeagueMemberAggregatedStats => Set<LeagueMemberAggregatedStats>();
        public DbSet<LeagueSeasonMemberAggregatedStats> LeagueSeasonMemberAggregatedStats => Set<LeagueSeasonMemberAggregatedStats>();
        public DbSet<WeeklyAggregationData> WeeklyAggregationData => Set<WeeklyAggregationData>();
        public DbSet<PlayerAggregationData> PlayerAggregationData => Set<PlayerAggregationData>();
        public DbSet<LeagueMember> LeagueMembers => Set<LeagueMember>();
        public DbSet<LeagueImport> LeagueImports => Set<LeagueImport>();
        public DbSet<LeagueImportStatus> LeagueImportStatuses => Set<LeagueImportStatus>();

        private Guid? _rlsUserId;

        public Guid? RLSUserId => _rlsUserId;
        public void SetRLSUserId(Guid? userId)
        {
            _rlsUserId = userId;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            SetTimestamps();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimestamps();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetTimestamps()
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;

            foreach (EntityEntry<ITimestamped> entity in ChangeTracker.Entries<ITimestamped>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property(x => x.CreatedAt).CurrentValue = now;
                    entity.Property(x => x.UpdatedAt).CurrentValue = now;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Property(x => x.UpdatedAt).CurrentValue = now;
                }
            }
        }
    }
}
