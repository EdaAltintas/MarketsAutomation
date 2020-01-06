using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.DAL
{
    public static class HelperCashier
    {
        public static (Cashier, bool) CUD(Cashier c, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(c).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (c, true);
                }
                else
                {
                    return (c, false);
                }
            }
        }
        public static List<Cashier> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Cashier.ToList();
            }
        }
        public static Cashier GetByID(int cashierId)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Cashier.Find(cashierId);
            }
        }
        public static List<Cashier> GetListByName(string _name)
        {
            using (SatisEntities se=new SatisEntities())
            {
                List<Cashier> cashier = new List<Cashier>();
                List<Cashier> cashier2 = GetList();
                foreach (var item in cashier2)
                {
                    if (item.name.ToLower().Contains(_name.ToLower()))
                    {
                        cashier.Add(item);
                    }
                }
                return cashier;
            }
        }
        public static Cashier GetByName(string _userName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Cashier.Where(x => x.userName == _userName).FirstOrDefault();
            }
        }
        public static List<Cashier> GetListBySurname(string _surname)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Cashier> cashier = new List<Cashier>();
                List<Cashier> cashier2 = GetList();
                foreach (var item in cashier2)
                {
                    if (item.surname.ToLower().Contains(_surname.ToLower()))
                    {
                        cashier.Add(item);
                    }
                }
                return cashier;
            }
        }
        public static List<Cashier> GetListByTc(string _tc)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Cashier> cashier = new List<Cashier>();
                List<Cashier> cashier2 = GetList();
                foreach (var item in cashier2)
                {
                    if (item.tcNo.ToLower().Contains(_tc.ToLower()))
                    {
                        cashier.Add(item);
                    }
                }
                return cashier;
            }
        }
        public static List<Cashier> GetListByUserName(string _username)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Cashier> cashier = new List<Cashier>();
                List<Cashier> cashier2 = GetList();
                foreach (var item in cashier2)
                {
                    if (item.userName.ToLower().Contains(_username.ToLower()))
                    {
                        cashier.Add(item);
                    }
                }
                return cashier;
            }
        }
        public static bool SearchUserName(string _userName)
        {
            //user name aynı oluşturmamak için bu metodu oluşturup kullandık
            List<Cashier> cashiers = GetList();
            foreach (var item in cashiers)
            {
                if (item.userName.ToLower()==(_userName.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
