using System;
using System.ComponentModel.DataAnnotations;
using SerwisSamochodowy.Data;

namespace SerwisSamochodowy.Commands
{
    public class AddCarCommand : ICommand
    {
        [Required]
        public string Producer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string ClientSureName { get; set; }
        [Required]
        public string ClientForeName { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Opis nie może zawierać więcej niż 250 znaków")]
        public string Description { get; set; }
        [Required]
        public StateEnum State { get; set; }
        public string Photo;
        [Required]
        public DateTime Received;
    }
}
