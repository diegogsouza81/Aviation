using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using AviationApp.Authorization;
using AviationApp.Aviation.Airplanes.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AviationApp.Aviation.Airplanes
{
    [AbpAuthorize(PermissionNames.Pages_Airplanes)]
    public class AirplaneAppService : AsyncCrudAppService<Airplane, AirplaneDto, int, PagedAirplaneResultRequestDto, CreateAirplaneDto, AirplaneDto>, IAirplaneAppService
    {
        private readonly IRepository<Airplane, int> _airplaneRepository;
      
        public AirplaneAppService(
            IRepository<Airplane, int> repository,
            IObjectMapper objectMapper
            ) : base(repository)
        {
            _airplaneRepository = repository;
        
        }

        public Task<GetAirplaneForEditOutput> GetAirplaneForEdit(EntityDto input)
        {
            
            var airplane = _airplaneRepository.Get(input.Id);
            
            var airplaneEditDto = ObjectMapper.Map<AirplaneEditDto>(airplane);

            return Task.FromResult(new GetAirplaneForEditOutput
            {
                Airplane = airplaneEditDto
                
            });
        }





    }
}
