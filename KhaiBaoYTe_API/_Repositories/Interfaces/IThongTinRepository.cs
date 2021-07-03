using System.Threading.Tasks;
using KhaiBaoYTe_API._Repositories.Interface;
using KhaiBaoYTe_API.Models;

namespace KhaiBaoYTe_API._Repositories.Interfaces
{
    public interface IThongTinRepository : IRepository<ThongTin>
    {
         Task<ThongTin> FindBySoThe(string soThe);
    }
}