using System;
using System.ComponentModel.DataAnnotations;
using SerwisSamochodowy.Mongo;

namespace SerwisSamochodowy.Data
{
    public class Car : BaseEntity
    {

        public string Producer { get; set; }

        public string Model { get; set; }

        public Client Client { get; set; }

        public string Description { get; set; }

        public StateEnum State { get; set; }

        public string Photo { get; set; }

        public DateTime Received { get; set; }
    }
}
