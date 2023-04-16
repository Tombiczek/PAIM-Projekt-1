using Model;
using Model.Services;

namespace Logic
{
    using Logic;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection;

    // Network = Repo
    // Node = Repair

    public class Repo : IRepo
    {
        private static readonly List<Repair> Repairs;

        private static readonly object RepoLock = new();

        static Repo()
        {
            Repairs = new List<Repair>(RepoReader.ReadRepairs("ListOfRepairs.json"));
        }

        public Repair[] FindById(int id)
        {
            lock (RepoLock)
            {
                IList<Repair> foundRepairs = Repairs.Where(c => c.Id == id).ToList();
                return foundRepairs.ToArray();
            }
        }

        public Repair[] FindByCarId(int carId)
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