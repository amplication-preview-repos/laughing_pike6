using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class PasswordRecoveryLogsExtensions
{
    public static PasswordRecoveryLog ToDto(this PasswordRecoveryLogDbModel model)
    {
        return new PasswordRecoveryLog
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PasswordRecoveryLogDbModel ToModel(
        this PasswordRecoveryLogUpdateInput updateDto,
        PasswordRecoveryLogWhereUniqueInput uniqueId
    )
    {
        var passwordRecoveryLog = new PasswordRecoveryLogDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            passwordRecoveryLog.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            passwordRecoveryLog.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return passwordRecoveryLog;
    }
}
