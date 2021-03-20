using ImmortalFighters.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImmortalFighters.WebApp.Repositories
{
    public interface IRoleRepository
    {
        ICollection<Role> GetAll();
    }

    public class RoleRepository : IRoleRepository
    {
        private readonly IfDbContext _context;

        public RoleRepository(IfDbContext context)
        {
            _context = context;
        }

        public ICollection<Role> GetAll()
        {
            return _context.Roles.ToList();
        }
    }
}
