using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public interface IRepo
    {
        public Repair[] GetRepairs();
        public Repair[] FindById(int id);
        public Repair[] FindByCarId(int carId);
        public Repair[] FindByClientId(int clientId);
        public Repair[] FindByMechanicId(int mechanicId);

    }
}
