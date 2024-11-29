using AutoMapper;
using DocUploader.DTO;
using DocUploader.Models;

namespace DocUploader.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>();
        }
    }
}
