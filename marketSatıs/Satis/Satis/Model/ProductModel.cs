using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.Model
{
    public class ProductModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public double unitPrice { get; set; }
        public int discount { get; set; }
        public bool discontinued { 
            get; 
            set; }
        public System.DateTime dateOfAdded { get; set; }
        public bool IsActive { get; set; }

        public Category category = new Category();
        public Supplier Supplier = new Supplier();
        public string stringDiscounted { get; set; }
        public int stock { get; set; }
    }
}
