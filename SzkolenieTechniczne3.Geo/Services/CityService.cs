using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SzkolenieTechniczne3.Common.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.Extensions;
using SzkolenieTechniczne3.Geo.Storage;
using SzkolenieTechniczne3.Geo.Storage.Entities;

namespace SzkolenieTechniczne3.Geo.Services
{
    public class CityService
    {
        private GeoDbContext _geoDbContext;
        public CityService(GeoDbContext geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CityDto> GetById(Guid id)
        {
            var city = await _geoDbContext
                .Set<City>()
                .Include(x => x.Translations)
                .AsNoTracking()
                .Where(e => e.ID!.Equals(id))
                .SingleOrDefaultAsync();
            return city.ToDto();
        }

        public async Task<IEnumerable<CityDto>> Get()
        {
            var cities = await _geoDbContext
                .Set<City>()
                .Include(e => e.Translations)
                .AsNoTracking()
                .Select(e => e.ToDto())
                .ToListAsync();
            return cities;
        }

        public async Task<CrudOperationResult<CityDto>> Create(CityDto dto)
        {
            var entity = dto.ToEntity();

            _geoDbContext
                .Set<City>()
                .Add(entity);

            await _geoDbContext.SaveChangesAsync();
            var newDto= await GetById(entity.ID);
            return new CrudOperationResult<CityDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}
