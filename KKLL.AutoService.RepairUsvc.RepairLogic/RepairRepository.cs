using KKLL.AutoService.RepairUsvc.RepairModel;
using KKLL.AutoService.RepairUsvc.RepairModel.Services;

namespace KKLL.AutoService.RepairUsvc.RepairLogic
{
    using RepairLogic;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection;

    // Network = RepairRepository
    // Node = Repair

    public class RepairRepository : IRepairRepository
    {
        private static readonly List<Repair> Repairs;

        private static readonly object RepoLock = new();

        static RepairRepository()
        {
            Repairs = new List<Repair>(RepairRepositoryReader.ReadRepairs("ListOfRepairs.json"));
        }

        public Repair[] FindById(int id)
        {
            lock (RepoLock)
            {
                IList<Repair> foundRepairs = Repairs.Where(c => c.Id == id).ToList();
                return foundRepairs.ToArray();
            }
        }

        public Repair[] FindByCarId(string carId)
        {
            lock (RepoLock)
            {
                IList<Repair> foundRepairs = Repairs.Where(c => c.CarId == carId).ToList();
                return foundRepairs.ToArray();
            }
        }
        
        public Repair[] FindByClientId(int clientId)
        {
            lock (RepoLock)
            {
                IList<Repair> foundRepairs = Repairs.Where(c => c.ClientId == clientId).ToList();
                return foundRepairs.ToArray();
            }
        }
        
        public Repair[] FindByMechanicId(int mechanicId)
        {
            lock (RepoLock)
            {
                IList<Repair> foundRepairs = Repairs.Where(c => c.MechanicId == mechanicId).ToList();
                return foundRepairs.ToArray();
            }
        }

        public Repair[] GetRepairs()
        {
            lock(RepoLock)
            {
                return Repairs.ToArray();
            }
        }
    }
}