using System.Runtime.CompilerServices;
using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.Storage.Entities;

namespace SzkolenieTechniczne3.Geo.Extensions
{
    public static class CountryDtoExtension
    {
        public static Country ToEntity(this CountryDto dto)
        {
            return new Country
            {
                ID = dto.Id,
                Alpha3Code = dto.Alpha3Code
            };
        }
       
    }
}
