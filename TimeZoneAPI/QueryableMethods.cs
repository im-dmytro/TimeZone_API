using Microsoft.EntityFrameworkCore;
using System.Web;
using System;
using TimeZoneAPI.Models;

namespace TimeZoneAPI
{
    public class QueryableMethods
    {
        private static IQueryable<CountryTimeInfoDTO> GetQueryableCountryTimeZones(CountryTimeApiContext dbContext)
        {
            return dbContext.CountryTimeZones.
                GroupBy(el => new { el.Country, el.CountryCode }).
                Select(el => new CountryTimeInfoDTO
                {
                    CountryCode = el.Key.CountryCode,
                    CountryName = el.Key.Country,
                    timeZones = el.Select(el => new TimeZoneDTO { TimeZoneName = el.TimeZoneName, GmtOffset = el.GmtOffset, CurrentTime = CurrentTimeByOffset(el.GmtOffset) })
                });
        }
        private static string CurrentTimeByOffset(string gmtOffsetNotFormated)
        {
            int gmtOffset = Convert.ToInt32(gmtOffsetNotFormated.Split(' ', ':')[1]);
            DateTime currentTimeUtc = DateTime.UtcNow.AddHours(gmtOffset);
            return currentTimeUtc.ToString("hh:mm tt");
        }
        private static IQueryable<CountryInfoDTO> GetQueryableCountryTimeInfo(CountryTimeApiContext dbContext)
        {
            var timeZones = GetQueryableCountryTimeZones(dbContext);

            return from f in dbContext.CountryFlags
                   join t in timeZones on f.Code equals t.CountryCode
                   join c in dbContext.CountryCapitals on t.CountryName equals c.Country
                   select new CountryInfoDTO
                   {
                       Id = t.CountryCode,
                       Country = t.CountryName,
                       CountryTimeZones = t.timeZones,
                       FlagUrl = f.Url,
                       Capital = c.Capital
                   };
        }
        public static async Task<List<CountryInfoDTO>> GetCountriesTimeInfo(CountryTimeApiContext dbContext)
        {
            return await GetQueryableCountryTimeInfo(dbContext).ToListAsync();
        }
        public static async Task<CountryInfoDTO> GetCountryTimeInfo(CountryTimeApiContext dbContext, string input)
        {
            return await GetQueryableCountryTimeInfo(dbContext).FirstOrDefaultAsync(x => x.Id == input);
        }
        public static async Task<CountryTimeInfoDTO> GetCurrentCountryTimeZoneInfo(CountryTimeApiContext dbContext, string input)
        {
            return GetQueryableCountryTimeZones(dbContext).FirstOrDefault(el => el.CountryCode == input);

        }
        public static async Task<IResult> UpdateTimeZoneName(CountryTimeApiContext dbContext, string timezone, CountryTimeZone inputTimeZone)
        {
            var timeZoneCountry = await dbContext.CountryTimeZones.FirstOrDefaultAsync(el => el.TimeZoneName == HttpUtility.UrlDecode(timezone));

            if (timeZoneCountry is null) return Results.NotFound();
            timeZoneCountry.TimeZoneName = inputTimeZone.TimeZoneName;
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        }
        public static async Task<IResult> PostTimeZone(CountryTimeApiContext dbContext, CountryTimeZone inputTimeZone)
        {
            var timeZoneCountry = await dbContext.CountryTimeZones.FirstOrDefaultAsync(el => el.TimeZoneName == inputTimeZone.TimeZoneName);
            if (timeZoneCountry == null)
            {
                dbContext.CountryTimeZones.Add(inputTimeZone);
                await dbContext.SaveChangesAsync();
                return Results.Created($"/timezones/{inputTimeZone.TimeZoneName}", inputTimeZone);
            }

            return Results.BadRequest();

        }
        public static async Task<IResult> DeleteTimeZone(CountryTimeApiContext dbContext, string timezone, CountryTimeZone inputTimeZone)
        {


            if (await dbContext.CountryTimeZones.FirstOrDefaultAsync(el => el.TimeZoneName == HttpUtility.UrlDecode(timezone)) is CountryTimeZone timeZoneCountry)
            {
                dbContext.CountryTimeZones.Remove(timeZoneCountry);
                await dbContext.SaveChangesAsync();
                return Results.Ok(timeZoneCountry);
            }

            return Results.NotFound();
        }
    }
}
