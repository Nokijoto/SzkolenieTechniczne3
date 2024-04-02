using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne3.Common.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.Extensions;
using SzkolenieTechniczne3.Geo.Storage;
using SzkolenieTechniczne3.Geo.Storage.Entities;

namespace SzkolenieTechniczne3.Geo.Services
{
    public class CountryService
    {
        private GeoDbContext _geoDbContext;
        public CountryService(GeoDbContext geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }
        public async Task<CountryDto> GetById(Guid Id)
        {
            var country = await _geoDbContext
                .Set<Country>()
                .Include(x => x.Translations)
                .AsNoTracking()
                .Where(e => e.ID!.Equals(Id))
                .SingleOrDefaultAsync();
            return country.ToDto();
        }

        public async Task<IEnumerable<CountryDto>> Get()
        {
            var countries = await _geoDbContext
                .Set<Country>()
                .Include(x => x.Translations)
                .AsNoTracking()
                .Select(e => e.ToDto())
                .ToListAsync();
            return countries;
        }

        public async Task<CrudOperationResult<CountryDto>> Create (CountryDto dto)
        {
            var entity = dto.ToEntity();

            _geoDbContext
                .Set<Country>()
                .Add(entity);

            await _geoDbContext.SaveChangesAsync();
            var newDto = await GetById(entity.ID);
            return new CrudOperationResult<CountryDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };

        }
    }
}
