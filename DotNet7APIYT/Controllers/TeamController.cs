using DotNet7APIYT.Interfaces;

namespace DotNet7APIYT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository teamRepository;

        public TeamController(ITeamRepository repository)
        {
            teamRepository = repository;
        }


        [HttpGet("GetTeams")]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var teams = await teamRepository.GetAllTeams();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetTeamById/{teamId}")]
        public async Task<IActionResult> GetTeamById(int teamId)
        {
            try
            {
                var teams = await teamRepository.GetTeamById(teamId);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("AddTeam")]
        public async Task<IActionResult> AddTeam(Team newTeam)
        {
            try
            {
                var teams = await teamRepository.AddTeam(newTeam);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("EditTeam")]
        public async Task<IActionResult> EditTeam(Team team)
        {
            try
            {
                var rowsAffected = await teamRepository.EditTeam(team);
                return Ok(rowsAffected);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("DeleteTeam/{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            try
            {
                var rowsAffected = await teamRepository.DeleteTeam(teamId);
                return Ok(rowsAffected);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
