using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Interfaces.Services.Models
{
    public abstract class BaseItemResultModel
    {
        public IEnumerable<ValidationResult> ValidationErrors { get; set; }
        public bool Issuccess { get; set; }
    }
}
