
namespace S_Squared.EmployeeClient.Models
{
    public class Employee
    {
        public Employee()
        {
            Roles = new List<EmployeeRole>();
            ManagerId = 0;
        }
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "First Name is required data!")]
        [Display(Name = "First Name"), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last Name is required data!")]
        [Display(Name = "Last Name"),  MaxLength(50)]
        public string LastName { get; set; }

        public string FullName
        {
            get {
                    return $"{FirstName} {LastName}";
                }
        }

        [Required]
        [Display(Name ="Employee ID"), MaxLength(10)]
        [StringLength(100, ErrorMessage = "Employee Id is required data!")]
        public string EmployeeId {  get; set; }

        [Display(Name ="Manager")]
        public int? ManagerId {  get; set; }

        [Display(Name = "Is Manager")]
        public bool IsManager {  get; set; } = false;

        public List<EmployeeRole> Roles { get; set; }

        public IEnumerable<SelectListItem> SelectManagers { get; set; }

        [Required(ErrorMessage = "Please select at least one role!")]
        public int[] SelectedRoles { get; set; }
        
        public int SelectedManager {  get; set; }

        public IEnumerable<SelectListItem> SelectRoles { get; set;}
    }
}
