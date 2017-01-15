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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCarnivoren = new System.Windows.Forms.Label();
            this.lblHerbivoren = new System.Windows.Forms.Label();
            this.lblNonivoren = new System.Windows.Forms.Label();
            this.lblOmnivoren = new System.Windows.Forms.Label();
            this.lblPlanten = new System.Windows.Forms.Label();
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
            this.panelBottom.Location = new System.Drawing.Point(0, 246);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(485, 35);
            this.panelBottom.TabIndex = 3;
            // 
            // simulationPanel
            // 
            this.simulationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.simulationPanel.Location = new System.Drawing.Point(0, 0);
            this.simulationPanel.MinimumSize = new System.Drawing.Size(200, 200);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(263, 231);
            this.simulationPanel.TabIndex = 4;
            this.simulationPanel.TabStop = false;
            this.simulationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Carnivoren";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Herbivoren";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nonivoren";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Omnivoren";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Aantal / Energie / Gemiddeld";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Planten";
            // 
            // lblCarnivoren
            // 
            this.lblCarnivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarnivoren.AutoSize = true;
            this.lblCarnivoren.Location = new System.Drawing.Point(337, 29);
            this.lblCarnivoren.Name = "lblCarnivoren";
            this.lblCarnivoren.Size = new System.Drawing.Size(51, 13);
            this.lblCarnivoren.TabIndex = 11;
            this.lblCarnivoren.Text = "InfoLabel";
            // 
            // lblHerbivoren
            // 
            this.lblHerbivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHerbivoren.AutoSize = true;
            this.lblHerbivoren.Location = new System.Drawing.Point(337, 52);
            this.lblHerbivoren.Name = "lblHerbivoren";
            this.lblHerbivoren.Size = new System.Drawing.Size(51, 13);
            this.lblHerbivoren.TabIndex = 12;
            this.lblHerbivoren.Text = "InfoLabel";
            // 
            // lblNonivoren
            // 
            this.lblNonivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNonivoren.AutoSize = true;
            this.lblNonivoren.Location = new System.Drawing.Point(337, 75);
            this.lblNonivoren.Name = "lblNonivoren";
            this.lblNonivoren.Size = new System.Drawing.Size(51, 13);
            this.lblNonivoren.TabIndex = 13;
            this.lblNonivoren.Text = "InfoLabel";
            // 
            // lblOmnivoren
            // 
            this.lblOmnivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOmnivoren.AutoSize = true;
            this.lblOmnivoren.Location = new System.Drawing.Point(337, 100);
            this.lblOmnivoren.Name = "lblOmnivoren";
            this.lblOmnivoren.Size = new System.Drawing.Size(51, 13);
            this.lblOmnivoren.TabIndex = 14;
            this.lblOmnivoren.Text = "InfoLabel";
            // 
            // lblPlanten
            // 
            this.lblPlanten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlanten.AutoSize = true;
            this.lblPlanten.Location = new System.Drawing.Point(337, 125);
            this.lblPlanten.Name = "lblPlanten";
            this.lblPlanten.Size = new System.Drawing.Size(51, 13);
            this.lblPlanten.TabIndex = 15;
            this.lblPlanten.Text = "InfoLabel";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 281);
            this.Controls.Add(this.lblPlanten);
            this.Controls.Add(this.lblOmnivoren);
            this.Controls.Add(this.lblNonivoren);
            this.Controls.Add(this.lblHerbivoren);
            this.Controls.Add(this.lblCarnivoren);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simulationPanel);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(200, 235);
            this.Name = "SimulationForm";
            this.Text = "Simulatie";
            this.Load += new System.EventHandler(this.SimulationForm_Load);
            this.Resize += new System.EventHandler(this.SimulationForm_Resize);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.simulationPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.PictureBox simulationPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCarnivoren;
        private System.Windows.Forms.Label lblHerbivoren;
        private System.Windows.Forms.Label lblNonivoren;
        private System.Windows.Forms.Label lblOmnivoren;
        private System.Windows.Forms.Label lblPlanten;
    }
}