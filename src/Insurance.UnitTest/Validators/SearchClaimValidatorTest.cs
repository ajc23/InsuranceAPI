using FluentValidation;
using Insurance.Api.RequestHandlers;
using Insurance.Api.Validators;
using Insurance.Models.Claim;
using Insurance.Service;
using Moq;
using NUnit.Framework;
using ValidationException = Insurance.Api.Exceptions.ValidationException;

namespace Insurance.UnitTest.Validators
{
    [TestFixture]
    public class SearchClaimValidatorTest
    {
        [Test]
        public void ValidateEmptySearchClaimRequest()
        {
            Mock<IValidatorFactory> validator = new Mock<IValidatorFactory>();
            validator.Setup(c => c.GetValidator<SearchClaimRequest>()).Returns(new SearchClaimRequestValidator());

            var claimService = new Mock<IClaimService>();
            var requestHandler = new ClaimRequestHandler(claimService.Object, validator.Object);

            var model = new SearchClaimRequest();

            var result = Assert.Throws<ValidationException>(() => requestHandler.GetClaim(model));

            Assert.AreEqual("Error occurred validating entity", result.Message);
            Assert.IsFalse(result.ValidationResult.IsValid);
            Assert.AreEqual("Please specify a ClaimNumber", result.ValidationResult.Errors[0].ErrorMessage);

            claimService.Verify(c => c.GetClaim(It.IsAny<SearchClaimRequest>()), Times.Never);
        }
    }
}
