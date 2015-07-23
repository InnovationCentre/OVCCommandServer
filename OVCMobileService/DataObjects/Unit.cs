using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OVCMobileService.DataObjects
{
    public class Unit : EntityData
    {
        public String Serial { get; set; }
        public String Name { get; set; }

        [ForeignKey("UnitTypeId")]
        public virtual UnitType Type { get; set; }
        public String UnitTypeId { get; set; }
    }
}