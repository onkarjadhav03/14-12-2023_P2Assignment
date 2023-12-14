create database ProductInventoryDb

use ProductInventoryDb

create table Products(
Pid int primary key,
Pname nvarchar(20),
Price float,
Quantity int,
MfDate date,
ExpDate date)

insert into Products values(1,'Mobile',50000,2,'12/02/2022','12/02/2040')

select * from Products