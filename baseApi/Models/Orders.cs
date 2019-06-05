using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baseApi.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTele { get; set; }
        public int itemId { get; set; }
        public int qty { get; set; }
        public double price { get; set; }
        public double TotalBill { get; set; }

        public Orders (int id, string name, string tele, int itemid, int qty, double price, double totBill)
        {
            this.OrderId = id;
            this.CustomerName = name;
            this.CustomerTele = tele;
            this.itemId = itemid;
            this.qty = qty;
            this.price = price;
            this.TotalBill = totBill;
        }
    }
}