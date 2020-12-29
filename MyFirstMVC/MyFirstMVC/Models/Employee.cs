using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }

        public string city { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal NetSalary { get; set; }

      //  [EmpId]
      //,[EmpName]
      //,[EmpSalary]
      //,[city]
      //,[NetSalary]
    }
}
