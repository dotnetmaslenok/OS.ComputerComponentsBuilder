using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Infrastructure;

namespace OS.ComputerComponentsBuilder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MotherboardController : ControllerBase
	{
		private readonly ApplicationStorage _storage;
		public MotherboardController(ApplicationStorage storage)
		{
			_storage = storage;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetMotherboardAsync([FromRoute] string id)
		{
			var motherboard = await _storage.Motherboards.FirstOrDefaultAsync(m => m.Id.ToString() == id);

			if (motherboard != null)
			{
				return Ok(motherboard);
			}

			return NotFound();
		}

		[HttpGet("search")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SearchAsync([FromQuery(Name = "q")] string term)
		{
			var motherboards = await Task.Run(async () =>
			{
				if (decimal.TryParse(term, out var price))
				{
					var byPrice = await _storage.Motherboards.OrderBy(p => Math.Abs(price - p.Price)).Take(5).ToArrayAsync();

					if (byPrice.Length > 0)
					{
						return byPrice;
					}
				}

				return _storage.Motherboards.AsEnumerable()
					.Where(x => x.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) > -1)
					.Take(5).ToArray();
			});

			if (motherboards != null)
			{
				return Ok(motherboards);
			}

			return NotFound();
		}
	}
}
