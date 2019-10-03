using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationApp.Aviation.Airplanes.Dto
{
    [AutoMap(typeof(Airplane))]
    public class AirplaneEditDto : CreationAuditedEntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string Model { get; set; }

        public int NumberPassengers { get; set; }
    }
}
