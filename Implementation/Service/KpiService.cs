using KpiNew.Dtos;
using KpiNew.Entities;
using KpiNew.Interface;
using KpiNew.Interface.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KpiNew.Implementation.Service
{
    public class KpiService : IKpiService
    {

        private readonly IKpiRepository _kpiRepository;
         private readonly IDepartmentRepository _departmentRepository;
         

        public KpiService(IKpiRepository kpiRepository, IDepartmentRepository departmentRepository)
        {
            _kpiRepository = kpiRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<BaseRespond<KpiDto>> AddKpiAsync(CreateKpiRequestModel model)
        {
            var kpiExist = await _kpiRepository.Get(a => a.Name == model.Name);
            if (kpiExist != null)
            {
                return new BaseRespond<KpiDto>
                {
                    Message = $"Kpi with {model.Name} already exist",
                    Success = false,
                };
            }

                var kpi = new Kpi
                {
                    Name = model.Name,
                    Description = model.Description,
                    DepartmentId = model.DepartmentId,
                    
                };

            

                var Kpi = await _kpiRepository.Create(kpi);
                return new BaseRespond<KpiDto>
                {
                    Success = true,
                    Message = "Kpi Create Successfully",
                    Data = new KpiDto
                    {
                        Name = kpi.Name,
                        Description = kpi.Description,
                       
                        

                    }
                };
            

        }

        public async Task<BaseRespond<KpiDto>> DeleteKpiAsync(int id)
        {
            var kpi = await _kpiRepository.GetKpiById(id);
            if (kpi == null)
            {
                return new BaseRespond<KpiDto>
                {
                    Message = "Kpi not found",
                    Success = false,
                };
            }
                kpi.IsDeleted = true;
                _kpiRepository.SaveChanges();

                return new BaseRespond<KpiDto>
                {
                    Success = true,
                    Message = $"Kpi With {kpi.Name} was delete successfully"
                };
            
        }

        public async Task<BaseRespond<ICollection<KpiDto>>> GetAllKpiAsync()
        {
             var kpi = await _kpiRepository.GetAll();
            var kpis = kpi.Select(a => new KpiDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
               
            }).ToList();
            
            return new BaseRespond<ICollection<KpiDto>>
            {
                Success = true,
                Data = kpis,
                Message = "kpi Retrieved"
            };

        }

        public async Task<BaseRespond<ICollection<KpiDto>>> GetAllKpiByDepartmentIdAsync(int departmentId)
        {
            var department = await _kpiRepository.GetSelected(a => a.Department.Id == departmentId);
            var departments = department.Select(a => new KpiDto
            {
                Id = a.Id,
                Description = a.Description,
                Name = a.Name

            }).ToList();

            return new BaseRespond<ICollection<KpiDto>>
            {
                Success = true,
                Data = departments,
                Message = "Department Retrived successfully",
            };
           
        }

        public async Task<BaseRespond<KpiDto>> GetKpiByIdAsync(int id)
        {
            var kpi = await _kpiRepository.GetKpiById(id);
            if(kpi == null)
            {
                return new BaseRespond<KpiDto>
                {
                    Message = "Kpi does not exist ",
                    Success = false,
                };
            };
            
            return new BaseRespond<KpiDto>
            {
                Success = true,
                Data = new KpiDto
                {
                    Name = kpi.Name,
                    Description = kpi.Description,
                    
                },

                Message = "kpi Retrieved"
            };

        }

        public async Task<BaseRespond<KpiDto>> UpdateKpiAsync(int id, UpdateKpiRequestModel model)
        {
             var kpi = await _kpiRepository.GetKpiById(id);
            if (kpi == null)
            {
                return new BaseRespond<KpiDto>
                {
                    Message = $"Kpi does not exixt",
                    Success = false,
                };
            }
            else
            {
                kpi.Name = model.Name;
                kpi.Description = model.Description;
                await _kpiRepository.Update(kpi);

                return new BaseRespond<KpiDto>
                {
                    Success = true,
                    Message = $"{kpi.Name} Successfully Updated",
                    Data = new KpiDto
                    {
                        Name = kpi.Name,
                        Description = kpi.Description,
                    },
                };
            }
        }
    }
}