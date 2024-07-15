using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CumulativeP1.Models
{
    public class Teacher
    {

        // we use this class to describe what teachers' fields are for other components
        public string TeacherName { get; set; }
        public string EmployeeNumber { get; set; }
        public decimal TeacherSalary { get; set; }
        public DateTime TeacherHireDate { get; set; }
        public int TeacherID { get; set; }

    }
}