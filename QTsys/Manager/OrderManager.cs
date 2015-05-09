﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTsys.DataObjects;
using QTsys.DAO;
using System.Data;

namespace QTsys.Manager
{
    class OrderManager
    {
        private OrderDAO odao;

        public OrderManager()
        {
            this.odao = new OrderDAO();
        }

        public static OrderManager getOrderManager()
        {
            return new OrderManager();
        }
        //-------------------------------------------------------------------------------------------------------------
        public DataTable GetAllOrders() { return this.odao.GetAllOrders(); }

        public string GetAutoNum() { return this.odao.GetAutoNum(); }

        public DataTable GetAllOrderDetailsBySerial(string key) { return this.odao.GetAllOrderDetailsBySerial(key); }
        public DataTable GetAllOrderByState(string key) { return this.odao.GetAllOrderByState(key); }

        public DataTable GetOrderByCreator(string userName)
        {
            return this.odao.GetOrderByCreator(userName);
        }

        public DataTable GetAllOrderDetails() { return this.odao.GetAllOrderDetails(); }

        public DataTable GetAllOrdersByTime(DateTime date1, DateTime date2) { return this.odao.GetAllOrdersByTime(date1, date2); }

        public int AddNewOrder(Order order) { return this.odao.AddNewOrder(order); }

        public bool DelOrder(String key) { return this.odao.DelOrder(key); }

        public bool AltOrder(Order order) { return this.odao.AltOrder(order); }

        public bool AddNewOrderDetail(OrderDetail order) { return this.odao.AddNewOrderDetail(order); }

        public bool DelOrderDetail(OrderDetail order) { return this.odao.DelOrderDetail(order); }

        public bool AltOrderDetail(OrderDetail order) { return this.odao.AltOrderDetail(order); }

        public DataTable GetAllSells() { return this.odao.GetAllSells(); }
    }
}
