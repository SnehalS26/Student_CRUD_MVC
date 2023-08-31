using System.Data.SqlClient;

namespace Student_CRUD_MVC.Models
{
    public class StudentCRUD
    {
        IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public StudentCRUD(IConfiguration configure)
        {
            this.configuration = configure;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Student> GetStudents()
        {
            List<Student> list = new List<Student>();
            string qry = "Select * from Student where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Student s = new Student();
                    s.Roll = Convert.ToInt32(dr["roll"]);
                    s.Name = dr["name"].ToString();
                    s.Percentage = Convert.ToDouble(dr["percentage"]);
                    list.Add(s);
                }
            }
            con.Close();
            return list;
        }
        public Student GetStudentById(int roll)
        {
            Student s = new Student();
            string qry = "select * from Student where roll=@roll";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@roll", roll);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    s.Roll = Convert.ToInt32(dr["roll"]);
                    s.Name = dr["name"].ToString();
                    s.Percentage = Convert.ToDouble(dr["percentage"]);
                    
                }
            }
            con.Close();
            return s;
        }
        public int AddStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "insert into Student values(@name,@percentage,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "update Student set name=@name,percentage=@percentage,isActive=@isActive where roll=@roll";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            cmd.Parameters.AddWithValue("@roll", student.Roll);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int roll)
        {
            int result = 0;
            string qry = "update Student set isActive=0 where roll=@roll";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@roll", roll);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
