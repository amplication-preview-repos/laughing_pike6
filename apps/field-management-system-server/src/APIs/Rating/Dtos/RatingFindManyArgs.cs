using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class RatingFindManyArgs : FindManyInput<Rating, RatingWhereInput> { }
