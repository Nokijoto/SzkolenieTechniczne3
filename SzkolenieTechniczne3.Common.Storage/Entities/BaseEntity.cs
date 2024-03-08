using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.Common.Storage.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid ID { get; set; }
    }
}
