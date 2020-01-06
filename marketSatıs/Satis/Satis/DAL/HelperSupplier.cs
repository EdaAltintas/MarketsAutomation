using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.DAL
{
   public static class HelperSupplier
    {
        public static (Supplier, bool) CUD(Supplier sp, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(sp).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (sp, true);
                }
                else
                {
                    return (sp, false);
                }
            }
        }
        public static List<Supplier> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Supplier.ToList();
            }
        }
        public static Supplier GetByID(int supplierId)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Supplier.Find(supplierId);
            }
        }
        public static List<Supplier> GetListBySuppliernamesurname(string _nameSurname)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Supplier> supplier = new List<Supplier>();
                List<Supplier> supplier2 = GetList();
                foreach (var item in supplier2)
                {
                    if (item.supplierNameSurname.ToLower().Contains(_nameSurname.ToLower()))
                    {
                        supplier.Add(item);
                    }
                }
                return supplier;
            }
        }
        public static List<Supplier> GetListByCompanyName(string _companyName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Supplier> supplier = new List<Supplier>();
                List<Supplier> supplier2 = GetList();
                foreach (var item in supplier2)
                {
                    if (item.companyName.ToLower().Contains(_companyName.ToLower()))
                    {
                        supplier.Add(item);
                    }
                }
                return supplier;
            }
        }
    }
}
