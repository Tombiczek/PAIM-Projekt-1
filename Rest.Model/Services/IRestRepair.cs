﻿using System;
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
        public RepairDto[] GetDtoByCarId(int carId);
        public RepairDto[] GetDtoByClientId(int clientId);
        public RepairDto[] GetDtoByMechanicId(int mechanicId);
    }
}
