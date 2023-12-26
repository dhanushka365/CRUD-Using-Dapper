using CRUD_Using_Dapper.Common;
using CRUD_Using_Dapper.IService;
using CRUD_Using_Dapper.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Using_Dapper.Services
{
    public class StudentService :IStudentService
    {
        Student _student = new Student();
        
        List<Student> _students = new List<Student>();
       

        public Student Save(Student student)
        {
          _student = new Student();
            try
            {
                int operationType = Convert.ToInt32(student.StudentId == 0 ? OperationType.Insert : OperationType.Update);
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();
                    
                    var students = con.Query<Student>("SP_Student",
                        this.SetParameters(student, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (students != null && students.Count() > 0)
                    {
                        _student = students.FirstOrDefault();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                _student.Message = ex.Message;
            }

            return _student;
        }


        private DynamicParameters SetParameters(Student student, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@StudentId", student.StudentId);
            parameters.Add("@Name", student.Name);
            parameters.Add("@Roll", student.Roll);
            parameters.Add("@OperationType", operationType);
            return parameters;
        }


        public List<Student> Gets()
        {
            _students = new List<Student>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();
                    
                    _students = con.Query<Student>("SP_Student",
                                               this.SetParameters(new Student(), Convert.ToInt32(OperationType.None)),
                                                                      commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            {
                _student.Message = ex.Message;
            }

            return _students;
       
        }

        public Student Get(int studentId)
        {
            _student = new Student();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();
                    
                    var students = con.Query<Student>("SP_Student",
                                  this.SetParameters(new Student { StudentId = studentId }, Convert.ToInt32(OperationType.None)),
                                                                 commandType: CommandType.StoredProcedure);

                    if (students != null && students.Count() > 0)
                    {
                        _student = students.FirstOrDefault();
                    }
                }
            }
            catch(Exception ex)
            {
                _student.Message = ex.Message;
            }

            return _student;
         
        }

        public String Delete(int studentId)
        {
            String message = String.Empty;
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if(con.State == ConnectionState.Closed) con.Open();
                    
                    var students = con.Query<Student>("SP_Student",
                                this.SetParameters(new Student { StudentId = studentId }, Convert.ToInt32(OperationType.Delete)),
                                                                                                                                                                                                                                       commandType: CommandType.StoredProcedure);

                    if (students != null && students.Count() > 0)
                    {
                        _student = students.FirstOrDefault();
                    }
                }
            }
            catch(Exception ex)
            {
                _student.Message = ex.Message;
            }

            return _student.Message;
        
        }   
    }
}
