using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Categories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories
{
    public class Details
    {
        public class Query : IRequest<Result<CategoryDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<CategoryDto>>
        {
			private readonly ICategoriesRepository _categoriesRepository;

			public Handler(ICategoriesRepository categoriesRepository)
            {
				_categoriesRepository = categoriesRepository;
			}

            public async Task<Result<CategoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<CategoryDto>.Success(await _categoriesRepository.GetAsync<CategoryDto>(request.Id));
            }
        }
    }
}