using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
	public interface IRepository<TInput, P> 
	{
		Task<TOutput> GetAsync<TOutput>(P id) where TOutput : class, IGenericModel<P>;
		Task<IEnumerable<TOutput>> GetAllAsync<TOutput>() where TOutput : class, IGenericModel<P>;
		Task<IEnumerable<TOutput>> FindAsync<TOutput>(Expression<Func<TInput, bool>> expression) where TOutput : class, IGenericModel<P>;

		Task<bool> AddAsync<TInputDto>(TInputDto input);
	}
}
