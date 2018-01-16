using GummyBearKingdom.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GummyBearKingdom.Tests
{
    [TestClass]
    public class ReviewTests
    {
        
        [TestMethod]
        public void GetAuthor_ReturnsReviewAuthor_String()
        {
            //Arrange
            var review = new Review();


            //Act
            var result = review.Author = "Jane";

            //Assert
            Assert.AreEqual("Jane", result);
        }

        [TestMethod]
        public void GetRating_ReturnsReviewRating_Int()
        {
            //Arrange
            var review = new Review();


            //Act
            var result = review.Rating = 4;

            //Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void GetContentBody_ReturnsReviewContentBody_String()
        {
            //Arrange
            var review = new Review();


            //Act
            var result = review.Content_Body = "Its a Decent Product";

            //Assert
            Assert.AreEqual("Its a Decent Product", result);
        }

       
    }
}
