using ClientsService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsService.Repositories
{
	public interface IClientsRepository
	{
		Task<bool> AddAsync(Client client);
		Task<IEnumerable<Client>> GetAllAsync();
	}
}
