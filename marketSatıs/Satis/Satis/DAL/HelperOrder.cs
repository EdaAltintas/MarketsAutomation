using Satis.Entity;
using Satis.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.DAL
{
    public static class HelperOrder
    {
        public static (Order, bool) CUD(Order or, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(or).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (or, true);
                }
                else
                {
                    return (or, false);
                }
            }
        }
        public static List<Order> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Order.ToList();
            }
        }
        public static Order GetByID(int orderID)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Order.Find(orderID);
            }
        }
        public static Order GetByCashierID(int cashierID)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Order.Find(cashierID);
            }
        }
        public static List<OrderModel> GetOrderModelList()
        {
            List<OrderModel> oml = new List<OrderModel>();
            using (SatisEntities se = new SatisEntities())
            {
                var ff = se.OrderDetail.ToList();
                foreach (var item in ff)
                {
                    OrderModel om = new OrderModel();
                    om.orderDetail.orderID = item.orderID;
                    om.product.productID = item.productID;
                    Product pml = HelperProduct.GetByID(item.productID);
                    om.product.productName = pml.productName;
                    om.orderDetail.count = item.count;
                    om.orderDetail.unitPrice = item.unitPrice;
                    om.product.discount = pml.discount;
                    om.totalPrice= (item.unitPrice - (item.unitPrice * (pml.discount / 100.0))) * item.count;
                    om.order.orderDate = item.Order.orderDate;
                    oml.Add(om);
                }
                return oml;
            }
        }
    }
}
