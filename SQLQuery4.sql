create table Make(
MakeId int not null primary key,
Origin varchar (50) null,
TypeId int null,
Constraint  Fk_maketype Foreign Key (TypeId) REFERENCES Types (TypeId)
)