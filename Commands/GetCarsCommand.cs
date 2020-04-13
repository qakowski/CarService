using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SerwisSamochodowy.Commands
{
    public class GetCarsCommand : ICommand
    {
        public string ClientName;
        public string CallId;
        public string Producer;
        public string Model;

        public GetCarsCommand(string clientName, string callId, string producer, string model)
        {
            ClientName = clientName;
            CallId = callId;
            Producer = producer;
            Model = model;
        }
    }
}
