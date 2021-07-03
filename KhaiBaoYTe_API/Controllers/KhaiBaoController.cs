using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Cells;
using KhaiBaoYTe_API._Services.Interfaces;
using KhaiBaoYTe_API._Services.Services;
using KhaiBaoYTe_API.DTOs;
using KhaiBaoYTe_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace KhaiBaoYTe_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhaiBaoController : ControllerBase
    {
        private readonly IDiaChiService _diaChiService;
        private readonly IThongTinService _thongTinService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public KhaiBaoController(IDiaChiService diaChiService, IThongTinService thongTinService, IWebHostEnvironment webHostEnvironment)
        {
            _diaChiService = diaChiService;
            _thongTinService = thongTinService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("DanhSachTinh",Name = "DanhSachTinh")]
        public async Task<IActionResult> DanhSachTinh()
        {
            var dsTinh = await _diaChiService.DanhSachTinh();
            return Ok(dsTinh);
        }

        [HttpGet("DanhSachHuyenTheoTinh/{MaTP}",Name = "DanhSachHuyenTheoTinh")]
        public async Task<IActionResult> DanhSachHuyenTheoTinh(string MaTP)
        {
            var dsHuyen = await _diaChiService.DanhSachHuyenTheoTinh(MaTP);
            return Ok(dsHuyen);
        }

        [HttpGet("DanhSachXaTheoHuyen/{MaQH}",Name = "DanhSachXaTheoHuyen")]
        public async Task<IActionResult> DanhSachXaTheoHuyen(string MaQH)
        {
            var dsXa = await _diaChiService.DanhSachXaTheoHuyen(MaQH);
            return Ok(dsXa);
        }

        [HttpGet("DanhSachMqh",Name = "DanhSachMqh")]
        public async Task<IActionResult> DanhSachMqh() {
            var dsMqh = await _diaChiService.DanhSachMqh();
            return Ok(dsMqh);
        }

        [HttpGet("ThongTinNLD/{SoThe}",Name = "ThongTinNLD")]
        public async Task<IActionResult> ThongTinNLD(string SoThe) {
            var thongTin = await _thongTinService.FindByID(SoThe);
            return Ok(thongTin);
        }
        
        [HttpPost("ThemThongTin")]
        public async Task<IActionResult> ThemThongTin(ThongTin thongTin)
        {
            var model = await _thongTinService.FindByID(thongTin.SoThe);
            var flag = true;
            if (model != null) {
                model.HoTen = thongTin.HoTen;
                model.SDTCaNhan = thongTin.SDTCaNhan;
                model.SoCMND = thongTin.SoCMND;
                model.TinhThuongTru = thongTin.TinhThuongTru;
                model.HuyenThuongTru = thongTin.HuyenThuongTru;
                model.XaThuongTru = thongTin.XaThuongTru;
                model.SoNhaThuongTru = thongTin.SoNhaThuongTru;
                model.TinhTamTru = thongTin.TinhTamTru;
                model.HuyenTamTru = thongTin.HuyenTamTru;
                model.XaTamTru = thongTin.XaTamTru;
                model.SoNhaTamTru = thongTin.SoNhaTamTru;
                model.HoTenNguoiThan = thongTin.HoTenNguoiThan;
                model.MQHNguoiThan = thongTin.MQHNguoiThan;
                model.SDTNguoiThan = thongTin.SDTNguoiThan;
                model.LoaiDT = thongTin.LoaiDT;
                flag = await _thongTinService.UpdateTT(model);
            }
            else 
                flag = await _thongTinService.Add(thongTin);
            
            if (flag)
            {
                return NoContent();
                // return CreatedAtRoute("GetDefectReasons", new { });
            }

            throw new Exception("Có lỗi xảy ra!");
        }

        [HttpGet("XuatExcel")]
        public async Task<IActionResult> XuatExcel() {
            var data = await _diaChiService.XuatExcel();
            var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources\\Template\\OutcomingData.xlsx");
            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Workbook = new Workbook(path);
            Worksheet ws = designer.Workbook.Worksheets[0];

            designer.SetDataSource("result", data);
            designer.Process();

            MemoryStream stream = new MemoryStream();
            designer.Workbook.Save(stream, SaveFormat.Xlsx);

            byte[] result = stream.ToArray();

            return File(result, "application/xlsx", "KhaiBaoYTe-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xlsx");
        }

        [HttpGet("GetInfoUser/{sothe}", Name = "GetInfoUser")]
        public async Task<IActionResult> GetInfoUser(string sothe) {
            var data = await _diaChiService.GetInfoUser(sothe);
            return Ok(data);
        }
    }
}