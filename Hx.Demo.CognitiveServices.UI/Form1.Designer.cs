namespace Hx.Demo.CognitiveServices.UI
{
    partial class FrmDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbAnalysis = new System.Windows.Forms.GroupBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.cmbAnalysisType = new System.Windows.Forms.ComboBox();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.grbAnalysis.SuspendLayout();
            this.grbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbAnalysis
            // 
            this.grbAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbAnalysis.Controls.Add(this.cmbAnalysisType);
            this.grbAnalysis.Controls.Add(this.btnSelectImage);
            this.grbAnalysis.Controls.Add(this.txtImagePath);
            this.grbAnalysis.Location = new System.Drawing.Point(13, 13);
            this.grbAnalysis.Name = "grbAnalysis";
            this.grbAnalysis.Size = new System.Drawing.Size(761, 52);
            this.grbAnalysis.TabIndex = 1;
            this.grbAnalysis.TabStop = false;
            this.grbAnalysis.Text = "Analysis";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(6, 19);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(394, 20);
            this.txtImagePath.TabIndex = 0;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(406, 17);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(108, 23);
            this.btnSelectImage.TabIndex = 1;
            this.btnSelectImage.Text = "Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.BtnSelectImage_Click);
            // 
            // cmbAnalysisType
            // 
            this.cmbAnalysisType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnalysisType.FormattingEnabled = true;
            this.cmbAnalysisType.Items.AddRange(new object[] {
            "Vision - Analyze",
            "Face - Detect",
            "Face - GetList"});
            this.cmbAnalysisType.Location = new System.Drawing.Point(634, 19);
            this.cmbAnalysisType.Name = "cmbAnalysisType";
            this.cmbAnalysisType.Size = new System.Drawing.Size(121, 21);
            this.cmbAnalysisType.TabIndex = 2;
            this.cmbAnalysisType.SelectedIndexChanged += new System.EventHandler(this.CmbAnalysisType_SelectedIndexChanged);
            // 
            // grbResult
            // 
            this.grbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbResult.Controls.Add(this.txtResult);
            this.grbResult.Location = new System.Drawing.Point(482, 72);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(294, 366);
            this.grbResult.TabIndex = 2;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(7, 20);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(281, 340);
            this.txtResult.TabIndex = 0;
            // 
            // FrmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbResult);
            this.Controls.Add(this.grbAnalysis);
            this.Name = "FrmDemo";
            this.Text = "Demo - Microsoft Cognitive Services";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDemo_Paint);
            this.grbAnalysis.ResumeLayout(false);
            this.grbAnalysis.PerformLayout();
            this.grbResult.ResumeLayout(false);
            this.grbResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbAnalysis;
        private System.Windows.Forms.ComboBox cmbAnalysisType;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.GroupBox grbResult;
        private System.Windows.Forms.TextBox txtResult;
    }
}

