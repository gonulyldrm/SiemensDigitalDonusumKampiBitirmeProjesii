create Database E_CommerceDb
go
use E_CommerceDb
go
create table Users
(
	userId int,
	userName nvarchar(90),
	email nvarchar(120),
	gender nvarchar(10)
)
go
create table Products
(
	productId int,
	productName nvarchar(90),
	price int,
	catagory nvarchar(100)
)
go
create table Baskets
(
	basketId int identity,
	totalPrice int
)
go
create table Payments
(
	paymentId int,
	basketId int,
	optionPayment nvarchar(40)
)