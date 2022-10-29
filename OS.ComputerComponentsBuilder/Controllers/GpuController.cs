using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Infrastructure;

namespace OS.ComputerComponentsBuilder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GpuController : ControllerBase
	{
		private readonly ApplicationStorage _storage;

		public GpuController(ApplicationStorage storage)
		{
			_storage = storage;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetGpuAsync([FromRoute] string id)
		{
			var gpu = await _storage.GraphicsProcessingUnits.FirstOrDefaultAsync(g => g.Id.ToString() == id);

			if (gpu != null)
			{
				return Ok(gpu);
			}

			return NotFound();
		}

		[HttpGet("search")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SearchAsync([FromQuery(Name = "q")] string term)
		{
			var gpus = await Task.Run(async () =>
			{
				if (decimal.TryParse(term, out var price))
				{
					var byPrice = await _storage.GraphicsProcessingUnits.OrderBy(p => Math.Abs(price - p.Price)).Take(5).ToArrayAsync();

					if (byPrice.Length > 0)
					{
						return byPrice;
					}
				}

				return _storage.GraphicsProcessingUnits.AsEnumerable()
					.Where(x => x.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) > -1)
					.Take(5).ToArray();
			});

			if (gpus != null)
			{
				return Ok(gpus);
			}

			return NotFound();
		}
	}
}
