
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativeP1.Models;

namespace CumulativeP1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: teacher/show/{id}
        public ActionResult Show(int id)
        {
            // work with the teacher data controller
            TeacherDataController controller = new TeacherDataController();

            //call the find teacher method
            Teacher NewTeacher = controller.FindTeacher(id);
            
            //pass along the FindTeacher to the view
            //Views/Teacher/Show.cshtml
            return View(NewTeacher);
        }

        // GET: teacher/list/{SearchKey}
        public ActionResult List(string SearchKey)
        {
            // work with the teacher data controller
            TeacherDataController controller = new TeacherDataController();

            //call the list teachers method
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);

            //pass along the List<Teacher> to the view
            //Views/Teacher/List.cshtml
            ViewData["SearchKey"] = SearchKey;
          
           return View(Teachers);
        }

        // POST:Teacher/Create
        // receive information about the teacher
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime TeacherHireDate, decimal TeacherSalary)
        {
            Debug.WriteLine("The teacher's first name is " + TeacherFname);
            Debug.WriteLine("The teacher's hiredate is " + TeacherHireDate);

            //todo: add the teacher to the database
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.TeacherHireDate = TeacherHireDate;
            NewTeacher.TeacherSalary = TeacherSalary;

            controller.AddTeacher(NewTeacher);
            // will execute the action of list view
            return RedirectToAction("List");

        }
        public ActionResult New()
        {


            return View();

        }

        [HttpGet]
        [Route("/teacher/ConfirmDelete/{TeacherId}")]
        // GET: /teacher/ConfirmDelete/{TeacherId}
        public ActionResult DeleteConfirm(int id)
        {
            // work with the teacher data controller
            TeacherDataController controller = new TeacherDataController();

            //call the previous find teacher method as we need that specific teacher information to confirm with the user
            Teacher NewTeacher = controller.FindTeacher(id);

            //pass along the FindTeacher to the view
            //Views/Teacher/DeleteConfirm.cshtml
            return View(NewTeacher);
        }

        ///POST: Teacher/Delete/
        ///
        [HttpPost]
        // POST: Teacher/Delete/{TeacherId} 
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }
    }
}