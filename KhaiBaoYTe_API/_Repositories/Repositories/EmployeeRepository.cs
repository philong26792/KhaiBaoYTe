using KhaiBaoYTe_API.Models;
using KhaiBaoYTe_API._Repositories.Interfaces;
using KhaiBaoYTe_API.Data;

namespace KhaiBaoYTe_API._Repositories.Repositories
{
    public class EmployeeRepository :  UserRepository<Employee>, IEmployeeRepository
    {
        private readonly UserContext _context;
        public EmployeeRepository(UserContext context) : base(context)
        {
            _context = context;
        }
    }
}