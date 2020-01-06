using Satis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satis.Model
{
    public class StockModel
    {
        public Product product = new Product();
        public int stockID { get; set; }
        public int count { get; set; }
        public System.DateTime dateOfAdded { get; set; }
    }
}
