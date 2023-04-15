namespace Services
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepo
    {
        public Repair[] GetRepairs();
    }
}