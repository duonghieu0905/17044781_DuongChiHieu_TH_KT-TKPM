using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class DoiBong
    {
        [Key]
        public int madoibong { get; set; }
        public string tendoibong { get; set; }
        public virtual List<CauThu> CauThus { get; set; }

    }
}
