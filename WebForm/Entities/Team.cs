using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Team
    {
        [Key]
        public string madoibong { get; set; }
        public string tendoibong { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
