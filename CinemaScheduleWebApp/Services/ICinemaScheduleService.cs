using CinemaScheduleWebApi.Database;
using CinemaScheduleWebApi.Models;

namespace CinemaScheduleWebApp.Services
{
	public interface ICinemaScheduleService
	{
		Task<List<CinemaSchedule>> GetPageAsync(PaggingParameters paggingParameters);
		Task<List<CinemaSchedule>> GetPageByCityIdAsync(PaggingParameters paggingParameters, int cityId);
		Task<List<CinemaSchedule>> GetPageByCinemaIdAsync(PaggingParameters paggingParameters, int cinemaId);
		Task<CinemaSchedule> GetAsync(int id);
		Task<int> AddAsync(CinemaSchedule item);
		Task DeleteAsync(int id);
		Task UpdateAsync(CinemaSchedule item);
	}
}
