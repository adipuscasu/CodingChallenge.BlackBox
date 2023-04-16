using BlackBox.BusinessLogic;
using System.Text;

namespace BlackBox.Test
{
    public class BlackboxHelperShould
    {
        private readonly string _testFileName = "blackbox.dat";
        private readonly Dictionary<string, byte[]> _expectedDict = new Dictionary<string, byte[]>
        {
            { "description1", new byte[] { 0xff, 0xd8, 0xff, 0xd9 } },
            { "description2", new byte[] { 0xff, 0xd8, 0xff, 0xd9 } },
        };

        [Fact]
        public void FillDictionary_AddsEntriesToDictionary()
        {
            // Arrange
            using (FileStream fs = new FileStream(_testFileName, FileMode.Create))
            {
                byte[] testData = new byte[]
                {
                0xff, 0xd8, // Start of image
                0xff, 0xd9, // End of image
                };
                fs.Write(Encoding.UTF8.GetBytes("description1"));
                fs.Write(testData, 0, testData.Length);
                fs.Write(Encoding.UTF8.GetBytes("description2"));
                fs.Write(testData, 0, testData.Length);
            }

            Dictionary<string, byte[]> blackbox = new();


            // Act
            BlackboxHelper.FillDictionary(_testFileName, blackbox);

            // Assert
            Assert.Equal(_expectedDict.Count, blackbox.Count);

            foreach (var expectedEntry in _expectedDict)
            {
                Assert.True(blackbox.ContainsKey(expectedEntry.Key));
                Assert.Equal(expectedEntry.Value, blackbox[expectedEntry.Key]);
            }
        }

    }
}
