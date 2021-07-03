using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API.Data;
using KhaiBaoYTe_API.Models;

namespace KhaiBaoYTe_API._Repositories.Repositories
{
    public class XaRepository : Repository<Xa>, IXaRepository
    {
        private readonly DBContext _context;
        public XaRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}