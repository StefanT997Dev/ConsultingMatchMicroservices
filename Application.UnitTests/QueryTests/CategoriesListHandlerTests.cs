using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Categories;
using AutoFixture;
using AutoMapper;
using Domain;
using Infrastructure.RepositoriesImpl;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Categories.List;

namespace Application.UnitTests.QueryTests
{
	public class CategoriesListHandlerTests : HandlerBase<ICategoriesRepository>
	{
		private readonly Handler _sut;
		private readonly Query _query;

		public CategoriesListHandlerTests()
		{
			repository = new Mock<ICategoriesRepository>();
			_sut = new Handler(repository.Object);
			_query = new Query();
		}

		[Theory]
		[InlineData(0, false)]
		[InlineData(5, true)]
		public async Task Handle_BasedOnCategoriesListLength_ReturnsAdequateResult(
			int numberOfEntries,
			bool isSuccess)
		{
			var fixture = new Fixture();
			var listOfCategories = fixture.Build<CategoryDto>().CreateMany(numberOfEntries);
			repository.Setup(repo => repo.GetAllAsync<CategoryDto>())
				.ReturnsAsync(listOfCategories);

			var result = await _sut.Handle(_query, cancellationToken);

			Assert.Equal(isSuccess, result.IsSuccess);
		}
	}
}
