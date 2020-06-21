using System.ComponentModel;

namespace Entities
{
    public class eDoiBong
    {
        [DisplayName("Mã đội bóng")]
        public int madoibong { get; set; }
        [DisplayName("Tên đội bóng")]
        public string tendoibong { get; set; }
    }
}
