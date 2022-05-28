using System;

namespace CinemaScheduleWebApi.Models
{
	public class CinemaSchedule : BaseModel
	{
		public int CityId { get; set; }
		public virtual City City { get; set; }
		public int CinemaId { get; set; }
		public virtual Cinema Cinema { get; set; }
		public int? CinemaHallId { get; set; }
		public virtual CinemaHall CinemaHall { get; set; }
		public int FilmId { get; set; }
		public virtual Film Film { get; set; }
		public DateTime? ShowDateTime { get; set; }
		public decimal? Cost { get; set; }
	}
}
