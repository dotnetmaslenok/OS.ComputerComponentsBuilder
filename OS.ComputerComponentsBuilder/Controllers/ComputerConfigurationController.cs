using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Entities;
using OS.ComputerComponentsBuilder.Infrastructure;
using OS.ComputerComponentsBuilder.Requests;
using OS.ComputerComponentsBuilder.Responses;
using System.Text.RegularExpressions;

namespace OS.ComputerComponentsBuilder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerConfigurationController : ControllerBase
    {
        private readonly ApplicationStorage _storage;

        public ComputerConfigurationController(ApplicationStorage storage)
        {
            _storage = storage;
        }

        [HttpPost("build-configuration")]
        public async Task<IActionResult> BuildComputerConfigurationAsync([FromBody] ComputerConfigurationRequest request)
        {
            int priceCategory;
            List<string> ratiosTable;
            var existedPriceCategories = new List<int>();
            using (var sr = new StreamReader("ComponentsRatios/ComponentsRatios.txt"))
            {
                string? line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    if (int.TryParse(line, out int price))
                    {
                        existedPriceCategories.Add(price);
                    }
                }

                priceCategory = existedPriceCategories.MinBy(x => Math.Abs(x - request.Price));
                ratiosTable = new List<string>();
                sr.BaseStream.Position = 0;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    if (line == priceCategory.ToString())
                    {
                        while ((line = await sr.ReadLineAsync()) != null)
                        {
                            if (!string.IsNullOrEmpty(line))
                            {
                                ratiosTable.Add(Regex.Replace(line, @"\s+", " "));
                            }
                        }
                    }
                }
            }

            double[] componentsRatios = new double[typeof(ComputerConfigurationResponse).GetProperties().Count(x => x.GetType() != typeof(Enum))];
            foreach (var t in ratiosTable.Where(t => t.Split(' ').First() == Regex.Replace(request.Type, @"\s+", "")))
            {
                componentsRatios = t.Split(' ').Skip(1).Select(double.Parse).ToArray();
                break;
            }

            var response = new ComputerConfigurationResponse()
            {
                Type = request.Type,
                CPU = (await _storage.CentralProcessingUnits.OrderBy(x => Math.Abs(Convert.ToDecimal(priceCategory * componentsRatios[0]) - x.Price)).FirstOrDefaultAsync())!,
                GPU = componentsRatios[1] != 0 ? await _storage.GraphicsProcessingUnits.OrderBy(x => Math.Abs(Convert.ToDecimal(priceCategory * componentsRatios[1]) - x.Price)).FirstOrDefaultAsync() : null,
                RAM = (await _storage.RandomAccessMemories.OrderBy(x => Math.Abs(Convert.ToDecimal(priceCategory * componentsRatios[2]) - x.Price)).FirstOrDefaultAsync())!,
                Motherboard = (await _storage.Motherboards.OrderBy(x => Math.Abs(Convert.ToDecimal(priceCategory * componentsRatios[3]) - x.Price)).FirstOrDefaultAsync())!,
                Storage = new List<Storage> { (await _storage.Storages.OrderBy(x => Math.Abs(Convert.ToDecimal(priceCategory * componentsRatios[4]) - x.Price)).FirstOrDefaultAsync())! },
            };

            return Ok(response);
        }

        [HttpGet("rebuild")]
        public async Task<IActionResult> RebuildConfigurationAsync(
            [FromQuery(Name = "c")] string? cpuId,
            [FromQuery(Name = "g")] string? gpuId,
            [FromQuery(Name = "m")] string? motherboardId,
            [FromQuery(Name = "r")] string? ramId,
            [FromQuery(Name = "s")] string? storageId,
            [FromQuery(Name = "s2")] string? additionalStorageId)
        {
            var cpu = await _storage.CentralProcessingUnits.FirstOrDefaultAsync(c => c.Id.ToString() == cpuId);
            var gpu = await _storage.GraphicsProcessingUnits.FirstOrDefaultAsync(g => g.Id.ToString() == gpuId);
            var motherboard = await _storage.Motherboards.FirstOrDefaultAsync(m => m.Id.ToString() == motherboardId);
            var ram = await _storage.RandomAccessMemories.FirstOrDefaultAsync(m => m.Id.ToString() == ramId);
            var storage = await _storage.Storages.FirstOrDefaultAsync(s => s.Id.ToString() == storageId);
            var additionalStorage = await _storage.Storages.FirstOrDefaultAsync(s => s.Id.ToString() == additionalStorageId);

            var configuration = new ComputerConfigurationResponse
            {
                CPU = cpu,
                GPU = gpu,
                Motherboard = motherboard,
                RAM = ram,
                Storage = new List<Storage> { storage, additionalStorage },
            };

            return Ok(configuration);
        }
    }
}
