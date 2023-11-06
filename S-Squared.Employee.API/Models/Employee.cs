namespace S_Squared.EmployeeAPI.Models
{
    public class Employee : Entity
    {
        public Employee()
        {
            Roles = new List<EmployeeRoles>();
        }

        public string EmployeeId {  get; set; }
        public string LastName { get; set; } 
        public string FirstName { get; set; }
        public int? ManagerId {  get; set; }
        public bool IsManager {  get; set; }
        public List<EmployeeRoles> Roles { get; set; }

    }
}
