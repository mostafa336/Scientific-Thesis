
create table Country(
   CNT_ID int identity(1,1) primary key,
   CNT_NameAr nvarchar(30) not null,
   CNT_NameEN nvarchar(30) not null
)

create table University(
   UNI_ID  int identity (1,1) primary key,
   UNI_NameAr nvarchar(30) not null,
   UNI_NameEn nvarchar(30) not null
)


create table Degree(
   DEG_ID int identity (1,1) primary key,
   DEG_NameAr nvarchar(15) not null,
   DEG_NameEn nvarchar(15) not null
)

create table ApplicantAdvisor(
   APAD_ID int identity (1,1),
   APAD_ApplicantID int not null,
   APAD_AdvisorName nvarchar(30) not null ,

   CONSTRAINT fkApplicant FOREIGN KEY (APAD_ApplicantID) 
        REFERENCES FirstApplication(APP_ID)
)

create table Status(
   ST_ID int identity(1,1) primary key,
   ST_State varchar(30) not null
)


create table Admin(
  AD_ID int identity(1,1) primary key,
  AD_Name nvarchar(30) not null,
  AD_Email nvarchar(70) not null,
  AD_Password nvarchar(70) not null
)

create table FirstApplication(
   APP_ID int identity (1,1) primary key,
   APP_NameAr nvarchar(100) not null,
   APP_NameEn nvarchar(100) not null,
   APP_Email nvarchar(70) not null,
   APP_BirthDate DATE not null,
   APP_Job nvarchar(15) null,
   APP_NationalityID int ,
   APP_NationalID nvarchar(20) not null,
   APP_ThesisTitleAr nvarchar(80) not null,
   APP_ThesisTitleEn nvarchar(80) not null,
   APP_Volumes smallint null,
   APP_Pages smallint not null,
   APP_PublicationYear smallint,
   APP_Department nvarchar(50) not null,
   APP_Faculty nvarchar(50) not null,
   APP_UniversityID int,
   APP_keyword nvarchar(max) not null,
   APP_notes nvarchar(max) not null,
   APP_SubmissionLetter varchar(30) not null,
   APP_Thesis varchar(max) not null,
   APP_SubmissionTime datetime not null,
   APP_LanguageMaster nvarchar(15) not null,
   APP_DegreeID  int not null,

   
   CONSTRAINT FkDegree FOREIGN KEY (APP_DegreeID) 
        REFERENCES Degree(DEG_ID) ,
   CONSTRAINT FkUnversity FOREIGN KEY (APP_UniversityID) 
        REFERENCES University(UNI_ID) ,
   CONSTRAINT FkNationality FOREIGN KEY (APP_NationalityID) 
        REFERENCES Country(CNT_ID) 
)


create table ModifiedApplication(
   APP_ID int identity (1,1) primary key,
   APP_NameAr nvarchar(100) not null,
   APP_NameEn nvarchar(100) not null,
   APP_Email nvarchar(70) not null,
   APP_BirthDate DATE not null,
   APP_Job nvarchar(15) null,
   APP_NationalityID int ,
   APP_NationalID nvarchar(20) not null,
   APP_ThesisTitleAr nvarchar(80) not null,
   APP_ThesisTitleEn nvarchar(80) not null,
   APP_Volumes smallint null,
   APP_Pages smallint not null,
   APP_PublicationYear smallint,
   APP_Department nvarchar(50) not null,
   APP_Faculty nvarchar(50) not null,
   APP_UniversityID int,
   APP_keyword nvarchar(max) not null,
   APP_notes nvarchar(max) not null,
   APP_SubmissionLetter varchar(30) not null,
   APP_Thesis varchar(max) not null,
   APP_LanguageMaster nvarchar(15) not null,
   APP_DegreeID  int not null,
   APP_LastModificationDate datetime not null,
   APP_LastModifierID int null,
   APP_StatusID int not null ,
   APP_EbCode varchar(15) null,

   CONSTRAINT FkOriginal FOREIGN KEY (APP_ID) 
        REFERENCES FirstApplication(APP_ID) ,
   CONSTRAINT FkAdmin FOREIGN KEY (APP_LastModifierID) 
        REFERENCES Admin(AD_ID) ,
   CONSTRAINT FkStatus FOREIGN KEY (APP_StatusID) 
        REFERENCES Status(ST_ID) ,
   CONSTRAINT FkDegree1 FOREIGN KEY (APP_DegreeID) 
        REFERENCES Degree(DEG_ID) ,
   CONSTRAINT FkUnversity1 FOREIGN KEY (APP_UniversityID) 
        REFERENCES University(UNI_ID) ,
   CONSTRAINT FkNationality1 FOREIGN KEY (APP_NationalityID) 
        REFERENCES Country(CNT_ID)  
)
