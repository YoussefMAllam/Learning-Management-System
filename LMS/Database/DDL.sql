use LMS2
--student table--
create table student(
ID int check(ID between 200000000 and 300000000), 
Sname varchar(20), 
Major varchar(15), 
batch int check (batch between 2000 and 3000), 
email varchar(40) unique,
pass varchar(20),
primary key(ID)
);
--course table--
create table course(
ccode varchar (7),
semester varchar(11),
inst_ID int check(inst_ID between 0 and 2000),
primary key(ccode, semester),
);
--course data--
create table course_data(
ccode varchar(7),
cname varchar(30),
[pre-requisites] varchar(7) null,
credits int null,
primary key(ccode),
foreign key ([pre-requisites]) references course_data(ccode)
);
--instructor table--
create table instructor(
Iname varchar(20),
ID int check(ID between 0 and 2000),
email varchar(40) unique,
pass varchar(20),
primary key(ID)
);
--Adding foreign keys to course--
alter table course
add foreign key(ccode) references course_data(ccode)
alter table course
add foreign key (inst_ID) references instructor(ID)
--Assignment Table--
create table assignment(
Aname varchar(20),
ccode varchar(7),
sem varchar(11),
due_date date,
done BIT
primary key(Aname,ccode,sem),
foreign key(ccode, sem) references course
);
--Assignment Submissions Table--
create table assignment_submissions(
Aname varchar(20),
ccode varchar(7),
sem varchar(11),
Submission varchar(255),
graded bit,
StID int check (StID between 200000000 and 300000000),
grade int check(grade between 0 and 10),
primary key(Aname, ccode, sem, StID),
foreign key(Aname,ccode,sem) references assignment(Aname,ccode,sem),
foreign key(StID) references student(ID)
);
--Transcript Entries--
create table transcript(
StID int check(StID between 200000000 and 300000000),
ccode varchar(7),
sem varchar(11),
grade float check (grade between 0 and 4.00),
primary key(StID, ccode,sem),
foreign key(StID,ccode, sem) references registered(StID,ccode,sem),
);
--Exam--
create table exam(
ccode varchar(7) ,
sem varchar(11) ,
venue varchar(10),
proctor_ID int,
exan_date date,
primary key(ccode,sem),
foreign key(ccode,sem) references course,
foreign key (proctor_ID) references instructor
);
 --Exam Submissions--
create table exam_submissions(
ccode varchar(7),
sem varchar(11) ,
StID int,
grade int check(grade between 0 and 100),
primary key(ccode,sem,StID),
foreign key(ccode, sem) references exam,
foreign key(StID) references student(ID)
);
--Material--
create table material(
Mname varchar(30),
ccode varchar(7),
link varchar(255),
primary key(Mname,ccode),
foreign key (ccode) references course_data(ccode)
);
--Announcement--
create table announcements(
ccode varchar(7),
sem varchar(11),
title varchar(20),
content varchar(255),
primary key(ccode,sem,title),
foreign key(ccode,sem) references course
);
--Thread--
create table thread(
ccode varchar(7),
title varchar(20),
question varchar(255),
posted_on date,
StID int null,
primary key(ccode, title),
foreign key(ccode) references course_data,
foreign key(StID) references student(ID)
);
--Thread Entries--
create table thread_entries(
title varchar(20),
ccode varchar(7),
comment varchar(255),
primary key(title,ccode),
foreign key(ccode,title) references thread
);
--Registered--
create table registered(
StID int ,
ccode varchar(7),
sem varchar(11),
feedback varchar(255),
foreign key(ccode, sem) references course,
foreign key(StID) references student(ID),
primary key(StID,ccode,sem)
);
--To Do List--
create table todo(
StID int,
task varchar(100),
done bit,
ccode varchar(7),
sem varchar(11)
primary key(StID, task),
foreign key(StID) references student,
foreign key(ccode,sem) references course(ccode,semester)
);

--admin users--
create table admins(
email varchar(40),
pass varchar(20),
primary key(email)
)
