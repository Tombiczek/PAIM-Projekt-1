namespace Model
{
    public class Repair
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public int MechanicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Repair(int id, int carId, int clientId, int mechanicId, string name, string description, int price)
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