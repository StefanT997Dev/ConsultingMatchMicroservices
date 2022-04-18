using ClientsService.Data;
using ClientsService.Entities;
using ClientsService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClientsController : ControllerBase
	{
		private readonly IClientsRepository _clientsRepository;

		public ClientsController(IClientsRepository clientsRepository)
		{
			_clientsRepository = clientsRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var clients = await _clientsRepository.GetAllAsync();

			if (clients.Any())
			{
				return Ok(clients);
			}
			return Ok("No clients in our database");
		}

		[HttpPost]
		public async Task<IActionResult> Add(Client client)
		{
			var result = await _clientsRepository.AddAsync(client);

			if (result)
			{
				return Ok("Success");
			}
			return BadRequest("Failure");
		}
	}
}
