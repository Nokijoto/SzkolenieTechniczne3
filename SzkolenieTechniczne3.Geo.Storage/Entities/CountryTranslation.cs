using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace SzkolenieTechniczne3.Geo.Storage.Entities
{
    [Index(nameof(Name), IsUnique = false)]
    [Table("CountryTranslations", Schema = "Geo")]
    public class CountryTranslation : BaseTranslation
    {
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }

        [MaxLength(64)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; }

    }
}
