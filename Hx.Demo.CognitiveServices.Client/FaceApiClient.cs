using Hx.Demo.CognitiveServices.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Client
{
    public class FaceApiClient : IFaceApiClient
    {
        #region Fields

        private readonly string subscriptionKey;
        private readonly string faceApiBaseEndPoint;
        private readonly IImageServices imageService;

        #endregion

        #region Constructor

        public FaceApiClient(IImageServices imageService)
        {
            subscriptionKey = ConfigurationManager.AppSettings["subscriptionKey"];
            faceApiBaseEndPoint = ConfigurationManager.AppSettings["faceApiEndPoint"];

            this.imageService = imageService;
        }

        #endregion

        #region IFaceApiClient Implementation Methods

        public async Task<string> MakeDetectRequest(string imageFilePath)
        {
            byte[] byteData = imageService.GetImageAsByteArray(imageFilePath);

            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
            string uri = $"{faceApiBaseEndPoint}detect?{requestParameters}";

            return await MakeRequest(byteData, uri);
        }

        public async Task<string> MakeDetectRequest(byte[] byteData)
        {
            string requestParameters = "returnFaceId=true&returnFaceLandmarks=true&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
            string uri = $"{faceApiBaseEndPoint}detect?{requestParameters}";

            return await MakeRequest(byteData, uri);
        }

        public async Task<string> MakeGetListRequest(string imageFilePath)
        {
            string jsonResponse = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Request headers
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                    string requestParameters = "returnRecognitionModel=false";

                    string uri = $"{faceApiBaseEndPoint}detect?{requestParameters}";

                    // Request body
                    byte[] byteData = imageService.GetImageAsByteArray(imageFilePath);

                    using (var content = new ByteArrayContent(byteData))
                    {
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        using (HttpResponseMessage response = await client.PostAsync(uri, content))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string contentString = await response.Content.ReadAsStringAsync();

                                jsonResponse = JToken.Parse(contentString).ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }

            return jsonResponse;
        }

        #endregion

        private  async Task<string> MakeRequest(byte[] byteData, string uri)
        {
            string jsonResponse = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                    using (var content = new ByteArrayContent(byteData))
                    {
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        using (HttpResponseMessage response = await client.PostAsync(uri, content))
                        {
                            if (response.IsSuccessStatusCode)
                                jsonResponse = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("\n" + e.Message);
            }

            return jsonResponse;
        }

    }
}
