using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKLL.AutoService.RepairUsvc.RepairModel.Services
{
    public interface IRepairRepository
    {
        public Repair[] GetRepairs();
        public Repair[] FindById(int id);
        public Repair[] FindByCarId(string carId);
        public Repair[] FindByClientId(int clientId);
        public Repair[] FindByMechanicId(int mechanicId);

    }
}
