using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal_Department_AspNetCoreMVC.Models
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        public string PersonalName { get; set; }
        public string PersonalSurname { get; set; }
        public string PersonalCity { get; set; }
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
