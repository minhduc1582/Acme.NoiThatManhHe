using Acme.NoiThatManhHe.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Acme.NoiThatManhHe.Designs
{
    public class MongoDbDesignTypeRepository : MongoDbRepository<NoiThatManhHeMongoDbContext, DesignType, Guid>,
        IDesignTypeRepository
    {
        public MongoDbDesignTypeRepository(IMongoDbContextProvider<NoiThatManhHeMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
