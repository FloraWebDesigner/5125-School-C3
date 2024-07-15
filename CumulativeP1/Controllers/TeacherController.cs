using CumulativeP1.Models;
using System;
using System.Collections.Generic;
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
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            
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
            ViewData["SearchKey"] = SearchKey;
            //Views/Teacher/List.cshtml
            return View(Teachers);
        }

    }
}