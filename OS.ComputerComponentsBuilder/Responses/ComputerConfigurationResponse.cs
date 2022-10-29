using OS.ComputerComponentsBuilder.Entities;

namespace OS.ComputerComponentsBuilder.Responses
{
    public class ComputerConfigurationResponse
    {
        public string Type { get; set; }
        public CentralProcessingUnit CPU { get; set; }
        public GraphicsProcessingUnit? GPU { get; set; }
        public Motherboard Motherboard { get; set; }
        public RandomAccessMemory RAM { get; set; }
        public List<Storage> Storage { get; set; }
    }
}
