using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Controllers;
using WebAppHF.Models;
using Xunit;
using Moq;
using WebAppHF.Repositories;

namespace Uni_ttests
{
    public class Class1
    {
        [Fact]
        public void CreateTests()
        {
            //arrange
            IResetaurantRepo repo = new RestaurantRepo();
            Restaurant input = new Restaurant();
            AdminController controller = new AdminController();

            //act
            controller.Create(input);
            
            //assert
            
            
        }

        [Fact]
        public void DeleteTest()
        {
            //arrange
            AdminController controller = new AdminController();
            IResetaurantRepo repo = new RestaurantRepo();
            //act
            controller.Delete(13);
            //assert
            Assert.Null(repo.GetRestaurant(13));
        }
    }
}
