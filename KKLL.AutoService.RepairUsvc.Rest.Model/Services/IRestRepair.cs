using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKLL.AutoService.RepairUsvc.RepairModel;
using KKLL.AutoService.RepairUsvc.Rest.Model.Model;

namespace KKLL.AutoService.RepairUsvc.Rest.Model.Services
{
    public interface IRestRepair
    {
        public RepairDto[] GetDtoRepairs();
        public RepairDto[] GetDtoById(int id);
        public RepairDto[] GetDtoByCarId(string carId);
        public RepairDto[] GetDtoByClientId(int clientId);
        public RepairDto[] GetDtoByMechanicId(int mechanicId);
        public void AddNewDtoRepair(Repair newRepair);
        public void DeleteDtoById(int id);
    }
}
