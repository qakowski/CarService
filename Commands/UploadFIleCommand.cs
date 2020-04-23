using System.ComponentModel.DataAnnotations;
using BlazorInputFile;

namespace SerwisSamochodowy.Commands
{
    public class UploadFIleCommand : ICommand
    {
        [Required]
        public IFileListEntry file;
    }
}
