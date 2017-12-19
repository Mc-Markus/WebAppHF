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
        public void CreateTestWithEmptyRestaurant()
        {
            //arrange
            IResetaurantRepo repo = new RestaurantRepo();
            Restaurant input = new Restaurant();
            AdminController controller = new AdminController();

            //act
            bool result = controller.Create(input);

            //assert
            Assert.False(result);
        }

        //[Fact]
        //public void CreateTest()
        //{
        //    //arrange
        //    IResetaurantRepo repo = new RestaurantRepo();
        //    Restaurant input = new Restaurant();
        //    AdminController controller = new AdminController();
        //    input.Name = "The Fancy Place";
        //    input.Price = 123;
        //    input.ReducedPrice = 12;
        //    input.RestaurantIMGString = "Woof.img";
        //    input.Stars = 4;
        //    input.Address = "Waterkade";
        //    input.FoodTypes = "Nederlands, Vis";
        //    input.FoodIMGString = "Vis.img";
        //    //act
        //    bool result = controller.Create(input);

        //    //assert
        //    Assert.True(result);
        //}

        [Fact]
        public void DeleteTest()
        {
            //arrange
            AdminController controller = new AdminController();
            IResetaurantRepo repo = new RestaurantRepo();
            //act
            controller.Delete(17);
            //assert
            Assert.Null(repo.GetRestaurant(17));
        }
    }
}
