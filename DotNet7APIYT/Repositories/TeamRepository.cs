namespace DotNet7APIYT.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly SampleDatabaseContext _dbContext;

        public TeamRepository(SampleDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task<int> AddTeam(Team team)
        {
            Team newTeam = new Team() { ConfederationId = team.ConfederationId, CountryName = team.CountryName };
            _dbContext.Teams.Add(newTeam);
            await _dbContext.SaveChangesAsync();
            return team.TeamId;
        }

        public async Task<int> DeleteTeam(int teamId)
        {
            var rowsAffected = await _dbContext.Teams.Where(x => x.TeamId == teamId).ExecuteDeleteAsync();

            return rowsAffected;
        }

        public async Task<int> EditTeam(Team team)
        {
            var rowsAffected = await _dbContext.Teams.Where(x => x.TeamId == team.TeamId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.CountryName, team.CountryName));

            return rowsAffected;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            var teams = await _dbContext.Teams.Include(x => x.Confederation).ToListAsync();
            return teams;
        }

        public async Task<Team> GetTeamById(int teamId)
        {
            var team = await _dbContext.Teams.Include(x => x.Confederation).Where(x => x.TeamId == teamId).FirstOrDefaultAsync();
            return team;
        }
    }
}
