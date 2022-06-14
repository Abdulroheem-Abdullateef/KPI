using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KpiNew.Entities;

namespace KpiNew.Interface.Repository
{
    public interface IKpiRepository : IRepository<Kpi>
    {
        public Task<Kpi> GetKpiById(int id);
        public Task<Kpi> Get(Expression<Func<Kpi, bool>> expression);
        public Task<IList<Kpi>> GetSelected(IList<int> ids);
        public Task<IList<Kpi>> GetSelected(Expression<Func<Kpi, bool>> expression);
        public Task<IList<Kpi>> GetAll();

    }
}