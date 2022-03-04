using System;
using System.Net;
using FluentValidation;
using Insurance.Api.RequestHandlers;
using Insurance.Api.Validators;
using Insurance.Models.Policy;
using Insurance.Service;
using Moq;
using NUnit.Framework;
using ValidationException = Insurance.Api.Exceptions.ValidationException;

namespace Insurance.UnitTest.Validators
{
    [TestFixture]
    public class SearchPolicyValidatorTest
    {
        [Test]
        public void ValidateEmptySearchPolicyRequest()
        {
            Mock<IValidatorFactory> validator = new Mock<IValidatorFactory>();
            validator.Setup(c => c.GetValidator<SearchPolicyRequest>()).Returns(new SearchPolicyRequestValidator());

            var policyService = new Mock<IPolicyService>();
            var requestHandler = new PolicyRequestHandler(policyService.Object, validator.Object);

            var model = new SearchPolicyRequest();

            var result = Assert.Throws<ValidationException>(() => requestHandler.GetPolicy(model));

            Assert.AreEqual("Error occurred validating entity", result.Message);
            Assert.IsFalse(result.ValidationResult.IsValid);
            Assert.AreEqual("Please specify a PolicyNumber", result.ValidationResult.Errors[0].ErrorMessage);

            policyService.Verify(c => c.FindPolicy(It.IsAny<SearchPolicyRequest>()), Times.Never);
        }

        [Test]
        public void ValidateSearchPolicyRequestMissingDateOfBirth()
        {
            Mock<IValidatorFactory> validator = new Mock<IValidatorFactory>();
            validator.Setup(c => c.GetValidator<SearchPolicyRequest>()).Returns(new SearchPolicyRequestValidator());

            var policyService = new Mock<IPolicyService>();
            var requestHandler = new PolicyRequestHandler(policyService.Object, validator.Object);

            var model = new SearchPolicyRequest
            {
                PolicyNumber = 12345
            };

            var result = Assert.Throws<ValidationException>(() => requestHandler.GetPolicy(model));

            Assert.AreEqual("Error occurred validating entity", result.Message);
            Assert.IsFalse(result.ValidationResult.IsValid);
            Assert.AreEqual("Please specify a DateOfBirth", result.ValidationResult.Errors[0].ErrorMessage);

            policyService.Verify(c => c.FindPolicy(It.IsAny<SearchPolicyRequest>()), Times.Never);
        }

        [Test]
        public void ValidateSearchPolicyRequestWithValidParameters()
        {
            Mock<IValidatorFactory> validator = new Mock<IValidatorFactory>();
            validator.Setup(c => c.GetValidator<SearchPolicyRequest>()).Returns(new SearchPolicyRequestValidator());

            var model = new SearchPolicyRequest
            {
                PolicyNumber = 12345, 
                DateOfBirth = DateTime.Now.AddYears(-30)
            };

            var policyService = new Mock<IPolicyService>();
            policyService.Setup(x => x.FindPolicy(model)).Returns(new SearchPolicyResponse());
            var requestHandler = new PolicyRequestHandler(policyService.Object, validator.Object);

            var result = requestHandler.GetPolicy(model);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            policyService.Verify(c => c.FindPolicy(model), Times.Once);
        }

        [Test]
        public void ValidateSearchPolicyRequestNotFound()
        {
            Mock<IValidatorFactory> validator = new Mock<IValidatorFactory>();
            validator.Setup(c => c.GetValidator<SearchPolicyRequest>()).Returns(new SearchPolicyRequestValidator());

            var model = new SearchPolicyRequest
            {
                PolicyNumber = 12345,
                DateOfBirth = DateTime.Now.AddYears(-30)
            };

            var policyService = new Mock<IPolicyService>();
            var requestHandler = new PolicyRequestHandler(policyService.Object, validator.Object);

            var result = requestHandler.GetPolicy(model);

            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);

            policyService.Verify(c => c.FindPolicy(model), Times.Once);
        }
    }
}
