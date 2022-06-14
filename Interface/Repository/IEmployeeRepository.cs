using KpiNew.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KpiNew.Interface.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<Employee> GetEmployeeById(int id);
        public Task<Employee> Get(Expression<Func<Employee, bool>> expression);
        public Task<IList<Employee>> GetAll();
        //public Task<IList<Employee>> GetSelected(IList<int> ids);
        public Task<IList<Employee>> GetSelected(Expression<Func<Employee, bool>> expression);
        public Task<ICollection<Employee>> GetAllEmployeeDepartmentByNameAsync( string departmentName);
        public Task<ICollection<Employee>> GetAllHodAsync();   
    }
}