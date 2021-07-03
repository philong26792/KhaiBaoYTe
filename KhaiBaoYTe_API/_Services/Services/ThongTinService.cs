using System.Collections.Generic;
using System.Threading.Tasks;
using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API._Services.Interfaces;
using KhaiBaoYTe_API.DTOs;
using KhaiBaoYTe_API.Helpers;
using KhaiBaoYTe_API.Models;
using Microsoft.EntityFrameworkCore;
using SmartTooling_API._Services.Interfaces;

namespace KhaiBaoYTe_API._Services.Services
{
    public class ThongTinService : IThongTinService
    {
        private readonly IThongTinRepository _thongTinRepo;
        public ThongTinService(IThongTinRepository thongTinRepo)
        {
            _thongTinRepo = thongTinRepo;
        }
        public async Task<bool> Add(ThongTin model)
        {
            _thongTinRepo.Add(model);

            return await _thongTinRepo.Save();
        }

        public async Task<bool> UpdateTT(ThongTin thongTin)
        {
            _thongTinRepo.Update(thongTin);

            return await _thongTinRepo.Save();
        }

        public Task<bool> Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ThongTin> FindByID(string id)
        {
            return await _thongTinRepo.FindBySoThe(id);
        }


        public Task<bool> Update(ThongTin model)
        {
            throw new System.NotImplementedException();
        }

        Task<List<ThongTin>> IMainService<ThongTin>.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<PagedList<ThongTin>> IMainService<ThongTin>.GetWithPaginations(PaginationParams param)
        {
            throw new System.NotImplementedException();
        }

        Task<PagedList<ThongTin>> IMainService<ThongTin>.Search(PaginationParams param, object text)
        {
            throw new System.NotImplementedException();
        }

        ThongTin IMainService<ThongTin>.GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        
    }
}