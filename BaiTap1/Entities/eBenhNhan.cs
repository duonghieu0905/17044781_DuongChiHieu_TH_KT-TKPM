using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    [Serializable,XmlRoot("eBenhNhan")]
    public class eBenhNhan
    {
        public string MSBN { get; set; }
        public string SOCMND { get; set; }
        public string HOTEN { get; set; }
        public string DIACHI { get; set; }
    }
}
