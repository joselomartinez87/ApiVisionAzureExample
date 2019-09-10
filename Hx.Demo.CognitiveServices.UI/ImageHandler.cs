using System.Drawing;

namespace Hx.Demo.CognitiveServices.UI
{
    internal class ImageHandler
    {
        private Bitmap _currentBitmap;

        public Bitmap CurrentBitmap
        {
            get
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);

                return _currentBitmap;
            }
            set
            {
                _currentBitmap = value;
            }
        }

        public string BitmapPath { get; set; }
    }
}