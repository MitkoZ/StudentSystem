using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsMVC.Models;
namespace StudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {   Student[] students = new Student[3];
            students[0] = new Student{ Name = "Petar",FacultyNumber="20013" };
            students[1] = new Student { Name = "Mariq", FacultyNumber = "20014" };
            students[2] = new Student { Name = "Ivan", FacultyNumber = "20015" };
            return View(students);
        }

        public ActionResult ViewStudent(string studentName)
        {

            string[,] students = new string[,]{
                { "Ivan", "20020"},
                { "Pesho", "20019"},
                { "Lili", "20018"}
            };
            bool condition=false;
            for(int i = 0; i < students.GetLength(0); i++)
            {
                if (students[i,0] == studentName)
                {
                    
                    ViewBag.Student =students[i, 0];
                    ViewBag.FacultyNumber = students[i, 1];
                    condition = true;
                }
                
            }

            if (condition==false)
            {
                ViewBag.Message = "This student doesn't exist";
            }
            return View();
            
        }
        
        public ActionResult EditStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditStudentPost(string name)
        {
            ViewBag.Updated = "The info was updated for the user" + name;
            return View("EditStudent");
            
        }
        
        public ActionResult Login(LoginMenu login)
        {
            LoginMenu loginMenu = new LoginMenu();
            Session["username"] = login.Username;
            return View(loginMenu);

        }
        
    }
}