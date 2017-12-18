using Xunit;
using WebAppHF.Controllers;
using WebAppHF.Models;
using System.Security.Authentication;

namespace WebAppHF
{
    public class Tests
    {
        [Fact]
        public void CreateTests()
        {
            //Arrange
            Restaurant input = new Restaurant();
            input.Name = "Testhuis";
            input.Price = 1252;
            input.ReducedPrice = 1000;
            input.Address = "Waterstraat 51";
            input.FoodTypes = "Nederlands";
            input.Stars = 4;
            AdminController controller = new AdminController();
            //Act

            //Assert
            Assert.Throws<AuthenticationException>(() => controller.Create(input));
        }

    }

}