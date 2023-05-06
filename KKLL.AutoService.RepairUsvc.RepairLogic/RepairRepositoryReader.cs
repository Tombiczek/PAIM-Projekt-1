using KKLL.AutoService.RepairUsvc.RepairModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KKLL.AutoService.RepairUsvc.RepairLogic
{
    public class RepairRepositoryReader
    {
        public static IEnumerable<Repair>? ReadRepairs(string filename)
        {
            var result = JsonSerializer.Deserialize<Repair[]>(File.ReadAllText(filename));

            return result;
        }
    }
}
