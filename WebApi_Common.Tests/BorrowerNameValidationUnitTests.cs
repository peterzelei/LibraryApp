using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using WebApi_Common.Models;

namespace WebApi_Common.Tests
{
    [TestClass]
    public class BorrowerNameValidationUnitTests : BorrowerNameValidation
    {
        [DataRow("John Doe")]
        [DataRow("Jane Roe")]
        [DataRow("Richard Roe")]
        [DataTestMethod]
        public void IsValid_WithValidName_ValidationSuccess(string name)
        {
            // Arrange
            var validationContext = new ValidationContext(name);
            var attribute = new BorrowerNameValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(name, validationContext);

            // Assert
            Assert.AreEqual(validationResult, ValidationResult.Success);
        }

        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        public void IsValid_WithNullOrEmpty_ReturnsError(string name)
        {
            // Arrange
            var validationContext = new ValidationContext(name);
            var attribute = new BorrowerNameValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(name, validationContext);

            // Assert
            Assert.AreEqual(validationResult.ErrorMessage, "The name cannot be null or empty");
        }

        [DataRow(" ")]
        [DataRow("\t")]
        [DataRow("\n")]
        [DataRow("\v")]
        [DataTestMethod]
        public void IsValid_WithNullOrWhiteSpace_ReturnsError(string name)
        {
            // Arrange
            var validationContext = new ValidationContext(name);
            var attribute = new BorrowerNameValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(name, validationContext);

            // Assert
            Assert.AreEqual(validationResult.ErrorMessage, "The name cannot be null or whitespace");
        }

        [DataRow("John $Doe")]
        [DataRow("John\tDoe")]
        [DataRow("John\nDoe")]
        [DataRow("John Do@")]
        [DataRow("J\u00AEhn Doe")]
        [DataRow("J?hn Doe")]
        [DataRow("John Do#")]
        [DataTestMethod]
        public void IsValid_WithSpecialCharacter_ReturnsError(string name)
        {
            // Arrange
            var validationContext = new ValidationContext(name);
            var attribute = new BorrowerNameValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(name, validationContext);

            // Assert
            Assert.AreEqual(validationResult.ErrorMessage, "The name cannot special character");
        }
    }
}
