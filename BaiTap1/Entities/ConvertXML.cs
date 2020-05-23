using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class ConvertXML<T>
    {
        public string O2XML(T bn)
        {
            string xml = "";
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream ms= new MemoryStream())
            {
                ser.Serialize(ms, bn);
                ms.Position = 0;
                xml = new StreamReader(ms).ReadToEnd();
                return xml;
            }
        }
        public T XML2O(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader reader= new StringReader(xml))
            {
                return (T)ser.Deserialize(reader);
                
            }
        }
    }
}
