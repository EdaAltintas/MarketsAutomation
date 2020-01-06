using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.Model
{
     public class OrderModel
    {
        //public int orderID { get; set; }
        //public int customerID { get; set; }
        //public int cashierID { get; set; }
        //public System.DateTime orderDate { get; set; }
        public double totalPrice { get; set; }

        //public Cashier Cashier = new Cashier();
        //public Customer Customer = new Customer();
        //public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public OrderDetail orderDetail = new OrderDetail();
        public Order order = new Order();
        //public int orderDetailID { get; set; }
        public Product product = new Product();
        //public int productID { get; set; }
        //public double unitPrice { get; set; }
        //public int count { get; set; }
    }
}
