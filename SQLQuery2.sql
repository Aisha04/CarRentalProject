create table booking(
BookId int not null primary key,
Booking_Date DateTime null,
Start_Date DateTime null,
End_Date DateTime null,
Amount int null,
UserId int null,
VehicleId int null,
Constraint  Fk_Bookuser Foreign Key (UserId) REFERENCES Users (UserId),
Constraint  Fk_Bookvehicle Foreign Key (UserId) REFERENCES Users (UserId),

)
