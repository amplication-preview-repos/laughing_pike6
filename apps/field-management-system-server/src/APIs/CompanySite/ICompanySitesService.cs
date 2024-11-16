using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;

namespace FieldManagementSystem.APIs;

public interface ICompanySitesService
{
    /// <summary>
    /// Create one CompanySite
    /// </summary>
    public Task<CompanySite> CreateCompanySite(CompanySiteCreateInput companysite);

    /// <summary>
    /// Delete one CompanySite
    /// </summary>
    public Task DeleteCompanySite(CompanySiteWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CompanySites
    /// </summary>
    public Task<List<CompanySite>> CompanySites(CompanySiteFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about CompanySite records
    /// </summary>
    public Task<MetadataDto> CompanySitesMeta(CompanySiteFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CompanySite
    /// </summary>
    public Task<CompanySite> CompanySite(CompanySiteWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CompanySite
    /// </summary>
    public Task UpdateCompanySite(
        CompanySiteWhereUniqueInput uniqueId,
        CompanySiteUpdateInput updateDto
    );
}
