using System.Text;

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

            _blackBox.Clear();

            BlackboxHelper.FillDictionary(_fileName, _blackBox);
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

                // create a BinaryWriter object to write to the output file
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
                // deal with error in UI
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
    }
}
