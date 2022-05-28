namespace CinemaScheduleWebApi.Models
{
	public class CinemaHall : BaseModel
	{
		public string Code { get; set; }
		public int CinemaId { get; set; }
		public virtual Cinema Cinema { get; set; }
		public bool Is3D { get; set; }
		public bool IsImax { get; set; }
	}
}
