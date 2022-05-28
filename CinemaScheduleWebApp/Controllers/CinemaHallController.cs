using CinemaScheduleWebApi.Database;
using CinemaScheduleWebApp.Database;
using Microsoft.AspNetCore.Mvc;

namespace CinemaScheduleWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CinemaHallController : ControllerBase
	{
		private readonly CinemaScheduleDbContext _context;
		private readonly ILogger<CinemaHallController> _logger;

		public CinemaHallController(ILogger<CinemaHallController> logger, CinemaScheduleDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Get Page with list of cinema halls names
		/// example: /api/cinemaHall?pageNumber=1&pageSize=2
		/// </summary>
		/// <param name="paggingParameters"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetPage([FromQuery] PaggingParameters paggingParameters)
		{
			var items = await _context.CinemaHalls.OrderBy(on => on.Code).GetPage(paggingParameters);

			return Ok(items);
		}
	}
}
