using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CumulativeP1.Models;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;

namespace CumulativeP1.Controllers
{
    public class ClassDataController : ApiController
    {
        // The database context class which allows us to access to our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        // This controller will access the class table of our school database.
        ///<summary>
        ///GET api/ClassData/ListClass/{SearchKey}
        ///To access a list of classes and their properties, including Class Code,Class Name,Start Date,Finish Date and Student Enrolment link
        ///</summary>
        ///<param name="SearchKey">search class name</param>
        ///<example>
        ///SearchKey = Pro
        ///Show two classes: Project Management and Web Programming and their Class Codes,Start Dates,Finish Dates and Student Enrolment links
        /// </example>
        ///<returns>
        ///Return a list of classes in the system with Class Code,Class Name,Start Date,Finish Date and Student Enrolment link
        ///</returns>

        [HttpGet]
        [Route("api/ClassData/ListClass/{SearchKey?}")]
        public List<Class> ListClass(string SearchKey = null)
        {
            //Create an instance of a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between the web server and database
            Connection.Open();

            // Establish a new command (query) for out database
            MySqlCommand Command = Connection.CreateCommand();

            //SQL QUERY
            Command.CommandText = "SELECT * FROM classes WHERE classname like lower(@key)";
            Command.Parameters.AddWithValue("@key", "%"+SearchKey+"%");
            Command.Prepare();


            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = Command.ExecuteReader();

            // Create an empty list of Class Names

            List<Class> Classes = new List<Class>();

            // Loop Through Each Row the ResultSet

            while (ResultSet.Read())
            {
                // Access Column information by the DB column name as an index
                string ClassName = ResultSet["classname"].ToString();
                string ClassCode = ResultSet["classcode"].ToString();
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                String StartDate = ((DateTime)ResultSet["startdate"]).ToShortDateString();
                String FinishDate = ((DateTime)ResultSet["finishdate"]).ToShortDateString();


            Class NewClass = new Class();
                NewClass.ClassCode = ClassCode;
                NewClass.ClassId = ClassId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName= ClassName;

                // Add class name to the list
                Classes.Add(NewClass);
            }
            //Close the connection between MySQL Database and the webserver
            Connection.Close();

            // return the final list of class names
            return Classes;

            }


        ///<summary>
        ///POST api/ClassData/FindStudent/{classid}
        ///To access a list of students and their properties, including StudentNumber,StudentName,Enroldate.
        ///</summary>
        ///<param name="ClassId">use classid to find students information</param>
        ///<example>
        ///ClassId = 2
        ///curl -d "" "http://localhost:61978/api/StudentData/FindStudent/2"
        ///Show 27 students information(StudentNumber,StudentName,Enroldate)
        ///</example>
        ///<returns>
        ///Return a list of students who enrolled in this class.
        ///</returns>
        [HttpPost]
        // I'd like to change to post, seems the url refers to the one I defined in the view, still show up the classid on the browser... 
        [Route("api/ClassData/FindStudent/{ClassId?}")]
        public List<Student> FindStudent(int ClassId)
        {
            
            //Create an instance of a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between the web server and database
            Connection.Open();

            // Establish a new command (query) for out database
            MySqlCommand Command = Connection.CreateCommand();

            //SQL QUERY
            Command.CommandText = "SELECT * FROM studentsxclasses LEFT JOIN classes ON classes.classid = studentsxclasses.classid LEFT JOIN students ON students.studentid = studentsxclasses.studentid WHERE classes.classid = @id";
            Command.Parameters.AddWithValue("@id",ClassId);
            Command.Prepare();


            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = Command.ExecuteReader();

            // Create an empty list of student properties

            List<Student> Students = new List<Student>();

            // Loop Through Each Row the ResultSet

            while (ResultSet.Read())
            {
                // Access Column information by the DB column name as an index
                string StudentName = ResultSet["studentfname"] + " " + ResultSet["studentlname"];
                string StudentNumber = ResultSet["studentnumber"].ToString();
                string Enroldate = ((DateTime)ResultSet["enroldate"]).ToShortDateString();
                ClassId = Convert.ToInt32(ResultSet["classid"]);


                Student NewStudent = new Student();
                NewStudent.StudentName = StudentName;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.Enroldate = Enroldate;
                NewStudent.ClassId = ClassId;

                // Add student information to the list
                Students.Add(NewStudent);
            }
            //Close the connection between MySQL Database and the webserver
            Connection.Close();

            // return the final list of student names
            return Students;

        }
    }
    }

