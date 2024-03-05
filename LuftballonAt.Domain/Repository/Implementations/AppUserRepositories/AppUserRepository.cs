using LuftballonAt.Data;
using LuftballonAt.Domain.Repository.Contracts.AppUserRepositories;
using LuftballonAt.Web.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Implementations.AppUserRepositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly ApplicationDbContext _db;
        public AppUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
