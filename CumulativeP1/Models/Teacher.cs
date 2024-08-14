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
        // updated course from previous "class" according to Christine's feedback on 0814
        public string CourseName { get; set; }
        public string CourseCode {  get; set; }

        // added on 7/22 to get new teacher
        public string TeacherFname { get; set; }
        public string TeacherLname { get; set; }

        // Fail to figure it out, only have 1 on 1 relationship now, and missing some class data if one teacher has multiple classes.
        // public List<Class>ClassName { get; set; }
        // public List<Class> ClassCode { get; set; }


        //parameter-less constructor function
        public Teacher() { }

    }
}