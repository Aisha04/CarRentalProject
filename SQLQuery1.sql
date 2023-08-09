create table Users(
UserId int not null Primary key,
FirstName varchar(50) null,
Surname varchar(50) null,
Age int null,
Address varchar(50) null,
PhoneNumber int null,
Gender char(1) null default ('M'),
Status char(1) null default ('A'),

)