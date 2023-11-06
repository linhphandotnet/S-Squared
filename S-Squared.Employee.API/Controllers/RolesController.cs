using Microsoft.AspNetCore.Mvc;

namespace S_Squared.EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<RolesController> _logger;

        public RolesController(ILogger<RolesController> logger, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRole()
        {
            _logger.LogInformation("Getting all role");
            var data = await _roleRepository.GetAll();
            return Ok(data);
        }

        [HttpGet]
        [Route("role/id/{id:int}")]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            _logger.LogInformation("Getting role by id");
            var data = await _roleRepository.GetById(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateRole(Role role)
        {
            try
            {
                _roleRepository.CreateRole(role);
                var result = await _roleRepository.SaveChangeAsync();
                _logger.LogInformation("Role was created successfuly!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                LoggerExtensions.LogError(_logger, ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateRole(Role role)
        {
            try
            {
                _roleRepository.UpdateRole(role);
                var data = await _roleRepository.SaveChangeAsync();
                _logger.LogInformation("Role was updated successfully!");
                return Ok(data);
            }
            catch (Exception ex)
            {
                LoggerExtensions.LogError(_logger, ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteRole(int id)
        {
            try
            {
                _roleRepository.DeleteRole(id);
                var data = await _roleRepository.SaveChangeAsync();
                _logger.LogInformation("Role was deleted successfully!");
                return Ok(data);
            }
            catch (Exception ex)
            {
                LoggerExtensions.LogError(_logger, ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
