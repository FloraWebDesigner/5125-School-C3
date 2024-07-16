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
        public int TeacherId { get; set; }
        public string ClassName { get; set; }
        public string ClassCode {  get; set; }

        // Fail to figure it out, only have 1 on 1 relationship now, and missing some class data if one teacher has multiple classes.
       // public List<Class>ClassName { get; set; }
       // public List<Class> ClassCode { get; set; }

    }
}