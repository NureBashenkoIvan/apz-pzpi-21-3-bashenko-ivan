using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges);
        Task<IEnumerable<CompanyDto>> GetAllCompaniesForUserAsync(string userId, CompanyParameters companyParameters, bool trackChanges);
        Task<CompanyDto> GetCompanyAsync(Guid id, bool trackChanges);
        Task<CompanyDto> CreateCompanyAsync(string userId, CreateUpdateCompanyDto company);
        Task DeleteCompanyAsync(Guid id, bool trackChanges);
        Task UpdateCompanyAsync(Guid companyId, CreateUpdateCompanyDto companyForUpdate, bool trackChanges);
    }
}
