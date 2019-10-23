using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutoTraining.Course5.ResponseMappers
{
    public class ProductListResults
    {
        [JsonProperty("GetProductListRestResult")]
        public List<Products> GetProductListRestResults { get; set; }       

    }
}
