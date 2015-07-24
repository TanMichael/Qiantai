using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTsys.DataObjects;
using QTsys.DAO;
using System.Data;
using QTsys.Common;

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

        public DataTable GetOrderBySerial(string num) { return this.odao.GetOrderBySerial(num); }
       
        public string GetAutoNum() { return this.odao.GetAutoNum(); }

        public DataTable GetAllOrderDetailsBySerial(string key) { return this.odao.GetAllOrderDetailsBySerial(key); }
        public DataTable GetAllOrderDetailsBySerialEx(string key) { return this.odao.GetAllOrderDetailsBySerialEx(key); }
        public DataTable GetAllOrderByState(string key) { return this.odao.GetAllOrderByState(key); }
        public DataTable GetAllOrderByStateAndSerial(string state, string key) { return this.odao.GetAllOrderByStateAndSerial(state, key); }


        public DataTable GetFinishedSampleOrders()
        {
            return this.odao.GetFinishedSampleOrders();
        }

        public DataTable GetOrderByCreator(string userName)
        {
            return this.odao.GetOrderByCreator(userName);
        }

        public DataTable GetAllOrderDetails() { return this.odao.GetAllOrderDetails(); }

        public DataTable GetAllOrdersByTime(DateTime date1, DateTime date2) { return this.odao.GetAllOrdersByTime(date1, date2); }

        public int AddNewOrder(Order order) { return this.odao.AddNewOrder(order); }

        public bool DelOrder(String key) { return this.odao.DelOrder(key); }

        public bool AltOrder(Order order) { return this.odao.AltOrder(order); }

        public bool UpdateOrderStatus(string status, string oId)
        {
            return this.odao.UpdateOrderStatus(status, oId);
        }

        public bool AddNewOrderDetail(OrderDetail order) { return this.odao.AddNewOrderDetail(order); }

        public bool DelOrderDetail(OrderDetail order) { return this.odao.DelOrderDetail(order); }

        public bool AltOrderDetail(OrderDetail order) { return this.odao.AltOrderDetail(order); }

        public DataTable GetAllSells(DateTime startDate, DateTime endDate) { return this.odao.GetAllSells(startDate, endDate); }

        public DataTable GetOrderFinish(String key)//将订单和产品入库情况进行比较，返回一个订单是否完成的比较表格
        { 
            // TODO
            return null;
        }


        public DataTable GetReconciliation(string customerId, DateTime startDate, DateTime endDate)
        {
            return this.odao.GetReconciliation(customerId, startDate, endDate);
        }

        public DataTable GetOrderInProduction()
        {
            return this.odao.GetOrderInProduction();
        }

        public int InsertDeliverRecord(string selectedCustomerId, string customerName, string orderId, List<DeliveryRecords> records)
            //string isSample, string productName, string standard, string texture,
            //int count, double price, double sum, DateTime now, string expressNO, string username)
        {
            int RecordId = this.odao.InsertDeliverRecord(selectedCustomerId, customerName, orderId, DateTime.Now, "", Utils.GetCurrentUsername());
            if (RecordId > 0)
            {
                foreach (DeliveryRecords record in records)
                {
                    record.DeliveryRecordId = RecordId.ToString();
                    this.odao.InsertDeliverRecordDetail(record);
                }

            }
            else
            {
                return -1;
            }
            return RecordId;
        }

        public int GetMaxDeliverID()
        {
            return this.odao.GetMaxDeliverID();
        }
    }
}
