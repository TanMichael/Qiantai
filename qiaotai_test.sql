/*初始化数据库用*/
create database Qiaotai character set gbk;

use qiaotai;
SET auto_increment_increment=10000;

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
   所属客户编号 int not null
);

create table 客户地址
(
   编号 int primary key auto_increment,
   客户编号 int not null,
   地址顺序 int not null,
   地址 nvarchar(256) not null,
   联系电话 nvarchar(128) not null
);

create table 产品信息
(
   产品编号 int primary key auto_increment,
   产品名称 nvarchar(256),
   规格 nvarchar(256) not null,
   材质 nvarchar(128) not null,
   变位 nvarchar(128),
   实测变位 nvarchar(128),
   颜色 nvarchar(128),
   单位 nvarchar(32),
   单价 decimal(7,2),
   库存数量 int,

-- 发布
   布料编号 nvarchar(128),
   开料要求 nvarchar(128),
   开料尺寸 nvarchar(128),
-- 含浸
   胶水型号 nvarchar(128),
   溶剂 nvarchar(128),
   脱模剂 nvarchar(128),
   硬化剂 nvarchar(128),
   含浸比重 nvarchar(128),
   搅拌时间 nvarchar(128),
   比重计 nvarchar(128),
   胶滚压力 nvarchar(128),
   含浸转速HZ nvarchar(128),
   烤箱温度C nvarchar(128),
-- 成型
   成型模号 nvarchar(128),
   成型机台 nvarchar(128),
   手动自动 nvarchar(128),
   单个整条 nvarchar(128),
   成型上下模温度 nvarchar(128),
   成型时间 nvarchar(128),
   成型压力 nvarchar(128),
   自动切 nvarchar(128),
   是否拉布成型 nvarchar(128),
   是否中孔加补强布 nvarchar(128),
   补强布大小 nvarchar(128),
   是否压纸板 nvarchar(128),
   剪边喷水 nvarchar(128),
   压定位板 nvarchar(128),
   定型时间 nvarchar(128),
   压纸板时间 nvarchar(128),
-- 切断
   刀模 nvarchar(128),
   中孔模 nvarchar(128),
   刀模中心定位 nvarchar(128),
   切刀模个数 nvarchar(128),
   切断模 nvarchar(128),
   切断模架 nvarchar(128),
   切断机台 nvarchar(128),
   单个整条切断 nvarchar(128),
   通用气冲模 nvarchar(128),
   气冲压力 nvarchar(128),
   多个多条切断 nvarchar(128),
-- 导线弹波
   导线方式 nvarchar(128),
   导线规格 nvarchar(128),
   内留mm nvarchar(128),
   外留mm nvarchar(128),
   点锡长mm nvarchar(128),
   导线长度 nvarchar(128),
   方向数量 nvarchar(128),
   线距mm nvarchar(128),
   单面双面点胶 nvarchar(128),
-- 双层弹波
   胶水 nvarchar(128),
   边胶 nvarchar(128),
   胶水重量 nvarchar(128),
   摆放要求 nvarchar(128),
   工艺要求 nvarchar(128),
   打胶方式 nvarchar(128),
   贴合方式 nvarchar(128),
   贴合压力 nvarchar(128),
   贴合模具 nvarchar(128),
   贴合机台 nvarchar(128),
-- 品质/包装
   成型首检变位 nvarchar(128),
   生产单重 nvarchar(128),
   样品变位 nvarchar(128),
   样品单重 nvarchar(128),
   测试夹具外内 nvarchar(128),
   是否留样 nvarchar(128),
   是否备品 nvarchar(128),
   是否产品全检 nvarchar(128),
   是否数量超交 nvarchar(128),
   是否标签盖环保章 nvarchar(128),
   外贴标签要求 nvarchar(128),
-- 表尾
   备注 nvarchar(1024),
   批准 nvarchar(128),
   审核 nvarchar(128),
   制作 nvarchar(128)
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
   成交次数                 int,
   最近成交价               decimal(7,2),
   primary key (客户编号,产品编号)
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
   供应商                 nvarchar(256),
   原料名称               nvarchar(128),
   单位                   nvarchar(128),
   库存数量               int
);

create table 原材料进出仓
(
   编号                   int primary key auto_increment,
   类型                   nvarchar(128),
   数量                   int,
   原料编号               int,
   供应商                 nvarchar(256),
   供应单价               decimal(7,2),
   发生时间                 DATETIME,
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
   生产状态                 nvarchar(128),
   相关订单编号             int,
   最后更新时间             DATETIME,
   已完成生产数             int default 0,
   已发货数                 int default 0,
   是否含库存               nvarchar(32) default '否',
   负责人                   nvarchar(128)
);

create table 订单
(
   订单编号                 int primary key auto_increment,
   客户编号                 int,
   客户名称                 nvarchar(128),
   是否样品订单             nvarchar(128),
   创建时间                 DATETIME not null,
   发货时间                 DATETIME,
   最后更新时间             DATETIME,
   订单状态                 nvarchar(128),
   送货单号                 nvarchar(128),
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

INSERT INTO `员工信息` (账户名, 密码, 姓名, 系统角色,职位,手机, 办公电话,电子邮箱,部门) VALUES
   ('1','c4ca4238a0b923820dcc509a6f75849b','1','超级管理员','4','4','4','4','4');