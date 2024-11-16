using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;

namespace FieldManagementSystem.APIs;

public interface IPasswordRecoveryLogsService
{
    /// <summary>
    /// Create one PasswordRecoveryLog
    /// </summary>
    public Task<PasswordRecoveryLog> CreatePasswordRecoveryLog(
        PasswordRecoveryLogCreateInput passwordrecoverylog
    );

    /// <summary>
    /// Delete one PasswordRecoveryLog
    /// </summary>
    public Task DeletePasswordRecoveryLog(PasswordRecoveryLogWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PasswordRecoveryLogs
    /// </summary>
    public Task<List<PasswordRecoveryLog>> PasswordRecoveryLogs(
        PasswordRecoveryLogFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PasswordRecoveryLog records
    /// </summary>
    public Task<MetadataDto> PasswordRecoveryLogsMeta(PasswordRecoveryLogFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PasswordRecoveryLog
    /// </summary>
    public Task<PasswordRecoveryLog> PasswordRecoveryLog(
        PasswordRecoveryLogWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one PasswordRecoveryLog
    /// </summary>
    public Task UpdatePasswordRecoveryLog(
        PasswordRecoveryLogWhereUniqueInput uniqueId,
        PasswordRecoveryLogUpdateInput updateDto
    );
}
