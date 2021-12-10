using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesImpl
{
	public class Repository<TInput, P> : IRepository<TInput, P> where TInput:class, IGenericModel<P> 
	{
		protected readonly DbContext context;
		protected readonly IMapper mapper;
		protected readonly DbSet<TInput> entities;
		protected readonly IConfigurationProvider mapperConfigurationProvider;

		public Repository(DbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
			entities = this.context.Set<TInput>();
			mapperConfigurationProvider = mapper.ConfigurationProvider;
		}

		public async Task<bool> AddAsync<TInputDto>(TInputDto input)
		{
			entities.Add(mapper.Map<TInput>(input));

			return await context.SaveChangesAsync() > 0;
		}

		public async Task<IEnumerable<TOutput>> FindAsync<TOutput>(Expression<Func<TInput, bool>> expression) where TOutput : class, IGenericModel<P>
		{
			return await entities
				.Where(expression)
				.ProjectTo<TOutput>(mapperConfigurationProvider)
				.ToListAsync();
		}

		public async Task<IEnumerable<TOutput>> GetAllAsync<TOutput>() where TOutput : class, IGenericModel<P>
		{
			return await entities
				.ProjectTo<TOutput>(mapperConfigurationProvider)
				.ToListAsync();
		}

		public async Task<TOutput> GetAsync<TOutput>(P id) where TOutput : class, IGenericModel<P>
		{
			return await entities
				.ProjectTo<TOutput>(mapperConfigurationProvider)
				.FirstOrDefaultAsync(x => x.Id.Equals(id));
		}
	}
}
