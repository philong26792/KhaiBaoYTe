using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API._Repositories.Repositories;
using KhaiBaoYTe_API._Services.Interfaces;
using KhaiBaoYTe_API.DTOs;
using KhaiBaoYTe_API.Helpers;
using KhaiBaoYTe_API.Models;
using Microsoft.EntityFrameworkCore;
using SmartTooling_API._Services.Interfaces;

namespace KhaiBaoYTe_API._Services.Services
{
    public class DiaChiService : IDiaChiService
    {
        private readonly ITinhRepository _tinhRepo;
        private readonly IHuyenRepository _huyenRepo;
        private readonly IXaRepository _xaRepo;
        private readonly IMqhRepository _mqhRepo;
        private readonly IThongTinRepository _thongTinRepo;
        private readonly IEmployeeRepository _employeeRepo;
        public DiaChiService(ITinhRepository tinhRepo, 
                            IHuyenRepository huyenRepo, 
                            IXaRepository xaRepo, 
                            IMqhRepository mqhRepo,
                            IThongTinRepository thongTinRepo,
                            IEmployeeRepository employeeRepo)
        {
            _tinhRepo = tinhRepo;
            _huyenRepo = huyenRepo;
            _xaRepo = xaRepo;
            _mqhRepo = mqhRepo;
            _thongTinRepo = thongTinRepo;
            _employeeRepo = employeeRepo;
        }
        public async Task<List<Tinh>> DanhSachTinh()
        {
            return await _tinhRepo.FindAll().ToListAsync();
        }

        public async Task<List<Huyen>> DanhSachHuyenTheoTinh(string MaTP) 
        {
            return await _huyenRepo.FindAll(x => x.MaTP == MaTP).ToListAsync();
        }

        public async Task<List<Xa>> DanhSachXaTheoHuyen(string MaQH)
        {
            return await _xaRepo.FindAll(x => x.MaQH == MaQH).ToListAsync();
        }

        public async Task<List<Mqh>> DanhSachMqh()
        {
            return await _mqhRepo.FindAll().ToListAsync();
        }

        public async Task<List<ThongTinExcelDto>> XuatExcel()
        {
            var dataAll = await _thongTinRepo.FindAll().ToListAsync();
            var result = new List<ThongTinExcelDto>();
            var count = 0;
            var tinhList = _tinhRepo.FindAll();
            var huyenList  =  _huyenRepo.FindAll();
            var xaList = _xaRepo.FindAll();
            foreach (var item in dataAll)
            {
                count ++;
                var thongtinExcelItem = new ThongTinExcelDto();
                thongtinExcelItem.STT = count;
                thongtinExcelItem.SoThe =  item.SoThe.Trim();
                thongtinExcelItem.HoTen = item.HoTen.Trim();
                thongtinExcelItem.SoCMND = item.SoCMND.Trim();
                thongtinExcelItem.LoaiDT = item.LoaiDT.Trim();
                thongtinExcelItem.SDTCaNhan = item.SDTCaNhan.Trim();
                thongtinExcelItem.NguoiThan = item.MQHNguoiThan.Trim();
                thongtinExcelItem.HoTenNguoiThan = item.HoTenNguoiThan.Trim();
                thongtinExcelItem.SDTNguoiThan = item.SDTNguoiThan.Trim();

                thongtinExcelItem.TinhThuongTru = await tinhList.Where(x => x.Ma.Trim() == item.TinhThuongTru.Trim()).Select(x => x.Ten.Trim()).FirstOrDefaultAsync();
                thongtinExcelItem.HuyenThuongTru = await huyenList.Where(x => x.Ma.Trim() == item.HuyenThuongTru.Trim()).Select(x => x.Ten.Trim()).FirstOrDefaultAsync();
                thongtinExcelItem.XaThuongTru = await xaList.Where(x => x.Ma.Trim() == item.XaThuongTru.Trim()).Select(x => x.Ten.Trim()).FirstOrDefaultAsync();
                thongtinExcelItem.SoNhaThuongTru = item.SoNhaThuongTru;

                thongtinExcelItem.TinhTamTru = await tinhList.Where(x => x.Ma.Trim() == item.TinhTamTru.Trim()).Select(x => x.Ten.Trim()).FirstOrDefaultAsync();
                thongtinExcelItem.HuyenTamTru = await huyenList.Where(x => x.Ma.Trim() == item.HuyenTamTru.Trim()).Select(x => x.Ten.Trim()).FirstOrDefaultAsync();
                thongtinExcelItem.XaTamTru = await xaList.Where(x => x.Ma.Trim() == item.XaTamTru.Trim()).Select(x => x.Ten.Trim()).FirstOrDefaultAsync();
                thongtinExcelItem.SoNhaTamTru = item.SoNhaTamTru;
                
                result.Add(thongtinExcelItem);
            }
            return result;
        }

        public async Task<Employee> GetInfoUser(string sothe)
        {
            return await _employeeRepo.FindAll(x => x.EmpNumber.Trim() == sothe.Trim()).FirstOrDefaultAsync();
        }
    }
}