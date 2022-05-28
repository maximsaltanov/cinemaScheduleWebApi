using CinemaScheduleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaScheduleWebApp.Database
{
    public class CinemaScheduleDbContext : DbContext
    {
        public CinemaScheduleDbContext(DbContextOptions<CinemaScheduleDbContext> options)
            : base(options)
        {
			SeedData();
		}

        public DbSet<City> Cities => Set<City>();
        public DbSet<Cinema> Cinemas => Set<Cinema>();
		public DbSet<CinemaHall> CinemaHalls => Set<CinemaHall>();
		public DbSet<CinemaSchedule> CinemaSchedules => Set<CinemaSchedule>();
		public DbSet<Film> Films => Set<Film>();


		private void SeedData()
		{
			this.Database.EnsureCreated();

			SeedCities();
			SeedCinemas();
			SeedFilms();
			SeedCinemaSchedules();
		}

		private void SeedCities()
		{
			if (this.Cities.Any())
				return;

			this.AddRange(
				new City { Id = 1, Name = "Mirniy" },
				new City { Id = 2, Name = "Moscow" },
				new City { Id = 3, Name = "Rostov-on-Don" });

			this.SaveChanges();
		}

		private void SeedCinemas()
		{
			if (this.Cinemas.Any())
				return;
			
			this.AddRange(
				new Cinema { Id = 1, Name = "Mirniy Cinema", Address = "Mira st, 1", CityId = 1 },
				new Cinema { Id = 2, Name = "Central Cinema", Address = "Chehova st, 10", CityId = 2 },
				new Cinema { Id = 3, Name = "Cinema Don", Address = "Voroshilovsky", CityId = 3 });

			this.AddRange(
				new CinemaHall { Id = 1, CinemaId = 1, Code = "1A", Is3D = false, IsImax = false },
				new CinemaHall { Id = 2, CinemaId = 2, Code = "1", Is3D = true, IsImax = true },
				new CinemaHall { Id = 3, CinemaId = 3, Code = "Green", Is3D = true, IsImax = false });

			this.SaveChanges();
		}

		private void SeedFilms()
		{
			if (this.Films.Any())
				return;

			this.AddRange(
				new Film
				{
					Id = 1,
					AgeLimit = 6,
					CountryCreated = "Russia",
					Description = "Few people know, but a brownie lives in every house. This is a funny furry creature that secretly lives in the world of people to take care of the house and keep the hearth. Finnick is a kind and funny brownie, but a little mischievous and mischievous. He constantly makes fun of the tenants, so no family stays for a long time in his possessions. Everything changes when new tenants move into the house. The tricks of the brownie do not work for them at all, and Finnick suddenly meets the girl Christina, and inexplicable events begin to occur in the city. Finnick and Christina, so unlike each other, will have to team up to solve the mystery of the incident and save the city.",
					Promo = "A girl and a brownie investigate the frightening events taking place in the city",
					Rating = (decimal)7.8,
					DurationMins = 85,
					Title = "Finnik"
				});

			this.SaveChanges();
		}

		private void SeedCinemaSchedules()
		{
			if (this.CinemaSchedules.Any())
				return;

			this.AddRange(
				new CinemaSchedule
				{
					Id = 1,
					CityId = 1,
					FilmId = 1,
					CinemaId = 1,
					ShowDateTime = DateTime.Now
				},
				new CinemaSchedule
				{
					Id = 2,
					CityId = 3,
					FilmId = 1,
					CinemaId = 3,
					ShowDateTime = DateTime.Now.AddDays(1),
					CinemaHallId = 1
				});

			this.SaveChanges();
		}
	}
}
