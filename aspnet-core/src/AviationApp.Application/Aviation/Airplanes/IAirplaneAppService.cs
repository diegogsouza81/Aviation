using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AviationApp.Aviation.Airplanes.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationApp.Aviation.Airplanes
{
    public interface IAirplaneAppService : IAsyncCrudAppService<AirplaneDto, int, PagedAirplaneResultRequestDto, CreateAirplaneDto, AirplaneDto>
    {
    }
}
