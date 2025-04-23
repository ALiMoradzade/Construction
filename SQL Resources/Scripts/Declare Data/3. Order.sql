use [Construction Equipment]
go

insert into [order] values (4,default,default,270000)
insert into [Order Detail] values(1,N'آچار آلن',2,79000,79000*2)
insert into [Order Detail] values(1,N'چراغ قوه بزرگ',1,112000,112000)

insert into [order] values (1,default,default,13600)
insert into [Order Detail] values(2,N'پیچ کابینت',12,300,300*12)
insert into [Order Detail] values(2,N'چسب قطره ای رازی کوچک',1,10000,10000)

insert into [order] values (1,default,default,123000)
insert into [Order Detail] values(3,N'پوشال 7000',1,123000,123000)

insert into [order] values (6,default,default,207900)
insert into [Order Detail] values(4,N'آچار فرانسه',2,100000,2*100000)
insert into [Order Detail] values(4,N'پیچ کابینت',8,300,300*8)
insert into [Order Detail] values(4,N'چسب قطره ای رازی بزرگ',1,5500,5500)

insert into [order] values (1,default,default,459000)
insert into [Order Detail] values(5,N'آچار آلن',1,79000,79000)
insert into [Order Detail] values(5,N'آچار فرانسه',1,100000,100000)
insert into [Order Detail] values(5,N'پوشال 5000',2,110000,110000*2)
insert into [Order Detail] values(5,N'چراغ قوه کوچک',1,50000,50000)
insert into [Order Detail] values(5,N'چسب قطره ای رازی کوچک',1,10000,10000)

insert into [dbo].[Instalment] values (5,default)
insert into [dbo].[Instalment Detail] values (1,1,'2024-05-27','2024-05-27',0,153000)
insert into [dbo].[Instalment Detail] values (2,1,'2024-06-27',null,0,153000)
insert into [dbo].[Instalment Detail] values (3,1,'2024-07-27',null,0,153000)

insert into [order] values (9,default,default,79000)
insert into [Order Detail] values(6,N'آچار آلن',1,79000,79000)
insert into [order] values (9,default,default,100000)
insert into [Order Detail] values(7,N'آچار فرانسه',1,100000,100000)
insert into [order] values (9,default,default,110000)
insert into [Order Detail] values(8,N'پوشال 5000',2,110000,110000)
insert into [order] values (9,default,default,50000)
insert into [Order Detail] values(9,N'چراغ قوه کوچک',1,50000,50000)
insert into [order] values (9,default,default,100000)
insert into [Order Detail] values(10,N'چسب قطره ای رازی کوچک',1,10000,10000)
