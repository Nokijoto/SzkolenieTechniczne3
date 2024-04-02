using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.CrossCutting.Dtos;
using SzkolenieTechniczne3.Common.CrossCutting.Validationattributes;

namespace SzkolenieTechniczne3.Geo.CrossCutting.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }

        [LocalizedStringRequiredAttribute]
        [LocalizedStringLength(32)]
        public LocalizedString Name { get; set; }

        [Required]
        public Guid CountryId { get; set; }
    }
}
