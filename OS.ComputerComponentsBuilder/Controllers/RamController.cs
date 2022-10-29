using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Infrastructure;

namespace OS.ComputerComponentsBuilder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RamController : ControllerBase
	{
		private readonly ApplicationStorage _storage;
		public RamController(ApplicationStorage storage)
		{
			_storage = storage;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetRamAsync([FromRoute] string id)
		{
			var ram = await _storage.RandomAccessMemories.FirstOrDefaultAsync(m => m.Id.ToString() == id);

			if (ram != null)
			{
				return Ok(ram);
			}

			return NotFound();
		}

		[HttpGet("search")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SearchAsync([FromQuery(Name = "q")] string term)
		{
			var rams = await Task.Run(async () =>
			{
				if (decimal.TryParse(term, out var price))
				{
					var byPrice = await _storage.RandomAccessMemories.OrderBy(p => Math.Abs(price - p.Price)).Take(5).ToArrayAsync();

					if (byPrice.Length > 0)
					{
						return byPrice;
					}
				}

				return _storage.RandomAccessMemories.AsEnumerable()
					.Where(x => x.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) > -1)
					.Take(10).ToArray();
			});

			if (rams != null)
			{
				return Ok(rams);
			}

			return NotFound();
		}
	}
}
