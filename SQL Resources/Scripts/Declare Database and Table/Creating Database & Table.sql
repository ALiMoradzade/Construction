create database [Construction Equipment]

use [Construction Equipment]
go

create table Customer(
ID int primary key identity(1,1),
[First Name] nvarchar(10),
[Last Name] nvarchar(15),
[Phone Number] char(11) check(len([Phone Number]) = 11),
[Postal Code] char(10) check(len([Postal Code]) = 10),
[Address] nvarchar(150)
)

Create table [Order](
ID int primary key identity(1,1),
[Customer ID] int not null,
[Date] date default CONVERT(date, getdate()) not null,
[Time] time default left(CONVERT(time, getdate()),8) not null,
[Total Price] int not null,
foreign key ([Customer ID]) references Customer([ID])
)

create table [Stuff](
[Name] nvarchar(25) primary key,
[Count] tinyint not null,
[Price] int not null
)

create table [Order Detail](
[Order ID] int not null,
[Stuff Name] nvarchar(25) not null,
[Order Count] tinyint not null,
[Price] int not null,
[Total Price] int not null,
primary key ([Order ID], [Stuff Name]),
foreign key ([Order ID]) references [Order](ID),
foreign key ([Stuff Name]) references [Stuff]([Name])
)

create table [Instalment](
ID int primary key identity(1,1),
[Order ID] int not null,
[Request Date] date default CONVERT(date, getdate()) not null,
foreign key ([Order ID]) references [Order]([ID])
)

create table [Instalment Detail](
ID int primary key,
[Instalment ID] int not null,
[Must Pay Date] date not null,
[Paid Date] date,
[Payment Type] bit,
[Paid Price] int,
foreign key ([Instalment ID]) references [Instalment]([ID])
)
