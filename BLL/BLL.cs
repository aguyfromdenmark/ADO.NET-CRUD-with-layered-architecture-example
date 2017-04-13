using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL
    {
        DAL.DAL objDal = new DAL.DAL();

        public string GetDatabaseName()
        {
            return objDal.GetDatabaseName();
        }
        public void CreateStudent(Student student)
        {
            objDal.CreateStudent(student);
        }
        public Student GetStudent(int studentId)
        {
            return objDal.GetStudent(studentId);
        }
        public void UpdateStudent(Student student)
        {
            objDal.UpdateStudent(student);
        }
        public void DeleteStudent(int studentId)
        {
            objDal.DeleteStudent(studentId);
        }
        public List<Student> GetAllStudents()
        {
            return objDal.GetAllStudents();
        }
    }
}
