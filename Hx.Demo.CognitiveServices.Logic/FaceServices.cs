using Hx.Demo.CognitiveServices.Client;
using Hx.Demo.CognitiveServices.Logic.Interfaces;
using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Logic
{
    internal class FaceServices : IFaceServices
    {
        #region Fields

        private readonly IFaceApiClient _faceClient;
        private readonly IVisionApiClient _visionClient;
        private readonly IFaceMapper _faceMapper;
        private readonly IModerationMapper _moderationMapper;
        private readonly ICelebritiesMapper _celebritiesMapper;

        #endregion

        #region Constructor

        public FaceServices(
            IFaceApiClient faceClient,
            IVisionApiClient visionClient,
            IFaceMapper faceMapper,
            IModerationMapper moderationMapper,
            ICelebritiesMapper celebritiesMapper)
        {
            _faceClient = faceClient;
            _visionClient = visionClient;
            _faceMapper = faceMapper;
            _moderationMapper = moderationMapper;
            _celebritiesMapper= celebritiesMapper;
        }

        #endregion

        #region IFaceServices Implementation Methods

        public async Task<List<JsonResult>> LoadImageFaceInformation(string imageFilePath)
        {
            List<JsonResult> jsonResults = new List<JsonResult>();

            string facesDetectedJson = await _faceClient.MakeDetectRequest(imageFilePath);

            if (!string.IsNullOrWhiteSpace(facesDetectedJson))
                jsonResults.Add(new JsonResult() { Name = "Face", Json = JsonConvert.DeserializeObject<JArray>(facesDetectedJson), JsonContent = facesDetectedJson });

            return jsonResults;
        }

        public async Task<List<JsonResult>> LoadImageInformation(byte[] imageByteData)
        {
            List<JsonResult> jsonResults = new List<JsonResult>();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string facesDetectedJson = await _faceClient.MakeDetectRequest(imageByteData);
            stopwatch.Stop();

            string elapsedTime = GetElapsedTime(stopwatch.Elapsed);

            if (!string.IsNullOrWhiteSpace(facesDetectedJson))
                jsonResults.Add(new JsonResult() { Name = "Face", Time = elapsedTime, Json = JsonConvert.DeserializeObject<JArray>(facesDetectedJson) });

            stopwatch.Start();
            string imageAnalysisJson = await _visionClient.MakeAnalysisRequest(imageByteData);
            stopwatch.Stop();

            elapsedTime = GetElapsedTime(stopwatch.Elapsed);

            if (!string.IsNullOrWhiteSpace(imageAnalysisJson))
                jsonResults.Add(new JsonResult() { Name = "Vision", Time = elapsedTime, Json = JsonConvert.DeserializeObject<JObject>(imageAnalysisJson) });

            return jsonResults;
        }

        public FaceAnalyzeResult ProcessInformation(List<JsonResult> jsonResults)
        {
            FaceAnalyzeResult result = new FaceAnalyzeResult();

            if (jsonResults.Any())
            {
                JsonResult faceAnalysisResult = GetJson(jsonResults, "Face");
                JsonResult visionAnalysisResult = GetJson(jsonResults, "Vision");

                if (faceAnalysisResult != null)
                {
                    List<Face> faces = _faceMapper.Map(faceAnalysisResult.Json);

                    if (visionAnalysisResult != null)
                        _celebritiesMapper.Map(visionAnalysisResult.Json, faces);

                    result.Faces = faces;
                }

                if (visionAnalysisResult != null)
                    result.Moderation = _moderationMapper.Map(visionAnalysisResult.Json);

                result.JsonResults = jsonResults;
            }

            return result;
        }

        #endregion

        #region Private Methods

        private JsonResult GetJson(List<JsonResult> jsonResults, string jsonName)
        {
            return jsonResults
                .Where(jr => jr.Name.Equals(jsonName))
                .FirstOrDefault();
        }

        private static string GetElapsedTime(TimeSpan ts)
        {
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }

        #endregion
    }
}
