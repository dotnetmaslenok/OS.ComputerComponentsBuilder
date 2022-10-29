using OS.ComputerComponentsBuilder.Abstractions;

namespace OS.ComputerComponentsBuilder.Entities
{
    public class CentralProcessingUnit : IComponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClockFrequency { get; set; }
        public double MaxClockFrequency { get; set; }
        public string Socket { get; set; }
        public string TechnicalProcess { get; set; }

        public CentralProcessingUnit(string name, decimal price, int cores, int threads, double baseClockFrequency, double maxClockFrequency, string socket, string technicalProcess)
        {
            Name = name;
            Price = price;
            Producer = Name.Split(' ').First();
            Cores = cores;
            Threads = threads;
            BaseClockFrequency = baseClockFrequency;
            MaxClockFrequency = maxClockFrequency;
            Socket = socket;
            TechnicalProcess = technicalProcess;
        }
    }
}
