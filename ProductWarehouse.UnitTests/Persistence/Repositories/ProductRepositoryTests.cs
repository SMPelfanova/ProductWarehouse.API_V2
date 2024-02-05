﻿using AutoFixture.AutoMoq;
using AutoFixture;
using FakeItEasy;
using ProductWarehouse.Infrastructure.Http;
using Xunit;
using Microsoft.Extensions.Options;
using ProductWarehouse.Infrastructure.Configuration;
using Serilog;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.UnitTests.Persistence.Repositories;

public class ProductRepositoryTests
{
    [Fact]
    public async Task GetProductsAsync_ReturnsNoResult()
    {
        // Arrange
        var fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization());

        var httpClient = A.Fake<HttpClient>();
        var loggerMock = A.Fake<ILogger>();
        var appDbContext = A.Fake<ApplicationDbContext>();
        var configMock = A.Fake<IOptions<MockyClientOptions>>();
        A.CallTo(() => configMock.Value).Returns(new MockyClientOptions
        {
            BaseUrl = "http://example.com",
            ProductUrl = "/products"
        });
        var mockyClientService = new MockyClientService(httpClient, loggerMock, configMock);

        //var repository = new ProductRepository(appDbContext);

        //// Act
        //var result = await repository.GetProductsAsync();

        // Assert
        //result.Should().BeEmpty();
    }
}