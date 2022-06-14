using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KpiNew.Entities;

namespace KpiNew.Interface.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task<Role> GetRoleById(int id);
        public Task<Role> GetByName(string name);
        public Task<Role> Get(Expression<Func<Role, bool>> expression);
        public Task<IList<Role>> GetSelected(IList<int> ids);
        public Task<IList<Role>> GetSelected(Expression<Func<Role, bool>> expression);
        public Task<IList<Role>> GetAll();

    }
}