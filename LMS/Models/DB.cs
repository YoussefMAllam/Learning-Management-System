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
            string constr = "Data Source=G15;Initial Catalog=LMS;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
            con = new SqlConnection(constr);
           
           
        }


        //Student Courses
        //Query for all
        public DataTable getAllCourses()
        {
            DataTable dt = new DataTable();
            string Q = "select course_data.cname, course.ccode, semester from course inner join course_data on course.ccode=course_data.ccode";
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
            string Q = "select course_data.cname, course.ccode, semester from course inner join course_data on course.ccode=course_data.ccode where course.semester = '"+getsemester()+"' and course.ccode in (select ccode from registered where StID = " + stid +"and sem = '"+getsemester()+"')";
            DataTable dt = new DataTable();


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
            string Q = "select course_data.cname,transcript.ccode,transcript.sem,course_data.credits,transcript.grade \r\nfrom transcript inner join course_data on transcript.ccode = course_data.ccode\r\nwhere transcript.StID="+stid;
            DataTable dt = new DataTable();


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
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


        public DataTable getIcourses(string id, string sem) {
            DataTable dt = new DataTable();
            string Q = "select cname,course.ccode,course.semester,count(StID) from course inner join course_data on course.ccode = course_data.ccode left join registered on course.ccode = registered.ccode and course.semester = registered.sem where inst_ID ="+id+" and semester = '"+sem+"' group by course.ccode,course.semester,course_data.cname";
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
            string Q = "select ccode,Aname from assignment where assignment.sem='" + getsemester() + "' and assignment.ccode in(select distinct course.ccode from course where inst_ID=" + id + " and assignment.sem in(select distinct course.semester from course where inst_ID=" + id + ") and (done=0 or done is null))";
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
            string Q = "select assignment.Aname,assignment.due_date,count(StID),count(grade) from assignment left join assignment_submissions on assignment.Aname = assignment_submissions.Aname and assignment.ccode = assignment_submissions.ccode and assignment.sem = assignment_submissions.sem where assignment.ccode = '" + ccode + "' and assignment.sem = '" + sem + "' group by assignment.Aname,assignment.due_date,assignment.done";
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
            string Q = "select student.Sname,assignment_submissions.Submission,student.ID,\r\nassignment_submissions.grade\r\nfrom assignment_submissions,student\r\nwhere StID=ID and Aname='" + aname + "' and ccode='" + ccode + "' and\r\nsem='" + sem + "' Order by (Sname) asc";
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
        public void addassignment(string ccode, string sem, string aname, string due_date,string descript)
        {
            string Q = "insert into assignment(Aname,ccode,sem,due_date,descript)\r\nvalues('" + aname + "','" + ccode + "','" + sem + "','" + due_date + "','"+descript+"')";
            
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
            string Q = "insert into announcements(ccode,sem,title,content)\r\nvalues('" + ccode + "','" + sem + "','" + title + "','" + content + "')";
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

        public void addexam(string ccode, string sem, string venue, string date)
        {
            string Q = "insert into exam(ccode,sem,venue,exan_date)\r\nvalues('" + ccode + "','" + sem + "','" + venue + "','" + date + "')";
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
            string Q = "update exam_submissions set grade=" + grade + " where ccode='" + ccode+"'and sem='" + sem + "' and StID='" + stid + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public DataTable getexamsub(string ccode, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select exam_submissions.StID, student.Sname, exam_submissions.grade from student,exam_submissions where student.ID=exam_submissions.StID and ccode='" + ccode + "' and sem='" + sem + "'";
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


        //ADMIN HOME FUNCTIONS
        public void AddStudent(string id, string name, string major, string batch, string email, string pass)
        {
            string Q = "insert into student(ID,Sname,Major,batch,email,pass) values(" + id + ", '" + name + "', '" + major + "', " + batch + ", '" + email + "', '" + pass + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void AddInstructor(string id, string name, string email, string pass)
        {
            string Q = " insert into instructor(Iname, ID, email, pass) values('"+name+"',"+id+",'"+email+"','"+pass+"')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void RemoveStudent(string id)
        {
            string Q = "delete from student where ID="+id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void RemoveInstructor(string id)
        {
            string Q = "delete from instructor where ID=" + id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void RemoveAdmin(string id)
        {
            string Q = "delete from admin where ID=" + id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void AddCourse(string CCode, string CName, string Prereqs, string credits)
        {
            string Q = "insert into course_data(ccode, cname, [pre-requisites],credits) values('"+CCode+"','"+CName+"','"+Prereqs+"',"+credits+")";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void AddAdmin(string email, string password, string id)
        {
            string Q = "insert into admin(email, pass,Id) values('"+email+"','"+password+"',"+id+")";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void AddCourseInstance(string ccode, string semester, string id)
        {
            string Q = "insert into course(ccode, semester,inst_ID) values('"+ccode+"','"+semester+"','"+id+"')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void RemoveCourse(string ccode)
        {
            string Q = "delete from course_data where ccode='"+ccode+"'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void RemoveCourseInstance(string ccode, string semester, string id)
        {
            string Q = "delete from course where ccode='"+ccode+"' and semester='"+semester+"' and inst_ID="+id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }
        public void RemoveAllCourseInstances(string ccode)
        {
            string Q = "delete from course where ccode='"+ccode+"'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }        
        //END OF ADMIN HOME FUNCTIONS

        //ADMIN EDIT STUDENTS
        public DataTable getAllStudents()
        {
            DataTable dt = new DataTable();
            string Q = "select Sname,ID,email from student";
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
        public void ChangeStudentPassword(string id, string password)
        {
            string Q = "update student set pass = '"+password+"' where ID = "+id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }


        //ADMIN EDIT INSTRUCTORS
        public DataTable getAllInstructors()
        {
            DataTable dt = new DataTable();
            string Q = "select Iname,ID,email from instructor";
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
        public void ChangeInstructorPassword(string id, string password)
        {
            string Q = "update instructor set pass = '"+password+"' where ID = "+id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        //ADMIN EDIT ADMIN
        public DataTable getAllAdmins()
        {
            DataTable dt = new DataTable();
            string Q = "select email,Id from admin";
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
        public DataTable AgetAllCourses()
        {
            DataTable dt = new DataTable();
            string Q = "select cname, ccode,[pre-requisites], credits from course_data";
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
        public void ChangeAdminPassword(string id, string password)
        {
            string Q = "update admin set pass='"+password+"' where Id="+id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq) { }
            finally { con.Close(); }
        }

        //ADMIN COURSES
        public DataTable getCourseInstances(string ccode)
        {
            DataTable dt = new DataTable();
            string Q = "select instructor.Iname, course.semester,count(StID) from course inner join instructor on course.inst_ID= instructor.ID left join registered on registered.ccode = course.ccode and registered.sem = semester  where course.ccode = '"+ccode+"' group by instructor.Iname,course.semester";
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
            DataTable dt = new DataTable();
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
        public DataTable getdatename(string title, string ccode)
        {
            DataTable dt = new DataTable();
            string Q = "select posted_on,sname,question from thread left join student on StID=ID where title='" + title + "' and ccode='" + ccode + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }
        public DataTable getthreadcomments(string title, string ccode)
        {
            DataTable dt = new DataTable();
            string Q = "select thread_entries.comment from thread_entries where thread_entries.title = '" + title + "' and thread_entries.ccode = '" + ccode + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }
        public DataTable getfeedback(string ccode, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select feedback from registered where ccode='" + ccode + "' and sem='" + sem + "'";
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

        public DataTable getstudents(string ccode, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select sname,major,id,email from student,registered where student.ID=registered.StID and ccode='" + ccode + "' and sem='" + sem + "' order by sname";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getallcourses()
        {
            DataTable dt = new DataTable();
            string Q = "select ccode,cname from course_data";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getunattended(string ccode, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select sname, StID from registered left join student on registered.StID=student.ID where ccode='" + ccode + "' and sem='" + sem + "' and StID not in(select StID from exam_submissions where ccode='" + ccode + "' and sem='" + sem + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public void addexamsub(string ccode, string sem, string stid)
        {
            string Q = "insert into exam_submissions(ccode,sem,StID) values('" + ccode + "','" + sem + "','" + stid + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
        }

        public DataTable getexaminedstudents(string ccode, string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select Sname, exam_submissions.StID, transcript.grade \r\nfrom exam_submissions left join student on StID=ID left join transcript on transcript.StID=exam_submissions.StID and ((transcript.ccode=exam_submissions.ccode) or (transcript.ccode is null))\r\nwhere exam_submissions.ccode='" + ccode + "' and exam_submissions.sem='" + sem + "'\r\n order by Sname";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public void addtranscript(string ccode, string sem, string ID, string grade)
        {
            DataTable dt = new DataTable();
            string Q = "insert into transcript(StID,ccode,sem,grade) values(" + ID + ",'" + ccode + "','" + sem + "'," + grade + ")";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
        }

        public DataTable getthreads()
        {
            DataTable dt = new DataTable();
            string Q = "select title, ccode from thread\r\n";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getInstructorName(string id)
        {
            DataTable dt = new DataTable();
            string Q = "select Iname from instructor where ID="+id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }
        public DataTable getsubmittedassignments(string id,string ccode,string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select assignment.aname,assignment.due_date,assignment_submissions.grade\r\nfrom assignment inner join assignment_submissions on assignment.Aname=assignment_submissions.Aname and assignment.ccode=assignment_submissions.ccode and assignment.sem=assignment_submissions.sem\r\nwhere StID=" + id + "and assignment.ccode='" + ccode + "' and assignment.sem='" + sem + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getunsubmittedassignments(string id,string ccode,string sem)
        {
            DataTable dt = new DataTable();
            string Q = "select aname, due_date \r\nfrom assignment \r\nwhere ccode='" + ccode + "' and sem='" + sem + "' and Aname not in(select assignment_submissions.Aname from assignment_submissions where ccode='" + ccode + "' and sem='" + sem + "' and StID=" + id + ") ";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public void Addthread(string ccode,string title, string question, string posted_on)
        {
            string Q= "insert into thread(ccode,title,question,posted_on) values('"+ccode+"','"+title+"','"+question+"','"+posted_on+"')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
        }

        public void addthreadentry(string title,string ccode,string comment)
        {
            string Q = "insert into thread_entries values('" + title + "','" + ccode + "','" + comment + "')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
        }

        public DataTable getassavg(string aname,string ccode,string sem)
        {
            DataTable dt=new DataTable();
            string Q= "select avg(assignment_submissions.grade) from assignment_submissions,student\r\nwhere StID=ID and Aname='"+aname+"' and ccode='"+ccode+"' and sem='"+sem+"'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getexamavg(string ccode,string sem)
        {
            DataTable dt=new DataTable();
            string Q = "select avg(exam_submissions.grade) from exam_submissions,student where StID=ID and ccode='"+ccode+"' and sem='"+sem+"'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;
        }

        public DataTable getallexams()
        {
            DataTable dt=new DataTable();
            string Q = "select cname ,exam.ccode, exam.sem, exam.venue, exam.exan_date from exam inner join course_data on course_data.ccode=exam.ccode where exam.sem='"+getsemester()+"'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;

        }

        public DataTable tobesetexams()
        {
            DataTable dt = new DataTable();
            string Q = "select cname,course.ccode, semester from course inner join course_data on course.ccode = course_data.ccode where semester = '"+getsemester()+"' and course.ccode not in(select exam.ccode from exam where sem = '"+getsemester()+"')";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException sq)
            {
            }
            finally { con.Close(); }
            return dt;

        }

    }


}
