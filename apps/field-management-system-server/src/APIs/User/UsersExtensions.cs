using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class UsersExtensions
{
    public static User ToDto(this UserDbModel model)
    {
        return new User
        {
            Avatar = model.Avatar,
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Facebook = model.Facebook,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            Roles = model.Roles,
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
            Whatsapp = model.Whatsapp,
        };
    }

    public static UserDbModel ToModel(this UserUpdateInput updateDto, UserWhereUniqueInput uniqueId)
    {
        var user = new UserDbModel
        {
            Id = uniqueId.Id,
            Avatar = updateDto.Avatar,
            Email = updateDto.Email,
            Facebook = updateDto.Facebook,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            PhoneNumber = updateDto.PhoneNumber,
            Whatsapp = updateDto.Whatsapp
        };

        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }

        return user;
    }
}
