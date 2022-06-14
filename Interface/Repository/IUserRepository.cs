using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KpiNew.Entities;

namespace KpiNew.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetUserById(int id);
        public Task<User> Get(Expression<Func<User, bool>> expression);
        public Task<IList<User>> GetSelected(IList<int> ids);
        public Task<IList<User>> GetSelected(Expression<Func<User, bool>> expression);
        public Task<IList<User>> GetAll();
        public Task<User> GetByEmail(string email);
        public Task<IList<User>> GetAllHod();
    }
}