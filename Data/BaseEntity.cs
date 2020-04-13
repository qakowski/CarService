using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SerwisSamochodowy.Mongo;

namespace SerwisSamochodowy.Data
{
    public class BaseEntity : IBase
    {
        public ObjectId Id { get; set ; }
    }
}
