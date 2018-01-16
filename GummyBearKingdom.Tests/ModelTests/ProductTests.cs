using GummyBearKingdom.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GummyBearKingdom.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void GetName_ReturnsReviewName_String()
        {
            //Arrange
            var product = new Product();


            //Act
            var result = product.Name = "Gummy Bear Vitamins";

            //Assert
            Assert.AreEqual("Gummy Bear Vitamins", result);
        }

        [TestMethod]
        public void GetDescription_ReturnsReviewDesc_String()
        {
            //Arrange
            var product = new Product();

            //Act
            var result = product.Description = "MightyVites Children's Gummy Multivitamins: Extra Strength Vitamin A, B6, B12, C, D3, & Biotin";

            //Assert
            Assert.AreEqual("MightyVites Children's Gummy Multivitamins: Extra Strength Vitamin A, B6, B12, C, D3, & Biotin", result);
        }

        [TestMethod]
        public void GetCost_ReturnsReviewCost_Int()
        {
            //Arrange
            var product = new Product();


            //Act
            var result = product.Cost = 20;

            //Assert
            Assert.AreEqual(20, result);
        }
    }
}
