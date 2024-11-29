using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocUploader.DTO
{
    public class ProductDTO
    {
        public string? Name { get; set; }
        public string? Price { get; set; }
    }
}
