using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using S_Squared.EmployeeClient.Services;
using S_Squared.EmployeeClient.ViewModels;
using System.Collections.Immutable;

namespace S_Squared.EmployeeClient.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        public EmployeeController(IEmployeeService employeeService, IRoleService roleService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
        }
        public async Task<IActionResult> Index()
        {
            EmployeeViewModel vm=new EmployeeViewModel();
            List<Employee> employees = await _employeeService.GetEmployeesAsync();

            vm.Employees = employees;
            vm.Managers = employees.Where(e => e.IsManager).ToList();

            return View(vm);
        }

        public async Task<PartialViewResult> LoadEmployeesAjax(int managerId)
        {
            List<Employee> employees = await _employeeService.GetEmployeesByManagerAsync(managerId);
            if(employees is null || employees.Count == 0)
            {
                return PartialView("_NoData");
            }
            return PartialView("_EmployeeRow",employees);
        }

        public async Task<JsonResult> ValidateEmployee(string employeeId)
        {

            if(await IsEmployeeIdExisted(employeeId))
                return Json(true);
         
            return Json(false);
        }

        public async Task<IActionResult> Create()
        {
            Employee employee = new Employee();

            await LoadRelatedData(employee);

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            var mol = ModelState.First(c => c.Key == "EmployeeId");

            bool isExisted = await IsEmployeeIdExisted(employee.EmployeeId);

            if(isExisted)
            {
                ModelState.AddModelError(nameof(employee.EmployeeId), "Employee Id already existed. Please enter another!");
            }

            if(employee.SelectedRoles is null || !employee.SelectedRoles.Any())
            {
                ModelState.AddModelError(nameof(employee.SelectedRoles), "Please select at least one role!");
            }

            if (ModelState.IsValid)
            {
                if (employee is not null)
                {

                    foreach (var role in employee.SelectedRoles)
                    {
                        employee.Roles.Add(new EmployeeRole { RoleId = role });
                    }
                }
                await _employeeService.CreateEmployee(employee);
                return RedirectToAction("Index");
            }
            await LoadRelatedData(employee);
            return View(employee);
        }

        private async Task LoadRelatedData(Employee employee)
        {
            List<Role> roles = new List<Role>();
            List<Employee> managers = await _employeeService.GetManagersAsync();

            roles = await _roleService.GetRolesAsync();

            SelectListItem[] managerItems = new SelectListItem[managers.Count];
            SelectListItem[] roleItems = new SelectListItem[roles.Count];

            for (int i = 0; i <= managers.Count - 1; i++)
            {
                managerItems[i] = new SelectListItem { Value = managers[i].Id.ToString(), Text = $"{managers[i].FirstName} {managers[i].LastName}" };
            }

            employee.SelectManagers = managerItems;

            for (int i = 0; i <= roles.Count - 1; i++)
            {
                roleItems[i] = new SelectListItem { Value = roles[i].Id.ToString(), Text = roles[i].RoleName };
            }
            employee.SelectRoles = roleItems;
        }

        private async Task<bool> IsEmployeeIdExisted(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
                return false;
            
            return await _employeeService.IsEmployeeExisted(employeeId);
        }
    }
}
