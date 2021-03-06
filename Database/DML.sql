--USE NHRMDB;
USE NH;

Go

INSERT INTO StaffRole
    (StaffType)
VALUES('Admin'),
    ('Clinician');

INSERT INTO Staff
    (Email,FirstName,Surname,[Password],Salt,RoleID)
VALUES('admin@nhrm', 'Admin', 'Admin', 'Admin123', 'salt', 1),
    ('clinician@nhrm', 'Clinician', 'Clinician', 'Admin123', 'salt', 2);


-- For when the password in Patient table is of type binary

INSERT INTO Patient
    (URNumber,Email,Title,SurName,FirstName,Gender,DOB,[Address],Suburb,PostCode,MobileNumber,HomeNumber,CountryOfBirth,PreferredLanguage,[Password],Salt,LivesAlone,RegisteredBy,Active, Deceased)
VALUES('123456789', 'patient@patient.com', 'Mrs', 'Doe', 'Jane', 'Female', GETDATE(), '123 Evergreen Terrace', 'Springfield', '1234', '0123456789', '0123456789', 'Australia', 'English', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 0, 1, 1, 0),
    ('987654321', 'patient2@patient.com', 'Mr', 'Doe', 'John', 'Male', GETDATE(), '123 Evergreen Terrace', 'Springfield', '1234', '0123456789', '0123456789', 'Australia', 'English', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 0, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('1', 'tgreave0@surveymonkey.com', 'Mrs', 'Greave', 'Tiena', 'Female', '1990-02-03', '90116 Esker Trail', 'South Australia', '2064', '1642532084', '4329711023', 'Australia', 'English', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('2', 'clatty1@sohu.com', 'Rev', 'Latty', 'Charla', 'Male', '1985-05-21', '760 Warbler Trail', 'South Australia', 4037, '8152535583', '3888551379', 'Australia', 'Tamil', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('3', 'sdipietro2@bravesites.com', 'Dr', 'Di Pietro', 'Sigismund', 'Female', '1996-02-04', '392 Roxbury Place', 'South Australia', '2895', '5688948853', '3582076951', 'Australia', 'Northern Sotho', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('4', 'ldaltry3@earthlink.net', 'Dr', 'Daltry', 'Lothario', 'Female', '1988-08-26', '97799 Heath Center', 'South Australia', '7128', '6256581952', '2053191335', 'Australia', 'Amharic', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('5', 'gjeaneau4@kickstarter.com', 'Rev', 'Jeaneau', 'Gerda', 'Male', '1997-09-08', '68 Rigney Point', 'South Australia', '5186', '8865328005', '8951720274', 'Australia', 'Hindi', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('6', 'ehanby5@twitter.com', 'Rev', 'Hanby', 'Erny', 'Male', '1997-01-03', '6201 Spenser Drive', 'South Australia', '3857', '1814819427', '4873723585', 'Australia', 'Tamil', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('7', 'zivantsov6@jugem.jp', 'Mrs', 'Ivantsov', 'Zacharia', 'Male', '1985-06-29', '115 Arkansas Park', 'South Australia', '8534', '9408732150', '3537820593', 'Australia', 'Somali', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('8', 'mfrances7@independent.co.uk', 'Rev', 'Frances', 'Marcile', 'Female', '1990-08-23', '58954 Drewry Crossing', 'South Australia', '1003', '9182565975', '5731596188', 'Australia', 'Danish', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('9', 'gabbati8@businesswire.com', 'Honorable', 'Abbati', 'Gwen', 'Female', '1993-05-29', '0 Ridgeview Parkway', 'South Australia', '5748', '6976640408', '3806333191', 'Australia', 'Malay', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('10', 'edriuzzi9@myspace.com', 'Mrs', 'Driuzzi', 'Evelyn', 'Female', '1990-03-05', '31678 Commercial Crossing', 'South Australia', '2182', '8802327623', '1319382318', 'Australia', 'Afrikaans', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('11', 'eludrona@ycombinator.com', 'Dr', 'Ludron', 'Evangelia', 'Female', '1994-09-06', '80 Lillian Junction', 'South Australia', '6354', '4191621072', '9143610667', 'Australia', 'Tetum', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('12', 'fmarob@ted.com', 'Mrs', 'Maro', 'Fonz', 'Female', '1994-02-12', '12135 Carpenter Pass', 'South Australia', '9604', '8897583519', '1544589103', 'Australia', 'Burmese', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('13', 'sbarrowcliffc@bluehost.com', 'Rev', 'Barrowcliff', 'Steffi', 'Male', '1988-01-09', '2 Sutherland Lane', 'South Australia', '2185', '9263457107', '8916798049', 'Australia', 'Swahili', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('14', 'senricod@163.com', 'Rev', 'Enrico', 'Shep', 'Male', '1982-06-09', '461 Dawn Lane', 'South Australia', '7666', '9705132099', '2576201009', 'Australia', 'Marathi', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('15', 'ggrisarde@naver.com', 'Mr', 'Grisard', 'Grayce', 'Female', '1994-12-31', '47297 Randy Avenue', 'South Australia', '6815', '5573332651', '3162810338', 'Australia', 'Pashto', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('16', 'ahandrockf@people.com.cn', 'Mrs', 'Handrock', 'Angelita', 'Male', '1988-12-05', '454 Jackson Park', 'South Australia', '4463', '5129270709', '8332657146', 'Australia', 'Northern Sotho', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('17', 'femmanuelg@seattletimes.com', 'Mrs', 'Emmanuel', 'Faulkner', 'Female', '1992-06-20', '44 Harbort Trail', 'South Australia', '1880', '2679114898', '8693552439', 'Australia', 'Tamil', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('18', 'jtrowbridgeh@desdev.cn', 'Honorable', 'Trowbridge', 'Jannelle', 'Female', '1995-08-25', '90768 Eliot Parkway', 'South Australia', '3975', '4753095675', '4161580931', 'Australia', 'Italian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('19', 'wcornessi@oracle.com', 'Dr', 'Corness', 'Wake', 'Female', '1981-05-06', '65 Kipling Lane', 'South Australia', '9852', '8189249631', '5349354788', 'Australia', 'French', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('20', 'letonj@usa.gov', 'Mr', 'Eton', 'Leonard', 'Female', '1985-12-22', '395 Buhler Place', 'South Australia', '5330', '1533686288', '5671101318', 'Australia', 'Thai', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('21', 'lhyndleyk@bravesites.com', 'Ms', 'Hyndley', 'Lorrie', 'Female', '1980-11-05', '56873 Welch Junction', 'South Australia', '8048', '4477272672', '1748298671', 'Australia', 'Filipino', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('22', 'jsantorol@fc2.com', 'Honorable', 'Santoro', 'Jessy', 'Female', '1988-02-24', '727 American Ash Center', 'South Australia', '7228', '2208459577', '1467291911', 'Australia', 'Aymara', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('23', 'jsaywoodm@amazon.co.uk', 'Mrs', 'Saywood', 'Joye', 'Female', '1985-07-02', '86 West Hill', 'South Australia', '4877', '9447239799', '6153402759', 'Australia', 'Macedonian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('24', 'vchengn@cocolog-nifty.com', 'Ms', 'Cheng', 'Verine', 'Female', '1993-07-08', '602 Loftsgordon Center', 'South Australia', '7339', '5928276940', '8814806828', 'Australia', 'Afrikaans', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('25', 'cpartono@pbs.org', 'Rev', 'Parton', 'Culver', 'Female', '1986-09-22', '0979 Saint Paul Parkway', 'South Australia', '7531', '5504972591', '5141722647', 'Australia', 'French', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('26', 'cbevirp@tuttocitta.it', 'Mr', 'Bevir', 'Celestyna', 'Male', '1987-05-19', '4884 Algoma Drive', 'South Australia', '5802', '1114008286', '1062350444', 'Australia', 'Japanese', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('27', 'ggianulloq@census.gov', 'Dr', 'Gianullo', 'Gustie', 'Male', '1987-09-21', '5 Bay Place', 'South Australia', '7955', '9614396704', '4352560051', 'Australia', 'Northern Sotho', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('28', 'arupprechtr@csmonitor.com', 'Rev', 'Rupprecht', 'Angus', 'Male', '1984-05-11', '54978 Blue Bill Park Center', 'South Australia', '1312', '3761140674', '1045553780', 'Australia', 'Belarusian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('29', 'egimbers@google.de', 'Ms', 'Gimber', 'Eileen', 'Female', '1993-05-15', '64 Main Crossing', 'South Australia', '1616', '9602610711', '9235701018', 'Australia', 'Czech', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('30', 'lchitteyt@newyorker.com', 'Ms', 'Chittey', 'Lena', 'Female', '1984-06-17', '3 Truax Trail', 'South Australia', '8307', '7218212982', '8998345426', 'Australia', 'Bengali', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('31', 'awildtu@uol.com.br', 'Rev', 'Wildt', 'Astrix', 'Female', '1994-07-29', '227 Lunder Street', 'South Australia', '8178', '5248067653', '7598625464', 'Australia', 'Tok Pisin', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('32', 'ndyv@apache.org', 'Ms', 'Dy', 'Normie', 'Male', '1990-09-04', '087 Washington Alley', 'South Australia', '3380', '5933456617', '5676279901', 'Australia', 'Gagauz', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('33', 'csneakerw@merriam-webster.com', 'Rev', 'Sneaker', 'Chrisy', 'Female', '1995-10-28', '95 Nevada Drive', 'South Australia', '1468', '4306684017', '8099387315', 'Australia', 'Telugu', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('34', 'cdranx@cbslocal.com', 'Rev', 'Dran', 'Cathe', 'Male', '1982-12-26', '5 Packers Junction', 'South Australia', '7255', '8014040835', '1897677724', 'Australia', 'Gujarati', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('35', 'gdaubery@exblog.jp', 'Ms', 'Dauber', 'Godfry', 'Male', '1993-11-28', '89561 Armistice Crossing', 'South Australia', '5007', '8632626150', '3641098872', 'Australia', 'Filipino', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('36', 'lchellamz@goo.gl', 'Ms', 'Chellam', 'Leia', 'Male', '1997-07-15', '545 Superior Lane', 'South Australia', '9024', '1703734027', '7049400504', 'Australia', 'Zulu', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('37', 'jreisk10@liveinternet.ru', 'Rev', 'Reisk', 'Jammie', 'Female', '1984-01-23', '918 Del Mar Park', 'South Australia', '7866', '4807996425', '3857324581', 'Australia', 'Swahili', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('38', 'rtewkesbury11@mashable.com', 'Mr', 'Tewkesbury', 'Raina', 'Male', '1987-03-02', '0432 Nobel Point', 'South Australia', '5482', '5636139413', '9841828570', 'Australia', 'Czech', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('39', 'ddambrogi12@simplemachines.org', 'Ms', 'D''Ambrogi', 'Davidde', 'Male', '1983-12-11', '5694 Helena Parkway', 'South Australia', '6941', '9888192777', '5881466194', 'Australia', 'Swahili', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('40', 'negar13@google.co.jp', 'Mrs', 'Egar', 'Nike', 'Male', '1996-03-11', '096 Roth Drive', 'South Australia', '4905', '9605109999', '2557155434', 'Australia', 'Papiamento', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('41', 'cmaidens14@timesonline.co.uk', 'Mrs', 'Maidens', 'Curr', 'Male', '1989-02-25', '19 Montana Lane', 'South Australia', '4044', '8837445028', '9786381559', 'Australia', 'Czech', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('42', 'anormant15@japanpost.jp', 'Dr', 'Normant', 'Audie', 'Male', '1989-09-18', '5495 Arrowood Circle', 'South Australia', '1157', '1307901971', '6043624025', 'Australia', 'Malay', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('43', 'gcharopen16@google.es', 'Honorable', 'Charopen', 'Gisella', 'Male', '1994-08-02', '481 Quincy Alley', 'South Australia', '8647', '4665412106', '8353728977', 'Australia', 'Filipino', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('44', 'bjerrard17@vimeo.com', 'Honorable', 'Jerrard', 'Bibby', 'Female', '1991-06-05', '935 Killdeer Park', 'South Australia', '9614', '5068495295', '9042759428', 'Australia', 'Quechua', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('45', 'baujean18@e-recht24.de', 'Ms', 'Aujean', 'Buddie', 'Female', '1993-02-25', '6 Dryden Drive', 'South Australia', '7616', '2144089746', '9914547298', 'Australia', 'Kannada', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('46', 'ffedorski19@alibaba.com', 'Mr', 'Fedorski', 'Franzen', 'Female', '1985-06-06', '40 3rd Pass', 'South Australia', '3373', '7585755879', '9078357011', 'Australia', 'Malay', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('47', 'atoffanini1a@lycos.com', 'Rev', 'Toffanini', 'Alberta', 'Female', '1990-01-14', '52897 Scofield Drive', 'South Australia', '5089', '3359341871', '7611925007', 'Australia', 'Punjabi', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('48', 'hcyson1b@sciencedirect.com', 'Mr', 'Cyson', 'Hal', 'Male', '1987-01-28', '4706 Meadow Vale Junction', 'South Australia', '5051', '8513438838', '2588716574', 'Australia', 'Sotho', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('49', 'dbonsale1c@tinyurl.com', 'Mrs', 'Bonsale', 'Dannie', 'Male', '1982-01-23', '16661 Warrior Place', 'South Australia', '8543', '2169300513', '2156624156', 'Australia', 'Belarusian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('50', 'mseefeldt1d@cisco.com', 'Honorable', 'Seefeldt', 'Marchelle', 'Male', '1982-11-10', '35168 8th Pass', 'South Australia', '8824', '7273535440', '6138586068', 'Australia', 'Danish', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('51', 'hconelly1e@uol.com.br', 'Mrs', 'Conelly', 'Harman', 'Female', '1987-04-29', '00617 Redwing Pass', 'South Australia', '8531', '5847480279', '2724541642', 'Australia', 'Czech', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('52', 'crenad1f@samsung.com', 'Mr', 'Renad', 'Charlotta', 'Female', '1992-12-11', '97 Mcbride Hill', 'South Australia', '1824', '7017134957', '9202853776', 'Australia', 'Dari', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('53', 'mweepers1g@furl.net', 'Ms', 'Weepers', 'Meriel', 'Female', '1993-09-22', '13861 Doe Crossing Way', 'South Australia', '5718', '3826097621', '7553085526', 'Australia', 'Dutch', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('54', 'xbetteney1h@globo.com', 'Rev', 'Betteney', 'Xenos', 'Male', '1986-06-08', '15740 School Lane', 'South Australia', '2211', '4599279139', '5067941141', 'Australia', 'French', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('55', 'climeburn1i@phpbb.com', 'Ms', 'Limeburn', 'Cullan', 'Female', '1986-03-04', '130 Elgar Alley', 'South Australia', '9284', '7721081637', '6727693839', 'Australia', 'Mongolian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('56', 'dgreensite1j@cpanel.net', 'Honorable', 'Greensite', 'Demetre', 'Male', '1984-11-02', '448 Bayside Place', 'South Australia', '1487', '6959853602', '4865676408', 'Australia', 'Irish Gaelic', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('57', 'hgalliford1k@cnbc.com', 'Mrs', 'Galliford', 'Henrie', 'Male', '1994-09-20', '2262 Arkansas Way', 'South Australia', '7684', '4895800133', '6294587374', 'Australia', 'Kazakh', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('58', 'lpibsworth1l@nifty.com', 'Honorable', 'Pibsworth', 'Lisette', 'Male', '1994-12-27', '23 Buhler Parkway', 'South Australia', '7828', '8431894797', '7405431732', 'Australia', 'Dari', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('59', 'fenstone1m@blogger.com', 'Rev', 'Enstone', 'Feodor', 'Female', '1994-10-15', '79558 Ridge Oak Center', 'South Australia', '2829', '9521186985', '1779889565', 'Australia', 'Zulu', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('60', 'snorcutt1n@youku.com', 'Ms', 'Norcutt', 'Simmonds', 'Male', '1992-06-04', '8751 Melvin Crossing', 'South Australia', '3619', '4099447889', '7579435424', 'Australia', 'Tsonga', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('61', 'mrollings1o@cpanel.net', 'Ms', 'Rollings', 'Marylynne', 'Female', '1996-12-26', '94 Moland Avenue', 'South Australia', '6173', '4871314659', '7326583117', 'Australia', 'Hungarian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('62', 'aioannou1p@upenn.edu', 'Rev', 'Ioannou', 'Amalie', 'Female', '1993-11-08', '95 Fulton Avenue', 'South Australia', '7445', '2954677703', '6021104972', 'Australia', 'Thai', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('63', 'jdymidowicz1q@liveinternet.ru', 'Ms', 'Dymidowicz', 'Johannah', 'Female', '1991-09-27', '46205 Clemons Terrace', 'South Australia', '1760', '9768288809', '5986064391', 'Australia', 'Northern Sotho', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('64', 'vmcmichael1r@arizona.edu', 'Ms', 'McMichael', 'Viva', 'Female', '1992-10-17', '52091 Mayfield Circle', 'South Australia', '6398', '8752317233', '4015643211', 'Australia', 'Marathi', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('65', 'ssuter1s@ted.com', 'Dr', 'Suter', 'Shem', 'Female', '1993-11-10', '0 Coolidge Court', 'South Australia', '3070', '2656323170', '3116592375', 'Australia', 'Fijian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('66', 'slaguerre1t@apple.com', 'Ms', 'Laguerre', 'Sheree', 'Male', '1988-09-02', '30926 Clarendon Parkway', 'South Australia', '1784', '1735089543', '1481816258', 'Australia', 'Gujarati', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('67', 'emurfett1u@paginegialle.it', 'Rev', 'Murfett', 'Elroy', 'Male', '1984-10-12', '4 Division Trail', 'South Australia', '1989', '9257089085', '7368341545', 'Australia', 'Norwegian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('68', 'tvicary1v@unicef.org', 'Dr', 'Vicary', 'Terrel', 'Male', '1988-06-11', '1610 Declaration Park', 'South Australia', '6646', '3504313162', '8048225979', 'Australia', 'Romanian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('69', 'ekirrens1w@addthis.com', 'Mrs', 'Kirrens', 'Eddie', 'Female', '1990-04-10', '01818 Burrows Avenue', 'South Australia', '2253', '8523199853', '7655719603', 'Australia', 'Danish', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('70', 'iwolton1x@hubpages.com', 'Rev', 'Wolton', 'Inger', 'Female', '1987-06-22', '35 Bunker Hill Park', 'South Australia', '3487', '4973333701', '3345408758', 'Australia', 'West Frisian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('71', 'psentinella1y@amazon.co.uk', 'Mr', 'Sentinella', 'Pattin', 'Male', '1980-10-30', '26 Pearson Street', 'South Australia', '8033', '5294947916', '2298305339', 'Australia', 'Kazakh', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('72', 'wshore1z@yellowbook.com', 'Mrs', 'Shore', 'Wally', 'Male', '1986-03-02', '6488 Village Green Circle', 'South Australia', '2068', '5287645883', '3547122314', 'Australia', 'Portuguese', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('73', 'sbauld20@huffingtonpost.com', 'Dr', 'Bauld', 'Sutton', 'Male', '1993-04-06', '0 Washington Terrace', 'South Australia', '6801', '2066993906', '7285238895', 'Australia', 'Tok Pisin', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('74', 'lbrittoner21@washingtonpost.com', 'Dr', 'Brittoner', 'Lidia', 'Male', '1994-02-25', '96356 Bunting Way', 'South Australia', '7138', '9755934437', '7301166302', 'Australia', 'Bislama', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('75', 'tkleimt22@examiner.com', 'Mrs', 'Kleimt', 'Tabbie', 'Female', '1993-12-07', '3 Gulseth Road', 'South Australia', '4108', '8269907546', '6534728621', 'Australia', 'Czech', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('76', 'bpughsley23@bizjournals.com', 'Mrs', 'Pughsley', 'Babbie', 'Female', '1989-04-29', '7353 Dapin Road', 'South Australia', '8280', '5299470404', '1583534885', 'Australia', 'Swati', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('77', 'dlineker24@wordpress.com', 'Ms', 'Lineker', 'Datha', 'Male', '1986-09-14', '4549 Service Crossing', 'South Australia', '7183', '2317737253', '3261773562', 'Australia', 'Tsonga', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('78', 'cborges25@sciencedirect.com', 'Ms', 'Borges', 'Cameron', 'Female', '1990-03-01', '05 Meadow Valley Circle', 'South Australia', '2117', '1245531426', '7089308956', 'Australia', 'Burmese', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('79', 'jlambrecht26@cnet.com', 'Dr', 'Lambrecht', 'Jarred', 'Male', '1984-10-05', '2434 Westport Drive', 'South Australia', '1371', '8898808161', '8684548100', 'Australia', 'Amharic', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('80', 'tdash27@hc360.com', 'Ms', 'Dash', 'Travis', 'Male', '1986-09-09', '5 Sommers Terrace', 'South Australia', '3336', '4126816571', '8585390281', 'Australia', 'Tetum', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('81', 'mterran28@ed.gov', 'Mrs', 'Terran', 'Mattie', 'Female', '1988-03-04', '7 Scott Street', 'South Australia', '4732', '8326820257', '8015684180', 'Australia', 'Luxembourgish', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('82', 'forford29@shutterfly.com', 'Ms', 'Orford', 'Flint', 'Female', '1981-01-01', '670 Caliangt Terrace', 'South Australia', '9849', '5353590644', '5788540329', 'Australia', 'Kazakh', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('83', 'bduchant2a@quantcast.com', 'Ms', 'Duchant', 'Brett', 'Male', '1991-12-28', '82 Oak Valley Lane', 'South Australia', '5026', '3711410729', '3447212315', 'Australia', 'Georgian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('84', 'jchaves2b@earthlink.net', 'Honorable', 'Chaves', 'Jenda', 'Female', '1987-12-10', '542 Barnett Trail', 'South Australia', '6320', '4614706017', '2005810025', 'Australia', 'Pashto', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('85', 'lbyfield2c@samsung.com', 'Mr', 'Byfield', 'Lari', 'Male', '1982-05-31', '997 Barnett Way', 'South Australia', '6897', '8716442585', '7301827013', 'Australia', 'Croatian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('86', 'fbittlestone2d@qq.com', 'Ms', 'Bittlestone', 'Franky', 'Female', '1989-05-18', '37 Sundown Court', 'South Australia', '8892', '6083917201', '6112913483', 'Australia', 'Quechua', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('87', 'jcutajar2e@ask.com', 'Rev', 'Cutajar', 'Jemmy', 'Male', '1989-04-05', '64 Merrick Center', 'South Australia', '1475', '2352900200', '5312737040', 'Australia', 'Korean', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('88', 'osongist2f@hugedomains.com', 'Ms', 'Songist', 'Orton', 'Male', '1990-03-04', '44463 Warbler Circle', 'South Australia', '8983', '8132090117', '2605160884', 'Australia', 'Quechua', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('89', 'mcarlill2g@netscape.com', 'Mrs', 'Carlill', 'Margareta', 'Female', '1994-03-15', '71772 Blaine Lane', 'South Australia', '9402', '3738938913', '8499205938', 'Australia', 'Tetum', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('90', 'ekear2h@wisc.edu', 'Honorable', 'Kear', 'Emmalyn', 'Male', '1995-11-25', '5 Vahlen Terrace', 'South Australia', '7094', '3721314218', '8484287768', 'Australia', 'Korean', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('91', 'rsprankling2i@indiegogo.com', 'Mrs', 'Sprankling', 'Rozalie', 'Female', '1995-12-06', '0 Rusk Place', 'South Australia', '3437', '9187272653', '8036880194', 'Australia', 'Yiddish', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('92', 'bvorley2j@biglobe.ne.jp', 'Ms', 'Vorley', 'Brigitta', 'Female', '1994-01-02', '459 Transport Alley', 'South Australia', '2679', '1062118082', '7611813421', 'Australia', 'West Frisian', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('93', 'aallerton2k@sakura.ne.jp', 'Ms', 'Allerton', 'Abdul', 'Male', '1994-03-08', '92702 Sycamore Place', 'South Australia', '2527', '6736657206', '7219889569', 'Australia', 'Polish', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('94', 'vgreendale2l@scribd.com', 'Mr', 'Greendale', 'Vinita', 'Male', '1996-05-26', '77 Burrows Point', 'South Australia', '3608', '4004185110', '1726466652', 'Australia', 'Kannada', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('95', 'japplin2m@berkeley.edu', 'Mrs', 'Applin', 'Jilly', 'Female', '1983-03-14', '2 Porter Hill', 'South Australia', '4938', '3805784323', '1172408653', 'Australia', 'German', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('96', 'tthackham2n@dell.com', 'Dr', 'Thackham', 'Teador', 'Male', '1983-02-01', '95 Farragut Drive', 'South Australia', '6064', '6141365515', '1621581084', 'Australia', 'Papiamento', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('97', 'lferryman2o@mayoclinic.com', 'Dr', 'Ferryman', 'Lynda', 'Female', '1988-05-02', '61653 Ruskin Street', 'South Australia', '3631', '6413779266', '7052313447', 'Australia', 'Malagasy', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('98', 'pharrow2p@about.me', 'Mr', 'Harrow', 'Percy', 'Male', '1986-09-18', '353 Walton Plaza', 'South Australia', '8672', '8104389763', '5618814211', 'Australia', 'Montenegrin', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('99', 'cphelip2q@parallels.com', 'Rev', 'Phelip', 'Cristin', 'Female', '1985-05-05', '712 Straubel Junction', 'South Australia', '2298', '9854569546', '4336213932', 'Australia', 'Moldovan', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);
INSERT INTO Patient
    (URNumber, Email, Title, SurName, FirstName, Gender, DOB, [Address], Suburb, PostCode, MobileNumber, HomeNumber, CountryOfBirth, PreferredLanguage, [Password], Salt, LivesAlone, RegisteredBy, Active, Deceased)
values
    ('100', 'fkharchinski2r@jugem.jp', 'Mrs', 'Kharchinski', 'Fidelia', 'Female', '1988-08-25', '98 Straubel Place', 'South Australia', '1010', '6541123971', '8529819100', 'Australia', 'Chinese', HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 'salt', 1, 1, 1, 0);


-- For when the password in Patient table is of type Nvarchar
-- INSERT INTO Patient
--     (URNumber,Email,Title,SurName,FirstName,Gender,DOB,[Address],Suburb,PostCode,MobileNumber,HomeNumber,CountryOfBirth,PreferredLanguage,[Password],Salt,LivesAlone,RegisteredBy,Active)
-- VALUES('123456789', 'patient@patient.com', 'Mrs', 'Doe', 'Jane', 'Female', GETDATE(), '123 Evergreen Terrace', 'Springfield', '1234', '0123456789', '0123456789', 'Australia', 'English', convert(nvarchar(max),HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 1), 'salt', 0, 1, 1),
--     ('987654321', 'patient2@patient.com', 'Mr', 'Doe', 'John', 'Male', GETDATE(), '123 Evergreen Terrace', 'Springfield', '1234', '0123456789', '0123456789', 'Australia', 'English', convert(nvarchar(max),HASHBYTES('SHA2_512', CONCAT('password', 'salt', 'this15myp3pper')), 1), 'salt', 0, 1, 1);


INSERT INTO Measurement
    (MeasurementName, Frequency)
VALUES('ECOG Status', 28),
    ('Breathlessness', 1),
    ('Level of Pain', 1),
    ('Fluid Drain', 1),
    ('Quality of Life', 7);

INSERT INTO DataPoint
    (MeasurementID,DataPointNumber,UpperLimit,LowerLimit,[Name])
VALUES(1, 1, 4, 0, 'ECOG Status'),
    (2, 1, 5, 1, 'Breathlessness'),
    (3, 1, 5, 1, 'Level of Pain'),
    (4, 1, 600, 0, 'Fluid Drain'),
    (5, 1, 5, 1, 'Mobility'),
    (5, 2, 5, 1, 'Self-Care'),
    (5, 3, 5, 1, 'Usual-Activies'),
    (5, 4, 5, 1, 'Pain/Discomfort'),
    (5, 5, 5, 1, 'Anxiety/Depression'),
    (5, 6, 100, 0, 'QoL Vas Health Slider');

INSERT INTO ResourceType
    (TypeName)
VALUES('phone'),
    ('pdf'),
    ('link'),
    ('dialog');

INSERT INTO [Resource]
    (Title,Prompt,Content,TypeID)
VALUES('Pleural Nurse Clinical Consultant', '0428-167-972', '', 1),
    ('How to drain your Indwelling Pleural Catheter', 'Click Here', '', 4),
    ('Northern Health Respiratory Medicine', 'Click Here', 'https://www.nh.org.au/service/respiratory-medicine/', 3),
    ('Indwelling Pleural Catheter Information Sheet', 'Click Here', 'IPC.pdf', 2),
    ('Northern Health Telehealth', 'Click Here', 'https://www.nh.org.au/telehealth/', 3);

INSERT INTO ResourceDialog
    (Heading,Content,Video,ResourceID)
VALUES('How to drain your Indwelling Pleural Catheter', 'Please enter the amount of fluid you have drained today in millilitres. Enter the value in the box. <p>Below is a video which details how to perform a fluid drainage of an Indwelling Pleural Catheter.</p>', 'https://player.vimeo.com/video/270685188', 2);

INSERT INTO RecordCategory
    (Category)
VALUES('Immunisation');

INSERT INTO RecordType
    (RecordType,RecordCategoryID)
VALUES('MMR', 1);

INSERT INTO PatientRecord
    (DateTimeRecorded,Notes,URNumber,RecordTypeID)
VALUES(GETDATE(), 'No Notes', '123456789', 1);

INSERT INTO Treating
    (StartDate,EndDate,URNumber,StaffID)
VALUES(GETDATE(), GETDATE(), '123456789', 1);

INSERT INTO TemplateCategory
    (CategoryName)
VALUES('Indwelling Pleural Catheter'),
    ('Asthma'),
    ('COPD');

INSERT INTO PatientCategory
    (CategoryID,URNumber)
VALUES(1, '123456789'),
    (1, '987654321')


INSERT INTO ConditionDetails
    (CategoryID, URNumber, Diagnosis, ProcedureDate, NextAppointment)
VALUES(1, '123456789', 'There has been a build-up of fluid around your lungs. Therefore, it is important for us to know and monitor how you are feeling by using this app  to allow us to best optimise your care. The app will be used in hospital and in clinic during follow-up.', GETDATE(), GETDATE()),
    (1, '987654321', 'There has been a build-up of fluid around your lungs. Therefore, it is important for us to know and monitor how you are feeling by using this app  to allow us to best optimise your care. The app will be used in hospital and in clinic during follow-up.', GETDATE(), GETDATE())

INSERT INTO PatientResource
    (CategoryID,URNumber,ResourceID)
VALUES(1, '123456789', 1),
    (1, '123456789', 2),
    (1, '123456789', 3),
    (1, '123456789', 4),
    (1, '123456789', 5),
    (1, '987654321', 1),
    (1, '987654321', 2),
    (1, '987654321', 3),
    (1, '987654321', 4),
    (1, '987654321', 5);

INSERT INTO TemplateResource
    (CategoryID,ResourceID)
VALUES(1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (1, 5);

INSERT INTO TemplateMeasurement
    (MeasurementID,CategoryID)
VALUES(1, 1),
    (2, 1),
    (3, 1),
    (4, 1),
    (5, 1);

INSERT INTO PatientMeasurement
    (MeasurementID,CategoryID,URNumber,Frequency,FrequencySetDate)
VALUES
    (1, 1, '123456789', 28, GETDATE()),
    (2, 1, '123456789', 1, GETDATE()),
    (3, 1, '123456789', 1, GETDATE()),
    (4, 1, '123456789', 1, GETDATE()),
    (5, 1, '123456789', 1, GETDATE()),
    (1, 1, '987654321', 1, GETDATE()),
    (2, 1, '987654321', 1, GETDATE()),
    (3, 1, '987654321', 1, GETDATE()),
    (4, 1, '987654321', 7, GETDATE()),
    (5, 1, '987654321', 7, GETDATE());



INSERT into MeasurementRecord
    (DateTimeRecorded, MeasurementID,CategoryID,URNumber)
VALUES
    ('2020-01-20 10:34:09 AM', 1, 1, '123456789'),
    ('2020-01-20 10:35:10 AM', 2, 1, '123456789'),
    ('2020-01-20 10:36:09 AM', 3, 1, '123456789'),
    ( '2020-01-20 10:37:09 AM', 4, 1, '123456789'),
    ( '2020-01-20 10:38:09 AM', 5, 1, '123456789'),

    ('2020-01-21 10:34:09 AM', 1, 1, '123456789'),
    ('2020-01-21 10:35:09 AM', 2, 1, '123456789'),
    ('2020-01-21 10:36:09 AM', 3, 1, '123456789'),
    ( '2020-01-21 10:37:09 AM', 4, 1, '123456789'),
    ( '2020-01-21 10:38:09 AM', 5, 1, '123456789'),

    ('2020-01-22 10:34:09 AM', 1, 1, '123456789'),
    ('2020-01-22 10:35:09 AM', 2, 1, '123456789'),
    ('2020-01-22 10:36:09 AM', 3, 1, '123456789'),
    ( '2020-01-22 10:37:09 AM', 4, 1, '123456789'),
    ( '2020-01-22 10:38:09 AM', 5, 1, '123456789'),

    -- new patient
    ('2020-01-20 10:34:09 AM', 1, 1, '987654321'),
    ('2020-01-20 10:35:10 AM', 2, 1, '987654321'),
    ('2020-01-20 10:36:09 AM', 3, 1, '987654321'),
    ( '2020-01-20 10:37:09 AM', 4, 1, '987654321'),
    ( '2020-01-20 10:38:09 AM', 5, 1, '987654321'),

    ('2020-01-21 10:34:09 AM', 1, 1, '987654321'),
    ('2020-01-21 10:35:09 AM', 2, 1, '987654321'),
    ('2020-01-21 10:36:09 AM', 3, 1, '987654321'),
    ( '2020-01-21 10:37:09 AM', 4, 1, '987654321'),
    ( '2020-01-21 10:38:09 AM', 5, 1, '987654321'),

    ('2020-01-22 10:34:09 AM', 1, 1, '987654321'),
    ('2020-01-22 10:35:09 AM', 2, 1, '987654321'),
    ('2020-01-22 10:36:09 AM', 3, 1, '987654321'),
    ( '2020-01-22 10:37:09 AM', 4, 1, '987654321'),
    ( '2020-01-22 10:38:09 AM', 5, 1, '987654321');


--need to match up the measurement record id from a select * from measurementrecord
-- 4 1 fluid drainge 600
-- 5 6 100 
-- for 5 values (1-6)

-- INSERT INTO DataPoint
--     (MeasurementID,DataPointNumber,UpperLimit,LowerLimit,[Name])
-- VALUES(1, 1, 4, 0, 'ECOG Status'),
--     (2, 1, 5, 1, 'Breathlessness'),
--     (3, 1, 5, 1, 'Level of Pain'),
--     (4, 1, 600, 0, 'Fluid Drain'),
--     (5, 1, 5, 1, 'Mobility'),
--     (5, 2, 5, 1, 'Self-Care'),
--     (5, 3, 5, 1, 'Usual-Activies'),
--     (5, 4, 5, 1, 'Pain/Discomfort'),
--     (5, 5, 5, 1, 'Anxiety/Depression'),
--     (5, 6, 100, 0, 'QoL Vas Health Slider');
-- */

INSERT DataPointRecord
    (MeasurementID,DataPointNumber,[Value],MeasurementRecordId)
values
    (1, 1, 1, 1),
    (2, 1, 3, 2),
    (3, 1, 5, 3),
    (4, 1, 350, 4),
    (5, 1, 2, 5),
    (5, 2, 3, 5),
    (5, 3, 5, 5),
    (5, 4, 4, 5),
    (5, 5, 97, 5),
    --
    (1, 1, 4, 6),
    (2, 1, 3, 7),
    (3, 1, 5, 8),
    (4, 1, 500, 9),
    (5, 1, 3, 10),
    --
    (1, 1, 5, 11),
    (2, 1, 5, 12),
    (3, 1, 5, 13),
    (4, 1, 500, 14),
    (5, 1, 3, 15),
    (5, 2, 3, 15),
    (5, 3, 5, 15),
    (5, 4, 4, 15),
    (5, 5, 97, 15),
    -- 
    (1, 1, 2, 16),
    (2, 1, 3, 17),
    (3, 1, 4, 18),
    (4, 1, 220, 19),
    (5, 1, 3, 20),
    (5, 2, 3, 20),
    (5, 3, 4, 20),
    (5, 4, 1, 20),
    (5, 5, 67, 20),
    --
    (1, 1, 5, 21),
    (2, 1, 4, 22),
    (3, 1, 5, 23),
    (4, 1, 230, 24),
    (5, 1, 3, 25),
    --
    (1, 1, 5, 26),
    (2, 1, 5, 27),
    (3, 1, 5, 28),
    (4, 1, 500, 29),
    (5, 1, 3, 30),
    (5, 2, 3, 30),
    (5, 3, 5, 30),
    (5, 4, 4, 30),
    (5, 5, 97, 30);


INSERT INTO tbl_AlertType
    (Title , Details , TriggerCondition, TriggerThresholdValue)
values
    ('High Fluid Drain', 'The Patients IPC drains greater than the threshold amount', 'IPC_Drainage >', 300),
    ('Quality of Life Poor', 'Alert triggers when QOL survey is poor three times in a row', 'QOL <= poor', 3 ),
    ('Level of Pain', 'Level of pain Higher than four three times in a row', 'Level of Pain >= 4', 4),
    ('Breathlessness', 'When breathlessness is greater than or equal to 4 three recordings in a row', 'Breathlessness >=', 4),
    ('Quality of life very poor', 'Alert triggers when QOL survey questions are very poor', 'QOL <= very poor', 4),
    ('Missed Survey', 'Patient Missed a Survey', 'Survey Missed', 1);

-- When an alert is acted upon
INSERT INTO tbl_Alert
    (URNumber, StaffID, AlertTypeID, TriggerValue, DateTimeRaised, DateTimeActioned, [Status], Notes)
VALUES
    ('1', 1, 1, 320 , '2021-10-13 08:50:12', '2021-10-13 09:30:12', 'Actioned', null),
    ('2', 1, 1, 320 , '2021-10-13 07:50:12', '2021-10-13 09:30:12', 'Snooze', null),
    ('3', 1, 1, 320 , '2021-11-13 08:50:12', '2021-10-13 09:30:12', 'Dismiss', null),
    ('4', 1, 1, 320 , '2020-10-13 08:50:12', '2021-10-13 09:30:12', 'Actioned', null),
    ('5', 1, 1, 320 , '2021-10-13 09:50:12', '2021-10-13 09:30:12', 'Actioned', null),
    ('6', 1, 1, 320 , '2021-10-13 10:50:12', '2021-10-13 09:30:12', 'Dismiss', null);

-- When an alert is NOT acted upon
INSERT INTO tbl_Alert
    (URNumber, AlertTypeID, TriggerValue, DateTimeRaised, DateTimeActioned, [Status], Notes)
VALUES
    ('1', 1, 320 , '2015-10-13 07:50:12', null, null , null),
    ('2', 1, 320 , '2015-10-13 08:50:12', null, null , null),
    ('3', 1, 320 , '2015-10-13 06:50:12', null, null , null),
    ('4', 1, 320 , '2015-10-13 09:50:12', null, null , null),
    ('5', 1, 320 , '2016-10-13 09:50:12', null, null , null),
    ('6', 1, 320 , '2015-11-13 08:50:12', null, null , null);
