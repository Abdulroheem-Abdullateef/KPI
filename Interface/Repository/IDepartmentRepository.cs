using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KpiNew.Entities;

namespace KpiNew.Interface.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<Department> Get(Expression<Func<Department, bool>> expression);
        //public Task<IList<Department>> GetSelected(IList<int> ids);
        public Task<IList<Department>> GetSelected(Expression<Func<Department, bool>> expression);
        public Task<IList<Department>> GetAll();

    }
}