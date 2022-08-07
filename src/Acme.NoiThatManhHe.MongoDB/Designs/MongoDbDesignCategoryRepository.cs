using Acme.NoiThatManhHe.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Acme.NoiThatManhHe.Designs
{
    internal class MongoDbDesignCategoryRepository : MongoDbRepository<NoiThatManhHeMongoDbContext, DesignCategory, Guid>,
        IDesignCategoryRepository
    {
        public MongoDbDesignCategoryRepository(IMongoDbContextProvider<NoiThatManhHeMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<DesignCategory>> GetByDesignTypeId(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            var res = await queryable
                .WhereIf<DesignCategory, IMongoQueryable<DesignCategory>>(
                    !filter.IsNullOrWhiteSpace(),
                    designCategory => designCategory.DesignTypeId.Equals(filter)
                )
                .As<IMongoQueryable<DesignCategory>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
            return res;
        }
    }
}
