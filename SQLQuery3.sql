create table Vehicle(
VehicleId int not null primary key,
RegistrationNumber int  null,
Color varchar(30)  null,
MakeId int null,
Constraint  Fk_vehmake Foreign Key (VehicleId) REFERENCES Vehicle (VehicleId),
)