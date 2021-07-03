using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API.Data;
using KhaiBaoYTe_API.Models;

namespace KhaiBaoYTe_API._Repositories.Repositories
{
    public class HuyenRepository : Repository<Huyen>, IHuyenRepository
    {
        private readonly DBContext _context;
        public HuyenRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}