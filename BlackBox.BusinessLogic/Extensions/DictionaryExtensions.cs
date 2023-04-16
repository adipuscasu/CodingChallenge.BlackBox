namespace BlackBox.BusinessLogic.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddToDictionary(this Dictionary<string, byte[]> dictionary, string key, byte[] value)
        {
            bool keyExists = dictionary.TryGetValue(key, out _);
            if (keyExists)
            {
                key = key.AppendRandomStringSuffix();
            }

            bool wasAdded = dictionary.TryAdd(key, value);
            if (!wasAdded)
            {
                throw new ApplicationException($"Could not add key {key}");
            }
        }
    }
}
