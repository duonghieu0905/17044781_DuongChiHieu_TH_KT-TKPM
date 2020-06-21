using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class CauThu
    {
        [Key]
        public int macauthu { get; set; }
        public string tencauthu { get; set; }
        public string sodt { get; set; }
        public string email { get; set; }
        [ForeignKey("DoiBong")]
        public int iddoibong { get; set; }
        public virtual DoiBong DoiBong { get; set; }
    }
}
