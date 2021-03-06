/*==============================================================*/
/* Database name:  Qiaotai                                      */
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2015/4/20 18:22:19                           */
/*==============================================================*/


drop database if exists Qiaotai;

/*==============================================================*/
/* Database: Qiaotai                                            */
/*==============================================================*/
create database Qiaotai;

use Qiaotai;

/*==============================================================*/
/* Table: 产品信息                                                  */
/*==============================================================*/
create table 产品信息
(
   产品编号                 int not null,
   产品名称                 nvarchar(128),
   规格                   nvarchar(128) not null,
   材质                   nvarchar(128) not null,
   变位                   nvarchar(128) not null,
   实测变位                 nvarchar(128) not null,
   温度                   nvarchar(128) not null,
   生产耗时                 nvarchar(128),
   压力                   nvarchar(128),
   树脂名称                 nvarchar(128),
   树脂比重                 nvarchar(128),
   含浸尺寸                 nvarchar(128),
   外盘                   nvarchar(128),
   内治具                  nvarchar(128),
   重量                   nvarchar(128),
   成型模                  nvarchar(128),
   切模号                  nvarchar(128),
   单位                   nvarchar(32),
   库存数量                 int,
   primary key (产品编号)
);

/*==============================================================*/
/* Table: 产品原料关系                                                */
/*==============================================================*/
create table 产品原料关系
(
   原料编号                 int not null,
   产品编号                 int not null,
   原料数量                 int,
   primary key (原料编号, 产品编号)
);

/*==============================================================*/
/* Table: 产品客户记录                                                */
/*==============================================================*/
create table 产品客户记录
(
   编号                   int not null,
   产品编号                 int,
   客户编号                 int,
   订单数量                 int,
   primary key (编号)
);

/*==============================================================*/
/* Table: 产品进出库                                                 */
/*==============================================================*/
create table 产品进出库
(
   编号                   int not null,
   产品编号                 int,
   发生时间                 date,
   类型                   nvarchar(128),
   相关订单编号               int,
   相关计划编号               int,
   不合格产品数               int,
   primary key (编号)
);

/*==============================================================*/
/* Table: 原材料                                                   */
/*==============================================================*/
create table 原材料
(
   原料编号                 int not null,
   原料名称                 nvarchar(128),
   单位                   nvarchar(128),
   库存数量                 int,
   primary key (原料编号)
);

/*==============================================================*/
/* Table: 原材料进出仓                                                */
/*==============================================================*/
create table 原材料进出仓
(
   编号                   int not null,
   类型                   nvarchar(128),
   库存数量                 int,
   原料编号                 int,
   供应商编号                int,
   供应单价                 int,
   操作员                  nvarchar(128),
   primary key (编号)
);

/*==============================================================*/
/* Table: 员工信息                                                  */
/*==============================================================*/
create table 员工信息
(
   员工编号                 int not null,
   账户名                  nvarchar(128) not null,
   密码                   varchar(128) not null,
   姓名                   nvarchar(128) not null,
   系统角色                 nvarchar(32) not null,
   职位                   nvarchar(32),
   手机                   varchar(32),
   办公电话                 varchar(32),
   电子邮箱                 varchar(128),
   部门                   nvarchar(32),
   primary key (员工编号)
);

/*==============================================================*/
/* Table: 客户信息                                                  */
/*==============================================================*/
create table 客户信息
(
   客户编号                 int not null,
   客户名称                 nvarchar(128) not null,
   地址                   nvarchar(256) not null,
   联系电话                 varchar(32) not null,
   传真                   varchar(32),
   电子邮箱                 varchar(128),
   结算方式                 nvarchar(32),
   流水号                  varchar(32),
   备注                   nvarchar(2048),
   primary key (客户编号)
);

/*==============================================================*/
/* Table: 客户地址                                                  */
/*==============================================================*/
create table 客户地址
(
   编号                   int not null,
   客户编号                 int not null,
   地址顺序                 int not null,
   地址                   nvarchar(256) not null,
   联系电话                 nvarchar(128) not null,
   primary key (编号)
);

/*==============================================================*/
/* Table: 客户联系人                                                 */
/*==============================================================*/
create table 客户联系人
(
   编号                   int not null,
   姓名                   nvarchar(128) not null,
   类型                   nvarchar(32) not null,
   联系电话                 nvarchar(128) not null,
   电子邮件                 nvarchar(32) not null,
   所属客户编号               int not null,
   primary key (编号)
);

/*==============================================================*/
/* Table: 操作记录                                                  */
/*==============================================================*/
create table 操作记录
(
   记录编号                 int not null,
   操作员编号                int,
   操作动作                 nvarchar（128）,
   操作时间                 datetime,
   primary key (记录编号)
);

/*==============================================================*/
/* Table: 生产计划                                                  */
/*==============================================================*/
create table 生产计划
(
   编号                   int not null,
   产品编号                 int,
   客户编号                 int,
   下单日期                 date,
   产品数量                 int,
   交付时间                 date,
   实际完成时间               date,
   计划类型                 nvarchar(128),
   相关订单编号               int,
   负责人                  nvarchar(128),
   primary key (编号)
);

/*==============================================================*/
/* Table: 订单                                                    */
/*==============================================================*/
create table 订单
(
   订单编号                 int not null,
   创建时间                 date,
   发货时间                 date,
   最后更新时间               date,
   订单状态                 nvarchar(128),
   快递单号                 nvarchar(128),
   订金方式                 nvarchar(128),
   收货地址                 nvarchar(128),
   收货联系人                nvarchar(128),
   收货电话                 nvarchar(128),
   创建人                  nvarchar(128),
   primary key (订单编号)
);

/*==============================================================*/
/* Table: 订单明细                                                  */
/*==============================================================*/
create table 订单明细
(
   订单编号                 int not null,
   产品编号                 int not null,
   数量                   int,
   单价                   int,
   折扣                   double,
   成交价                  int,
   是否库存                 bool,
   primary key (订单编号, 产品编号)
);

