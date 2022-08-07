using Acme.NoiThatManhHe.Assets;
using Acme.NoiThatManhHe.Designs;
using Acme.NoiThatManhHe.Images;
using Acme.NoiThatManhHe.Products;
using Acme.NoiThatManhHe.Projects;
using AutoMapper;

namespace Acme.NoiThatManhHe;

public class NoiThatManhHeApplicationAutoMapperProfile : Profile
{
    public NoiThatManhHeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Product, ProductDto>();
        CreateMap<ProductType, ProductTypeDto>();
        CreateMap<ProductCategory, ProductCategoryDto>();
        CreateMap<ProductType, ProductTypeLookupDto>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<Project, ProjectDto>();
        CreateMap<DesignType, DesignTypeDto>();
        CreateMap<DesignCategory, DesignCategoryDto>();
        CreateMap<Image, ImageDto>();

    }
}
