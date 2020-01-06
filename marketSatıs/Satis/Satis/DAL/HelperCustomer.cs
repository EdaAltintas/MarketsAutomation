using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.DAL
{
    public static class HelperCustomer
    {
        public static (Customer, bool) CUD(Customer cm, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(cm).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (cm, true);
                }
                else
                {
                    return (cm, false);
                }
            }
        }
        public static List<Customer> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Customer.ToList();
            }
        }
        public static Customer GetByID(int customerId)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Customer.Find(customerId);
            }
        }
        public static List<Customer> GetListByName(string _name)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Customer> customer = new List<Customer>();
                List<Customer> customer2 = GetList();
                foreach (var item in customer2)
                {
                    if (item.name.ToLower().Contains(_name.ToLower()))
                    {
                        customer.Add(item);
                    }
                }
                return customer;
            }
        }
        public static List<Customer> GetListBySurname(string _surname)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Customer> customer = new List<Customer>();
                List<Customer> customer2 = GetList();
                foreach (var item in customer2)
                {
                    if (item.surname.ToLower().Contains(_surname.ToLower()))
                    {
                        customer.Add(item);
                    }
                }
                return customer;
            }
        }
        public static List<Customer> GetListByTc(string _tc)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Customer> customer = new List<Customer>();
                List<Customer> customer2 = GetList();
                foreach (var item in customer2)
                {
                    if (item.tcNo.ToLower().Contains(_tc.ToLower()))
                    {
                        customer.Add(item);
                    }
                }
                return customer;
            }
        }
    }
}
