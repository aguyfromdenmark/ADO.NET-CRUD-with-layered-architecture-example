using System;
using Model;

namespace AdoNetStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL.BLL objBll = new BLL.BLL();

            Console.WriteLine("Connected to: " + objBll.GetDatabaseName() + "\n");

            Console.WriteLine("These are all the students:");
            foreach (var student in objBll.GetAllStudents())
            {
                Console.WriteLine(student.FirstNam + " " + student.LastName);
            }
        }
    }
}
