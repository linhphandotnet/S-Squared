using Microsoft.AspNetCore.Mvc;

namespace S_Squared.EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var data = await _employeeRepository.GetAllAsync();
            _logger.LogInformation("Getting all employee list");
            return Ok(data);
        }

        [HttpGet]
        [Route("key/{key:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeByKey(int key)
        {
            var data = await _employeeRepository.GetByKeyAsync(key);
            _logger.LogInformation("Getting employee by identity Id");
            return Ok(data);
        }

        [HttpGet]
        [Route("employee")]
        public async Task<Employee> GetEmployeeById(string id)
        {
            var data = await _employeeRepository.GetByIDAsync(id);
            _logger.LogInformation("Getting employee by employee Id");
            return data;
        }

        [HttpGet]
        [Route("managerid/{managerid:int?}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeByManagerId(int? managerId)
        {
            var data = await _employeeRepository.GetByManagerAsync(managerId);
            _logger.LogInformation("Getting employee by manager Id");
            return Ok(data);
        }

        [HttpGet]
        [Route("managers")]
        public async Task<ActionResult<List<Employee>>> GetManagersAsync()
        {
            var data = await _employeeRepository.GetManagersAsync();
            _logger.LogInformation("Getting manager");
            return Ok(data);
        }

        [HttpGet]
        [Route("check")]
        public async Task<bool> IsEmployeeExisted(string id)
        {
            return await _employeeRepository.IsEmployeeExist(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateEmployee(Employee employee)
        {
            try
            {
                _employeeRepository.CreateEmployee(employee);
                var result = await _employeeRepository.SaveChangeAsync();

                _logger.LogInformation("Employee was created successfully!");

                return Ok(result);
            }
            catch (Exception ex)
            {
                LoggerExtensions.LogError(_logger, ex, ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateEmployee(Employee employee)
        {
            try
            {
                _employeeRepository.UpdateEmployee(employee);
                var result = await _employeeRepository.SaveChangeAsync();
                _logger.LogInformation("Employee was updated successfully");

                return Ok(result);
            }
            catch (Exception ex)
            {
                LoggerExtensions.LogError(_logger, ex, ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
                var result = await _employeeRepository.SaveChangeAsync();
                _logger.LogInformation("Employee was deleted successfully!");

                return Ok(result);

            }
            catch (Exception ex)
            {
                LoggerExtensions.LogError(_logger, ex, ex.Message);
                return BadRequest(ex);
            }
        }

    }
}
