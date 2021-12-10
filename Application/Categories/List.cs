using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Categories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories
{
    public class List
    {
        public class Query : IRequest<Result<List<CategoryDto>>> { }

        public class Handler : GenericHandler<Category, Guid>,IRequestHandler<Query, Result<List<CategoryDto>>>
        {
			public Handler(ICategoriesRepository repository) : base(repository)
			{
			}

			public async Task<Result<List<CategoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var categories = await repository.GetAllAsync<CategoryDto>();

                var categoriesList = categories.ToList();

                if (categoriesList.Any())
                {
                    return Result<List<CategoryDto>>.Failure("Kategorije ne postoje u bazi podataka");
                }

                return Result<List<CategoryDto>>.Success(categoriesList);
            }
        }
    }
}