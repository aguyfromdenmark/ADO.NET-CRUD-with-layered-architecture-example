using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentClient.Controllers
{
    public class StudentController : Controller
    {
        BLL.BLL objBll = new BLL.BLL();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(string firstName,string lastName, string email)
        {
            var student = new Student { FirstNam = firstName, LastName = lastName, Email = email };

            try
            {
                objBll.CreateStudent(student);
            }
            catch (Exception)
            {

                throw new Exception("Something went horribly wrong!");
            }

            ViewBag.Message = "Student Created!";
            return RedirectToAction("CreateStudent",ViewBag);
        }

        public ActionResult GetAllStudents()
        {
            var allStudents = new List<Student>();

            allStudents = objBll.GetAllStudents();

            return View(allStudents);
        }

        public ActionResult DeleteStudent(int studentId)
        {
            try
            {
                objBll.DeleteStudent(studentId);
            }
            catch (Exception)
            {

                throw new Exception("Student could not be deleted!");
            }

            return RedirectToAction("GetAllStudents");
        }

        public ActionResult UpdateStudent(int studentId)
        {
            var studentToUpdate = objBll.GetStudent(studentId);

            return View(studentToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateStudent(string firstName,string lastName,string email,int studentId)
        {
            var studentToUpdate = new Student { FirstNam = firstName, LastName = lastName, Email = email, Id = studentId };
            try
            {
                objBll.UpdateStudent(studentToUpdate);

            }
            catch (Exception)
            {

                throw new Exception("Something went wrong!");
            }
            return RedirectToAction("GetAllStudents");
        }
    }
}