namespace CinemaScheduleWebApi.Models
{
	public class Cinema : BaseModel
	{
		public string Name { get; set; }
		public string? Address { get; set; }
		public int CityId { get; set; }
		public virtual City City { get; set; }
	}
}
