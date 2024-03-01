using Delosi.API.Controllers;
using Delosi.Application;
using Delosi.Application.Interface;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Delosi.API.Tests.Systems
{
    public class ArrayControllerTests
    {
        
        [Fact]
        public void ShouldReturnOKResult_WhenArrayIsCorrect()
        {
            //Arrange
            var mockApp = new Mock<IArrayApp>();
            var sut = new ArrayController(mockApp.Object);
            var request = new int[][]{
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9}
            };

            var response = new int[][]{
                new int[] {3, 6, 9},
                new int[] {2, 5, 8},
                new int[] {1, 4, 7}
            };

            mockApp.Setup(service => service.rotateArray(request)).Returns(response);

            //Act
            var result = sut.RotateArray(request);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().BeOfType<int[][]>();
            objectResult.Value.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void ShouldReturnBadRequest_WhenArrayIsInCorrect()
        {
            //Arrange
            var mockApp = new Mock<IArrayApp>();
            var sut = new ArrayController(mockApp.Object);
            var request = new int[][]{
                new int[] {1, 2, 3},
                new int[] {4, 5, 6, 7},
                new int[] {8, 9, 10}
            };

            var response = new Exception("");

            mockApp.Setup(service => service.rotateArray(request)).Throws(response);

            //Act
            var result = sut.RotateArray(request);

            //Assert
            result.Should().BeOfType<BadRequestResult>();
            var objectResult = (BadRequestResult)result;
            objectResult.StatusCode.Should().Be(400);
        }
    }
}
