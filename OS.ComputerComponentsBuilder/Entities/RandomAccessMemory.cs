using OS.ComputerComponentsBuilder.Abstractions;

namespace OS.ComputerComponentsBuilder.Entities
{
    public class RandomAccessMemory : IComponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public int Count { get; set; }
        public int FullVolume { get; set; }
        public string Producer { get; set; }
        public string MemoryType { get; set; }
        public string FormFactor { get; set; }
        public int ClockFrequency { get; set; }
        public bool RegisterMemory { get; set; }
        public bool EccMemory { get; set; }

        public RandomAccessMemory(string name, decimal price, int volume, int count, string memoryType, string formFactor, int clockFrequency, bool registerMemory, bool eccMemory)
        {
            Name = name;
            Price = price;
            Volume = volume;
            Count = count;
            FullVolume = volume * count;
            Producer = Name.Split(' ').First();
            MemoryType = memoryType;
            FormFactor = formFactor;
            ClockFrequency = clockFrequency;
            RegisterMemory = registerMemory;
            EccMemory = eccMemory;
        }
    }
}
