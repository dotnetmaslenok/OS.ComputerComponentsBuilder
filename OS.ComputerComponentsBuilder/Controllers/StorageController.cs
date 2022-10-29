using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Infrastructure;

namespace OS.ComputerComponentsBuilder.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StorageController : ControllerBase
	{
		private readonly ApplicationStorage _storage;
		public StorageController(ApplicationStorage storage)
		{
			_storage = storage;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetStorageAsync([FromRoute] string id)
		{
			var storage = await _storage.Storages.FirstOrDefaultAsync(s => s.Id.ToString() == id);

			if (storage != null)
			{
				return Ok(storage);
			}

			return NotFound();
		}

		[HttpGet("search")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SearchAsync([FromQuery(Name = "q")] string term)
		{
			var storages = await Task.Run(async () =>
			{
				if (decimal.TryParse(term, out var price))
				{
					var byPrice = await _storage.Storages
						.OrderBy(p => Math.Abs(price - p.Price))
						.Take(5)
						.ToArrayAsync();

					if (byPrice.Length > 0)
					{
						return byPrice;
					}
				}

				return _storage.Storages.AsEnumerable()
					.Where(x => x.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) > -1)
					.Take(5)
					.ToArray();
			});

			if (storages.Length > 0)
			{
				return Ok(storages);
			}

			return NotFound();
		}
	}
}
