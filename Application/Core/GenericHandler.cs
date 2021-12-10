using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
	public class GenericHandler<TInput, P>
	{
		protected readonly IRepository<TInput, P> repository;

		public GenericHandler(IRepository<TInput, P> repository)
		{
			this.repository = repository;
		}
	}
}
