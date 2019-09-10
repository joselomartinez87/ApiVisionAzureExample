using Hx.Demo.CognitiveServices.Client;
using Hx.Demo.CognitiveServices.Logic.Interfaces;
using Hx.Demo.CognitiveServices.Logic.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hx.Demo.CognitiveServices.UI
{
    public partial class FrmDemo : Form
    {
        private ImageHandler imageHandler;
        private double zoomFactor = 1;

        private IVisionApiClient _visionClient;
        private IFaceApiClient _faceClient;
        private readonly IImageAnalizer _imageAnalizer;
        private Pen bluePen;
        private Pen pinkPen;

        public FrmDemo(IVisionApiClient visionClient, IFaceApiClient faceClient, IImageAnalizer imageAnalizer)
        {
            InitializeComponent();

            _visionClient = visionClient;
            _faceClient = faceClient;
            _imageAnalizer = imageAnalizer;
            cmbAnalysisType.Text = "--Select--";

            bluePen = new Pen(Color.Blue, 3);
            pinkPen = new Pen(Color.Pink, 3);

            imageHandler = new ImageHandler();
        }

        private void BtnSelectImage_Click(object sender, System.EventArgs e)
        {
            CleanForm();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageHandler.CurrentBitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                imageHandler.BitmapPath = openFileDialog.FileName;

                txtImagePath.Text = imageHandler.BitmapPath;

                int width = Convert.ToInt32(imageHandler.CurrentBitmap.Width * zoomFactor);
                int height = Convert.ToInt32(imageHandler.CurrentBitmap.Height * zoomFactor);

                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(width, height);

                this.Invalidate();
            }
        }

        private void FrmDemo_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            DrawImage(graphics);
        }
        
        private async void CmbAnalysisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(imageHandler.BitmapPath))
            {
                switch (cmbAnalysisType.Text)
                {
                    case "Vision - Analyze":
                        txtResult.Text = await _visionClient.MakeAnalysisRequest(imageHandler.BitmapPath);
                        break;

                    case "Face - Detect":
                        FaceAnalyzeResult detectedFaces = await _imageAnalizer.FaceAnalyze(imageHandler.BitmapPath);
                        txtResult.Text = detectedFaces.JsonResults[0].JsonContent;

                        Graphics graphic = this.CreateGraphics();

                        foreach (Face face in detectedFaces.Faces)
                        {
                            int xPos = this.AutoScrollPosition.X + grbAnalysis.Location.X + face.Box.Left;
                            int yPos = this.AutoScrollPosition.Y + grbAnalysis.Location.Y + grbAnalysis.Size.Height + 20 + face.Box.Top;

                            Rectangle rectangle = new Rectangle(xPos, yPos, face.Box.Width, face.Box.Height);
                            graphic.DrawRectangle(face.Gender.Equals("female") ? pinkPen : bluePen, rectangle);
                        }
                        
                        break;

                    case "Face - GetList":
                        txtResult.Text = await _faceClient.MakeGetListRequest(imageHandler.BitmapPath);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select an image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DrawImage(Graphics graphics)
        {
            Bitmap bitmap = imageHandler.CurrentBitmap;
            int width = Convert.ToInt32(bitmap.Width * zoomFactor);
            int height = Convert.ToInt32(bitmap.Height * zoomFactor);

            int xPos = this.AutoScrollPosition.X + grbAnalysis.Location.X;
            int yPos = this.AutoScrollPosition.Y + grbAnalysis.Location.Y + grbAnalysis.Size.Height + 20;

            Rectangle rectangule = new Rectangle(xPos, yPos, width, height);

            graphics.DrawImage(imageHandler.CurrentBitmap, rectangule);
        }

        private void CleanForm()
        {
            cmbAnalysisType.Text = "--Select--";
            txtResult.Text = string.Empty;
        }
    }
}
