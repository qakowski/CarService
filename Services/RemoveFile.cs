using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SerwisSamochodowy.Commands;

namespace SerwisSamochodowy.Services
{
    public class RemoveFile : IService<RemoveFileCommand>
    {
        public Task Handle(RemoveFileCommand command)
        {
            var fileName = command.FilePath;
            var filePath = Path.Combine(@"wwwroot\", fileName);
            File.Delete(filePath);
            return Task.CompletedTask;
        }
    }
}
