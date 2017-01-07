namespace Life
{
    partial class SimulationForm
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
            this.btnStartPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.simulationPanel = new System.Windows.Forms.PictureBox();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartPause
            // 
            this.btnStartPause.Location = new System.Drawing.Point(12, 3);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(75, 23);
            this.btnStartPause.TabIndex = 1;
            this.btnStartPause.Text = "Start";
            this.btnStartPause.UseVisualStyleBackColor = true;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnStartPause);
            this.panelBottom.Controls.Add(this.btnStop);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 215);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(545, 35);
            this.panelBottom.TabIndex = 3;
            // 
            // simulationPanel
            // 
            this.simulationPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.simulationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationPanel.Location = new System.Drawing.Point(0, 0);
            this.simulationPanel.MinimumSize = new System.Drawing.Size(200, 200);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(545, 215);
            this.simulationPanel.TabIndex = 4;
            this.simulationPanel.TabStop = false;
            this.simulationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 250);
            this.Controls.Add(this.simulationPanel);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(200, 235);
            this.Name = "SimulationForm";
            this.Text = "Simulatie";
            this.Resize += new System.EventHandler(this.SimulationForm_Resize);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.simulationPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.PictureBox simulationPanel;
    }
}