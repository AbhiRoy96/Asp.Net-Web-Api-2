using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using baseApi.Models;
using System.Data;
using System.Data.OleDb;

namespace baseApi.Controllers
{
    public class OrderController : ApiController
    {
        ItemsModel[] items = new ItemsModel[]
            {
                new ItemsModel(1001, "Burrito", "Vegan", 2.56, "https://upload.wikimedia.org/wikipedia/commons/a/ad/Hippie_Kitchen%2C_Jefferson_Highway%2C_Old_Jefferson_Louisiana_Burrito_Unwrapped.jpg"),
                new ItemsModel(1002, "Chicharrón", "Pork", 1.25, "https://upload.wikimedia.org/wikipedia/commons/thumb/2/22/ChicharronMixto.JPG/375px-ChicharronMixto.JPG"),
                new ItemsModel(1003, "Taco", "Vegan, Chicken, Pork, Beef", 1.00, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/001_Tacos_de_carnitas%2C_carne_asada_y_al_pastor.jpg/330px-001_Tacos_de_carnitas%2C_carne_asada_y_al_pastor.jpg"),
                new ItemsModel(1004, "Nachos", "Fried", 0.25,  "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/Goettanachos.jpg/330px-Goettanachos.jpg"),
                new ItemsModel(1005, "Huarache", "Vegan, Beef", 3.00, "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f7/Huarache_de_pollo_en_salsa_roja.JPG/375px-Huarache_de_pollo_en_salsa_roja.JPG")
            };

        public IEnumerable<Orders> GetAllOrders()
        {

            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"E:\\My Documents\\wipro - cc\\Customer.accdb\"";

            conn.Open();

            OleDbCommand objcmd = new OleDbCommand("Select * from CustomerBookings", conn);
            OleDbDataReader reader = objcmd.ExecuteReader();

            List<Orders> orBills = new List<Orders>();


            while (reader.Read())
            {
                orBills.Add(new Orders(int.Parse(reader["OrderId"].ToString()), reader["CustomerName"].ToString(), reader["CustomerTele"].ToString(), int.Parse(reader["ItemId"].ToString()), int.Parse(reader["Qty"].ToString()), double.Parse(reader["Price"].ToString()), double.Parse(reader["TotalPrice"].ToString())));

            }



            conn.Close();
            return orBills;
        }

        public IHttpActionResult Post(int id, int qty)
        {
            


            var food = items.FirstOrDefault((p) => p.ItemId == id);
            if (food == null)
            {
                //HttpResponseMessage errMsg = new HttpResponseMessage(HttpStatusCode.BadRequest);
                //return errMsg;
                return NotFound();
            }
            else
            {
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"E:\\My Documents\\wipro - cc\\Customer.accdb\"";

                conn.Open();

                double totalBills = 0.0;

                OrderList ordList = new OrderList(id, qty, food.ItemPrice);
                List<OrderList> myOrders = new List<OrderList>();
                myOrders.Add(ordList);
                totalBills += (food.ItemPrice + food.ItemPrice * 0.18);

                

                OleDbCommand objcmd = new OleDbCommand("INSERT INTO CustomerBookings(OrderId,CustomerName,CustomerTele, ItemId, Qty, Price, TotalPrice) Values(" + 10001 + ",'" + "Abhishek Roy"  + "','" + "8622030400" + "'," + 1001 + "," + 1 + "," + 5.0 + "," + 5.0 + ")", conn);
                objcmd.ExecuteNonQuery();

                conn.Close();

                //HttpResponseMessage OkMsg = new HttpResponseMessage();
                return Ok(food);
            }
        }

    }
}
