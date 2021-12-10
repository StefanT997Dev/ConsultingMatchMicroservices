using Application.Interfaces.Repositories.Categories;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace Infrastructure.RepositoriesImpl
{
	public class CategoriesRepository : Repository<Category, Guid>, ICategoriesRepository
	{
		public CategoriesRepository(DataContext context, IMapper mapper) : base(context, mapper)
		{
		}
	}
}
