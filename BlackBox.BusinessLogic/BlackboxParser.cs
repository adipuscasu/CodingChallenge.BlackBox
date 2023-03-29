using BlackBox.BusinessLogic.Extensions;
using System.Text;
using System.Linq;

namespace BlackBox.BusinessLogic
{
    public class BlackboxParser
    {
        private readonly string _fileName;
        Dictionary<string, byte[]> _blackBox = new Dictionary<string, byte[]>();

        public BlackboxParser(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            _fileName = fileName;

            FillDictionary();
        }


        /// <summary>
        /// Retrieves the image coresponding to the description
        /// </summary>
        /// <param name="description"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void BuildImageByDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            string outputPath = Path.GetDirectoryName(_fileName) + "\\" + description + ".jpg";

            try
            {
                // specify the path and filename for the output file
                if (string.IsNullOrEmpty(outputPath))
                {
                    outputPath = $@"C:\temp\\{description}.jpg";
                }

                string directoryPath = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // check if the image file exists
                if (File.Exists(outputPath))
                {
                    // Clean up on Isle 5
                    File.Delete(outputPath);
                }

                // create a StreamWriter object to write to the output file
                using (var stream = File.Open(outputPath, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.Default, false))
                    {
                        bool isImageDataRetrieved = _blackBox.TryGetValue(description, out var imageData);
                        if (isImageDataRetrieved && imageData is not null)
                        {
                            writer.Write(imageData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                // deal with error
                throw;
            }
        }


        /// <summary>
        /// Returns a collection of descriptions loaded from the blackbox file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDescriptions()
        {
            List<string> list = new();

            list.AddRange(from string key in _blackBox.Keys
                          select key);
            return list;
        }

        private void FillDictionary()
        {
            _blackBox.Clear();

            using (FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read))
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

                        bool keyExists = _blackBox.TryGetValue(description, out _);
                        if (keyExists)
                        {
                            description = description.AppendRandomStringSuffix();
                        }

                        bool wasAdded = _blackBox.TryAdd(description, imageData);

                        if (!wasAdded)
                        {
                            throw new ApplicationException($"Could not add key {description}");
                        }
                    }
                }
                //while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //}
            }
        }
    }
}
