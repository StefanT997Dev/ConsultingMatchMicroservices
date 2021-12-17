using Application.Core;
using AutoMapper;
using Domain;
using Infrastructure.RepositoriesImpl;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.UnitTests
{
	public class MentorsRepositoryTests
	{
		[Fact]
		public async Task GetMentorsPaginatedAsync_s_s()
		{
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "DataContextDB")
            .Options;
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfiles());
			});

			// Insert seed data into the database using one instance of the context
			using (var context = new DataContext(options))
			{
				context.Users.AddRange(new AppUser
				{
					DisplayName = "Bob",
					UserName = "bob",
					Email = "bob@test.com",
					Bio = "I am Bob and I'm a software engineer",
					Role = new Role { Name = "Mentor" }
				},
				new AppUser
				{
					DisplayName = "Tom",
					UserName = "tom",
					Email = "tom@test.com",
					Bio = "I am Tom and I'm a software engineer",
					Role = new Role { Name = "Mentor" }
				},
				new AppUser
				{
					DisplayName = "John",
					UserName = "john",
					Email = "john@test.com",
					Bio = "I am John and I'm a software engineer",
					Role = new Role { Name = "Mentor" }
				});
				context.SaveChanges();
			}

			// Use a clean instance of the context to run the test
			using (var context = new DataContext(options))
			{
				MentorsRepository mentorsRepository = new MentorsRepository(context, mappingConfig.CreateMapper());
				var mentors = await mentorsRepository.GetMentorsPaginatedAsync(1, 5, null);

				var mentorsList = mentors.Item1.ToList();

				Assert.Equal(3, mentorsList.Count);
			}
		}
	}
}
