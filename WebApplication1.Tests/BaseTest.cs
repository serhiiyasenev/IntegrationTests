using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Tests
{
    public abstract class BaseTest
    {
        protected WebApplicationFactory<Startup> _factory;
        protected HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Remove the existing registration.
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IItemRepository));
                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }

                        // Add a mock repository.
                        var mockRepo = new Mock<IItemRepository>();
                        mockRepo.Setup(repo => repo.GetAllItemsAsync()).ReturnsAsync(new List<Item>
                        {
                            new Item { Id = 1, Name = "Item1" },
                            new Item { Id = 2, Name = "Item2" }
                        });

                        services.AddScoped(provider => mockRepo.Object);
                    });
                });

            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}
