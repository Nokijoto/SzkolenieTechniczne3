using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.CrossCutting.Dtos;
using SzkolenieTechniczne3.Common.CrossCutting.Validationattributes;

namespace SzkolenieTechniczne3.Geo.CrossCutting.Dtos
{
    public class CityDto
    {
        public Guid id { get; set; }

        [LocalizedStringRequired]
        [LocalizedStringLength(30)]
        public CountryDto Country { get; set; }
    }
}
