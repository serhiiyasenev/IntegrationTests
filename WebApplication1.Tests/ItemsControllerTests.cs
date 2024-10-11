using NUnit.Framework;

namespace WebApplication1.Tests
{
    public class ItemsControllerTests : BaseTest
    {
        [Test]
        public async Task GetItems_ReturnsOkResult()
        {
            // Act
            var response = await _client.GetAsync("/api/items");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.That(responseString, Does.Contain("Item1"));
            Assert.That(responseString, Does.Contain("Item2"));
        }
    }
}
