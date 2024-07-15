using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CumulativeP1.Models;
using MySql.Data.MySqlClient;

namespace CumulativeP1.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        // This Controller will access the teacher table of our school database.
        ///<summary>
        ///Returns a list of teachers' properties in the system
        /// </summary>
        /// <example>
        /// GET api/TeacherData/ListTeachers
        /// </example>
        /// <returns>
        /// A list of teachers' name, employee number, hire date and salary
        /// </returns>

        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey}")]
        public List<Teacher> ListTeachers(string SearchKey)
        {
            // Create an instance of a connection
            MySqlConnection Connection = School.AccessDatabase();
            Debug.WriteLine("I want to search " + SearchKey);
            // Open the connection between the web server and database
            Connection.Open();

            // Establish a new command (query) for our database
            MySqlCommand Command = Connection.CreateCommand();

            //SQL QUERY
            Command.CommandText = "Select * from teachers where lower (teacherfname) like lower (@key) or lower (teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower (@key)";

            // Use @key to avoid error outcome of special symbol
            Command.Parameters.AddWithValue("@key", "%"+SearchKey+"%");
            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = Command.ExecuteReader();

            // Create an empty list of Teacher Names
            List<Teacher> Teachers = new List<Teacher>();

            // Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column innformation by the DB column name as an index
                string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                string EmployeeNumber = Convert.ToString(ResultSet["employeenumber"]);
                decimal TeacherSalary = Convert.ToDecimal(ResultSet["salary"]);
                DateTime TeacherHireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                int TeacherID = (int)ResultSet["teacherid"];


                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherName= TeacherName;
                NewTeacher.TeacherSalary= TeacherSalary;
                NewTeacher.TeacherHireDate= TeacherHireDate;
                NewTeacher.EmployeeNumber= EmployeeNumber;
                NewTeacher.TeacherID = TeacherID;

                // Add the Teacher elements to the List
                Teachers.Add(NewTeacher);
            }

            // Close the connection between the MySQL Database and the WebServer
            Connection.Close();

            // Return the final list of author names
            return Teachers;

        }

        [HttpGet]
        [Route("api/TeacherData/FindTeacher")]
        public Teacher FindTeacher(int TeacherId)
        {
            Teacher NewTeacher = new Teacher();

            // Create an instance of a connection
            MySqlConnection Connection = School.AccessDatabase();

            // Open the connection between the web server and database
            Connection.Open();

            // Establish a new command (query) for our database
            MySqlCommand Command = Connection.CreateCommand();

            //SQL QUERY
            Command.CommandText = "SELECT * FROM teachers WHERE teacherid = @id";

            // Use @key to avoid error outcome of special symbol
            Command.Parameters.AddWithValue("@id",TeacherId);

            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = Command.ExecuteReader();

            while (ResultSet.Read())
            {
                string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                string EmployeeNumber = Convert.ToString(ResultSet["employeenumber"]);
                decimal TeacherSalary = Convert.ToDecimal(ResultSet["salary"]);
                DateTime TeacherHireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                int TeacherID = (int)ResultSet["teacherid"];


                NewTeacher.TeacherName = TeacherName;
                NewTeacher.TeacherSalary = TeacherSalary;
                NewTeacher.TeacherHireDate = TeacherHireDate;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.TeacherID = TeacherID;

            }

            return NewTeacher;
        }
    }
}
