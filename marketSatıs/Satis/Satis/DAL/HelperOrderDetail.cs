using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.DAL
{
    public static class HelperOrderDetail
    {
        public static (OrderDetail, bool) CUD(OrderDetail ord, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(ord).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (ord, true);
                }
                else
                {
                    return (ord, false);
                }
            }
        }
        public static List<OrderDetail> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.OrderDetail.ToList();
            }
        }
        public static OrderDetail GetByID(int orderID)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.OrderDetail.Find(orderID);
            }
        }
        public static List<OrderDetail> GetListByOrderID(int orderID)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                List<OrderDetail> orderDetails2 = GetList();
                foreach (var item in orderDetails2)
                {
                    if (item.orderID == orderID)
                    {
                        orderDetails.Add(item);
                    }
                }
                return orderDetails;
            }
        }
    }
}
