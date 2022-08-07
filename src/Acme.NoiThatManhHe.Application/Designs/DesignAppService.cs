using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Designs
{
    public class DesignAppService :
        CrudAppService<Design,
                    DesignDto,
                    Guid,
                    PagedAndSortedResultRequestDto,
                    CreateUpdateDesignDto>,
        IDesignAppService
    {
        private readonly IDesignTypeRepository _designTypeRepository;
        private readonly IDesignCategoryRepository _designCategoryRepository;
        public DesignAppService(IRepository<Design, Guid> repository,
            IDesignTypeRepository designTypeRepository,
            IDesignCategoryRepository designCategoryRepository) : base(repository)
        {
            _designTypeRepository = designTypeRepository;
            _designCategoryRepository = designCategoryRepository;
        }

        public async Task<PagedResultDto<DesignDto>>
            GetListByDesignTypeIdAsync(GetDesignDto input)
        {
            //Set a default sorting, if not provided
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(DesignDto.Title);
            }
            var filter = await _designCategoryRepository.GetByDesignTypeId(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();
            List<Guid> ids = filter.Select(a => a.Id).ToList();
            //Get the books
            var designs = await AsyncExecuter.ToListAsync(
                queryable
                    .WhereIf<Design, IQueryable<Design>>(
                        !input.Filter.IsNullOrWhiteSpace(),
                        designCategory => ids.Contains(designCategory.DesignCategoryId)
                        )
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)

                
            );

            //Convert to DTOs
            var designDtos = ObjectMapper.Map<List<Design>, List<DesignDto>>(designs);

            //Get the total count with another query (required for the paging)
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<DesignDto>(
                totalCount,
                designDtos
            );
        }
        public async Task<ListResultDto<DesignCategoryDto>> GetDesignCategoryByDesignTypeIdAsync(GetDesignDto input)
        {
            var designCategories = await _designCategoryRepository.GetByDesignTypeId(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);

            return new ListResultDto<DesignCategoryDto>(
                ObjectMapper.Map<List<DesignCategory>, List<DesignCategoryDto>>(designCategories)
            );
        }
        public async Task<ListResultDto<DesignTypeDto>> GetDesignTypeLookupAsync()
        {
            var designCategories = await _designTypeRepository.GetListAsync();

            return new ListResultDto<DesignTypeDto>(
                ObjectMapper.Map<List<DesignType>, List<DesignTypeDto>>(designCategories)
            );
        }
    }
}
