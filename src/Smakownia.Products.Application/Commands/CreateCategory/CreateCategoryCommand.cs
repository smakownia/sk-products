﻿using MediatR;
using Smakownia.Products.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Products.Application.Commands.CreateCategory;

public sealed record CreateCategoryCommand : IRequest<Category>
{
    [Required]
    [MinLength(1)]
    public string Name { get; init; } = string.Empty;
}
