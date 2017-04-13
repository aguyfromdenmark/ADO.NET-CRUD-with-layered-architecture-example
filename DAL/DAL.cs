using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL
    {
        private static SqlConnection connectionString;

        public DAL()
        {
            connectionString = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\ADO.NET-CRUD-with-layered-architecture-example\DAL\App_Data\StudentDb.mdf;Integrated Security=True");
        }

        public string GetDatabaseName()
        {
            connectionString.Open();
            string returnString = connectionString.Database;
            connectionString.Close();

            return returnString;
        }
        public void CreateStudent(Student student)
        {
            string createStudentQuery = "INSERT INTO Students (fname,lname,email) VALUES (@fname,@lname,@email)";
            createStudentQuery = "CreateStudent"; //Using stored procedure
            
            SqlCommand createStudentCommand = new SqlCommand(createStudentQuery, connectionString);

            createStudentCommand.CommandType = System.Data.CommandType.StoredProcedure;

            createStudentCommand.Parameters.AddWithValue("@fname", student.FirstNam);
            createStudentCommand.Parameters.AddWithValue("@lname", student.LastName);
            createStudentCommand.Parameters.AddWithValue("@email", student.Email);
            connectionString.Open();
            createStudentCommand.ExecuteNonQuery();
            connectionString.Close();
        }
        public Student GetStudent(int studentId)
        {
            string getStudentQuery = "SELECT * FROM Students WHERE Id = @Id";
            getStudentQuery = "GetStudent"; //Stored precedure
            SqlCommand getStudentCommand = new SqlCommand(getStudentQuery, connectionString);

            getStudentCommand.CommandType = System.Data.CommandType.StoredProcedure;

            getStudentCommand.Parameters.AddWithValue("@Id", studentId);
            SqlDataReader getStudentReader;

            connectionString.Open();
            getStudentReader = getStudentCommand.ExecuteReader();

            var student = new Student();

            while (getStudentReader.Read())
            {
                student.Id = Int32.Parse(getStudentReader[0].ToString());
                student.FirstNam = getStudentReader[1].ToString().Trim();
                student.LastName = getStudentReader[2].ToString().Trim();
                student.Email = getStudentReader[3].ToString().Trim();
            }
            connectionString.Close();
            return student;

        }
        public void UpdateStudent(Student student)
        {
            string updateStudentQuery = "UPDATE Students SET fname = @fname, lname = @lname, email = @email WHERE Id = @Id";
            updateStudentQuery = "UpdateStudent"; //Stored procedure
            SqlCommand updateStudentCommand = new SqlCommand(updateStudentQuery, connectionString);

            updateStudentCommand.CommandType = System.Data.CommandType.StoredProcedure;

            updateStudentCommand.Parameters.AddWithValue("@Id", student.Id);
            updateStudentCommand.Parameters.AddWithValue("@fname", student.FirstNam);
            updateStudentCommand.Parameters.AddWithValue("@lname", student.LastName);
            updateStudentCommand.Parameters.AddWithValue("@email", student.Email);
            connectionString.Open();
            updateStudentCommand.ExecuteNonQuery();
            connectionString.Close();
        }
        public void DeleteStudent(int studentId)
        {
            string deleteStudentQuery = "DELETE FROM Students WHERE Id = @Id";
            deleteStudentQuery = "DeleteStudent"; //Stored procedure
            SqlCommand deleteStudentCommand = new SqlCommand(deleteStudentQuery, connectionString);

            deleteStudentCommand.CommandType = System.Data.CommandType.StoredProcedure;

            deleteStudentCommand.Parameters.AddWithValue("@Id", studentId);
            connectionString.Open();
            deleteStudentCommand.ExecuteNonQuery();
            connectionString.Close();
        }
        public List<Student> GetAllStudents()
        {
            List<Student> allStudents = new List<Student>();

            string getAllStudentsQuery = "SELECT * from Students";
            getAllStudentsQuery = "GetAllStudents"; //Stored procedure
            SqlCommand getAllStudentsCommand = new SqlCommand(getAllStudentsQuery, connectionString);

            getAllStudentsCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader getAllStudentsReader;
            connectionString.Open();
            getAllStudentsReader = getAllStudentsCommand.ExecuteReader();

            while (getAllStudentsReader.Read())
            {
                var tempStudent = new Student();
                tempStudent.Id = Int32.Parse(getAllStudentsReader[0].ToString());
                tempStudent.FirstNam = getAllStudentsReader[1].ToString().Trim();
                tempStudent.LastName = getAllStudentsReader[2].ToString().Trim();
                tempStudent.Email = getAllStudentsReader[3].ToString().Trim();

                allStudents.Add(tempStudent);
            }
            connectionString.Close();

            return allStudents;

        }

    }
}
