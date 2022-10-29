using OS.ComputerComponentsBuilder.Abstractions;

namespace OS.ComputerComponentsBuilder.Entities
{
    public class Motherboard : IComponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }
        public string FormFactor { get; set; }
        public string Chipset { get; set; }
        public string Socket { get; set; }
        public string MemoryType { get; set; }
        public int MemorySpeed { get; set; }
        public int NumberOfMemorySlots { get; set; }
        public int MaxMemoryVolume { get; set; }

        public Motherboard(string name, decimal price, string formFactor, string chipset, string socket, string memoryType, int memorySpeed, int numberOfMemorySlots, int maxMemoryVolume)
        {
            Name = name;
            Price = price;
            Producer = name.Split(' ').First();
            FormFactor = formFactor;
            Chipset = chipset;
            Socket = socket;
            MemoryType = memoryType;
            MemorySpeed = memorySpeed;
            NumberOfMemorySlots = numberOfMemorySlots;
            MaxMemoryVolume = maxMemoryVolume;

        }
    }
}
