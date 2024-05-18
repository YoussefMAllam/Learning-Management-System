using Microsoft.AspNetCore.Components.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LMS.Models
{

    public class DB
    {
        public SqlConnection con { get; set; }


        public DB() {
            string constr = " Data Source =DESKTOP-50DDNCA; Initial Catalog = LMS; Integrated Security = True; TrustServerCertificate = True";
            con = new SqlConnection(constr);
           
           
        }


        //Student Courses
        //Query for all
        public DataTable getAllCourses()
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        //Query for registered
        public DataTable getRegisteredCourses(string id, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course\r\ninner join course_data on course.ccode=course_data.ccode\r\nwhere course.ccode in (select ccode from registered where StID=" + id + " and sem='" + sem + "') ";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        //Query for Registered and search by course code
        public DataTable getRegisteredAndCodeCourses(string id, string sem, string CCode)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course\r\ninner join course_data on course.ccode=course_data.ccode\r\nwhere course.ccode in (select ccode from registered where StID=" + id + " and sem='" + sem + "') and course.ccode like '%" + CCode + "%'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        //Query for Registered and search by course name
        public DataTable getRegisteredAndNameCourses(string id, string sem, string name)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course\r\ninner join course_data on course.ccode=course_data.ccode\r\nwhere course.ccode in (select ccode from registered where StID=" + id + " and sem='" + sem + "') and course_data.cname like '%" + name + "%'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        //Query by course name
        public DataTable getByNameCourses(string name)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course\r\ninner join course_data on course.ccode=course_data.ccode\r\nwhere course_data.cname like '%" + name + "%'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        //Query by course code
        public DataTable getByCodeCourses(string CCode)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course\r\ninner join course_data on course.ccode=course_data.ccode\r\nwhere course.ccode like '%" + CCode + "%'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        //Query by course name and semester
        public DataTable getByNameandSemesterCourses(string name, string Sem)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course\r\ninner join course_data on course.ccode=course_data.ccode\r\nwhere course_data.cname like '%" + name + "%' and course.semester like '%" + Sem + "%'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        //Query by course code and semester
        public DataTable getByCodeandSemesterCourses(string CCode, string Sem)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course\r\ninner join course_data on course.ccode=course_data.ccode\r\nwhere course.ccode like '%" + CCode + "%' and course.semester like '%\"+Sem+\"%'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }


        //Logging in//
        public DataTable getInstID(string email, string password)
        {
            DataTable dt = new DataTable();
            string Q = "select ID from student where email='" + email + "' and pass='" + password + "'\r\nunion\r\nselect ID from instructor where email='" + email + "' and pass='" + password + "'\r\nunion\r\nselect ID from admin where email='" + email + "' and pass='" + password + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        //Teacher Selection Queries//
        public DataTable getIname(string id)
        {
            DataTable dt = new DataTable();
            string Q = "select Iname from instructor where ID =" + id;
            try {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) {

            }
            finally { con.Close(); }
            return dt;
        }

        public DataTable Getstudentcourses(string stid)
        {
            string Q = "select course_data.cname, course.ccode, semester from course " +
                       "inner join course_data on course.ccode=course_data.ccode " +
                       "where course.ccode in (select ccode from registered where StID=@studentId and sem=@semester)";
            DataTable dt = new DataTable();


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("@stid", stid);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable GetFilteredcourses(string courseName, string semester, string courseCode)
        {
            string Q = "select course_data.cname, course.ccode, semester from course " +
                   "inner join course_data on course.ccode=course_data.ccode " +
                   "where course_data.cname like @courseName and " +
                   "semester like @semester and " +
                   "course.ccode like @courseCode";
            DataTable dt = new DataTable();


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);

                cmd.Parameters.AddWithValue("@courseName", courseName);
                cmd.Parameters.AddWithValue("@semester", semester);
                cmd.Parameters.AddWithValue("@courseCode", courseCode);
               
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable Getstudenttranscript(string stid)
        {
            string Q = "select course_data.cname,transcript.ccode,transcript.sem,course_data.credits,transcript.grade from transcript inner join course_data on transcript.ccode = course_data.ccode";
            DataTable dt = new DataTable();


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);


                cmd.Parameters.AddWithValue("@stid", stid);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) {

            }
            
            finally { con.Close(); }
            return dt;
        }

        public double calculateGPA(string stid)
        {
            string Q = "SELECT AVG(grade) AS CGPA FROM transcript WHERE StID = @studentID";

            double gpa = 0.0;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);

                cmd.Parameters.AddWithValue("@studentID", stid); // Corrected parameter name
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    gpa = reader["CGPA"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["CGPA"]);
                }
            }
            catch (SqlException sq) { }
            finally { con.Close(); }

            return gpa;
        }


        public DataTable getIcourses(string id) {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, transcript.ccode, transcript.sem, course_data.credits, transcript.grade " +
                 "from transcript " +
                 "inner join course_data on transcript.ccode = course_data.ccode " +
                 "where transcript.StID = @studentId";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getExams(string id)
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname,exam.venue,exam.exan_date from registered\r\ninner join course_data ON registered.ccode=course_data.ccode\r\nleft join exam on registered.ccode=exam.ccode\r\nwhere registered.StID=202200286 and registered.sem='Spring 2024'\r\norder by exam.exan_date asc";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getungraded(string id)
        {
            DataTable dt = new DataTable();
            string Q = "select ccode,Aname from assignment where assignment.ccode in(select distinct course.ccode from course where inst_ID=" + id + " and assignment.sem in(select distinct course.semester from course where inst_ID=" + id + ") and (done=0 or done is null))";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
           
            finally { con.Close(); }
            return dt;
        }

        public DataTable getallcourseassignments(string ccode, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select assignment.Aname,assignment.due_date,count(StID)\r\nfrom assignment,assignment_submissions\r\nwhere assignment.Aname=assignment_submissions.Aname and\r\nassignment.ccode=assignment_submissions.ccode and\r\nassignment.sem=assignment_submissions.sem and\r\nassignment.ccode='" + ccode + "' and assignment.sem='" + sem + "'\r\ngroup by assignment.Aname,assignment.due_date";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getassignmentsub(string aname, string ccode, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select student.Sname,assignment_submissions.Submission,\r\nassignment_submissions.grade\r\nfrom assignment_submissions,student\r\nwhere StID=ID and Aname='" + aname + "' and ccode='" + ccode + "' and\r\nsem='" + sem + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getmaterial(string ccode)
        {
            DataTable dt = new DataTable();
            string Q = "select Mname,link from material where ccode = '" + ccode + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        //Teacher Manipulation Queries//
        public void addassignment(string ccode, string sem, string aname, string due_date)
        {
            string Q = "insert into assignment(Aname,ccode,sem,due_date)\r\nvalues('" + aname + "','" + ccode + "','" + sem + "'," + due_date + ")";
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void addmaterial(string ccode, string mname, string link)
        {
            string Q = "insert into material(ccode,Mname,link)\r\nvalues('" + ccode + "','" + mname + "','" + link + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void addannouncement(string ccode, string sem, string title, string content)
        {
            string Q = "insert into announcement(ccode,sem,title,content)\r\nvalues('" + ccode + "','" + sem + "','" + title + "','" + content + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void registerstudent(string ccode, string sem, string stid)
        {
            string Q = "insert into registered(StID,ccode,sem) values(" + stid + ",'" + ccode + "','" + sem + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void gradeassignment(string aname, string ccode, string sem, string stid, string grade)
        {
            string Q = "update assignment_submissions\r\nset grade=" + grade + "\r\nwhere Aname='" + aname + "' and ccode='" + ccode + "' and sem='" + sem + "' and StID='" + stid + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void addexam(string ccode, string sem, string venue, string proctor, string date)
        {
            string Q = "insert into exam(ccode,sem,venue,proctor_ID,exam_date)\r\nvalues('" + ccode + "','" + sem + "','" + venue + "','" + proctor + "','" + date + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void gradeexam(string ccode, string sem, string stid, string grade)
        {
            string Q = "insert into exam_submissions(ccode,sem,StID,grade) values('" + ccode + "','" + sem + "','" + stid + "'," + grade + ")'"
                ;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void addfinalgrade(string ccode, string sem, string stid, string grade)
        {
            string Q = "insert into transcript(ccode,sem,StID,grade) values('" + ccode + "','" + sem + "','" + stid + "'," + grade + ")";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
           
            finally { con.Close(); }
        }
        public void AddStudent(string id, string name, string major, string batch, string email, string pass)
        {
            string Q = "insert into student(ID,Sname,Major,batch,email,pass) values(" + id + ", " + name + ", " + major + ", " + batch + ", " + email + ", " + pass + ")";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public void AddStudentfeedback( string stid, string ccode,string feedback)
        {
            string Q = "update registered set Feedback=@feedback where StID=@stid and ccode=@ccode\r\n";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("stid", stid);
                cmd.Parameters.AddWithValue("feedback", feedback);
                cmd.Parameters.AddWithValue("ccode", ccode);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void Addassignmentsubmission(string stid, string ccode, string Assignmentlink,string Aname,string sem)
        {
            string Q = "insert into assignment_submissions(Aname,ccode,sem,StID,Submission) values ('"+Aname + "', '"+ ccode+"', '"+sem+ "',"+ stid+",'"+Assignmentlink+"')";
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void AddTodo(string stid, string task, string ccode, string sem)
        {
            string Q = "insert into todo(StID,task,done,ccode,sem) values(@stid,@task,0,@ccode,@sem)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("@stid", stid);
                cmd.Parameters.AddWithValue("@task", task);
                cmd.Parameters.AddWithValue("@ccode", ccode);
                cmd.Parameters.AddWithValue("@sem", sem);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        public DataTable ViewTasks(string stid)
        {
            string Q = "select task,done from todo where StID=@stid";
            DataTable dt = new DataTable();


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("@stid", stid);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        public DataTable Viewassignments(string ccode,string sem)
        {
            string Q = "select assignment.Aname, assignment.due_date from assignment\r\nwhere assignment.ccode=@ccode and assignment.sem=@sem";
            DataTable dt = new DataTable();


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("@ccode", ccode);
                cmd.Parameters.AddWithValue("@sem", sem);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }



        public void CompleteTask(string stid, string task)
        {
            string Q = "update todo set done=1 where StID=@stid and task=@task";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("@stid", stid);
                cmd.Parameters.AddWithValue("@task", task);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

      


        public string getsemester()
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            if (month == "10" || month == "11" || month == "12" || month == "01")
            {
                return "Fall" + year;
            }
            else
            {
                return "Spring " + year;
            }
        }
        public DataTable getccode(string cname)
        {
            DataTable dt = new DataTable();
            string Q = "select ccode from course_data where cname='" + cname + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getstudentname(string stID)
        {
            DataTable dt = new DataTable();
            string Q = "select Sname from student where  ID = '" + stID + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        public DataTable getcoursename(string ccode)
        {
            DataTable dt = new DataTable();
            string Q = "select cname from course_data where ccode='" + ccode + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        public DataTable get_ID(string email)
        {
            DataTable dt=new DataTable();
            string Q = "select ID from student where email='" + email + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }
        public DataTable getanouncement(string ccode,string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select announcements.title, announcements.content from announcements\r\nwhere @ccode=ccode and @sem=sem";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("ccode", ccode);
                cmd.Parameters.AddWithValue("sem", sem);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getstudentmaterial(string ccode)
        {
            DataTable dt = new DataTable();
            string Q = "select Mname,link from material\r\nwhere ccode=@ccode";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.Parameters.AddWithValue("ccode", ccode);
               
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
            return dt;
        }

        public void Removetask(string task,string stID)
        {
            string Q = "delete from todo where task='" + task+"' and StID='" + stID+"'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

    }


}

