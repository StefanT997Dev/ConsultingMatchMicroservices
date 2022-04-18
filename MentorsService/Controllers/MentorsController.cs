using Confluent.Kafka;
using MentorsService.Entities;
using MentorsService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MentorsService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MentorsController : ControllerBase
	{
		private readonly IMentorsRepository _mentorsRepository;
		private readonly ILogger<MentorsController> _logger;
		private readonly ProducerConfig _config;
		public MentorsController(IMentorsRepository mentorsRepository, ILogger<MentorsController> logger)
		{
			_config = new ProducerConfig
			{
				BootstrapServers = "localhost:9092",
				ClientId = Dns.GetHostName()
			};
			_mentorsRepository = mentorsRepository;
			_logger = logger;
		}

		[HttpPost]
		public async Task<IActionResult> Add(Mentor mentor)
		{
			/*await _mentorsRepository.AddAsync(mentor);

			return Ok();*/

			using (var producer = new ProducerBuilder<Null, string>(_config).Build())
			{
				var message = "poruka";
				var topic = "weblog";

				_logger.LogDebug($"Sending message `{message}` to kafka topic {topic}...");

				if (producer != null)
				{
					producer.Produce(topic, new Message<Null, string> { Value = message }, r =>
					{
						if (!r.Error.IsError)
						{
							_logger.LogDebug($"Wrote to kafka offset: {r.TopicPartitionOffset}");
						}
						else
						{
							throw new Exception($"Failed to write to kafka: {r.Error.Reason}!");
						}
					});

					producer.Flush();

				}
				else
				{
					_logger.LogWarning($"Message not sent: Kafka disabled!");
				}
			}
			return Ok();
		}

		/*var result = await _mentorsRepository.AddAsync(mentor);

		if (result)
		{
			return Ok("Success");
		}
		return BadRequest("Failure");*/


	[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _mentorsRepository.GetAllAsync();

			if (result.Any())
			{
				return Ok(result);
			}
			return Ok("List is empty");
		}
	}
}
