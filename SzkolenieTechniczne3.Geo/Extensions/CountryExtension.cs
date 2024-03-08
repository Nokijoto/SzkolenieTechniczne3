using SzkolenieTechniczne3.Geo.CrossCutting.Dtos;

namespace SzkolenieTechniczne3.Geo.Extensions
{
    public static class CountryExtension
    {
        public static CountryDto ToDto(this CountryDto entity)
        {
            var result = new CountryDto
            {
                Id = entity.Id,
                Name = new Common.CrossCutting.Dtos.LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, T.Name)))
                Alpha3Code = entity.Alpha3Code
            };
            return result;
        }
    }
}
