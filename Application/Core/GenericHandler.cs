using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
	public class GenericHandler<TInput>
	{
		protected readonly IRepository<TInput> repository;

		public GenericHandler(IRepository<TInput> repository)
		{
			this.repository = repository;
		}
	}
}
