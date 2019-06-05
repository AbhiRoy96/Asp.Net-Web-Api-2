using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baseApi.Models
{
    public class OrderList
    {
        public int ItemId { get; set; }
        public int ItemQty { get; set; }
        public double ItemPrice { get; set; }

        public OrderList(int id, int qty, double price)
        {
            this.ItemId = id;
            this.ItemQty = qty;
            this.ItemPrice = price;
        }
    }  
}