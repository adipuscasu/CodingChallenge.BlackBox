using System.Text;

namespace CodingChallenge.BlackBox
{
    public class BlackBoxGenerator
    {
        public void CreateFile(IReadOnlyDictionary<string, byte[]> fileDescriptions, string outputPath)
        {
            try
            {
                // specify the path and filename for the output file
                if (string.IsNullOrEmpty(outputPath))
                {
                    outputPath = @"C:\temp\blackbox.dat";
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

                using (var stream = File.Open(outputPath, FileMode.Create))
                {
                    // create a StreamWriter object to write to the output file
                    using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, false);
                    foreach (KeyValuePair<string, byte[]> keyValuePair in fileDescriptions)
                    {
                        writer.Write(Encoding.UTF8.GetBytes(keyValuePair.Key));
                        writer.Write(keyValuePair.Value);
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

        public static byte[] GetFileContentAsByteArray(string fileName)
        {
            try
            {
                // check if the image file exists
                if (File.Exists(fileName))
                {
                    // read the contents of the image file
                    byte[] imageData = File.ReadAllBytes(fileName);

                    return imageData;
                }
                else { throw new FileNotFoundException(fileName); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
