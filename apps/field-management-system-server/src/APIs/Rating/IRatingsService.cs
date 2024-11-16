using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;

namespace FieldManagementSystem.APIs;

public interface IRatingsService
{
    /// <summary>
    /// Create one Rating
    /// </summary>
    public Task<Rating> CreateRating(RatingCreateInput rating);

    /// <summary>
    /// Delete one Rating
    /// </summary>
    public Task DeleteRating(RatingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Ratings
    /// </summary>
    public Task<List<Rating>> Ratings(RatingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Rating records
    /// </summary>
    public Task<MetadataDto> RatingsMeta(RatingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Rating
    /// </summary>
    public Task<Rating> Rating(RatingWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Rating
    /// </summary>
    public Task UpdateRating(RatingWhereUniqueInput uniqueId, RatingUpdateInput updateDto);
}
