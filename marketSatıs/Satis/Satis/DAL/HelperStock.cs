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
    public static class HelperStock
    {
        public static (Stock, bool) CUD(Stock s, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(s).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (s, true);
                }
                else
                {
                    return (s, false);
                }
            }
        }
        public static List<Stock> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Stock.ToList();
            }
        }
        public static Stock GetByID(int stockId)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Stock.Find(stockId);
            }
        }
        public static List<StockModel> GetStockModelList()
        {
            List<StockModel> sml = new List<StockModel>();
            using (SatisEntities se=new SatisEntities())
            {
                var ff = se.Stock.ToList();
                foreach (var item in ff)
                {
                    StockModel sm = new StockModel();
                    sm.stockID = item.stockID;
                    sm.product.productID = item.productID;
                    sm.product.productName = item.Product.productName;
                    sm.count = item.count;
                    sm.dateOfAdded = item.dateOfAdded;
                    sml.Add(sm);
                }
                return sml;
            }
        }
        public static List<StockModel> GetStockModelPartialList(List<Stock> s)
        {
            List<StockModel> sml = new List<StockModel>();
            using (SatisEntities se = new SatisEntities())
            {
                var ff = s;
                foreach (var item in ff)
                {
                    Product p = HelperProduct.GetByID(item.productID);
                    StockModel sm = new StockModel();
                    sm.stockID = item.stockID;
                    sm.product.productID = item.productID;
                    sm.product.productName = p.productName;
                    sm.count = item.count;
                    sm.dateOfAdded = item.dateOfAdded;
                    sml.Add(sm);
                }
                return sml;
            }
        }
        public static int GetTotalStockByProductID(int _productID)
        {
            int stock = 0;
            using (SatisEntities se=new SatisEntities())
            {
                var a = se.Stock.Where(x => x.productID == _productID);
                foreach (var item in a)
                {
                    stock += item.count;
                }
                return stock;
            }
        }

        public static int GetStockByProductID(int productID)
        {
            //kasiyer ekranında stoğu olmayan ürünleri getirmemek için
            int stock = 0;
            using (SatisEntities se = new SatisEntities())
            {
                var a = se.Stock.Where(x => x.productID == productID);
                foreach (var item in a)
                {
                    stock += item.count;
                }
                return stock;
            }
        }
        public static List<StockModel> GetListByProductName(string productName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<StockModel> stock = new List<StockModel>();
                List<StockModel> stock2 = GetStockModelList();
                foreach (var item in stock2)
                {
                    if (item.product.productName.ToLower().Contains(productName.ToLower()))
                    {
                        stock.Add(item);
                    }
                }
                return stock;
            }

        }
        public static List<Stock> GetUniqStock()
        {
            using (SatisEntities se=new SatisEntities())
            {
                var a = se.Stock.GroupBy(x => x.productID).Select(x => x.FirstOrDefault()).ToList();
                return a;
            }
        }
    }
}
