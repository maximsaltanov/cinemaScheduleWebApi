using CinemaScheduleWebApi.Database;
using CinemaScheduleWebApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaScheduleWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CinemaController : ControllerBase
	{
		private readonly CinemaScheduleDbContext _context;
		private readonly ILogger<CinemaController> _logger;

		public CinemaController(ILogger<CinemaController> logger, CinemaScheduleDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Get Page with list of cinemas names
		/// example: /api/cinema
		/// </summary>
		/// <param name="paggingParameters"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetPage([FromQuery] PaggingParameters paggingParameters)
		{
			var items = (await _context.Cinemas.OrderBy(on => on.Name).GetPage(paggingParameters)).Select(f => new 
			{ 
				Id = f.Id, 
				Name = f.Name
			});

			return Ok(items);
		}

		/// <summary>
		/// Get Page with list of cinemas names by cityId
		/// example: /api/cinema/city/1
		/// </summary>
		/// <param name="paggingParameters"></param>
		/// <param name="id">City Id</param>
		/// <returns></returns>
		[HttpGet("city/{id}")]
		public async Task<IActionResult> GetPage([FromQuery] PaggingParameters paggingParameters, int id)
		{
			var items = (await _context.Cinemas.Where(r => id == 0 || r.CityId == id).OrderBy(on => on.Name).GetPage(paggingParameters)).Select(f => new
			{
				Id = f.Id,
				Name = f.Name
			});

			return Ok(items);
		}

		/// <summary>
		/// Get Cinema by Id
		/// example: /api/cinema/1
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var item = await _context.Cinemas.FirstOrDefaultAsync(f => f.Id == id);
			if (item == null)
				return NotFound();

			return Ok(item);
		}
	}
}
