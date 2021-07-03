using System.Linq;
using System.Threading.Tasks;
using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API.Data;
using KhaiBaoYTe_API.Models;
using Microsoft.EntityFrameworkCore;

namespace KhaiBaoYTe_API._Repositories.Repositories
{
    public class ThongTinRepository : Repository<ThongTin>, IThongTinRepository
    {
        private readonly DBContext _context;
        public ThongTinRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ThongTin> FindBySoThe(string soThe)
        {
            return await _context.ThongTin.Where(x => x.SoThe == soThe).FirstOrDefaultAsync();
        }
    }
}