using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course5.ResponseMappers
{
    public class Products2
    {
        public class Rootobject
        {
            public Getproductlistrestresult[] GetProductListRestResult { get; set; }
        }

        public class Getproductlistrestresult
        {
            public string CategoryName { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int ProductId { get; set; }
        }
    }
}
