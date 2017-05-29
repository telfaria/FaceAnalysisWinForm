namespace FaceAnalysisWinForm
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (webCameraControl1.IsCapturing)
                {
                    webCameraControl1.StopCapture();
                }

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.webCameraControl1 = new WebEye.Controls.WinForms.WebCameraControl.WebCameraControl();
            this.btnCapture = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoVisionAPI = new System.Windows.Forms.RadioButton();
            this.rdoEmotionAPI = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webCameraControl1
            // 
            this.webCameraControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webCameraControl1.Location = new System.Drawing.Point(12, 12);
            this.webCameraControl1.Name = "webCameraControl1";
            this.webCameraControl1.Size = new System.Drawing.Size(960, 540);
            this.webCameraControl1.TabIndex = 0;
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Location = new System.Drawing.Point(850, 564);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(154, 45);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture!";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtResults.Location = new System.Drawing.Point(978, 12);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(334, 540);
            this.txtResults.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdoVisionAPI);
            this.groupBox1.Controls.Add(this.rdoEmotionAPI);
            this.groupBox1.Location = new System.Drawing.Point(458, 558);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select API";
            // 
            // rdoVisionAPI
            // 
            this.rdoVisionAPI.AutoSize = true;
            this.rdoVisionAPI.Location = new System.Drawing.Point(236, 17);
            this.rdoVisionAPI.Name = "rdoVisionAPI";
            this.rdoVisionAPI.Size = new System.Drawing.Size(109, 22);
            this.rdoVisionAPI.TabIndex = 1;
            this.rdoVisionAPI.TabStop = true;
            this.rdoVisionAPI.Text = "Vision API";
            this.rdoVisionAPI.UseVisualStyleBackColor = true;
            // 
            // rdoEmotionAPI
            // 
            this.rdoEmotionAPI.AutoSize = true;
            this.rdoEmotionAPI.Location = new System.Drawing.Point(86, 17);
            this.rdoEmotionAPI.Name = "rdoEmotionAPI";
            this.rdoEmotionAPI.Size = new System.Drawing.Size(124, 22);
            this.rdoEmotionAPI.TabIndex = 0;
            this.rdoEmotionAPI.TabStop = true;
            this.rdoEmotionAPI.Text = "Emotion API";
            this.rdoEmotionAPI.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 615);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.webCameraControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WebEye.Controls.WinForms.WebCameraControl.WebCameraControl webCameraControl1;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoVisionAPI;
        private System.Windows.Forms.RadioButton rdoEmotionAPI;
    }
}

