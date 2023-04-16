using BlackBox.BusinessLogic.Extensions;
using System.Text;

namespace BlackBox.BusinessLogic
{
    public static class BlackboxHelper
    {

        /// <summary>
        /// Parses a file consisting of a series of string descriptions and JPEG images. 
        /// Each description/image pair is added into a Dictionary<string, byte[]> object passes as parameter
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="blackbox"></param>
        public static void FillDictionary(string fileName, Dictionary<string, byte[]> blackbox)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                int bytesRead = fs.Read(buffer, 0, buffer.Length);
                int imageCount = 0;
                string description = string.Empty;

                // Search for the "magic number" indicating the start of a JPEG image.
                for (int i = 0; i < bytesRead - 1; i++)
                {

                    if (buffer[i] == 0xff && buffer[i + 1] == 0xd8)
                    {
                        // We found the start of a JPEG image.
                        imageCount++;

                        int k = i;
                        // go back to the end of the previous image or the begining of the buffer
                        while (k < bytesRead - 1 && k >= 1 && !(buffer[k] == 0xff && buffer[k + 1] == 0xd9))
                        {
                            k--;
                        }
                        k = k == 0 ? 0 : k + 2;
                        // get description
                        description = Encoding.UTF8.GetString(buffer[k..i]);

                        // Extract the image from the buffer.
                        int imageStartIndex = i;
                        while (i < bytesRead - 1 && !(buffer[i] == 0xff && buffer[i + 1] == 0xd9))
                        {
                            i++;
                        }
                        int imageEndIndex = i + 1;
                        byte[] imageData = new byte[imageEndIndex - imageStartIndex + 1];

                        Array.Copy(buffer, imageStartIndex, imageData, 0, imageData.Length);

                        blackbox.AddToDictionary(description, imageData);
                    }
                }
            }
        }
    }
}
