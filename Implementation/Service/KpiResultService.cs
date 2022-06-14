using KpiNew.Dtos;
using KpiNew.Entities;
using KpiNew.Enum;
using KpiNew.Interface;
using KpiNew.Interface.Repository;
using KpiNew.Interface.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KpiNew.Implementation.Service
{
    public class KpiResultService : IKpiResultService
    {

        private readonly IKpiResultRepository _kpiResultRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IKpiRepository _kpiRepository;
        private readonly IUserRepository _userRepository;
        private readonly IKpiFormRepository _kpiFormRepository;
        public KpiResultService(IKpiResultRepository kpiResultRepository, IEmployeeRepository employeeRepository,
            IKpiRepository kpiRepository, IUserRepository userRepository, IKpiFormRepository kpiFormRepository)
        {
            _kpiResultRepository = kpiResultRepository;
            _employeeRepository = employeeRepository;
            _kpiRepository = kpiRepository;
            _userRepository = userRepository;
            _kpiFormRepository = kpiFormRepository;
        }

        public async Task<BaseRespond<KpiResultDto>> AddKpiResultAsync(CreateKpiResultRequestModel model)
        { 
             var kpiResultExist = await _kpiResultRepository.Get(a => a.Id == model.Id);

            if (kpiResultExist != null)
            {
                return new BaseRespond<KpiResultDto>
                {
                    Success = false,
                    Message = $"KpiResult with {model.Id} already exist"
                };
            }


            else
            {
                var kpiResult = new KpiResult
                {
                    DateCreated = model.DateCreated,
                    EmployeeId = model.EmployeeId,
                    Month = model.Month,
                    Year = model.Year
                };

                var response = await _kpiResultRepository.Create(kpiResult);
                double totalPercentage = 0;
                foreach(var item in model.KpiForms)
                {
                    var kpiForms = new KpiForm
                    {
                        KpiId = item.KpiId,
                        Percentage = item.Percentage,
                        KpiResultId = kpiResult.Id,


                    };
                    await _kpiFormRepository.Create(kpiForms);
                    totalPercentage += item.Percentage;
                }
                kpiResult.TotalPercentage = totalPercentage;
                await _kpiResultRepository.Update(kpiResult);
                

                return new BaseRespond<KpiResultDto>
                {
                    Success = true,
                    Data = new KpiResultDto
                    {
                        EmployeeId = response.EmployeeId
                    },
                    Message = "KpiResult Created Successfully"
                };

            }

        }

        public async Task<BaseRespond<KpiResultDto>> DeleteKpiResultAsync(int id)
        {
            var kpiResult = await _kpiResultRepository.GetKpiResultById(id);
            if (kpiResult == null)
            {
                return new BaseRespond<KpiResultDto>
                {
                    Success = false,
                    Message = "KpiResult not found",
                };
            }
            kpiResult.IsDeleted = true;
            _kpiResultRepository.SaveChanges();

            return new BaseRespond<KpiResultDto>
            {
                Success = true,
                Message = "KpiResult Delete Successfully"
            };
        }

        public async Task<BaseRespond<ICollection<KpiResultDto>>> GetAllEmployeeKpiResultAsync(int employeeId)
        {
            var employeeKpiId = await _employeeRepository.GetEmployeeById(employeeId);
            if (employeeKpiId == null)
            {
                return new BaseRespond<ICollection<KpiResultDto>>
                {
                    Success = false,
                    Message = " EmployeeKpiId Not Found",
                   
                };

            }


           var employeeKpiResult = await _kpiResultRepository.GetAllEmployeeId(employeeId);

                return new BaseRespond<ICollection<KpiResultDto>>
                {
                    Success = true,
                    Data = employeeKpiResult,
                    Message = "KpiResult Retrived Successfully"
                };

            
        }

        public async Task<BaseRespond<ICollection<KpiResultDto>>> GetAllKpiResultAsync()
        {
            var kpiResult = await _kpiResultRepository.GetAll();
            var kpiResults = kpiResult.Select(a => new KpiResultDto
            {
                DateCreated = a.DateCreated,
                Month = a.Month,
                TotalPercentage = a.TotalPercentage,
                Year = a.Year
            }).ToList();

            return new BaseRespond<ICollection<KpiResultDto>>
            {
                Success = true,
                Data = kpiResults,
                Message = "Employee Retrieved"
            };

        }

        public async Task<BaseRespond<KpiResultDto>> GetEmployeeKpiResultByMonthAsync(int employeeId, Month month)
        {
            var employeeMonth = await _kpiResultRepository.GetEmployeeKpiResultByMonth(employeeId, month);
            return new BaseRespond<KpiResultDto>
            {
                Success = true,
                Message = "Success",
                Data = employeeMonth
            };


        }

        public async Task<BaseRespond<KpiResultDto>> GetEmployeeKpiResultByYearAsync(int employeeId, int year)
        {
            var employeeYear = await _kpiResultRepository.GetEmployeeKpiResultByYear(employeeId, year);
            return new BaseRespond<KpiResultDto>
            {
                Success = true,
                Message = "Success",
                Data = employeeYear
            };
        }

        public async Task<BaseRespond<KpiResultDto>> GetKpiResultByIdAsync(int id)
        {
            var kpiResult = await _kpiResultRepository.GetKpiResultById(id);
            if (kpiResult == null)
            {
                return new BaseRespond<KpiResultDto>
                {
                    Success = false,
                    Message = $"KpiResult Not Found"
                };
            }

            else
            {
                return new BaseRespond<KpiResultDto>
                {
                    Success = true,
                    Data = new KpiResultDto
                    {
                        DateCreated = kpiResult.DateCreated,
                        Month = kpiResult.Month,
                        TotalPercentage = kpiResult.TotalPercentage,
                        Year = kpiResult.Year,
                    }
                };
            }
            
        }

        public async Task<BaseRespond<KpiResultDto>> UpdateKpiResultAsync(int id, UpdateKpiResultRequestModel model)
        {
            var kpiResult = await _kpiResultRepository.GetKpiResultById(id);

            if (kpiResult == null)
            {
                return new BaseRespond<KpiResultDto>
                {
                    Success = false,
                    Message = $" Employee was not found",
                };

            }

            else
            {
                kpiResult.DateCreated = model.DateCreated;
                kpiResult.Month = model.Month;
                kpiResult.TotalPercentage = model.TotalPercentage;
                kpiResult.Year = model.Year;
               


                await _kpiResultRepository.Update(kpiResult);
                return new BaseRespond<KpiResultDto>
                {
                    Success = true,
                    Message = "Kpiresult Update Successfully",
                    Data = new KpiResultDto
                    {
                        DateCreated = kpiResult.DateCreated,
                        Month = kpiResult.Month,
                        TotalPercentage = kpiResult.TotalPercentage,
                        Year = kpiResult.Year


                    }
                };


            }
        }
    }
}
