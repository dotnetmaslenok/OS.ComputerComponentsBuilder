namespace OS.ComputerComponentsBuilder.Abstractions
{
    public interface IComponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }
    }
}
