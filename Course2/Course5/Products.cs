using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Course5
{
    class Products
    {
        public string CategoryName{ get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ProductId{ get; set; }

        public override bool Equals(object obj)
        {
            var products = obj as Products;
            return products != null &&
                   ProductId == products.ProductId;
        }

        public override int GetHashCode()
        {
            return -661295095 + ProductId.GetHashCode();
        }
    }

}
