using KKLL.AutoService.RepairUsvc.RepairModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KKLL.AutoService.RepairUsvc.Rest.Model.Model;

namespace KKLL.AutoService.RepairUsvc.Rest.Model.Converters
{
    // Network = Repo
    // Node = Repair
    public static class DataConverter
    {
        public static RepairDto ConvertToRepairDto(this Repair repair)
        {
            return new RepairDto()
            {
                Id = repair.Id,
                Name = repair.Name
            };
        }
    }
}