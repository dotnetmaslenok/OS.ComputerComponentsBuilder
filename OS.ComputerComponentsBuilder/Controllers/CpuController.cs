using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Infrastructure;

namespace OS.ComputerComponentsBuilder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CpuController : ControllerBase
	{
		private readonly ApplicationStorage _storage;

		public CpuController(ApplicationStorage storage)
		{
			_storage = storage;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetCpuAsync([FromRoute] string id)
		{
			var cpu = await _storage.CentralProcessingUnits.FirstOrDefaultAsync(p => p.Id.ToString() == id);

			if (cpu != null)
			{
				return Ok(cpu);
			}

			return NotFound();
		}

		[HttpGet("search")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SearchAsync([FromQuery(Name = "q")] string term)
		{
			var cpus = await Task.Run(async () =>
			{
				if (decimal.TryParse(term, out var price))
				{
					var byPrice = await _storage.CentralProcessingUnits.OrderBy(p => Math.Abs(price - p.Price)).Take(5).ToArrayAsync();

					if (byPrice.Length > 0)
					{
						return byPrice;
					}
				}

				return _storage.CentralProcessingUnits.AsEnumerable()
					.Where(x => x.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) > -1)
					.Take(5).ToArray();
			});

			if (cpus != null)
			{
				return Ok(cpus);
			}

			return NotFound();
		}
	}
}
