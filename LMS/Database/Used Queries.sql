----------------------Student Queries------------------------
--Student Home--
select Sname from student
where ID=202200286

--Insert Task--
insert into todo(StID,task,done,ccode,sem) 
values(202200286,'Database Phase 1',0,'CIE 206','Spring 2024')

--view tasks--
select task,done from todo where StID=202200286

--complete task--
update todo set done=1 where StID=202200286 and task='Database Phase 1'

--Student Courses-
select course_data.cname, course.ccode, semester from course
inner join course_data on course.ccode=course_data.ccode
where course.ccode in (select ccode from registered where StID=202200286 and sem='Spring 2024') 

--Filter Strings-- (TO BE TESTED LATER)
course_data.cname like '%PHcourse%' and
course.semester like '%PHsem%' and
course.ccode like '%PHcode%'

--Student Undonde Assignments--
select assignment.Aname, assignment.due_date,assignment.descript from assignment,assignment_submissions
where assignment.ccode='CIE 202' and assignment.Aname not in (select assignment_submissions.Aname from assignment_submissions where StID='202200286')
and assignment.ccode not in (select assignment_submissions.ccode from assignment_submissions where StID='202200286') 
and assignment.sem not in (select assignment_submissions.sem from assignment_submissions where StID='202200286')
order by assignment.due_date asc

--Student All Assignments--
select assignment.Aname, assignment.due_date,grade from assignment,assignment_submissions
where assignment.ccode='CIE 202' and assignment_submissions.ccode=assignment.ccode and assignment.Aname=assignment_submissions.aname
order by assignment.due_date asc


--add submission--
insert into assignment_submissions(Aname,ccode,sem,StID,Submission)
values ('Assignment 1', 'CIE 202', 'Spring 2024',202200286,'yes')

--Student Transcript
select course_data.cname,transcript.ccode,transcript.sem,course_data.credits,transcript.grade from transcript
inner join course_data on transcript.ccode=course_data.ccode where
transcript.StID= 202200286

--Calculate CGPA--
select avg(grade) as CGPA from transcript
where StID=202200286

--Student Exam--
select course_data.cname,exam.venue,exam.exan_date from registered
inner join course_data ON registered.ccode=course_data.ccode
left join exam on registered.ccode=exam.ccode
where registered.StID=202200286 and registered.sem='Spring 2024'
order by exam.exan_date asc

--course material--

--add feedback--
update registered set Feedback='Very Good' where StID=202200286 and ccode='CIE 202'

--Student get material
select Mname,link from material
where ccode='PHcode'

--Add thread
insert into thread(ccode,title,question,posted_on,StID) values('PHcode','Title','Question','current_date','PHID')

--View Announcements--
select title, content from announcements where ccode='CIE 202' and sem='Spring 2024'

------------------------Teacher Queries-----------------------
--Get Name--
select Iname from instructor where ID=666

--Get ungraded assignments--
select ccode,Aname from assignment 
where assignment.ccode in(select distinct course.ccode from course where inst_ID=666) 
and assignment.sem in(select distinct course.semester from course where inst_ID=666)
and (done=0 or done is null)

--Get List of Courses for a teacher--
select course_data.cname,course.ccode,course.semester,count(StID)
from registered,course,instructor,course_data
where 
	course.ccode=registered.ccode and 
	course.semester=registered.sem and 
	course.inst_ID=instructor.ID and 
	course_data.ccode=course.ccode and
	inst_ID=666
group by course.ccode,course.semester, instructor.Iname,course_data.cname

--Add Announcement--
insert into announcements(ccode,sem,title,content) 
values('CIE 202','Spring 2024','Quiz1','Quiz 1 postponed to next week')

--Add Assignment--
insert into assignment(Aname,ccode,sem,due_date) 
values('Assignment 2','CIE 239','Spring 2024',12/02/2025)

--Add Material--
insert into material(Mname,ccode,link) 
values('Intro to circuits','ENG 210','----')

--Add Student--
insert into registered(ccode,sem,StID) values('ENG 210','Fall 2023',202200286)

--View All Course Assignments--
select  assignment.Aname,assignment.due_date,count(StID)
from assignment,assignment_submissions 
where assignment.Aname=assignment_submissions.Aname and 
assignment.ccode=assignment_submissions.ccode and
assignment.sem=assignment_submissions.sem and
assignment.ccode='CHM 101' and assignment.sem='Fall 2023'
group by assignment.Aname,assignment.due_date

--View All Assignment Instances--
select student.Sname,assignment_submissions.Submission, assignment_submissions.grade 
from assignment_submissions,student 
where StID=ID and Aname='Assignment 1' and ccode='CIE 202' and sem='Spring 2024'

--Set Grade--
update assignment_submissions set grade=7 where assignment_submissions.Aname='Periodic Table' and StID=202301287;

--teacher get material--
select Mname,link from material
where ccode='PHcode'

--set exam date--
insert into exam(ccode,sem,venue,proctor_ID,exam_date) values('CIE 205','Spring 2024','G-008-B','666','12/12/2024')

--grade exam--
insert into exam_submissions(ccode,sem,StID,grade) values('CIE 205','Spring 2024','202200286',90)

--Insert grade
insert into transcript values ('PHStID','PHcode','PHsem','grade')

--view feedback--
select feedback from registered where ccode='CIE 202' and sem='Spring 2024'

-------------------------Admin Queries------------------------
--All Students Data for Admin--
select Sname,ID,email from student

--All Teacher Data for Admin--
select Iname,ID,email from instructor

--Add Student For Admin--
insert into student(ID,Sname,Major,batch,email,pass) values(201800124,'Ahmed','CIE',2018,'s-ahmed.ghamry@zewailcity.edu.eg',12345678)

--Add Teacher for Admin--
insert into instructor(Iname,ID,email,pass) values('Osama',150,'osama.mohamed@zewailcity.edu.eg',1429502)

--Update Password for Student--
update student
set pass='newpass' where ID=202200286

--Update Password for Instructor
update instructor
set pass='newpass' where ID=666

--Remove Student--
delete from student where ID=202200286

--Remove Instructor--
delete from instructor where ID=224

--Add Course--
insert into course_data(ccode, cname, [pre-requisites],credits) values('ENG 210','Circuits','PHY 102',3)

--View Course Data--
select ccode,cname,[pre-requisites],credits from course_data

--View Instances of Course--
select course.ccode,course_data.cname,course.semester,course.Inst_ID, instructor.Iname from instructor, course left join course_data on course.ccode=course_data.ccode where course.ccode='CHM 101' and course_data.ccode='CHM 101' and inst_ID=ID

--Create Course Instance--
insert into course(ccode, semester,inst_ID) values('ENG 210','Fall 2023','454')

--Add Admin--
insert into admins(email, pass) values('admin','admin1')

--update admin password--
update admins set pass='admin' where email='admin'

------------------------------General Queries------------------------
--Get Cname inside course view--
select cname from course_data where ccode='PHY 201'

--Get Material Name inside course view--
select Mname from material where ccode='MTH 101'

--Get threads--
select thread.title,thread.ccode from thread 
inner join course_data on thread.ccode=course_data.ccode
where thread.ccode like '%PHcode%' and
course_data.cname like '%PHname%' and 
thread.ccode in (select ccode from transcript where StID ='PHID') 
order by thread.posted_on asc --desc

--Number of comments--
select count(comment) as [number of comments] from thread_entries
where title like 'PHTitle' and ccode like 'PHccode'

--Get thread entries--
select comment from thread_entries
where title like 'PHTitle' and ccode like 'PHccode'

--Add thread entry--
insert into thread_entries values('PHTitle','PHccode','PHcomment')
--View thread
select thread.title,thread.question,thread.ccode,thread.posted_on from thread

--View thread entries--
select thread_entries.comment from thread_entries
where thread_entries.title='PHTitle' and thread_entries.ccode='PHcode'

--Number of comments--
select count(comment) from thread_entries 
where thread_entries.title='PHTitle' and thread_entries.ccode='PHcode'



