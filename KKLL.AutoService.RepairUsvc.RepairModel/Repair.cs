﻿namespace KKLL.AutoService.RepairUsvc.RepairModel
{
    public class Repair
    {
        public int Id { get; set; }
        public string CarId { get; set; }
        public int ClientId { get; set; }
        public int MechanicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Repair(int id, string carId, int clientId, int mechanicId, string name, string description, int price)
        {
            Id = id;
            CarId = carId;
            ClientId = clientId;
            MechanicId = mechanicId;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}