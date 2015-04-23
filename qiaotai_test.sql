create database Qiaotai character set gbk;

use qiaotai;

create table 员工信息
(
	员工编号 int primary key auto_increment,
	账户名 nvarchar(128) not null,
	密码 varchar(128) not null,
	姓名 nvarchar(128) not null,
	系统角色 nvarchar(32) not null,
	职位 nvarchar(32),
	手机 varchar(32),
	办公电话 varchar(32),
	电子邮箱 varchar(128),
	部门 nvarchar(32)
);

create table 客户信息
(
	客户编号 int primary key auto_increment,
	客户名称 nvarchar(128) not null,
	地址 nvarchar(256) not null,
	联系电话 varchar(32) not null,
	传真 varchar(32),
	电子邮箱 varchar(128),
	结算方式 nvarchar(32),
	流水号 varchar(32),
	备注 nvarchar(2048)
);

create table 客户联系人
(
	编号 int primary key auto_increment,
	姓名 nvarchar(128) not null,
	类型 nvarchar(32) not null,
	联系电话 nvarchar(128) not null,
	电子邮件 nvarchar(32) not null,
	所属客户编号 int not null,
);

create table 客户地址
(
	编号 int primary key auto_increment,
	客户编号 int not null,
	地址顺序 int not null,
	地址 nvarchar(256) not null,
	联系电话 nvarchar(128) not null,
);

create table 产品信息
(
	产品编号 int primary key auto_increment,
	产品名称 nvarchar(256),
	规格 nvarchar(256) not null,
	材质 nvarchar(128) not null,
	变位 nvarchar(128) not null,
	实测变位 nvarchar(128) not null,
	温度 nvarchar(128) not null,
	生产耗时 nvarchar(128),
	压力 nvarchar(128),
	树脂名称 nvarchar(128),
	树脂比重 nvarchar(128),
	含浸尺寸 nvarchar(128),
	外盘 nvarchar(128),
	内治具 nvarchar(128),
	重量 nvarchar(128),
	成型模 nvarchar(128),
	切模号 nvarchar(128),
	单位 nvarchar(32),
	库存数量 int
);

create table 产品原料关系
(
   原料编号                 int,
   产品编号                 int,
   原料数量                 int,
   primary key (原料编号,产品编号)
);

create table 产品进出库
(
   编号                   int primary key auto_increment,
   产品编号                 int,
   发生时间                 date,
   类型                   nvarchar(128),
   相关订单编号               int,
   相关计划编号               int,
   不合格产品数               int
);

create table 原材料
(
   原料编号               int primary key auto_increment,
   原料名称               nvarchar(128),
   单位                   nvarchar(128),
   库存数量               int
);

create table 原材料进出仓
(
   编号                   int primary key auto_increment,
   类型                   nvarchar(128),
   库存数量               int,
   原料编号               int,
   供应商编号             int,
   供应单价               int,
   操作员                 nvarchar(128)
);

insert into 员工信息 (账户名, 密码, 姓名, 系统角色) values("michaeltan", "Abcd1234", "Weihua", "管理员");
insert into 员工信息 (账户名, 密码, 姓名, 系统角色) values("davidzhao", "Abcd1234", "赵鲁泉", "管理员");
insert into 员工信息 (账户名, 密码, 姓名, 系统角色) values("md5", "325a2cc052914ceeb8c19016c091d2ac", "fuck", "管理员");
SELECT * FROM `qiaotai`.`员工信息`;
select * from 员工信息 limit 0,1;