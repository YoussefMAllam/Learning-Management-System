insert into student(ID,Sname,Major,batch,email,pass)
values
(202200286,'Youssef Allam','CIE',2022,'s-youssef.allam@zewailcity.edu.eg','Allamtest'),
(202200438,'Mohammad Mahmoud','CIE',2022,'s-mohammad.elrahman@zewailcity.edu.eg','Momotest'),
(202200126,'Aml Tarek','CIE',2022,'s-aml.ismail@zewailcity.edu.eg','Amltest'),
(202200102,'Ali Ehab','NANENG',2022,'s-ali.aziz@zewailcity.edu.eg','Alitest'),
(202200603,'Mustafa Mahmoud','PEU',2022,'s-mustafa.elsayed@zewailcity.edu.eg','Mustafatest'),
(202100184,'Thomas Emad','PEU',2021,'s-thomas.fawzy@zewailcity.edu.eg','Thomastest'),
(202200477,'Ahmed Yasser','CIE',2022,'s-ahmed.kadah@zewailcity.edu.eg','Yassertest'),
(202201027,'Ziad Haitham','CIE',2022,'s-ziad.fahmy@zewailcity.edu.eg','Zizotest'),
(202200647,'Ziad Reda','CIE',2022,'s-ziad.elsadek@zewailcity.edu.eg','Ziadtest'),
(202200050,'Marwan Amr','REE',2022,'s-marwan.abdelmegid@zewailcity.edu.eg','Marotest'),
(202300129, 'Nourhan Hassan', 'CIE', 2023, 's-nourhan.hassan@zewailcity.edu.eg','rando1'),
(202300275, 'Omar Samir', 'NANENG', 2023, 's-omar.samir@zewailcity.edu.eg','rando2'),
(202300387, 'Laila Mohamed', 'PEU', 2023, 's-laila.mohamed@zewailcity.edu.eg','rando3'),
(202300512, 'Sara Ahmed', 'BMS', 2023, 's-sara.ahmed@zewailcity.edu.eg','rando4'),
(202300621, 'Youssef Ali', 'CIE', 2023, 's-youssef.ali@zewailcity.edu.eg','rando5'),
(202300743, 'Amr Tarek', 'NANENG', 2023, 's-amr.tarek@zewailcity.edu.eg','rando6'),
(202300888, 'Salma Hesham', 'BMS', 2023, 's-salma.hesham@zewailcity.edu.eg','rando7'),
(202301004, 'Omar Mohamed', 'CIE', 2023, 's-omar.mohamed@zewailcity.edu.eg','rando8'),
(202301156, 'Nada Sami', 'BMS', 2023, 's-nada.sami@zewailcity.edu.eg','rando9'),
(202301287, 'Mohamed Hany', 'CIE', 2023, 's-mohamed.hany@zewailcity.edu.eg','rando10');

insert into course_data (ccode,cname,[pre-requisites],credits)
values
('CIE 202','Object Oriented Programming',null,3),
('CIE 205','Data Structures','CIE 202',3),
('CIE 206','Database','CIE 202',3),
('CIE 227','Signals and Systems','MTH 201',3),
('CIE 212','Electronics',null,3),
('MTH 101', 'Calculus I',null,3),
('MTH 102','Calculus II','MTH 101',3),
('MTH 201','Linear Algebra','MTH 102',3),
('MTH 202','Differential Equations','MTH 201',3),
('PHY 101','Classical Mechanics',null,3),
('PHY 102','Electromagnetism','PHY 101',3),
('PHY 201','Waves','PHY 102',3),
('PHY 202', 'Modern Physics','PHY 201',3),
('PEU 204','Analytical Mechanics','PHY 101',3),
('PEU 205','Astrophysics',null,3),
('PEU 208','Electrodynamics I','PHY 102',3),
('ENG 152','Speaking and Composition',null,2),
('ENG 153','Scientific Writing','ENG 152',2),
('CIE 239','Digital Logic',null,3),
('CHM 101','Chemistry 101',null,3);

Insert into 
	instructor(Iname,ID,email,pass)
values
	('Yasser ElAwady',105,'yelawady@zewailcity.edu.eg','YasserPass'),
	('Ashraf Hendam',302,'ahendam@zewailcity.edu.eg','AshrafPass'),
	('Ahmed Hussein Khalil',454,'ahmkhalil@zewailcity.edu.eg','AhmedPass'),
	('Mostafa ElShafei',505,'moelshafei@zewailcity.edu.eg','ShafeiPass'),
	('Tamer Ashour',404,'tali@zewailcity.edu.eg','TamerPass'),
	('Doaa Sakout',101,'delsakout@zewailcity.edu.eg','DoaaPass'),
	('Waleed Abdelmeguid',103,'wabdelmagied@zewailcity.edu.eg','WaleedPass'),
	('Abdallah AbouTahoun',108,'atahoun@zewailcity.edu.eg','AbdullahPass'),
	('Amr Mohamed',204,'amr@zewailcity.edu.eg','MITPass'),
	('Hisham Anwer',666,'hisham.anwer@zewailcity.edu.eg','HishamPass'),
	('Maha Gouda',167,'mgouda@zewailcity.edu.eg','MahaPass'),
	('Mohamed Samir Eid',13,'mseid@zewailcity.edu.eg','SamirPass'),
	('Rabeay Younes Hassan',55,'ryounes@zewailcity.edu.eg','RabeayPass'),
	('Tarek Ibrahim',303,'tibrahim@zewailcity.edu.eg','TarekPass'),
	('Mohamed Reyad Sakr',909,'mreyad@zewailcity.edu.eg','SakrPass');

Insert into 
	course(ccode,semester,inst_ID)
values
	('CIE 205','Spring 2024',105),
	('CIE 206','Spring 2024',302),
	('CIE 212','Spring 2024',454),
	('CIE 227','Spring 2024',505),
	('CIE 202','Spring 2024',404),
	('MTH 101','Fall 2023', 101),
	('MTH 102','Spring 2023', 101),
	('MTH 201','Fall 2024', 103),
	('MTH 202','Spring 2024', 108),
	('PHY 101','Fall 2023', 204),
	('PHY 102','Spring 2023',204),
	('PHY 201','Fall 2024', 666),
	('PHY 202','Spring 2024', 303),
	('PEU 204','Spring 2023',909),	
	('PEU 205','Fall 2024',666),
	('PEU 208','Spring 2024',666),
	('ENG 152','Fall 2023',167),
	('ENG 153','Spring 2023',167),
	('CIE 239','Fall 2024',13),
	('CHM 101','Fall 2023',55);

	INSERT INTO assignment (Aname, ccode, sem, due_date)
VALUES
    ('Intro to Classes', 'CIE 202', 'Spring 2024', '2024-05-10'),
    ('Stack and Queue', 'CIE 205', 'Spring 2024', '2024-05-15'),
    ('ER Diagram', 'CIE 206', 'Spring 2024', '2024-05-18'),
    ('PN Diode', 'CIE 212', 'Spring 2024', '2024-05-20'),
    ('Sinosouids', 'CIE 227', 'Spring 2024', '2024-05-25'),
    ('Differentiation', 'MTH 101', 'Fall 2023', '2023-10-15'),
    ('Polar Coordinates', 'MTH 102', 'Spring 2023', '2023-05-20'),
    ('Row Reduction', 'MTH 201', 'Fall 2024', '2024-11-05'),
    ('Linear ODE', 'MTH 202', 'Spring 2024', '2024-05-10'),
    ('Vectors', 'PHY 101', 'Fall 2023', '2023-10-20'),
    ('Columb Law', 'PHY 102', 'Spring 2023', '2023-05-25'),
    ('Waves', 'PHY 201', 'Fall 2024', '2024-11-10'),
    ('Special Relativity', 'PHY 202', 'Spring 2024', '2024-05-15'),
    ('Assignment 1', 'PEU 204', 'Spring 2023', '2023-05-30'),
    ('Assignment 1', 'PEU 205', 'Fall 2024', '2024-11-15'),
    ('Assignment 1', 'PEU 208', 'Spring 2024', '2024-05-20'),
    ('Presentation  1', 'ENG 152', 'Fall 2023', '2023-10-25'),
    ('Essay 1', 'ENG 153', 'Spring 2023', '2023-05-30'),
    ('Logic Gates', 'CIE 239', 'Fall 2024', '2024-11-20'),
    ('Periodic Table', 'CHM 101', 'Fall 2023', '2023-11-05');


    
	INSERT INTO assignment_submissions (Aname, ccode, sem, StID, grade)
VALUES
    ('Intro to Classes', 'CIE 202', 'Spring 2024', 202200286, NULL),
    ('Stack and Queue', 'CIE 205', 'Spring 2024', 202200438, NULL),
    ('ER Diagram', 'CIE 206', 'Spring 2024', 202200126, NULL),
    ('PN Diode', 'CIE 212', 'Spring 2024', 202200102, NULL),
    ('Sinosouids', 'CIE 227', 'Spring 2024', 202200603, NULL)
    ('Differentiation', 'MTH 101', 'Fall 2023', 202100184, NULL),
    ('Polar Coordinates', 'MTH 102', 'Spring 2023', 202200477, NULL),
    ('Row Reduction', 'MTH 201', 'Fall 2024', 202201027, NULL),
    ('Linear ODE', 'MTH 202', 'Spring 2024', 202200647, NULL),
    ('Vectors', 'PHY 101', 'Fall 2023', 202200050, NULL),
    ('Columb Law', 'PHY 102', 'Spring 2023', 202300129, NULL),
    ('Waves', 'PHY 201', 'Fall 2024', 202300275, NULL),
    ('Special Relativity', 'PHY 202', 'Spring 2024', 202300387, NULL),
    ('Assignment 1', 'PEU 204', 'Spring 2023', 202300512, NULL),
    ('Assignment 1', 'PEU 205', 'Fall 2024', 202300621, NULL),
    ('Assignment 1', 'PEU 208', 'Spring 2024', 202300743, NULL),
    ('Essay 1', 'ENG 153', 'Spring 2023', 202301004, NULL),
    ('Logic Gates', 'CIE 239', 'Fall 2024', 202301156, NULL),
    ('Periodic Table', 'CHM 101', 'Fall 2023', 202301287, NULL),
    ('Presentation  1', 'ENG 152', 'Fall 2023', 202300888, NULL);

INSERT INTO exam (ccode, sem, venue, proctor_ID)
VALUES
    ('CIE 202', 'Spring 2024', 'G-006-E', 105),
    ('CIE 205', 'Spring 2024', 'F-007-D', 302),
    ('CIE 206', 'Spring 2024', 'S-008-F', 454),
    ('CIE 212', 'Spring 2024', 'G-006-B', 505),
    ('CIE 227', 'Spring 2024', 'F-014-B', 404),
    ('MTH 101', 'Fall 2023', 'S-023-D', 101),
    ('MTH 102', 'Spring 2023', 'G-018-D', 13),
    ('MTH 201', 'Fall 2024', 'F-007-D', 303),
    ('MTH 202', 'Spring 2024', 'G-006-F', 909),
    ('PHY 101', 'Fall 2023', 'S-003-E', 666),
    ('PHY 102', 'Spring 2023', 'G-018-E', 55),
    ('PHY 201', 'Fall 2024', 'F-007-A', 167),
    ('PHY 202', 'Spring 2024', 'G-006-C', 204),
    ('PEU 204', 'Spring 2023', 'G-006-D', 108),
    ('PEU 205', 'Fall 2024', 'F-007-B', 666),
    ('PEU 208', 'Spring 2024', 'G-006-G', 13),
    ('ENG 152', 'Fall 2023', 'S-023-A', 55),
    ('ENG 153', 'Spring 2023', 'G-018-A', 303),
    ('CIE 239', 'Fall 2024', 'F-007-C', 909),
    ('CHM 101', 'Fall 2023', 'S-003-F', 454);


INSERT INTO registered (StID, ccode, sem, feedback)
VALUES
    (202200286, 'CIE 202', 'Spring 2024', NULL),
    (202200438, 'CIE 205', 'Spring 2024', NULL),
    (202200126, 'CIE 206', 'Spring 2024', NULL),
    (202200102, 'CIE 212', 'Spring 2024', NULL),
    (202200603, 'CIE 227', 'Spring 2024', NULL),
    (202100184, 'MTH 101', 'Fall 2023', NULL),
    (202200477, 'MTH 102', 'Spring 2023', NULL),
    (202201027, 'MTH 201', 'Fall 2024', NULL),
    (202200647, 'MTH 202', 'Spring 2024', NULL),
    (202200050, 'PHY 101', 'Fall 2023', NULL),
    (202300129, 'PHY 102', 'Spring 2023', NULL),
    (202300275, 'PHY 201', 'Fall 2024', NULL),
    (202300387, 'PHY 202', 'Spring 2024', NULL),
    (202300512, 'PEU 204', 'Spring 2023', NULL),
    (202300621, 'PEU 205', 'Fall 2024', NULL),
    (202300743, 'PEU 208', 'Spring 2024', NULL),
    (202300888, 'ENG 152', 'Fall 2023', NULL),
    (202301004, 'ENG 153', 'Spring 2023', NULL),
    (202301156, 'CIE 239', 'Fall 2024', NULL),
    (202301287, 'CHM 101', 'Fall 2023', NULL);

INSERT INTO exam_submissions(ccode, sem, StID, grade)
SELECT r.ccode, r.sem, r.StID, 70 AS grade
FROM registered r;




INSERT INTO thread (ccode, title, question, posted_on, StID)
VALUES
    ('CIE 202', 'OOP Inheritance?', 'Looking for guidance on implementing inheritance in OOP.', CURRENT_TIMESTAMP, NULL),
    ('CIE 205', 'Data Structures?', 'Seeking examples of data structure applications.', CURRENT_TIMESTAMP, NULL),
    ('CIE 206', 'Query Optimization?', 'Interested in techniques for query optimization.', CURRENT_TIMESTAMP, NULL),
    ('CIE 212', 'Circuit Elements?', 'Curious about the fundamental elements of circuits.', CURRENT_TIMESTAMP, NULL),
    ('CIE 227', 'Signal Analysis?', 'Seeking explanations on signal analysis techniques.', CURRENT_TIMESTAMP, NULL),
    ('MTH 101', 'Calculus Concepts?', 'Looking for an overview of calculus concepts.', CURRENT_TIMESTAMP, NULL),
    ('MTH 102', 'Diff. Eq. Solving?', 'Need help understanding solving diff. equations.', CURRENT_TIMESTAMP, NULL),
    ('MTH 201', 'Lin. Alg. Apps?', 'Interested in practical examples of linear algebra usage.', CURRENT_TIMESTAMP, NULL),
    ('MTH 202', 'Phys. Sys. Modeling?', 'Seeking guidance on modeling physical phenomena.', CURRENT_TIMESTAMP, NULL),
    ('PHY 101', 'Mechanics Princ.?', 'Looking for explanations of mechanics principles.', CURRENT_TIMESTAMP, NULL),
    ('PHY 102', 'EM Field Analysis?', 'Interested in understanding electromagnetic fields.', CURRENT_TIMESTAMP, NULL),
    ('PHY 201', 'Wave Properties?', 'Seeking explanations on wave properties and behaviors.', CURRENT_TIMESTAMP, NULL),
    ('PHY 202', 'Mod. Phys. Chal.?', 'Curious about challenges of modern physics.', CURRENT_TIMESTAMP, NULL),
    ('PEU 204', 'Analyt. Mechanics?', 'Looking for explanations of mechanics principles.', CURRENT_TIMESTAMP, NULL),
    ('PEU 205', 'Astro. Study Meth.?', 'Interested in methods for studying astrophysics.', CURRENT_TIMESTAMP, NULL),
    ('PEU 208', 'Electromag. Apps?', 'Seeking explanations and applications.', CURRENT_TIMESTAMP, NULL),
    ('ENG 152', 'Speak & Comp. Tips?', 'Looking for tips to enhance speaking abilities.', CURRENT_TIMESTAMP, NULL),
    ('ENG 153', 'Sci. Writing Tips?', 'Seeking guidance on writing scientifically.', CURRENT_TIMESTAMP, NULL),
    ('CIE 239', 'Digital Logic?', 'Interested in understanding digital logic concepts.', CURRENT_TIMESTAMP, NULL),
    ('CHM 101', 'Chem. Struct.?', 'Seeking explanations on chemical structures.', CURRENT_TIMESTAMP, NULL);

INSERT INTO transcript (StID, ccode, sem, grade)
SELECT r.StID, r.ccode, r.sem, NULL AS grade
FROM registered r;

Insert into 
	material(Mname,ccode,link)
values
	('Data Structures and Algorithm Analysis in C++','CIE 205','https://libgen.rs/'),
	('Fundamentals of Database Systems','CIE 206','https://libgen.rs/'),
	('Fundamentals of Microelectronics','CIE 212','https://libgen.rs/'),
	('DSP First','CIE 227','https://libgen.rs/'),
	('Fundamentals of Programming in C++','CIE 202','https://libgen.rs/'),
	('Thomas Calculus','MTH 101','https://libgen.rs/'),
	('Stewart Calculus','MTH 102','https://libgen.rs/'),
	('Linear Algebra Done Right','MTH 201','https://libgen.rs/'),
	('Differential Equations and Boundary Value Problems','MTH 202','https://libgen.rs/'),
	('An Introduction To Mechanics','PHY 101','https://libgen.rs/'),
	('Introduction To Electromagnetism','PHY 102','https://libgen.rs/'),
	('University Physics','PHY 201','https://libgen.rs/'),
	('Modern Physics','PHY 202','https://libgen.rs/'),
	('Classical Mechanics','PEU 204','https://libgen.rs/'),
	('Introduction to Modern Astrophysics','PEU 205','https://libgen.rs/'),
	('Introduction To Electrodynamics','PEU 208','https://libgen.rs/'),
	('Fundamentals of English','ENG 152','https://libgen.rs/'),
	('Advanced English','ENG 153','https://libgen.rs/'),
	('Digital Design and Computer Architecture','CIE 239','https://libgen.rs/'),
	('Introduction to Chemistry','CHM 101','https://libgen.rs/'); 
