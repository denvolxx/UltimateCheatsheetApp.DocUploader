using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocUploader.Services.ExcelUploader
{
    public interface IExcelUploaderService
    {

        Task<string> UploadFileAsync(string value);
    }
}
