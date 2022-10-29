using OS.ComputerComponentsBuilder.Abstractions;

namespace OS.ComputerComponentsBuilder.Entities
{
    public class Storage : IComponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public string Producer { get; set; }
        public string Type { get; set; }
        public int ReadingSpeed { get; set; }
        public int WritingSpeed { get; set; }
        public string ConnectionConnector { get; set; }
        public string? MemoryStructure { get; set; }
        public string? WritingTechnology { get; set; }

        public Storage(string name, decimal price, int volume, string type, int readingSpeed, int writingSpeed, string connectionConnector, string? memoryStructure = null, string? writingTechnology = null)
        {
            Name = name;
            Price = price;
            Volume = volume;
            Producer = name.Split(' ').First();
            Type = type;
            ReadingSpeed = readingSpeed;
            WritingSpeed = writingSpeed;
            ConnectionConnector = connectionConnector;
            MemoryStructure = memoryStructure;
            WritingTechnology = writingTechnology;
        }
    }
}
