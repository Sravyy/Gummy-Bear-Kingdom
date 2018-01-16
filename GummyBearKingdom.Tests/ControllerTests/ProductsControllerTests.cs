using GummyBearKingdom.Controllers;
using System.Collections.Generic;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace GummyBearKingdom.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
           Mock<IProductRepository> mock = new Mock<IProductRepository>();
           EFProductRepository db = new EFProductRepository(new GummyBearKingdomDbContext());

        private void DbSetup()
            {
                mock.Setup(m => m.Products).Returns(new Product[]
                {
                new Product {ProductId = 1, Name = "Gummies", Cost = 20, Description = "Small Gummies" },
                 new Product {ProductId = 1, Name = "Gummy Bear Tablets", Cost = 30, Description = "Calcium Tablets for Kids" }
                }.AsQueryable());
            }


            [TestMethod]
            public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
            {
                //Arrange
                DbSetup();
                ProductsController controller = new ProductsController(mock.Object);

            //Act
            var result = controller.Index();

                //Assert
                Assert.IsInstanceOfType(result, typeof(ActionResult));
            }

            [TestMethod]
            public void Mock_IndexContainsModelData_List() // Confirms model as list of items
            {
                // Arrange
                DbSetup();
                ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

                // Act
                var result = indexView.ViewData.Model;

                // Assert
                Assert.IsInstanceOfType(result, typeof(List<Product>));
            }

            [TestMethod]
            public void Mock_IndexModelContainsProducts_Collection() // Confirms presence of known entry
            {
                // Arrange
                DbSetup();
                ProductsController controller = new ProductsController(mock.Object);
                Product testProduct = new Product();
                testProduct.ProductId = 1;
                testProduct.Name = "Gummies";
               
           
                // Act
                ViewResult indexView = controller.Index() as ViewResult;
                List<Product> collection = indexView.ViewData.Model as List<Product>;

                // Assert
                CollectionAssert.Contains(collection, testProduct);
            }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Product testProduct = new Product
            {
                //ProductId = 1,
                Name = "Gummies",
                Cost = 20,
                Description = "Best Buy"
            };

            DbSetup();
            ProductsController controller = new ProductsController(db);

            // Act
            var redirectToActionResult = controller.Create(testProduct) as RedirectToActionResult;


            // Assert
            Assert.IsInstanceOfType(redirectToActionResult, typeof(RedirectToActionResult));

        }

        [TestMethod]
        public void DB_CreatesNewEntries_Collection()
        {
            // Arrange
            ProductsController controller = new ProductsController(db);
            Product testProduct = new Product();
            testProduct.Name = "Test Product";
            testProduct.Cost = 10;
            testProduct.Description = "Test Desc";


            // Act
            controller.Create(testProduct);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            // Assert
            CollectionAssert.Contains(collection, testProduct);
        }



        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Gummies",
               
            };

            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            // Act
            var resultView = controller.Details(testProduct.ProductId) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));
        }





    }
}
