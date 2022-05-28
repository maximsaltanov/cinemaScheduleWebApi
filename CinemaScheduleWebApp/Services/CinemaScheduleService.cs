using System.Linq;
using CinemaScheduleWebApi.Database;
using CinemaScheduleWebApi.Models;
using CinemaScheduleWebApp.Database;
using Microsoft.EntityFrameworkCore;

namespace CinemaScheduleWebApp.Services
{
	public class CinemaScheduleService : ICinemaScheduleService
	{
		private readonly CinemaScheduleDbContext _context;

		public CinemaScheduleService(CinemaScheduleDbContext context)
		{ 
			_context = context;
		}

		public async Task<List<CinemaSchedule>> GetPageAsync(PaggingParameters paggingParameters)
		{
			var items = await _context.CinemaSchedules.OrderBy(on => on.Id).GetPage(paggingParameters);

			return items;
		}

		public async Task<List<CinemaSchedule>> GetPageByCityIdAsync(PaggingParameters paggingParameters, int cityId)
		{
			var items = (await _context.CinemaSchedules.Where(r => cityId == 0 || r.CityId == cityId).OrderBy(on => on.Id).GetPage(paggingParameters));

			return items;
		}

		public async Task<List<CinemaSchedule>> GetPageByCinemaIdAsync(PaggingParameters paggingParameters, int cinemaId)
		{
			var items = (await _context.CinemaSchedules.Where(r => cinemaId == 0 || r.CinemaId == cinemaId).OrderBy(on => on.Id).GetPage(paggingParameters));

			return items;
		}

		public async Task<CinemaSchedule> GetAsync(int id)
		{
			return await _context.CinemaSchedules.FirstOrDefaultAsync(f => f.Id == id);
		}

		public async Task<int> AddAsync(CinemaSchedule item)
		{
			_context.CinemaSchedules.Add(item);
			await _context.SaveChangesAsync();

			return item.Id;
		}

		public async Task DeleteAsync(int id)
		{
			var item = await _context.CinemaSchedules.FirstOrDefaultAsync(f => f.Id == id);
			if (item == null)
				throw new Exception("Not Found");

			_context.CinemaSchedules.Remove(item);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(CinemaSchedule item)
		{
			_context.CinemaSchedules.Update(item);
			await _context.SaveChangesAsync();
		}
	}
}
