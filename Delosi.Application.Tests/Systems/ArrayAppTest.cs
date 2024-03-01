namespace Delosi.Application.Tests.Systems
{
    public class ArrayAppTest
    {
        [Fact]
        public void ShouldReturnArrayRotate_WhenArrayIsCorrect()
        {
            //Arrange
            var sut = new ArrayApp();
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

            //Act
            var result = sut.rotateArray(request);

            //Assert
            Assert.Equal(result, response);
        }

        [Fact]
        public void ShouldReturnException_WhenArrayIsInCorrect()
        {
            //Arrange
            var sut = new ArrayApp();
            var request = new int[][]{
                new int[] {1, 2, 3},
                new int[] {4, 5, 6, 7},
                new int[] {8, 9, 10}
            };

            var response = new Exception("");

            //Act
            Action result = () => sut.rotateArray(request);

            //Assert
            Exception exception = Assert.Throws<Exception>(result);
            Assert.Equal("Bad Array", exception.Message);
        }

    }
}
