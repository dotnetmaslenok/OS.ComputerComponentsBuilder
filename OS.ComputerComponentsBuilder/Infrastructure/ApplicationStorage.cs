using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Entities;

namespace OS.ComputerComponentsBuilder.Infrastructure
{
    public class ApplicationStorage : DbContext
    {
        public DbSet<CentralProcessingUnit> CentralProcessingUnits { get; set; }
        public DbSet<GraphicsProcessingUnit> GraphicsProcessingUnits { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<RandomAccessMemory> RandomAccessMemories { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public ApplicationStorage(DbContextOptions<ApplicationStorage> options)
            : base(options)
        {

        }
    }
}
