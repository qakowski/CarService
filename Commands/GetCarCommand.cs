using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisSamochodowy.Commands
{
    public class GetCarCommand : ICommand
    {
        public string CallId { get; set; }
    }
}
