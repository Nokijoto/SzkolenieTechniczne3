using Microsoft.AspNetCore.Mvc.Infrastructure;
using SzkolenieTechniczne3.Common.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne3.Geo.Storage.Entities;

namespace SzkolenieTechniczne3.Geo.Extensions
{
    public static class CityExtension
    {
        public static CityDto ToDto(this City entity)
        {
            var result = new CityDto
            {
                Id = entity.ID,
                Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                CountryId = entity.CountryId

            };
            return result;
        }
    }
}
