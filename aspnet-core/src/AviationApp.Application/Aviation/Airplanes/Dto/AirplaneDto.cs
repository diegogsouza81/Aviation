using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AviationApp.Aviation.Airplanes.Dto
{
    [AutoMap(typeof(Airplane))]
    public class AirplaneDto : CreationAuditedEntityDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }

        public int NumberPassengers { get; set; }
    }
}
