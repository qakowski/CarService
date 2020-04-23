using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SerwisSamochodowy.Commands;

namespace SerwisSamochodowy.Services
{
    public class UploadFIleToServer : IService<UploadFIleCommand, string>
    {
        public async Task<string> Handle(UploadFIleCommand command)
        {
            var fileName = $"{Guid.NewGuid().ToString()}.jpg";
            var filePath = Path.Combine(@"wwwroot\cars", fileName);
            using (var stream = command.file.Data)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            return Path.Combine(@"cars", fileName);
        }
    }
}
