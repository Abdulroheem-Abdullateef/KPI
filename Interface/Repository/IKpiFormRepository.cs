using KpiNew.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KpiNew.Interface.Repository
{
    public interface IKpiFormRepository : IRepository<KpiForm>
    {
        public Task<KpiForm> GetKpiFormById(int id);
        public Task<KpiForm> Get(Expression<Func<KpiForm, bool>> expression);
        public Task<IList<KpiForm>> GetSelected(IList<int> ids);
        public Task<IList<KpiForm>> GetSelected(Expression<Func<KpiForm, bool>> expression);
        public Task<IList<KpiForm>> GetAll();
    }
}
