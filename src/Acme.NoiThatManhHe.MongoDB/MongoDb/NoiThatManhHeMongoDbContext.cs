using Acme.NoiThatManhHe.Assets;
using Acme.NoiThatManhHe.Designs;
using Acme.NoiThatManhHe.Products;
using Acme.NoiThatManhHe.Projects;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Acme.NoiThatManhHe.MongoDB;

[ConnectionStringName("Default")]
public class NoiThatManhHeMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<Image> Assets => Collection<Image>();
    public IMongoCollection<Customer> Customers => Collection<Customer>();
    public IMongoCollection<Design> Designs => Collection<Design>();
    public IMongoCollection<DesignCategory> DesignCategories => Collection<DesignCategory>();
    public IMongoCollection<DesignType> DesignTypes => Collection<DesignType>();
    public IMongoCollection<Product> Products => Collection<Product>();
    public IMongoCollection<ProductCategory> ProductCategories => Collection<ProductCategory>();
    public IMongoCollection<ProductType> ProductTypes => Collection<ProductType>();
    public IMongoCollection<Project> Projects => Collection<Project>();
    
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //builder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
