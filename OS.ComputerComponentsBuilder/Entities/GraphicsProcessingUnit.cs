using OS.ComputerComponentsBuilder.Abstractions;

namespace OS.ComputerComponentsBuilder.Entities
{
    public class GraphicsProcessingUnit : IComponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }
        public string Microarchitecture { get; set; }
        public string TechnicalProcess { get; set; }
        public int VideoMemorySize { get; set; }
        public string MemoryType { get; set; }
        public int MemoryFrequency { get; set; }
        public int BusWidth { get; set; }

        public GraphicsProcessingUnit(string name, decimal price, string microarchitecture, string technicalProcess, int videoMemorySize, string memoryType, int memoryFrequency, int busWidth)
        {
            Name = name;
            Price = price;
            Producer = Name.Split(' ').First();
            Microarchitecture = microarchitecture;
            TechnicalProcess = technicalProcess;
            VideoMemorySize = videoMemorySize;
            MemoryType = memoryType;
            MemoryFrequency = memoryFrequency;
            BusWidth = busWidth;
        }
    }
}
