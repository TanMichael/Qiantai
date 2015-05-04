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
   默认联系人 nvarchar(128),
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
	单价 decimal(7,2),
	库存数量 int
);

create table 产品原料关系
(
   原料编号                 int,
   产品编号                 int,
   原料数量                 int,
   primary key (原料编号,产品编号)
);

create table 产品客户关系
(
   客户编号                 int,
   产品编号                 int,
<<<<<<< HEAD
   订单编号                 int,
   成交价                 decimal(7,2),
   primary key (客户编号,产品编号,订单编号)
=======
   成交次数                 int,
   最近成交价               decimal(7,2),
   primary key (客户编号,产品编号)
>>>>>>> origin/master
);

create table 产品进出库
(
   编号                   int primary key auto_increment,
   产品编号                 int,
   发生时间                 DATETIME,
   类型                   nvarchar(128),
   相关订单编号               int,
   相关计划编号               int,
   不合格产品数               int,
   当前状态               nvarchar(128)
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
   供应商                 nvarchar(256),
   供应单价               decimal(7,2),
   操作员                 nvarchar(128)
);

create table 生产计划
(
   编号                     int primary key auto_increment,
   产品编号                 int not null,
   客户编号                 int,
   下单日期                 DATETIME not null,
   产品数量                 int not null,
   交付时间                 DATETIME,
   实际完成时间             DATETIME,
   计划类型                 nvarchar(128),
   相关订单编号             int,
   负责人                   nvarchar(128)
);

create table 订单
(
   订单编号                 int primary key auto_increment,
   客户编号                 int,
   是否样品订单             nvarchar(128),
   创建时间                 DATETIME not null,
   发货时间                 DATETIME,
   最后更新时间             DATETIME,
   订单状态                 nvarchar(128),
   快递单号                 nvarchar(128),
   订金方式                 nvarchar(128),
   收货地址                 nvarchar(128),
   收货联系人               nvarchar(128),
   收货电话                 nvarchar(128),
   创建人                   nvarchar(128) not null
);

create table 订单明细
(
   订单编号               int not null,
   产品编号               int not null,
   数量                   int not null,
   单价                   decimal(7,2) not null,
   折扣                   decimal(3,2),
   成交价                 decimal(7,2),
   primary key (订单编号, 产品编号)
);

create table 操作记录
(
   记录编号               int primary key auto_increment,
   操作员                 nvarchar(128) not null,
   操作动作               nvarchar(256) not null,
   操作对象               nvarchar(128) not null,
   操作结果               nvarchar(512),
   操作时间               DATETIME not null
);

insert into 员工信息 (账户名, 密码, 姓名, 系统角色) values("michaeltan", "Abcd1234", "Weihua", "管理员");
insert into 员工信息 (账户名, 密码, 姓名, 系统角色) values("davidzhao", "Abcd1234", "赵鲁泉", "管理员");
insert into 员工信息 (账户名, 密码, 姓名, 系统角色) values("md5", "325a2cc052914ceeb8c19016c091d2ac", "fuck", "管理员");

INSERT INTO `员工信息` (账户名, 密码, 姓名, 系统角色,职位,手机,	办公电话,电子邮箱,部门) VALUES
	('davidzhaoa','325a2cc052914ceeb8c19016c091d2ac','赵鲁泉','管理员','22222','2','2','2','2'),
	('md5_2','325a2cc052914ceeb8c19016c091d2ac','fuck','管理员','3','3','3','3','3'),
	('1','c4ca4238a0b923820dcc509a6f75849b','1','管理员','4','4','4','4','4');

SELECT * FROM `qiaotai`.`员工信息`;
select * from 员工信息 limit 0,1;

INSERT INTO `客户信息` (客户名称, 地址, 联系电话, 传真,电子邮箱,结算方式,	流水号,备注) VALUES ('SAP','b','c111','323','3243','432','432','342'),
	('Microsoft','2','2','2','2','2','2','2'),
	('Oracle','3','3','3','3','3','33','3');

INSERT INTO 客户联系人 (姓名,类型,联系电话,电子邮件,所属客户编号) VALUES ('刘寅', 'sales', '1532', 'liuren@48.com', 13),
	('左建雄', 'sales', '1532', 'zuojianxing@48.com', 13),
	('李艳', 'finance', '1632', 'diyan@48.com', 13);