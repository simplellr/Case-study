create database CaseStudy

use CaseStudy
go

Create table SetRoomRates(RoomTypeId int primary key,RoomType varchar(100) not null,BasePrice decimal(18,2)not null)

drop table roommanagement
create table RoomManagement (RoomNo int primary key,Facilities varchar(100) not null,No_Of_Adults int not null,
RoomType varchar(100) not null);

insert into RoomManagement values(101,'Fully Furnished',2,'Single')

select * from SetRoomRates
select * from RoomManagement

---Reservation

Create table reservation(
		Id int Not Null primary key,
		Name varchar(100) Not Null,
		Email varchar(100) Not Null,
		PhoneNumber int Not Null ,
		Address varchar(255) Not NUll,
		IdProof varchar(100) Not Null,
		RoomType varchar(100)not null,
		NoOfMembers int not null,
		CheckIn varchar(255)not null,
		CheckOut varchar(255)not null);

select * from reservation;
drop table reservation

insert into reservation values(1,'Sri','Sri@gmail.com',938477,'hyderabad','Pancard','Single Room',2,'06/06/2022','07/06/2022');

---Payment
CREATE TABLE Payment
(CardHolderName varchar(500) not null ,CardNumber bigint not null primary key, ExpiryDate varchar(50) not null,CVV int not null);

INSERT INTO Payment VALUES('Nia Verma',561112224454244,'03/2025',555);
INSERT INTO Payment VALUES('Peter Paul',651112224454244,'04/2028',456);

SELECT * FROM Payment

---------


--------------
create table SearchRooms
(
check_IN_DATE Date,
Check_OUT_DATE Date,
Rooms_Available int,
RoomType varchar(50)
)

insert into SearchRooms values('2022-07-30','2022-08-10',10,'SingleRooms')

Select * from SearchRooms

-----
Create Table UserRegistration(Name varchar(100) not null,UserName varchar(100)not null,
Email varchar(100) not null, Password varchar(100) not null)

insert into UserRegistration values('Akash','ak123','akash@gmail.com','pass123')
select * from UserRegistration



CREATE PROCEDURE [dbo].[twocolumnsdata] @UserName varchar(50),@Password varchar(50)
AS
BEGIN
SELECT count(UserName) as matches FROM [dbo].[UserRegistration]
WHERE UserName=@UserName AND Password=@Password
END
GO



-----
Create table Booking(PhotoFileName varchar(500),RoomType varchar(100) not null,Facilities varchar(500) not null,
					 No_of_Adults int not null,BasePrice decimal not null)

Insert into Booking values('anonymous.png','Single Room','Wifi',2,1500)
delete  from Booking where RoomType='double Room'
delete  from Booking where RoomType='family Room'
delete  from Booking where RoomType='AC Room'
select * from Booking