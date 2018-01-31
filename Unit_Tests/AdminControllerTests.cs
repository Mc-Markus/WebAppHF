using System;
using System.Linq;
using Xunit;

namespace Unit_Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void DeleteRestaurantConfirmTest()
        {
            //arrange
            AdminController testable = new AdminController();
            int id = 18;
            //act
            bool result = testable.DeleteRestaurantConfirm(id);
            //assert
            Assert.True(result);
        }
    }
}
