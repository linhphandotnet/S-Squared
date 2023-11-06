namespace S_Squared.EmployeeClient.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Role Name"), MaxLength(50)]
        public string RoleName { get; set; }
    }
}
