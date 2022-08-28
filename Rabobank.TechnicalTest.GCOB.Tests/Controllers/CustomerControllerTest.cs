using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Rabobank.TechnicalTest.GCOB.Controllers;
using Rabobank.TechnicalTest.GCOB.Dtos;
using Rabobank.TechnicalTest.GCOB.Services;

namespace Rabobank.TechnicalTest.GCOB.Tests.Services
{
    [TestClass]
    public class CustomerControllerTest
    {

        private IFixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Customize<BindingInfo>(c => c.OmitAutoProperties());
            _fixture.Freeze<Mock<ILogger>>();
        }


        [TestMethod]
        public async Task Get_GivenTheCustomerExistsInDB_WhenICallGet_ThenTheCustomerIsReturned()
        {
            // Arrange
            var customerDto = _fixture.Create<CustomerDto>();
            _fixture.Freeze<Mock<ICustomerService>>().Setup(x => x.GetCustomer(customerDto.Id)).Returns(Task.FromResult(Result<CustomerDto>.Success(customerDto)));
            var sut = _fixture.Create<CustomerController>();
            
            // Act
            var result = await sut.Get(customerDto.Id);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var resultValue = ((OkObjectResult) result).Value as CustomerDto;
            resultValue.Should().NotBeNull();
            resultValue.Should().BeEquivalentTo(customerDto);
        }
    }
}