using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rest.Model.Model;

namespace Rest.Model.Services
{
    public interface IRestRepair
    {
        public RepairDto[] GetDtoRepairs();
        public RepairDto[] GetDtoById(int id);
    }
}
