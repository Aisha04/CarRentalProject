create table Model(
ModelId int not null primary key,
ModelName varchar(50) null,
Availability int null,
Price_per_day varchar(30) null,
Seat_Capacities int null,
Fuel_Usage varchar(30) null,
Engine varchar(50) null,
MakeId int null,
Constraint  Fk_modelmake Foreign Key (MakeId) REFERENCES Make (MakeId)

)