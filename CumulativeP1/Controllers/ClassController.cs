using CumulativeP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CumulativeP1.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class/show/{classid}
        public ActionResult Show(int ClassId)
        {
                        
            // work with the class data controller
            ClassDataController Controller = new ClassDataController();

            //call the find student method to get all the students in this class
            List<Student> NewStudent = Controller.FindStudent(ClassId);

            //pass along the FindStudent to the view
            //Views/Class/Show.cshtml
            return View(NewStudent);
        }

        // POST: class/list/{SearchKey?}
        public ActionResult List(string SearchKey=null)
        {
            // work with the class data controller
            ClassDataController controller = new ClassDataController();

            //call the list classes method
            List<Class> Classes = controller.ListClass(SearchKey);

            //pass along the List<Class> to the view
            //Views/Class/List.cshtml
            ViewData["SearchKey"] = SearchKey;
            return View(Classes);
        }
    }
}