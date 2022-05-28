using CinemaScheduleWebApi.Database;
using CinemaScheduleWebApp.Database;
using Microsoft.AspNetCore.Mvc;

namespace CinemaScheduleWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CityController : ControllerBase
	{
		private readonly CinemaScheduleDbContext _context;
		private readonly ILogger<CityController> _logger;

		public CityController(ILogger<CityController> logger, CinemaScheduleDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Get Page with list of cities names
		/// example: /api/city?pageNumber=1&pageSize=2
		/// </summary>
		/// <param name="paggingParameters"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetPage([FromQuery] PaggingParameters paggingParameters)
		{
			var items = await _context.Cities.OrderBy(on => on.Name).GetPage(paggingParameters);

			return Ok(items);
		}
	}
}
