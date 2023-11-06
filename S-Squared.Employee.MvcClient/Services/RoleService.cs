
namespace S_Squared.EmployeeClient.Services
{
    public class RoleService : IRoleService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<AppSetting> _options;
        private string _baseUrl;
        public RoleService(IHttpClientFactory clientFactory, IOptions<AppSetting> options)
        {
            _clientFactory = clientFactory;
            _options = options;
            _baseUrl = $"{_options.Value.EmployeeUrl}/api/roles";
        }
        public async Task<List<Role>> GetRolesAsync()
        {
            var client = _clientFactory.CreateClient("EmployeeClient");
            var response = await client.GetStringAsync(_baseUrl);

            var role = JsonSerializer.Deserialize<List<Role>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return role;
        }
    }
}
