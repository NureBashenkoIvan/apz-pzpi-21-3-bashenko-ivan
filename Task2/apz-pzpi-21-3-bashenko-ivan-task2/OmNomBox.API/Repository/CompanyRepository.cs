using Contracts;
using Entities.Models;
using Shared.RequestFeatures;
using Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges) =>
        await FindAll(trackChanges)
                .Search(companyParameters.SearchTerm)
                .Sort(companyParameters.OrderBy)
                .Skip((companyParameters.PageNumber - 1) * companyParameters.PageSize)
                    .Take(companyParameters.PageSize)
                    .ToListAsync();

        public async Task<IEnumerable<Company>> GetCompaniesForUserAsync(string userId, CompanyParameters companyParameters, bool trackChanges) =>
        await FindByCondition(c => c.UserId.Equals(userId), trackChanges)
            .Search(companyParameters.SearchTerm)
            .Skip((companyParameters.PageNumber - 1) * companyParameters.PageSize)
            .Take(companyParameters.PageSize)
            .ToListAsync();

        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
        await FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) => Delete(company);
    }
}
