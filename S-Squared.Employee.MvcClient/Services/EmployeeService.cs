
namespace S_Squared.EmployeeClient.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IOptions<AppSetting> _appSettings;
        private readonly ILogger<EmployeeService> _logger;
        private string _baseUrl;

        public EmployeeService(IHttpClientFactory httpClientFactory, IOptions<AppSetting> options)
        {
            _httpClient = httpClientFactory;
            _appSettings = options;
            _baseUrl = $"{_appSettings.Value.EmployeeUrl}/api/employees";
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.GetStringAsync($"{_baseUrl}/key/{id}");

            var employee = JsonSerializer.Deserialize<Employee>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.GetStringAsync($"{_baseUrl}/employee?id={id}");
            
            var employee = JsonSerializer.Deserialize<Employee>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, 
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            return employee;
        }

        public async Task<bool> IsEmployeeExisted(string id)
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.GetStringAsync($"{_baseUrl}/check?id={id}");

            var isExisted = JsonSerializer.Deserialize<bool>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            return isExisted;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.GetStringAsync(_baseUrl);

            var employee = JsonSerializer.Deserialize<List<Employee>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return employee;
        }

        public async Task<List<Employee>> GetEmployeesByManagerAsync(int? managerId)
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.GetStringAsync($"{_baseUrl}/managerid/{managerId}");

            var employee = JsonSerializer.Deserialize<List<Employee>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return employee;
        }

        public async Task<List<Employee>> GetManagersAsync()
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.GetStringAsync($"{_baseUrl}/managers");

            var employee = JsonSerializer.Deserialize<List<Employee>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return employee;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.PostAsync(_baseUrl, new StringContent(JsonSerializer.Serialize(employee), System.Text.Encoding.UTF8, "application/json"));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }


        public async Task<bool> DeleteEmployee(int id)
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.DeleteAsync($"{_baseUrl}/{id}");
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var client = _httpClient.CreateClient("EmployeeClient");
            var response = await client.PutAsync(_baseUrl, new StringContent(JsonSerializer.Serialize(employee), System.Text.Encoding.UTF8, "application/json"));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
