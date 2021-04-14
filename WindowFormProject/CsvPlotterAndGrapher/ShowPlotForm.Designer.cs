
namespace CsvPlotterAndGrapher
{
    partial class ShowPlotForm
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
            this.pbPlotPreviewer = new System.Windows.Forms.PictureBox();
            this.btnDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlotPreviewer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlotPreviewer
            // 
            this.pbPlotPreviewer.Location = new System.Drawing.Point(115, 12);
            this.pbPlotPreviewer.Name = "pbPlotPreviewer";
            this.pbPlotPreviewer.Size = new System.Drawing.Size(640, 480);
            this.pbPlotPreviewer.TabIndex = 0;
            this.pbPlotPreviewer.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(405, 518);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "save plot";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // ShowPlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 567);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.pbPlotPreviewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowPlotForm";
            this.Text = "ShowPlotForm";
            this.Load += new System.EventHandler(this.ShowPlotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlotPreviewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlotPreviewer;
        private System.Windows.Forms.Button btnDownload;
    }
}