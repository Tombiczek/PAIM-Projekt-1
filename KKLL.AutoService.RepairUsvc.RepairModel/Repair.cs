namespace KKLL.AutoService.RepairUsvc.RepairModel
{
    public class Repair
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public int ClientId { get; set; }
        public int MechanicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Repair(int id, string plate, int clientId, int mechanicId, string name, string description, int price)
        {
            Id = id;
            Plate = plate;
            ClientId = clientId;
            MechanicId = mechanicId;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}