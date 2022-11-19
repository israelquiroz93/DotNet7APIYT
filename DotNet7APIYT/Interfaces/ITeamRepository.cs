namespace DotNet7APIYT.Interfaces
{
    public interface ITeamRepository
    {
        public Task<List<Team>> GetAllTeams();
        public Task<Team> GetTeamById(int teamId);
        public Task<int> AddTeam(Team team);
        public Task<int> DeleteTeam(int teamId);
        public Task<int> EditTeam(Team team);
    }
}
