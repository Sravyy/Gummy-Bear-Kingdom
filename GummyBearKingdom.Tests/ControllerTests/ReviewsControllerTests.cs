using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GummyBearKingdom.Controllers;
using Moq;
using System;
using System.Linq;

namespace GummyBearKingdom.Tests.ControllerTests
{
    [TestClass]
    public class ReviewsControllerTests 
    {

        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        EFReviewRepository db = new EFReviewRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
          {
                new Review {ReviewId = 1, Author = "Jean", Rating = 4 , Content_Body = "Good One", ProductId=1},
                new Review {ReviewId = 2, Author = "Ben", Rating = 3 , Content_Body = "Satisfied", ProductId=2},
                 new Review {ReviewId = 3, Author = "Sam", Rating = 1 , Content_Body = "Not Good", ProductId=1}
              }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of animals
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Review>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsReviews_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review testReview = new Review();
            testReview.ReviewId = 1;
            testReview.Author = "Jean";
            testReview.Rating = 4;
            testReview.Content_Body = "Good One";
            testReview.ProductId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Review> collection = indexView.ViewData.Model as List<Review>;

            // Assert
            CollectionAssert.Contains(collection, testReview);
        }

        [TestMethod]
        public void Db_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Review testReview = new Review
            {   
                Author ="Shane",
                Rating = 4,
                Content_Body = "Just Ok",
                ProductId = 2
                
            };

            DbSetup();
            ReviewsController controller = new ReviewsController(db);

            // Act
            var redirectToActionResult = controller.Create(testReview) as RedirectToActionResult;


            // Assert
            Assert.IsInstanceOfType(redirectToActionResult, typeof(RedirectToActionResult));

        }
        


    }
}
