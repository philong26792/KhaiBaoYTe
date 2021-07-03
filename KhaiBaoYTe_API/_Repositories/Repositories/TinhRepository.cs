using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API.Data;
using KhaiBaoYTe_API.Models;

namespace KhaiBaoYTe_API._Repositories.Repositories
{
    public class TinhRepository : Repository<Tinh>, ITinhRepository
    {
        private readonly DBContext _context;
        public TinhRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}