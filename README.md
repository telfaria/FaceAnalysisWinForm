# FaceAnalysisWinForm
Cognitive Service API Sample

## 何をするものか
Cognitive Serivice APIの動作サンプルです。

## 何が出来るのか
Emotion API と Vision APIをつかっての顔や風景判定

## つかいかた
起動するとWebカメラを見つけるとそれのソースが画面に映るので、試したいAPIを画面下のラジオボタンから選択して、右側のCapture!ボタンを押すと、Azure Cognitive Serviceにデータが飛んでそれが帰ってきます。

## 言語
C# (.NET Framework 4.5.2 or higher)

## 必要なもの
* Emotion API のAPIキー
* Vision API のAPIキー
* Webカメラ
* WebEye.Controls.WinForms.WebCameraControl
* Microsoft.ProjectOxford.Emotion
* Microsoft.ProjectOxford.Vision
NuGetから入手してください
'''
Install-Package WebEye.Controls.WinForms.WebCameraControl
Install-Package Microsoft.ProjectOxford.Emotion
Install-Package Microsoft.ProjectOxford.Vision
'''

また、Cognitive Service の、Emotion API と Compute Vision API のAPIキーが別途必要になります。
別途用意してください。
ref. https://azure.microsoft.com/ja-jp/services/cognitive-services/

## 作ったひと
@telfaria
http://d.hatena.ne.jp/elfaria/

## ライセンス
MIT License （とか言いながら本当にこれでいいのか不安である）
