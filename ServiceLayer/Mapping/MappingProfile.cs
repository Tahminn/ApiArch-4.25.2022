using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Entities.CustomerEntities;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs.Customer;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<CustomerDetails, CustomerListDto>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookCreateDTO>().ReverseMap();
            CreateMap<Book, BookEditDTO>().ReverseMap();
        }
    }
}
