use HotelManagement;
CREATE TABLE UserInformations (InformationId int IDENTITY(1,1) NOT NULL, UserId int NOT NULL, Name varchar(50) NOT NULL, Surname varchar(50), Bday datetime, Gender bit, MaritalStatus bit NOT NULL, Phone varchar(11), PRIMARY KEY (InformationId));
CREATE TABLE Booking (BookingId int IDENTITY(1,1) NOT NULL, UserId int NOT NULL, Cost float(10), InDate datetime, OutDate datetime, CustomerCount int DEFAULT 1 NOT NULL, HotelId int NOT NULL, PRIMARY KEY (BookingId));
CREATE TABLE Hotel (HotelId int IDENTITY(1,1) NOT NULL, HotelName varchar(100) NOT NULL, Place varchar(50), Address varchar(255), Phone varchar(11), TotalCapacity int, Type varchar(50), PRIMARY KEY (HotelId));
CREATE TABLE Guest (GuestId int IDENTITY(1,1) NOT NULL, BookingId int NOT NULL, Name varchar(50) NOT NULL, Surname varchar(50), BDate datetime, Phone varchar(11), Gender bit, BookingBookingId int NOT NULL, PRIMARY KEY (GuestId));
CREATE TABLE Room (RoomId int IDENTITY(1,1) NOT NULL, RoomNumber int NOT NULL UNIQUE, floorNo int, Capacity int, Type varchar(100), Bedsize int, NonSmoking bit, BedCount int, PRIMARY KEY (RoomId));
ALTER TABLE Booking ADD CONSTRAINT FKBooking FOREIGN KEY (RoomId) REFERENCES Room (RoomId);
ALTER TABLE Guest ADD CONSTRAINT FKGuest37242 FOREIGN KEY (BookingBookingId) REFERENCES Booking (BookingId);
ALTER TABLE Room_Booking ADD CONSTRAINT FKRoom_Booki605215 FOREIGN KEY (RoomRoomId) REFERENCES Room (RoomId);
ALTER TABLE Room_Booking ADD CONSTRAINT FKRoom_Booki17442 FOREIGN KEY (BookingBookingId) REFERENCES Booking (BookingId);
ALTER TABLE Booking ADD CONSTRAINT FKBooking11716 FOREIGN KEY (HotelId) REFERENCES Hotel (HotelId);
ALTER TABLE UserInformations ADD CONSTRAINT FKUserInformation FOREIGN KEY (UserId) REFERENCES UserProfile (UserId);
ALTER TABLE Booking ADD CONSTRAINT FKBookingUserId FOREIGN KEY (UserId) REFERENCES UserProfile (UserId);
ALTER TABLE webpages_UsersInRoles ADD CONSTRAINT FKUserProfileRole FOREIGN KEY (UserId) REFERENCES UserProfile (UserId);
ALTER TABLE webpages_UsersInRoles ADD CONSTRAINT FKwebpages_Roles FOREIGN KEY (RoleId) REFERENCES webpages_Roles (RoleId);



use HotelManagement;
ALTER TABLE UserInformations ALTER COLUMN  MaritalStatus varchar(15);
ALTER TABLE Guest ALTER COLUMN Gender varchar(15);
ALTER TABLE Room ALTER COLUMN NonSmoking varchar(15);
ALTER TABLE webpages_UsersInRoles ADD CONSTRAINT FKGuest37555 FOREIGN KEY (UserId) REFERENCES UserProfile (UserId);
ALTER TABLE webpages_UsersInRoles ADD CONSTRAINT FKGuest37999 FOREIGN KEY (RoleId) REFERENCES webpages_Roles (RoleId);