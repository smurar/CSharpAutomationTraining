using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Course2.Course5
{
   // [XmlRoot("Add", Namespace = "http://tempuri.org/")]
    public class XMLValues
    {
        

        [XmlElement(Namespace = "http://tempuri.org/")]
        public string val1 ;

        [XmlElement(Namespace = "http://tempuri.org/")]
        public string val2 ;

    }
}
