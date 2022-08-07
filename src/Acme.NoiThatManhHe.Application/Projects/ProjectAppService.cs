using Acme.NoiThatManhHe.Designs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Projects
{
    public class ProjectAppService :
        CrudAppService<Project,
                    ProjectDto,
                    Guid,
                    PagedAndSortedResultRequestDto,
                    CreateUpdateProjectDto>,
        IProjectAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDesignTypeRepository _designTypeRepository;
        public ProjectAppService(IRepository<Project, Guid> repository,
            ICustomerRepository customerRepository, IDesignTypeRepository designTypeRepository)
            : base(repository)
        {
            _customerRepository = customerRepository;
            _designTypeRepository = designTypeRepository;
        }

        public async Task<ListResultDto<DesignTypeDto>> GetDesignTypeLookupAsync()
        {
            var designTypes = await _designTypeRepository.GetListAsync();

            return new ListResultDto<DesignTypeDto>(
                ObjectMapper.Map<List<DesignType>, List<DesignTypeDto>>(designTypes)
            );
        }
        private async Task<Dictionary<Guid, Customer>>
            GetCustomerDictionaryAsync(List<Project> projects)
        {
            var customerIds = projects
                .Select(b => b.CustomerId)
                .Distinct()
                .ToArray();

            var queryable = await _customerRepository.GetQueryableAsync();

            var customers = await AsyncExecuter.ToListAsync(
                queryable.Where(a => customerIds.Contains(a.Id))
            );

            return customers.ToDictionary(x => x.Id, x => x);
        }
        public async override Task<PagedResultDto<ProjectDto>>
            GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Set a default sorting, if not provided
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Project.Name);
            }

            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Get the books
            var projects = await AsyncExecuter.ToListAsync(
                queryable
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
            );

            //Convert to DTOs
            var projectDtos = ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects);

            //Get a lookup dictionary for the related authors
            var customerDictionary = await GetCustomerDictionaryAsync(projects);

            //Set AuthorName for the DTOs
            projectDtos.ForEach(projectDto => {
                projectDto.CustomerName = customerDictionary[projectDto.CustomerId].CustomerName;
                projectDto.Address = customerDictionary[projectDto.CustomerId].Address;

            });

            //Get the total count with another query (required for the paging)
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ProjectDto>(
                totalCount,
                projectDtos
            );
        }
    }
}
