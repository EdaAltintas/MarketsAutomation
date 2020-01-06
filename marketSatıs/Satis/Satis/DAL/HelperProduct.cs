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
    public static class HelperProduct
    {
        public static (Product, bool) CUD(Product p, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(p).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (p, true);
                }
                else
                {
                    return (p, false);
                }
            }
        }
        public static List<Product> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Product.ToList();
            }
        }
        public static Product GetByID(int productId)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Product.Find(productId);
            }
        }
        public static Category GetByCategoryID(int categoryID)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Category.Find(categoryID);
            }
        }
        public static Supplier GetBySupplierID(int supplierID)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Supplier.Find(supplierID);
            }
        }
        public static List<ProductModel> GetListByCategoryName(string categoryName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<ProductModel> products = new List<ProductModel>();
                List<ProductModel> products2= GetProductModelList();
                foreach (var item in products2)
                {
                    if (item.IsActive==true)
                    {
                        if (item.category.categoryName.ToLower().Contains(categoryName.ToLower()))
                        {
                            products.Add(item);
                        }
                    }
                }
                return products;
            }
        }
        public static List<Product> GetListByProductName(string productName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Product> products = new List<Product>();
                List<Product> products2 = GetList();
                foreach (var item in products2)
                {
                    if (item.productName.ToLower().Contains(productName.ToLower()))
                    {
                        products.Add(item);
                    }
                }
                return products;
            }
        }
        public static List<Product> GetListByProdutID(int productID)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Product> products = new List<Product>();
                List<Product> products2 = GetList();
                foreach (var item in products2)
                {
                    if (item.IsActive==true&&item.productID==productID)
                    {
                        products.Add(item);
                    }
                }
                return products;
            }
        }
        public static List<ProductModel> GetListByProductname(string productName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<ProductModel> products = new List<ProductModel>();
                List<ProductModel> products2 = GetProductModelList();
                foreach (var item in products2)
                {
                    if (item.productName.ToLower().Contains(productName.ToLower()))
                    {
                        products.Add(item);
                    }
                }
                return products;
            }
        }
        public static List<ProductModel> GetListByCompanyName(string companyName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<ProductModel> products = new List<ProductModel>();
                List<ProductModel> products2 = GetProductModelList();
                foreach (var item in products2)
                {
                    if (item.IsActive==true)
                    {
                        if (item.Supplier.companyName.ToLower().Contains(companyName.ToLower()))
                        {
                            products.Add(item);
                        }
                    }
                }
                return products;
            }
        }
        public static List<ProductModel> GetProductModelList()
        {
            List<ProductModel> pml = new List<ProductModel>();
            using (SatisEntities se = new SatisEntities())
            {
                var ff = se.Product.ToList();
                foreach (var item in ff)
                {
                    ProductModel pm = new ProductModel();
                    pm.productID = item.productID;
                    pm.productName = item.productName;
                    pm.unitPrice = item.unitPrice;
                    pm.IsActive = item.IsActive;
                    pm.discount = item.discount;
                    pm.dateOfAdded = item.dateOfAdded;
                    pm.stock = item.stock;
                    if(item.discontinued == false)
                    {
                        pm.stringDiscounted="hayır";
                    }
                    else
                    {
                        pm.stringDiscounted="evet";
                    }
                    pm.category.categoryID = item.Category.categoryID;
                    pm.category.categoryName = item.Category.categoryName;
                    pm.Supplier.supplierID = item.Supplier.supplierID;
                    pm.Supplier.companyName = item.Supplier.companyName;
                    pml.Add(pm);
                }
                return pml;
            }
        }
        public static bool SearchProductName(string _productName)
        {
            //product name aynı oluşturmamak için bu metodu oluşturup kullandık
            List<Product> products = GetList();
            foreach (var item in products)
            {
                if (item.productName.ToLower().Contains(_productName.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
