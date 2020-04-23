using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisSamochodowy.Commands
{
    public class RemoveCarCommand : ICommand
    {
        [Required]
        public string CallId { get; set; }
    }
}
