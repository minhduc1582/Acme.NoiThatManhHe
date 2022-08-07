using Acme.NoiThatManhHe.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Acme.NoiThatManhHe.Projects
{
    public class MongoDbCustomerRepository : MongoDbRepository<NoiThatManhHeMongoDbContext, Customer, Guid>,
        ICustomerRepository
    {
        public MongoDbCustomerRepository(IMongoDbContextProvider<NoiThatManhHeMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
