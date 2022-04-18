using ClientsService.Data;
using ClientsService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsService.Repositories
{
	public class ClientsRepository : IClientsRepository
	{
		private readonly DataContext _context;

		public ClientsRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<bool> AddAsync(Client client)
		{
			_context.Clients.Add(client);

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<IEnumerable<Client>> GetAllAsync()
		{
			return await _context.Clients.ToListAsync();
		}
	}
}
