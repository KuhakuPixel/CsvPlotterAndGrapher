
using ProjectLibrary;

namespace CsvPlotterAndGrapher
{
    partial class MainForm
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
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbPlotType = new System.Windows.Forms.ComboBox();
            this.StartPlotBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(362, 118);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "open";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButtonClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PlotTypeComboBox
            // 
            this.cbPlotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlotType.FormattingEnabled = true;
            this.cbPlotType.Items.AddRange(new object[] {
            "Histogram",
            "Scatter"});
            this.cbPlotType.Location = new System.Drawing.Point(340, 172);
            this.cbPlotType.Name = "PlotTypeComboBox";
            this.cbPlotType.Size = new System.Drawing.Size(121, 21);
            this.cbPlotType.TabIndex = 1;
            this.cbPlotType.SelectedValueChanged += new System.EventHandler(this.PlotTypeComboBox_SelectedValueChanged);
            // 
            // StartPlotBtn
            // 
            this.StartPlotBtn.Location = new System.Drawing.Point(362, 275);
            this.StartPlotBtn.Name = "StartPlotBtn";
            this.StartPlotBtn.Size = new System.Drawing.Size(75, 23);
            this.StartPlotBtn.TabIndex = 2;
            this.StartPlotBtn.Text = "Start plotting";
            this.StartPlotBtn.UseVisualStyleBackColor = true;
            this.StartPlotBtn.Click += new System.EventHandler(this.StartPlotBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartPlotBtn);
            this.Controls.Add(this.cbPlotType);
            this.Controls.Add(this.OpenFileButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbPlotType;
        private System.Windows.Forms.Button StartPlotBtn;
    }
}

