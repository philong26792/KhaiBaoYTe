using System.ComponentModel.DataAnnotations;

namespace KhaiBaoYTe_API.Models
{
    public class ThongTin
    {
        public string HoTen { get; set; }
        [Key]
        public string SoThe { get; set; }
        public string SDTCaNhan { get; set; }
        public string SoCMND { get; set; }
        public string TinhThuongTru { get; set; }
        public string HuyenThuongTru { get; set; }
        public string XaThuongTru { get; set; }
        public string SoNhaThuongTru { get; set; }
        public string TinhTamTru { get; set; }
        public string HuyenTamTru { get; set; }
        public string XaTamTru { get; set; }
        public string SoNhaTamTru { get; set; }
        public string HoTenNguoiThan { get; set; }
        public string MQHNguoiThan { get; set; }
        public string SDTNguoiThan { get; set; }
        public string LoaiDT { get; set; }

    }
}