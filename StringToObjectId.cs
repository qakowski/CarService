using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SerwisSamochodowy
{
    public static class StringToObjectId
    {
        public static ObjectId ToObjectId(this string value)
        {
            if (ObjectId.TryParse(value, out ObjectId parsed)) 
                return parsed;

            return ObjectId.Empty;
        }
    }
}
