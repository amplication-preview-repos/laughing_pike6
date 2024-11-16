using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class RoleFindManyArgs : FindManyInput<Role, RoleWhereInput> { }