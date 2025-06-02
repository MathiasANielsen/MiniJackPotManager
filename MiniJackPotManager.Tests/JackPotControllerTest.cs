using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniJackPotManager.Controllers;
using MiniJackPotManager.Data;
using MiniJackPotManager.Models;
using Xunit;


namespace MiniJackPotManager.UnitTest
{
    public class JackPotControllerTest
    {
        private AppDbContent GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContent>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContent(options);

            context.Jackpots.AddRange(
                new Jackpot { Id = 1, Name = "Jackpot A", SeedValue = 100, HitThreshold = 500, CurrentValue = 100 },
                new Jackpot { Id = 2, Name = "Jackpot B", SeedValue = 200, HitThreshold = 1000, CurrentValue = 200 }
            );

            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetJackpots_ReturnsAllJackpots()
        {
            // Arrange
            var context = GetDbContext();
            var controller = new JackpotsController(context);

            // Act
            var result = await controller.GetJackpots();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Jackpot>>>(result);
            var returnValue = Assert.IsType<List<Jackpot>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task Contribute_InvalidId_ReturnsNotFound()
        {
            var context = GetDbContext();
            var controller = new JackpotsController(context);

            var result = await controller.Contribute(999, new Contribution { Amount = 50 });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Contribute_AddsAmountWithoutReset()
        {
            var context = GetDbContext();
            var controller = new JackpotsController(context);

            var result = await controller.Contribute(1, new Contribution { Amount = 50 });

            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedJackpot = Assert.IsType<Jackpot>(okResult.Value);
            Assert.Equal(150, updatedJackpot.CurrentValue);
        }

        [Fact]
        public async Task Contribute_HitsThreshold_ResetsToSeedValue()
        {
            var context = GetDbContext();
            var controller = new JackpotsController(context);

            var result = await controller.Contribute(1, new Contribution { Amount = 500 });

            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedJackpot = Assert.IsType<Jackpot>(okResult.Value);
            Assert.Equal(100, updatedJackpot.CurrentValue); // SeedValue
        }
    }
}
