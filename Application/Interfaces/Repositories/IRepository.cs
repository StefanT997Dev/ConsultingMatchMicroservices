using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
	public interface IRepository<TInput> 
	{
		Task<TOutput> GetAsync<TOutput>(Expression<Func<TOutput, bool>> expression) where TOutput : class;
		Task<IEnumerable<TOutput>> GetAllAsync<TOutput>() where TOutput : class;
		Task<IEnumerable<TOutput>> FindAsync<TOutput>(Expression<Func<TInput, bool>> expression) where TOutput : class;

		Task<bool> AddAsync<TInputDto>(TInputDto input);
	}
}
