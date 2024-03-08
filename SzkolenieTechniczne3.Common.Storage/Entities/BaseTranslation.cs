using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.CrossCutting.Interfaces;

namespace SzkolenieTechniczne3.Common.Storage.Entities
{
    [Index(nameof(LanguageCode),IsUnique = false)]
    public class BaseTranslation:BaseEntity, IEntityTranslation
    {
        [MaxLength(16)]
        [Required]
        public string LanguageCode { get; set; } = null!;
    }
}
