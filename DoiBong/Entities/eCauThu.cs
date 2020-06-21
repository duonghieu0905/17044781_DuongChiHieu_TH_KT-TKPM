using System.ComponentModel;

namespace Entities
{
    public class eCauThu
    {
        [DisplayName("Mã cầu thủ")]
        public int macauthu { get; set; }
        [DisplayName("Tên cầu thủ")]
        public string tencauthu { get; set; }
        [DisplayName("Số điện thoại")]
        public string sodt { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Mã đội bóng")]
        public int iddoibong { get; set; }
    }
}
