using CinemaScheduleWebApi.Database;
using CinemaScheduleWebApi.Models;
using CinemaScheduleWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaScheduleWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CinemaScheduleController : ControllerBase
	{		
		private readonly ICinemaScheduleService _cinemaScheduleService;
		private readonly ILogger<CinemaScheduleController> _logger;

		public CinemaScheduleController(ILogger<CinemaScheduleController> logger, ICinemaScheduleService cinemaScheduleService)
		{
			_logger = logger;
			_cinemaScheduleService = cinemaScheduleService;
		}

		/// <summary>
		/// Get Page with list of schedules
		/// example: /api/cinemaSchedule?pageNumber=1&pageSize=2
		/// </summary>
		/// <param name="paggingParameters"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetPage([FromQuery] PaggingParameters paggingParameters)
		{
			var items = await _cinemaScheduleService.GetPageAsync(paggingParameters);

			return Ok(items);
		}

		/// <summary>
		/// Get Page with list of schedules by cityId
		/// example: /api/cinemaSchedule/city/1
		/// </summary>
		/// <param name="id">City Id</param>
		/// <param name="paggingParameters"></param>
		/// <returns></returns>
		[HttpGet("city/{id}")]
		public async Task<IActionResult> GetPageByCityId([FromQuery] PaggingParameters paggingParameters, int id)
		{
			var items = await _cinemaScheduleService.GetPageByCityIdAsync(paggingParameters, id);

			return Ok(items);
		}

		/// <summary>
		/// Get Page with list of schedules by cinemaId
		/// example: /api/cinemaSchedule/cinema/1
		/// </summary>
		/// <param name="id">Cinema Id</param>
		/// <param name="paggingParameters"></param>
		/// <returns></returns>
		[HttpGet("cinema/{id}")]
		public async Task<IActionResult> GetPageByCinemaId([FromQuery] PaggingParameters paggingParameters, int id)
		{
			var items = await _cinemaScheduleService.GetPageByCinemaIdAsync(paggingParameters, id);

			return Ok(items);
		}

		/// <summary>
		/// Get CinemaSchedule by Id
		/// example: /api/cinemaSchedule/1
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var item = await _cinemaScheduleService.GetAsync(id);
			if (item == null)
				return NotFound();

			return Ok(item);
		}

		/// <summary>
		/// Create Cinema Schedule
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CinemaSchedule item)
		{
			var id = await _cinemaScheduleService.AddAsync(item);

			return Ok(id);
		}

		/// <summary>
		/// Remove Cinema Schedule By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _cinemaScheduleService.DeleteAsync(id);

			return Ok();
		}

		/// <summary>
		/// Update Cinema Schedule
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<IActionResult> Put([FromBody] CinemaSchedule item)
		{
			await _cinemaScheduleService.UpdateAsync(item);

			return Ok();
		}
	}
}
