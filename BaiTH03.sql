--BaiTH03
Create database Btap2
use Btap2
Create table Category
(
	id int identity(1,1) primary key,
	name nvarchar(50),
	nameVN nvarchar(50),
);

Create table Product 
(
	id int identity(1,1) primary key,
	name nvarchar(200),
	unitPrice float,
	image nvarchar(200),
	productDate date,
	available int,
	categoryId int,
	description nvarchar(1000),

	foreign key (categoryId) references Category(id)
);

Create table Orders
(
	id int identity(1,1) primary key,
	customerId int,
	orderDate date,
	address	nvarchar(200),
	aMount int,
	description	nvarchar(1000),

	foreign key (customerId) references Customer(id)
);

Create table OrderDetail 
(
	id int identity(1,1) primary key,
	orderId int,
	productId int,
	unitPrice float,
	quantity int,

	foreign key (orderId) references Orders(id),
	foreign key (productId) references Product(id)
);

Create table Customer 
(
	id int identity(1,1) primary key,
	password nvarchar(50),
	fullName nvarchar(200),
	email nvarchar(50),
	photo nvarchar(200),
	activated int,
);
insert into Category values (N'Dior', N'Đì O')
insert into Category values (N'Channel', N'Chà neo')
insert into Category values (N'Superme', N'Súp pơ mi')
insert into Category values (N'Porsche', N'Pọt chơ')
insert into Category values (N'LV', N'Lờ Vê')
insert into Category values (N'Dolce & Gabbana', N'Đôn chề')
insert into Category values (N'Owen', N'Ô wen')

insert into Product values (N'Sweatshirt 2018 off shoulder', 130000, 'ao.jpg', '2023-1-1', 1, 1, 'Không có gì cả')
insert into Product values (N'Simple product', 50000, 'ao1.jpg', '2023-1-1', 1, 2, N'Không có gì cả')
insert into Product values (N'Supper stereo earbuds',50000, 'ao2.jpg', '2023-1-1', 1, 4, N'Không có gì cả')
insert into Product values (N'Headset stereo Headphones', 100000, 'ao3.jpg', '2023-1-1', 1, 2, N'Không có gì cả')
insert into Product values (N'New badger Product', 80000, 'ao4.jpg', '2023-1-1', 1, 2, N'Không có gì cả')
insert into Product values (N'Affiliate Product', 29000, 'vay.jpg', '2023-1-1', 1, 1, N'Không có gì cả')
insert into Product values (N'Engagement rings for women', 130000, 'vay1.jpg', '2023-1-1', 1, 3, N'Không có gì cả')
insert into Product values (N'Man consise classical', 80000, 'vay2.jpg', '2023-1-1', 1, 5, N'Không có gì cả')