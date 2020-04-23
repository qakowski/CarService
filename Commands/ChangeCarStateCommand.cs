using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SerwisSamochodowy.Data;

namespace SerwisSamochodowy.Commands
{
    public class ChangeCarStateCommand : ICommand
    {
        [Required]
        public string CallId { get; set; }
        [Required]
        public StateEnum State { get; set; }
    }
}
