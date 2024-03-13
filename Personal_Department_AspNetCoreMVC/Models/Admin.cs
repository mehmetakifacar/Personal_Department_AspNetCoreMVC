using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal_Department_AspNetCoreMVC.Models
{
	public class Admin
	{
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName ="Varchar(20)")]
        public string User { get; set; }

        [Column(TypeName ="Varchar(10)")]
        public string Password { get; set; }
    }
}
