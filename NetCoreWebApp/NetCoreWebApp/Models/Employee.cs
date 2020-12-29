using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApp.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Required]
        [Display(Name = "Employee Id")]
        public string EmpId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public string Mobile { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.MultilineText)]
        public string Location { get; set; }

        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }

        [Display(Name = "Department Id")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

    }
}
