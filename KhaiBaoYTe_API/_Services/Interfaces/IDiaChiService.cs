using System.Collections.Generic;
using System.Threading.Tasks;
using KhaiBaoYTe_API.DTOs;
using KhaiBaoYTe_API.Models;

namespace KhaiBaoYTe_API._Services.Interfaces
{
    public interface IDiaChiService
    {
        Task<List<Tinh>> DanhSachTinh();
        Task<List<Huyen>> DanhSachHuyenTheoTinh(string MaTP);
        Task<List<Xa>> DanhSachXaTheoHuyen(string MaQH);
        Task<List<Mqh>> DanhSachMqh();
        Task<List<ThongTinExcelDto>> XuatExcel();
        Task<Employee> GetInfoUser(string sothe);
    }
}