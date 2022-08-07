using Acme.NoiThatManhHe.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Acme.NoiThatManhHe.Products
{
    public class MongoDBProductTypeRepository : MongoDbRepository<NoiThatManhHeMongoDbContext, ProductType, Guid>,
        IProductTypeRepository
    {
        public MongoDBProductTypeRepository(IMongoDbContextProvider<NoiThatManhHeMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
