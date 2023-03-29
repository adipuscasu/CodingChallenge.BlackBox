using BlackBox.BusinessLogic;
using FluentAssertions;

namespace BlackBox.Test
{
    public class BlackboxParserShould
    {
        [Fact]
        public void HaveAConstructorWithOneStringParameter()
        {
            // Arrange
            System.Reflection.ConstructorInfo[] constructorsInfo = typeof(BlackboxParser).GetConstructors();

            // Assert
            constructorsInfo.Should().NotBeNull();
            constructorsInfo[0].Should().NotBeNull();
            constructorsInfo[0].GetParameters().Should().NotBeNull();
            var parameters = constructorsInfo[0].GetParameters();
            parameters[0].Name.Should().Be("fileName");

        }

        [Fact]
        public void HaveAMethodNamedBuildImageByDescription()
        {
            // Arrange
            System.Reflection.MethodInfo? mi = typeof(BlackboxParser).GetMethod("BuildImageByDescription");

            // Assert
            mi.Should().NotBeNull();
            mi.IsPublic.Should().BeTrue();
            mi.GetParameters().Should().NotBeNull();

        }
    }
}