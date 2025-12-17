using FantasyHOF.Domain.Types;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FantasyHOF.EntityFramework
{
    public class FantasyHOFDBContext : DbContext
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
        
        public FantasyHOFDBContext(DbContextOptions<FantasyHOFDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
