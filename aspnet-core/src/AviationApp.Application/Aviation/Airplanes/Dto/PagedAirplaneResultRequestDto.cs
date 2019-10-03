using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationApp.Aviation.Airplanes.Dto
{
    public class PagedAirplaneResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
