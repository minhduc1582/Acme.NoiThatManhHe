using Acme.NoiThatManhHe.Assets;
using Acme.NoiThatManhHe.Designs;
using Acme.NoiThatManhHe.Images;
using Acme.NoiThatManhHe.Products;
using Acme.NoiThatManhHe.Projects;
using Acme.NoiThatManhHe.Web.Pages.Projects;
using AutoMapper;
using static Acme.NoiThatManhHe.Web.Pages.Designs.CreateModalModel;
using static Acme.NoiThatManhHe.Web.Pages.Designs.EditModalModel;
using static Acme.NoiThatManhHe.Web.Pages.Images.EditModalModel;
using static Acme.NoiThatManhHe.Web.Pages.Products.CreateModalModel;
using static Acme.NoiThatManhHe.Web.Pages.Products.EditModalModel;
using static Acme.NoiThatManhHe.Web.Pages.Projects.CreateModalModel;
using static Acme.NoiThatManhHe.Web.Pages.Projects.EditModalModel;

namespace Acme.NoiThatManhHe.Web;

public class NoiThatManhHeWebAutoMapperProfile : Profile
{
    public NoiThatManhHeWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<ProductType, ProductTypeLookupDto>();
        CreateMap<CreateBookViewModel, CreateUpdateProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<CreateProjectViewModel, CreateUpdateProjectDto>();
        CreateMap<CreateProjectViewModel, CreateUpdateCustomerDto>();
        CreateMap<ProductDto, EditBookViewModel>();
        CreateMap<EditBookViewModel, CreateUpdateProductDto>();
        CreateMap<CreateUpdateProjectDto, Project>();
        CreateMap<CreateUpdateCustomerDto, Customer>();
        CreateMap<CreateUpdateProjectDto, ProjectDto>();
        CreateMap<CreateUpdateCustomerDto, CustomerDto>();
        CreateMap<ProjectDto, EditProjectViewModel>();
        CreateMap<ProjectDto, Project>();
        CreateMap<CreateDesignViewModel, CreateUpdateDesignDto>();
        CreateMap<CreateUpdateDesignDto, Design>();
        CreateMap<CreateUpdateDesignDto, DesignDto>();
        CreateMap<Design, DesignDto>();
        CreateMap<DesignDto, CreateUpdateDesignDto>();
        CreateMap<DesignDto, EditDesignModel>(); 
        CreateMap<EditDesignModel, CreateUpdateDesignDto>();
        CreateMap<Image, ImageDto>();
        CreateMap<CreateUpdateImageDto, Image>();
        CreateMap<ImageDto, EditImageViewModel>();
        CreateMap<ImageDto, CreateUpdateImageDto>();
    }
}
