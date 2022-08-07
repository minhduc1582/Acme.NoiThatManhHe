using Acme.NoiThatManhHe.Assets;
using Acme.NoiThatManhHe.Designs;
using Acme.NoiThatManhHe.Products;
using Acme.NoiThatManhHe.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe
{
    internal class NoiThatManhHeDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Image, Guid> _imageRepository;
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<Design, Guid> _designRepository;
        private readonly IRepository<DesignCategory, Guid> _designCategoryRepository;
        private readonly IRepository<DesignType, Guid> _designTypeRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<ProductCategory, Guid> _productCategoryRepository;
        private readonly IRepository<ProductType, Guid> _productTypeRepository;
        private readonly IRepository<Project, Guid> _projectRepository;

        public NoiThatManhHeDataSeederContributor(IRepository<Image, Guid> imageRepository,
            IRepository<Customer, Guid> customerRepository,
            IRepository<Design, Guid> designRepository,
            IRepository<DesignCategory, Guid> designCategoryRepository,
            IRepository<DesignType, Guid> designTypeRepository,
            IRepository<Product, Guid> productRepository,
            IRepository<ProductCategory, Guid> productCategoryRepository,
            IRepository<ProductType, Guid> productTypeRepository,
            IRepository<Project, Guid> projectRepository  
            
        )
        {
            _imageRepository = imageRepository;
            _customerRepository = customerRepository;
            _designRepository = designRepository;
            _designCategoryRepository = designCategoryRepository;
            _designTypeRepository = designTypeRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productTypeRepository = productTypeRepository;
            _projectRepository = projectRepository;

        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _productCategoryRepository.GetCountAsync() > 0  )
            {
                return;
            }
            // PRODUCT CATEGORY
            var Cabinets = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "Tủ Bếp"
                },
                autoSave : true
            );
            var Bedroom = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "Bộ Phòng Ngủ"
                },
                autoSave: true
            );
            var Bunk = await _productCategoryRepository.InsertAsync(
                new ProductCategory
                {
                    Name = "Giường Tầng"
                },
                autoSave: true
            );
            // PRODUCT TYPE
            var NaturalWood = await _productTypeRepository.InsertAsync(
                new ProductType
                {
                    ProductCategoryId = Cabinets.Id,
                    Name = "Tủ Bếp Gỗ Tự Nhiên",
                    Description = "Ngày nay có rất nhiều loại vật liệu làm tủ bếp mới ra đời để đáp ứng nhu cầu cho người dùng về tính thẩm mỹ cũng như sự tiện lợi. Thế nhưng Tủ Bếp Gỗ Tự Nhiên vẫn rất được các gia chủ yêu thích bởi nhiều tính năng nổi bật, sang trọng, đẳng cấp và độ bền đẹp của nó mang lại cho không gian nhà bếp."
                },
                autoSave: true
            );
            var IndustryWood = await _productTypeRepository.InsertAsync(
                new ProductType
                {
                    ProductCategoryId = Cabinets.Id,
                    Name = "Tủ bếp gỗ công nghiệp",
                    Description = "Tủ bếp gỗ công nghiệp đẹp, hiện đại với nhiều kiểu dáng và vật liệu khác nhau như tủ bếp gỗ MDF, gỗ HDF, gỗ MFC phủ bề mặt Melamine, Acrylic, Laminate.... đang được xem là dẫn đầu xu hướng trong thị trường tủ bếp. Với những ưu điểm vượt trội từ tính thẩm mỹ cao, công năng đa dạng, giá thành hợp lý... mà tủ bếp gỗ công nghiệp mang lại thì nó xứng đáng trở thành lựa chọn ưu tiên cho mọi gia đình."
                },
                autoSave: true
            );
            var BoyBedroom = await _productTypeRepository.InsertAsync(
                new ProductType
                {
                    ProductCategoryId = Bedroom.Id,
                    Name = "Phòng ngủ bé trai",
                    Description = "Thiết kế phòng ngủ cho bé trai là một trong những chủ đề mà Nội thất Mạnh Hệ nhận được nhiều nhất từ khách hàng trong thời gian vừa qua. Nắm bắt được nhu cầu và xu hướng của nhiều bậc phụ huynh, chúng tôi gợi ý cho các bạn một số mẫu thiết kế nội thất phòng ngủ dành cho bé trai theo phong cách hiện đại cute, trẻ trung, năng động, phù hợp với mọi lứa tuổi."
                },
                autoSave: true
            );
            var GirlBedroom = await _productTypeRepository.InsertAsync(
                new ProductType
                {
                    ProductCategoryId = Bedroom.Id,
                    Name = "Phòng ngủ bé gái",
                    Description = "Đối với các bé gái 10-12-15 tuổi thì đây là độ tuổi mà các bé đang dần hình thành phát triển suy nghĩ cũng như tư duy của mình. Vì thế nên, ngoài môi trường ở bên ngoài như trường học, lớp học thêm, lớp kĩ năng mềm,..thì khi về nhà, không gian phòng ngủ cũng được xem là một điều khá quan trọng đối với các bé.Vì vậy, " +
                    "các ông bố bà mẹ cần nên chú ý nhiều hơn nữa trong thiết kế nội thất phòng ngủ của bé gái.Khiến không gian phòng ngủ của các con trở thành một không gian vui chơi, "+
                    "học tập cũng như nghỉ ngơi.Ngoài ra,phòng ngủ của bé gái cũng là nơi để kích thích trí sáng tạo,học tập của bé.Vậy hãy cùng Nội thất Mạnh Hệ điểm qua những mẫu thiết kế phòng ngủ bé gái màu hồng - xanh dễ thương, sinh động dưới đây để có thêm ý tưởng thiết kế phòng ngủ cho bé nhà mình nhé!"
                },
                autoSave: true
            );
            // PRODUCT
            var TB23 =await _productRepository.InsertAsync(
                new Product
                {
                    ProductTypeId = NaturalWood.Id,
                    Name = "Tủ Bếp gỗ sồi tự nhiên TB23",
                    Price = 5270000,
                    WarrantyPeriod = "2 năm",
                    ImageAvatarUrl = "https://noithatmanhhe.vn/media/22873/thiet-ke-tu-bep-noi-that-manh-he.jpg"
                }
            );
            var TB19 = await _productRepository.InsertAsync(
                new Product
                {
                    ProductTypeId = NaturalWood.Id,
                    Name = "Tủ Bếp gỗ sồi tự nhiên TB19",
                    Price = 5270000,
                    WarrantyPeriod = "2 năm",
                    ImageAvatarUrl = "https://noithatmanhhe.vn/media/22894/tu-bep-go-soi-noi-that-manh-he.jpg"
                }
            );
            // DESIGNs 
            //DESIGN TYPE
            var Apartment = await _designTypeRepository.InsertAsync(
                new DesignType
                {
                    Name = "Chung Cư"
                }    
            );
            var Townhouse = await _designTypeRepository.InsertAsync(
                new DesignType
                {
                    Name = "Nhà Phố"
                }
            );
            var Villa = await _designTypeRepository.InsertAsync(
                new DesignType
                {
                    Name = "Biệt Thự"
                }
            );
            var Office = await _designTypeRepository.InsertAsync(
                new DesignType
                {
                    Name = "Văn Phòng"
                }
            );
            var LivingRoom = await _designTypeRepository.InsertAsync(
                new DesignType
                {
                    Name = "Phòng Khách"
                }
            );
            var BRoom = await _designTypeRepository.InsertAsync(
                new DesignType
                {
                    Name = "Phòng Ngủ"
                }
            );
            // DESIGN CATEGORY
            var AppartmentOneBedroom = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = Apartment.Id,
                    Name = "Mẫu thiết kế nội thất căn hộ chung cư 1 phòng ngủ từ 35 - 54m2"
                }    
            );
            var AppartmentTwoBedroom = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = Apartment.Id,
                    Name = "Mẫu thiết kế nội thất căn hộ chung cư 2 phòng ngủ từ 55m2 - 79m2"
                }
            );
            var AppartmentThreeBedroom = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = Apartment.Id,
                    Name = "Mẫu thiết kế nội thất chung cư 3 phòng ngủ từ 80m2 – 130m2"
                }
            );
            var TownHouse1 = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = Townhouse.Id,
                    Name = "Mẫu thiết kế nội thất nhà phố đẹp hiện đại"
                }
            );
            var TownHouse2 = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = Townhouse.Id,
                    Name = "Mẫu thiết kế nội thất nhà phố cao cấp"
                }
            );
            var TownHouse3 = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = Townhouse.Id,
                    Name = "Mẫu thiết kế nội thất nhà phố phong cách tân cổ điển - cổ điển"
                }
            );
            var BRoom1 = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = BRoom.Id,
                    Name = "Mẫu thiết kế nội thất phòng ngủ nhỏ từ 5m2 - 8m2"
                }
            ); 
            
            var BRoom2 = await _designCategoryRepository.InsertAsync(
                new DesignCategory
                {
                    DesignTypeId = BRoom.Id,
                    Name = "Mẫu thiết kế phòng ngủ sang trọng hiện đại từ 9m2 - 14m2"
                }
            );
            // CUSTOMER
            var cus1 = await _customerRepository.InsertAsync(
                new Customer
                {
                    CustomerName = "Gia đình anh Tâm",
                    Address = "Quy Nhơn - Bình Định"
                }
            );

            // Project

            var pr1 = await _projectRepository.InsertAsync(
                new Project
                {
                    DesignTypeId = Townhouse.Id,
                    CustomerId = cus1.Id,
                    Name = "Hoàn thiện nội thất nhà phố Bình Định - 4PN",
                    ConstructionName = "Thi công nội thất nhà phố Bình Định",
                    Area = 0,
                    Items = "Phòng khách, phòng bếp, phòng sinh hoạt chung, phòng thờ, 4 phòng ngủ",
                    Style = "Hiện đại",
                    AvatarUrl = "https://noithatmanhhe.vn/media/31174/11-thi-cong-noi-that-phong-khach-nha-pho.jpg"
                }    
            );

        }
    }
}
