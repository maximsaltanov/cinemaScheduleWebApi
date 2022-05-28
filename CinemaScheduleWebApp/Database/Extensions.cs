using Microsoft.EntityFrameworkCore;

namespace CinemaScheduleWebApi.Database
{
    public static class Extensions
    {
        public static async Task<List<T>> GetPage<T>(this IOrderedQueryable<T> items, PaggingParameters? paggingParameters = null) where T : class
        {
            if (paggingParameters == null)
                paggingParameters = new PaggingParameters();

            return await items.Skip((paggingParameters.PageNumber - 1) * paggingParameters.PageSize)
                .Take(paggingParameters.PageSize)
                .ToListAsync();
        }
    }
}
