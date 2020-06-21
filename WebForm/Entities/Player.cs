using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Player
    {
        [Key]
        public string macauthu { get; set; }
        public string tencauthu { get; set; }
        public string sodt { get; set; }
        public string email { get; set; }
        public string madoibong { get; set; }
        public virtual Team Team { get; set; }
    }
}
