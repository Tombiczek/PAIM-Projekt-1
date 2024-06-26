﻿using System;
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
        public Repair[] FindByPlate(string plate);
        public Repair[] FindByClientId(int clientId);
        public Repair[] FindByMechanicId(int mechanicId);
        public void AddNewRepair(Repair newRepair);
        public void DeleteById(int id);

    }
}
