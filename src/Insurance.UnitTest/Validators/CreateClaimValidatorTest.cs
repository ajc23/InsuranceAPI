using System;
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
    public class CreateClaimValidatorTest
    {
        private Mock<IClaimService> claimService;
        private Mock<IValidatorFactory> validator;
        private ClaimRequestHandler requestHandler;

        [SetUp]
        public void Setup()
        {
            validator = new Mock<IValidatorFactory>();
            validator.Setup(c => c.GetValidator<CreateClaimRequest>()).Returns(new CreateClaimRequestValidator());

            claimService = new Mock<IClaimService>();
            requestHandler = new ClaimRequestHandler(claimService.Object, validator.Object);
        }

        [Test]
        public void ValidateEmptyCreateClaimRequest()
        {
            var model = new CreateClaimRequest();

            var result = Assert.Throws<ValidationException>(() => requestHandler.SubmitClaim(model));

            Assert.AreEqual("Error occurred validating entity", result.Message);
            Assert.IsFalse(result.ValidationResult.IsValid);
            Assert.AreEqual("Please specify a PolicyNumber", result.ValidationResult.Errors[0].ErrorMessage);

            claimService.Verify(c => c.SubmitClaim(It.IsAny<CreateClaimRequest>()), Times.Never);
        }

        [Test]
        public void ValidateCreateClaimRequestMissingInsuredId()
        {
            var model = new CreateClaimRequest
            {
                PolicyNumber = 12345
            };

            var result = Assert.Throws<ValidationException>(() => requestHandler.SubmitClaim(model));

            Assert.AreEqual("Error occurred validating entity", result.Message);
            Assert.IsFalse(result.ValidationResult.IsValid);
            Assert.AreEqual("Please specify an InsuredId", result.ValidationResult.Errors[0].ErrorMessage);

            claimService.Verify(c => c.SubmitClaim(It.IsAny<CreateClaimRequest>()), Times.Never);
        }

        [Test]
        public void ValidateCreateClaimRequestMissingCoverCause()
        {
            var model = new CreateClaimRequest
            {
                PolicyNumber = 12345,
                InsuredId = Guid.NewGuid()
            };

            var result = Assert.Throws<ValidationException>(() => requestHandler.SubmitClaim(model));

            Assert.AreEqual("Error occurred validating entity", result.Message);
            Assert.IsFalse(result.ValidationResult.IsValid);
            Assert.AreEqual("Please specify a CoverCause", result.ValidationResult.Errors[0].ErrorMessage);


            claimService.Verify(c => c.SubmitClaim(It.IsAny<CreateClaimRequest>()), Times.Never);
        }

        [Test]
        public void ValidateCreateClaimRequestMissingIncidentDate()
        {
            var model = new CreateClaimRequest
            {
                PolicyNumber = 12345,
                InsuredId = Guid.NewGuid(),
                CoverCause = "DelayedDeparture",
            };

            var result = Assert.Throws<ValidationException>(() => requestHandler.SubmitClaim(model));

            Assert.AreEqual("Error occurred validating entity", result.Message);
            Assert.IsFalse(result.ValidationResult.IsValid);
            Assert.AreEqual("Please specify an IncidentDate", result.ValidationResult.Errors[0].ErrorMessage);

            claimService.Verify(c => c.SubmitClaim(It.IsAny<CreateClaimRequest>()), Times.Never);
        }
    }
}
