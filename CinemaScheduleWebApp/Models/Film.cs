using System;

namespace CinemaScheduleWebApi.Models
{
	public class Film : BaseModel
	{
		public string Title { get; set; }
		public string? Promo { get; set; }
		public string? TopActors { get; set; }
		public string? Description { get; set; }
		public string? ImageUrl { get; set; }
		public string? TrailerUrl { get; set; }
		public int? AgeLimit { get; set; }
		public decimal? Rating { get; set; }
		public DateTime? PremierDate { get; set; }
		public int? YearCreated { get; set; }
		public string? CountryCreated { get; set; }
		public int? DurationMins { get; set; }
	}
}
