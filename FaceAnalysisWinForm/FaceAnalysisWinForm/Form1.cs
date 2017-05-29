using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebEye.Controls.WinForms.WebCameraControl;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.Configuration;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;



namespace FaceAnalysisWinForm
{
    public partial class Form1 : Form
    {

        Bitmap capturedImage;

        const string EmotionAPIKEY = "YOUR EMOTION API KEYS HERE";
        const string VisionAPIKEY = "YOUR VISION API KEY HERE";

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            List<WebCameraId> cameras = new List<WebCameraId>(webCameraControl1.GetVideoCaptureDevices());

            webCameraControl1.StartCapture(cameras[0]);

            rdoVisionAPI.Checked = true;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //ボタンを連続押しできないようにする
            btnCapture.Enabled = false;
            //カメラからのキャプチャをする
            capturedImage = webCameraControl1.GetCurrentImage();

            ////いったん取得を止める
            //if (webCameraControl1.IsCapturing)
            //{
            //    webCameraControl1.StopCapture();
            //}

            //取得したImageを一回保存する
            string path = Application.StartupPath;
            string imgFileName = System.IO.Path.Combine(path, string.Format("captured_{0:yyyyMMddhhmmss}.png", DateTime.Now));
            capturedImage.Save(imgFileName);

            txtResults.Clear();

            //解析をする
            if (rdoEmotionAPI.Checked)
            ImageAnalysisEmotion(imgFileName);

            if(rdoVisionAPI.Checked)
            ImageAnalysisVision(imgFileName);

            ////解析が終わったら、StartCaptureする
            //if (!webCameraControl1.IsCapturing)
            //{
            //    webCameraControl1.StartCapture(camera[0]);
            //}

            //ボタンを有効状態に戻す
            btnCapture.Enabled = true;

        }

        private async void ImageAnalysisVision(string imgFileName)
        {

            var vclient = new VisionServiceClient(VisionAPIKEY);
            AnalysisResult aResult = null;

            try
            {
                VisualFeature[] vFeature = new VisualFeature[] {
                    VisualFeature.Adult,
                    VisualFeature.Description,
                    VisualFeature.Faces ,
                    VisualFeature.Categories,
                    VisualFeature.Color,
                    VisualFeature.ImageType,
                    VisualFeature.Tags
                };
                txtResults.AppendText("Vision API 解析中...\r\n");

                aResult = await vclient.AnalyzeImageAsync(new System.IO.FileStream(imgFileName, System.IO.FileMode.Open), vFeature);
            }
            catch(Exception e)
            {
                txtResults.AppendText("検出できませんでした\r\n");
            }

            string resultText = "";

            if (aResult != null)
            {
                resultText += "Adult Score: " + Math.Round(aResult.Adult.AdultScore *100,2) + "%"  + "\r\n";
                resultText += "Is adult content?: " + aResult.Adult.IsAdultContent + "\r\n";

                string caps = "";
                foreach (var captions in aResult.Description.Captions)
                {
                    caps += Math.Round(captions.Confidence * 100,2)+ "%" + " : " + captions.Text + "\r\n";

                }

                resultText += "Description: \r\n" + caps;

                txtResults.AppendText("Vision APIの解析結果：\r\n");
                txtResults.AppendText(resultText);

            }
            else
            {
                txtResults.AppendText("Vision APIの呼び出しに失敗しました");

            }

        }

        private async void ImageAnalysisEmotion(string ImgFileName)
        {


            var res = "";

            var eClient = new EmotionServiceClient(EmotionAPIKEY);
            Emotion[] eResult = null;

            try
            {
                txtResults.AppendText("Emotion API 解析中...\r\n");
                eResult = await eClient.RecognizeAsync(new System.IO.FileStream(ImgFileName, System.IO.FileMode.Open));

            }
            catch (Exception e)
            {
                eResult = null;
                res = "検出できませんでした";
                txtResults.AppendText(res);

                return;
            }

            if (eResult != null)
            {   //データの整形と出力
                res = "Emotion API 解析できました";
                string resultText = "";
                for (int i = 0; i <= eResult.Length - 1; i++)
                {
                    var eScores = eResult[i].Scores;
                    // 検出された表情スコアをセット
                    resultText += string.Format("要素 {0} 個め\r\n", i);
                    resultText += string.Format("怒り: {0}%\r\n", Math.Round(eScores.Anger * 100, 2));
                    resultText += string.Format("軽蔑:{0}%\r\n", Math.Round(eScores.Contempt * 100, 2));
                    resultText += string.Format("ムカつき:{0}%\r\n", Math.Round(eScores.Disgust * 100, 2));
                    resultText += string.Format("恐れ:{0}%\r\n", Math.Round(eScores.Fear * 100, 2));
                    resultText += string.Format("喜び:{0}%\r\n", Math.Round(eScores.Happiness * 100, 2));
                    resultText += string.Format("無表情:{0}%\r\n", Math.Round(eScores.Neutral * 100, 2));
                    resultText += string.Format("悲しみ:{0}%\r\n", Math.Round(eScores.Sadness * 100, 2));
                    resultText += string.Format("驚き:{0}%\r\n", Math.Round(eScores.Surprise * 100, 2));
                }
                txtResults.AppendText(string.Format("{0}\r\n{1}", res, resultText));
            }
            else
            {
                res = "API呼び出しに失敗しました";
                txtResults.AppendText(res);

            }

        }

    }




}
