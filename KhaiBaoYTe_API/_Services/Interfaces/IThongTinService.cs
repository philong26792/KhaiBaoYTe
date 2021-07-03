using System.Collections.Generic;
using System.Threading.Tasks;
using KhaiBaoYTe_API.DTOs;
using KhaiBaoYTe_API.Models;
using SmartTooling_API._Services.Interfaces;

namespace KhaiBaoYTe_API._Services.Interfaces
{
    public interface IThongTinService : IMainService<ThongTin>
    {
         Task<ThongTin> FindByID(string id);
         Task<bool> UpdateTT(ThongTin thongTin);
        
    }
}