﻿
namespace CsvPlotterAndGrapher
{
    partial class PlotPropertyWindow
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
            this.pgPlotProperty = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pgPlotProperty
            // 
            this.pgPlotProperty.Location = new System.Drawing.Point(271, 12);
            this.pgPlotProperty.Name = "pgPlotProperty";
            this.pgPlotProperty.Size = new System.Drawing.Size(198, 332);
            this.pgPlotProperty.TabIndex = 0;
            // 
            // PlotPropertyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pgPlotProperty);
            this.Name = "PlotPropertyWindow";
            this.Text = "PlotPropertyWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgPlotProperty;
    }
}