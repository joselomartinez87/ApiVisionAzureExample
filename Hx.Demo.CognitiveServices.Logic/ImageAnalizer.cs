using Hx.Demo.CognitiveServices.Logic.Interfaces;
using Hx.Demo.CognitiveServices.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Logic
{
    internal class ImageAnalizer : IImageAnalizer
    {
        #region Fields

        private readonly IFaceServices faceServices;

        #endregion

        #region Constructor

        public ImageAnalizer(IFaceServices faceServices)
        {
            this.faceServices = faceServices;
        }

        #endregion

        #region ImageAnalizer Implementation Methods

        public async Task<FaceAnalyzeResult> FullAnalyze(byte[] imageToAnalyze)
        {
            List<JsonResult> imageInformation = await faceServices.LoadImageInformation(imageToAnalyze);

            return faceServices.ProcessInformation(imageInformation);
        }

        public async Task<FaceAnalyzeResult> FaceAnalyze(string imageFilePath)
        {
            List<JsonResult> imageInformation = await faceServices.LoadImageFaceInformation(imageFilePath);

            return faceServices.ProcessInformation(imageInformation);
        }

        #endregion
    }
}
