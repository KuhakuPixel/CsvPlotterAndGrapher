
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
            this.btnPlotGraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pgPlotProperty
            // 
            this.pgPlotProperty.Location = new System.Drawing.Point(3, 3);
            this.pgPlotProperty.Name = "pgPlotProperty";
            this.pgPlotProperty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pgPlotProperty.Size = new System.Drawing.Size(341, 351);
            this.pgPlotProperty.TabIndex = 0;
            this.pgPlotProperty.Click += new System.EventHandler(this.pgPlotProperty_Click);
            // 
            // btnPlotGraph
            // 
            this.btnPlotGraph.Location = new System.Drawing.Point(122, 371);
            this.btnPlotGraph.Name = "btnPlotGraph";
            this.btnPlotGraph.Size = new System.Drawing.Size(75, 23);
            this.btnPlotGraph.TabIndex = 1;
            this.btnPlotGraph.Text = "Plot Me";
            this.btnPlotGraph.UseVisualStyleBackColor = true;
            this.btnPlotGraph.Click += new System.EventHandler(this.btnPlotGraph_Click);
            // 
            // PlotPropertyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPlotGraph);
            this.Controls.Add(this.pgPlotProperty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlotPropertyWindow";
            this.Text = "PlotPropertyWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgPlotProperty;
        private System.Windows.Forms.Button btnPlotGraph;
    }
}