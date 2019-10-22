using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course2.Course5
{
    class ApiData
    {
        public const string URL_Rest= "http://localhost";
        
        public const string ServiceName_GetProductsList= "/RestProducts/Service1.svc/GetProductList";
        public const string ServiceName_PostRegister = "/RestProducts/Service1.svc/PostProduct";
        public const string ServiceName_Delete = "/RestProducts/Service1.svc/DeleteProduct";
        public const string ServiceName_PutRegister = "/RestProducts/Service1.svc/PutProduct";
    }
}
