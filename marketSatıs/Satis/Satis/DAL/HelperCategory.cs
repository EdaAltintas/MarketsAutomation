using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.DAL
{
    public static class HelperCategory
    {
        public static (Category, bool) CUD(Category cg, EntityState state)
        {
            using (SatisEntities se = new SatisEntities())
            {
                se.Entry(cg).State = state;
                if (se.SaveChanges() > 0)
                {
                    return (cg, true);
                }
                else
                {
                    return (cg, false);
                }
            }
        }
        public static List<Category> GetList()
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Category.ToList();
            }
        }
        public static Category GetByID(int categoryId)
        {
            using (SatisEntities se = new SatisEntities())
            {
                return se.Category.Find(categoryId);
            }
        }
        public static List<Category> GetListByCategoryName(string _categoryName)
        {
            using (SatisEntities se = new SatisEntities())
            {
                List<Category> categories = new List<Category>();
                List<Category> categories2 = GetList();
                foreach (var item in categories2)
                {
                    if (item.categoryName.ToLower().Contains(_categoryName.ToLower()))
                    {
                        categories.Add(item);
                    }
                }
                return categories;
            }
        }
        public static bool SearchCategoryName(string _categoryName)
        {
            //category name aynı oluşturmamak için bu metodu oluşturup kullandık
            List<Category> categories = GetList();
            foreach (var item in categories)
            {
                if (item.categoryName.ToLower().Contains(_categoryName.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
