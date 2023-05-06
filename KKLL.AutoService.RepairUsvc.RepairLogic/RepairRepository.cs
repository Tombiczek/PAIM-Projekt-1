using KKLL.AutoService.RepairUsvc.RepairModel;
using KKLL.AutoService.RepairUsvc.RepairModel.Services;

namespace KKLL.AutoService.RepairUsvc.RepairLogic
{
    using System.Collections.Generic;
    using System.Linq;

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

        public void AddNewRepair(Repair newRepair)
        {
            lock (RepoLock)
            {
                RepairRepository.Repairs.Add(newRepair);
            }
        }

        public void DeleteById(int id)
        {
            lock (RepoLock)
            {
                var repairToBeDeleted = Repairs.Find(c => c.Id == id);

                if (repairToBeDeleted != null)
                {
                    RepairRepository.Repairs.Remove(repairToBeDeleted);
                }
            }
        }
    }
}