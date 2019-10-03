using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationApp.Aviation
{
    
    public class Airplane : CreationAuditedEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }

        public int NumberPassengers { get; set; }

        public void SetNormalizedName()
        {
            throw new NotImplementedException();
        }
    }
}
