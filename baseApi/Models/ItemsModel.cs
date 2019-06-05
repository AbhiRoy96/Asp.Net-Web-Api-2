using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baseApi.Models
{
    public class ItemsModel
    {
        public int ItemId { get; set;  }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public double ItemPrice { get; set; }
        public string Url { get; set; }

        public ItemsModel( int id, string name, string type, double price, string url)
        {
            this.ItemId = id;
            this.ItemName = name;
            this.ItemType = type;
            this.ItemPrice = price;
            this.Url = url;
        }
    }
}