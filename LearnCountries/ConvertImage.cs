using System.IO;

namespace LearnCountries
{
    public static class ConvertImage
    {
        public static byte[] ImageToByteArrayFromFilePath(string imagefilePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagefilePath);
            return imageArray;
        }
    }
}