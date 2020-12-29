using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Departments
    {
        [Key]
        public int Deptid { get; set; }

        public string DeptName { get; set; }

        [ForeignKey("Empid")]
        public Employee Employee { get; set; }

    }
}
