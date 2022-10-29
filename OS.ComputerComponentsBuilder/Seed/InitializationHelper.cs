using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Entities;
using OS.ComputerComponentsBuilder.Infrastructure;

namespace OS.ComputerComponentsBuilder.Seed
{
    public static class InitializationHelper
    {
        public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider, ApplicationStorage storage)
        {
            if (!await storage.CentralProcessingUnits.AnyAsync())
            {
                var cpus = new List<CentralProcessingUnit>()
                {
                    new(name: "Intel Core i5-10400 BOX", price: 13400, cores: 6, threads: 12, baseClockFrequency: 2.9, maxClockFrequency: 4.3, socket: "LGA 1200", technicalProcess: "14 нм"),
                    new(name: "AMD Ryzen 5 5600G BOX", price: 12800, cores: 6, threads: 12, baseClockFrequency: 3.9, maxClockFrequency: 4.4, socket: "AM 4", technicalProcess: "TSMC 7FF"),
                    new(name: "Intel Core i5-11400 BOX", price: 15000, cores: 6, threads: 12, baseClockFrequency: 2.6, maxClockFrequency: 4.4, socket: "LGA 1200", technicalProcess: "14 нм"),
                    new(name: "Intel Core i3-10100F OEM", price: 6300, cores: 4, threads: 8, baseClockFrequency: 3.6, maxClockFrequency: 4.3, socket: "LGA 1200", technicalProcess: "14 нм"),
                    new(name: "Intel Celeron G5900 OEM", price: 3100, cores: 2, threads: 2, baseClockFrequency: 3.4, maxClockFrequency: 3.4, socket: "LGA 1200", technicalProcess: "14 нм"),
                    new(name: "AMD Ryzen 5 4500 BOX", price: 12300, cores: 6, threads: 12, baseClockFrequency: 3.6, maxClockFrequency: 4.1, socket: "AM 4", technicalProcess: "TSMC 7FF"),
                    new(name: "Intel Core i3-12100 BOX", price: 9500, cores: 4, threads: 8, baseClockFrequency: 3.3, maxClockFrequency: 4.3, socket: "LGA 1700", technicalProcess: "Intel 7"),
                    new(name: "AMD Ryzen 7 3800X BOX", price: 20700, cores: 8, threads: 16, baseClockFrequency: 3.9, maxClockFrequency: 4.5, socket: "AM 4", technicalProcess: "TSMC 7FF"),
                    new(name: "Intel Core i7-11700KF OEM", price: 25200, cores: 8, threads: 16, baseClockFrequency: 3.6, maxClockFrequency: 5, socket: "LGA 1200", technicalProcess: "14 нм"),
                    new(name: "Intel Core i7-12700K OEM", price: 36000, cores: 16, threads: 24, baseClockFrequency: 3.2, maxClockFrequency: 5.2, socket: "LGA 1700", technicalProcess: "Intel 7"),
                    new(name: "Intel Core i9-12900KF BOX", price: 45000, cores: 12, threads: 20, baseClockFrequency: 3.6, maxClockFrequency: 5, socket: "LGA 1700", technicalProcess: "Intel 7"),
                };

                var gpus = new List<GraphicsProcessingUnit>()
                {
                    new("KFA2 GeForce GTX 1630", 13500, "NVIDIA Turing", "12 нм", 4, "GDDR6", 12000, 64),
                    new("GIGABYTE Radeon RX 6400 D6 LOW PROFILE", 13800, "AMD  RDNA 2", "6 нм", 4, "GDDR6", 16000, 64),
                    new("GIGABYTE GeForce GTX 1630 OC Low Profile", 13600, "NVIDIA Turing", "12 нм", 4, "GDDR6", 12000, 64),
                    new("MSI GeForce GTX 1650", 16800, "NVIDIA Turing", "12 нм", 4, "GDDR6", 12000, 128),
                    new("PowerColor AMD Radeon R7 240", 3400, "AMD Oland Pro", "28 нм", 2, "GDDR5", 4600, 64),
                    new("GIGABYTE GeForce GT 1030", 8550, "NVIDIA Pascal", "14 нм", 2, "GDDR5", 6000, 64),
                    new("GIGABYTE GeForce GT 730", 5700, "NVIDIA Kepler", "28 нм", 2, "GDDR5", 5000, 64),
                    new("GIGABYTE AMD Radeon RX 6500 XT EAGLE", 21800, "AMD RDNA 2", "6 нм", 4, "GDDR6", 18000, 64),
                    new("Palit GeForce RTX 3050 Dual", 32800, "NVIDIA Ampere", "8 нм", 8, "GDDR6", 14000, 128),
                    new("ASUS TUF Gaming GeForce GTX 1660 Ti EVO OC Edition", 37000, "NVIDIA Turing", "12 нм", 6, "GDDR6", 12000, 192),
                    new("MSI AMD Radeon RX 6750 XT MECH 2X OC", 49300, "AMD RDNA 2", "7 нм", 12, "GDDR6", 18000, 192),
                };

                var rams = new List<RandomAccessMemory>()
                {
                    new("Crucial CT8G4DFRA266", 2900, 8, 1, "DDR4", "DIMM", 2666, false, false),
                    new("Patriot Signature Line", 2300, 4, 2, "DDR4", "DIMM", 2666, false, false),
                    new("AMD Radeon R9 Gamer Series", 2400, 4, 2, "DDR4", "DIMM", 3200, false, false),
                    new("Patriot Viper 4 Blackout", 4100, 8, 2, "DDR4", "DIMM", 3200, false, false),
                    new("Foxline", 4100, 16, 1, "DDR4", "DIMM", 3600, false, false),
                    new("A-Data Premier", 4200, 16, 1, "DDR4", "DIMM", 3200, false, false),
                    new("Kingston FURY Beast Black RGB", 5600, 16, 1, "DDR4", "DIMM", 3200, false, false),
                    new("A-Data XPG SPECTRIX D50 RGB", 8600, 16, 2, "DDR4", "DIMM", 3600, false, false),
                    new("Kingston FURY Beast Black RGB", 10500, 16, 1, "DDR5", "DIMM", 6000, false, false),
                    new("Kingston FURY Beast Black RGB", 15300, 8, 4, "DDR4", "DIMM", 3600, false, false),
                    new("G.Skill TRIDENT Z Neo RGB", 21500, 16, 4, "DDR4", "DIMM", 3200, false, false),
                    new("Kingston FURY Beast Black", 18400, 16, 2, "DDR5", "DIMM", 6000, false, false),
                };

                var motherboards = new List<Motherboard>()
                {
                    new("ASRock A320M-DVS R4.0", 3800, "Micro-ATX", "AMD A320", "AM4", "DDR4", 3200, 2, 64),
                    new("ASRock H410M-HDV R2.0", 4000, "Micro-ATX", "Intel H410", "LGA 1200", "DDR4", 2933, 2, 64),
                    new("GIGABYTE H410M S2 V3", 4000, "Micro-ATX", "Intel H510", "LGA 1200", "DDR4", 2933, 2, 64),
                    new("GIGABYTE H510M H", 4600, "Micro-ATX", "Intel H510", "LGA 1200", "DDR4", 3200, 2, 64),
                    new("ASRock H510M-HVS", 4700, "Micro-ATX", "Intel H510", "LGA 1200", "DDR4", 2933, 2, 64),
                    new("GIGABYTE B450M H", 5000, "Micro-ATX", "AMD B450", "AM4", "DDR4", 3466, 2, 64),
                    new("GIGABYTE B560M H", 6500, "Micro-ATX", "Intel B560", "LGA 1200", "DDR4", 3200, 2, 64),
                    new("Biostar B660MX-E PRO", 11000, "Micro-ATX", "Intel B660", "LGA 1700", "DDR4", 3200, 2, 128),
                    new("GIGABYTE B550 AORUS ELITE V2", 15000, "Standard-ATX", "AMD B550", "AM4", "DDR4", 3200, 4, 128),
                    new("ASUS PRIME A320I-K", 10000, "Mini-ITX", "AMD A320", "AM4", "DDR4", 2666, 2, 64),
                    new("ASUS PRIME B660-PLUS D4", 19000, "Standard-ATX", "Intel B660", "LGA 1700", "DDR4", 3200, 4, 128),
                    new("MSI PRO Z690-A WIFI", 25000, "Standard-ATX", "Intel Z690", "LGA 1700", "DDR5", 4800, 4, 128),
                    new("MSI MPG Z690 EDGE WIFI", 37000, "Standard-ATX", "Intel Z690", "LGA 1700", "DDR5", 4800, 4, 128),
                };

                var storages = new List<Storage>()
                {
                    new("A-Data SU650", 3100, 480, "SSD", 560, 520, "SATA", "3D NAND"),
                    new("Seagate BarraCuda", 5200, 2048, "HDD", 190, 190, "SATA III", null, "SMR"),
                    new("WD Purple", 5300, 1024, "HDD", 110, 110, "SATA III", null, "CMR"),
                    new("A-Data SU800", 5800, 512, "SSD", 520, 450, "SATA", "3D NAND"),
                    new("Toshiba P300", 8400, 4096, "HDD", 196, 196, "SATA III", null, "SMR"),
                    new("Seagate SkyHawk", 9200, 4096, "HDD", 180, 180, "SATA III", null, "CMR"),
                    new("WD Red IntelliPower", 9900, 4096, "HDD", 180, 180, "SATA III", null, "SMR"),
                    new("Crucial BX500", 16000, 2000, "SSD", 540, 500, "SATA", "3D NAND"),
                    new("WD Blue", 24200, 2000, "SSD", 560, 530, "SATA", "3D NAND"),
                    new("Apacer PPSS25", 13000, 1000, "SSD", 550, 500, "SATA", "3D NAND"),
                };

                await storage.CentralProcessingUnits.AddRangeAsync(cpus);
                await storage.GraphicsProcessingUnits.AddRangeAsync(gpus);
                await storage.Motherboards.AddRangeAsync(motherboards);
                await storage.Storages.AddRangeAsync(storages);
                await storage.RandomAccessMemories.AddRangeAsync(rams);
                await storage.SaveChangesAsync();
            }
        }
    }
}
