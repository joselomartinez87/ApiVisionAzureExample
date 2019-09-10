using System.IO;

namespace Hx.Demo.CognitiveServices.Common
{
    public class ImageServices : IImageServices
    {
        public byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);

                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}
