using Hx.Demo.CognitiveServices.Client;
using Hx.Demo.CognitiveServices.Common;
using System;
using System.IO;

namespace Hx.Demo.CognitiveServices.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IImageServices imageServices = new ImageServices();
            IVisionApiClient visionClient = new VisionApiClient(imageServices);
            IFaceApiClient faceClient = new FaceApiClient(imageServices);

            Console.WriteLine("Analyze an image:");
            Console.Write("Enter the path to the image you wish to analyze: ");

            string imageFilePath = Console.ReadLine();

            if (File.Exists(imageFilePath))
            {
                Console.WriteLine("\nWait a moment for the results to appear.\n");

                //visionClient.MakeAnalysisRequest(imageFilePath).Wait();
                string response = faceClient.MakeDetectRequest(imageFilePath).GetAwaiter().GetResult();
                Console.WriteLine($"\nResponse:\n\n{response}\n");
            }
            else
            {
                Console.WriteLine("\nInvalid file path");
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
