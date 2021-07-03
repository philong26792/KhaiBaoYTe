using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API.Data;
using KhaiBaoYTe_API.Models;

namespace KhaiBaoYTe_API._Repositories.Repositories
{
    public class MqhRepository : Repository<Mqh>, IMqhRepository
    {
        private readonly DBContext _context;
        public MqhRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}