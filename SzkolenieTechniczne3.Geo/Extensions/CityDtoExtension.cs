using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.Storage.Entities;

namespace SzkolenieTechniczne3.Geo.Extensions
{
    public static class CityDtoExtension
    {
        public static City ToEntity(this CityDto dto)
        {
            return new City
            {
                ID = dto.Id,
                CountryId = dto.CountryId
            };
        }
    }
}
