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
            this.lblCarnivoresEnergyTotal = new System.Windows.Forms.Label();
            this.lblHerbivoresEnergyTotal = new System.Windows.Forms.Label();
            this.lblNonivoresEnergyTotal = new System.Windows.Forms.Label();
            this.lblOmnivoresEnergyTotal = new System.Windows.Forms.Label();
            this.lblPlantsEnergyTotal = new System.Windows.Forms.Label();
            this.lblPlantsEnergyAvg = new System.Windows.Forms.Label();
            this.lblOmnivoresEnergyAvg = new System.Windows.Forms.Label();
            this.lblNonivoresEnergyAvg = new System.Windows.Forms.Label();
            this.lblHerbivoresEnergyAvg = new System.Windows.Forms.Label();
            this.lblCarnivoresEnergyAvg = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartPause
            // 
            this.btnStartPause.Location = new System.Drawing.Point(16, 4);
            this.btnStartPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(100, 28);
            this.btnStartPause.TabIndex = 1;
            this.btnStartPause.Text = "Start";
            this.btnStartPause.UseVisualStyleBackColor = true;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(124, 4);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 28);
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
            this.panelBottom.Location = new System.Drawing.Point(0, 303);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(699, 43);
            this.panelBottom.TabIndex = 3;
            // 
            // simulationPanel
            // 
            this.simulationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.simulationPanel.Location = new System.Drawing.Point(0, 0);
            this.simulationPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simulationPanel.MinimumSize = new System.Drawing.Size(267, 246);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(357, 284);
            this.simulationPanel.TabIndex = 4;
            this.simulationPanel.TabStop = false;
            this.simulationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Carnivoren";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Herbivoren";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nonivoren";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Omnivoren";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Aantal       Energie      Gemiddeld";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 154);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Planten";
            // 
            // lblCarnivoren
            // 
            this.lblCarnivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarnivoren.AutoSize = true;
            this.lblCarnivoren.Location = new System.Drawing.Point(474, 36);
            this.lblCarnivoren.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarnivoren.Name = "lblCarnivoren";
            this.lblCarnivoren.Size = new System.Drawing.Size(66, 17);
            this.lblCarnivoren.TabIndex = 11;
            this.lblCarnivoren.Text = "InfoLabel";
            // 
            // lblHerbivoren
            // 
            this.lblHerbivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHerbivoren.AutoSize = true;
            this.lblHerbivoren.Location = new System.Drawing.Point(474, 64);
            this.lblHerbivoren.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHerbivoren.Name = "lblHerbivoren";
            this.lblHerbivoren.Size = new System.Drawing.Size(66, 17);
            this.lblHerbivoren.TabIndex = 12;
            this.lblHerbivoren.Text = "InfoLabel";
            // 
            // lblNonivoren
            // 
            this.lblNonivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNonivoren.AutoSize = true;
            this.lblNonivoren.Location = new System.Drawing.Point(474, 92);
            this.lblNonivoren.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNonivoren.Name = "lblNonivoren";
            this.lblNonivoren.Size = new System.Drawing.Size(66, 17);
            this.lblNonivoren.TabIndex = 13;
            this.lblNonivoren.Text = "InfoLabel";
            // 
            // lblOmnivoren
            // 
            this.lblOmnivoren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOmnivoren.AutoSize = true;
            this.lblOmnivoren.Location = new System.Drawing.Point(474, 123);
            this.lblOmnivoren.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOmnivoren.Name = "lblOmnivoren";
            this.lblOmnivoren.Size = new System.Drawing.Size(66, 17);
            this.lblOmnivoren.TabIndex = 14;
            this.lblOmnivoren.Text = "InfoLabel";
            // 
            // lblPlanten
            // 
            this.lblPlanten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlanten.AutoSize = true;
            this.lblPlanten.Location = new System.Drawing.Point(474, 154);
            this.lblPlanten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlanten.Name = "lblPlanten";
            this.lblPlanten.Size = new System.Drawing.Size(66, 17);
            this.lblPlanten.TabIndex = 15;
            this.lblPlanten.Text = "InfoLabel";
            // 
            // lblCarnivoresEnergyTotal
            // 
            this.lblCarnivoresEnergyTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarnivoresEnergyTotal.AutoSize = true;
            this.lblCarnivoresEnergyTotal.Location = new System.Drawing.Point(548, 36);
            this.lblCarnivoresEnergyTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarnivoresEnergyTotal.Name = "lblCarnivoresEnergyTotal";
            this.lblCarnivoresEnergyTotal.Size = new System.Drawing.Size(66, 17);
            this.lblCarnivoresEnergyTotal.TabIndex = 16;
            this.lblCarnivoresEnergyTotal.Text = "InfoLabel";
            // 
            // lblHerbivoresEnergyTotal
            // 
            this.lblHerbivoresEnergyTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHerbivoresEnergyTotal.AutoSize = true;
            this.lblHerbivoresEnergyTotal.Location = new System.Drawing.Point(548, 64);
            this.lblHerbivoresEnergyTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHerbivoresEnergyTotal.Name = "lblHerbivoresEnergyTotal";
            this.lblHerbivoresEnergyTotal.Size = new System.Drawing.Size(66, 17);
            this.lblHerbivoresEnergyTotal.TabIndex = 17;
            this.lblHerbivoresEnergyTotal.Text = "InfoLabel";
            // 
            // lblNonivoresEnergyTotal
            // 
            this.lblNonivoresEnergyTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNonivoresEnergyTotal.AutoSize = true;
            this.lblNonivoresEnergyTotal.Location = new System.Drawing.Point(548, 92);
            this.lblNonivoresEnergyTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNonivoresEnergyTotal.Name = "lblNonivoresEnergyTotal";
            this.lblNonivoresEnergyTotal.Size = new System.Drawing.Size(66, 17);
            this.lblNonivoresEnergyTotal.TabIndex = 18;
            this.lblNonivoresEnergyTotal.Text = "InfoLabel";
            // 
            // lblOmnivoresEnergyTotal
            // 
            this.lblOmnivoresEnergyTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOmnivoresEnergyTotal.AutoSize = true;
            this.lblOmnivoresEnergyTotal.Location = new System.Drawing.Point(548, 123);
            this.lblOmnivoresEnergyTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOmnivoresEnergyTotal.Name = "lblOmnivoresEnergyTotal";
            this.lblOmnivoresEnergyTotal.Size = new System.Drawing.Size(66, 17);
            this.lblOmnivoresEnergyTotal.TabIndex = 19;
            this.lblOmnivoresEnergyTotal.Text = "InfoLabel";
            // 
            // lblPlantsEnergyTotal
            // 
            this.lblPlantsEnergyTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlantsEnergyTotal.AutoSize = true;
            this.lblPlantsEnergyTotal.Location = new System.Drawing.Point(548, 154);
            this.lblPlantsEnergyTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlantsEnergyTotal.Name = "lblPlantsEnergyTotal";
            this.lblPlantsEnergyTotal.Size = new System.Drawing.Size(66, 17);
            this.lblPlantsEnergyTotal.TabIndex = 20;
            this.lblPlantsEnergyTotal.Text = "InfoLabel";
            // 
            // lblPlantsEnergyAvg
            // 
            this.lblPlantsEnergyAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlantsEnergyAvg.AutoSize = true;
            this.lblPlantsEnergyAvg.Location = new System.Drawing.Point(622, 154);
            this.lblPlantsEnergyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlantsEnergyAvg.Name = "lblPlantsEnergyAvg";
            this.lblPlantsEnergyAvg.Size = new System.Drawing.Size(66, 17);
            this.lblPlantsEnergyAvg.TabIndex = 25;
            this.lblPlantsEnergyAvg.Text = "InfoLabel";
            // 
            // lblOmnivoresEnergyAvg
            // 
            this.lblOmnivoresEnergyAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOmnivoresEnergyAvg.AutoSize = true;
            this.lblOmnivoresEnergyAvg.Location = new System.Drawing.Point(622, 123);
            this.lblOmnivoresEnergyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOmnivoresEnergyAvg.Name = "lblOmnivoresEnergyAvg";
            this.lblOmnivoresEnergyAvg.Size = new System.Drawing.Size(66, 17);
            this.lblOmnivoresEnergyAvg.TabIndex = 24;
            this.lblOmnivoresEnergyAvg.Text = "InfoLabel";
            // 
            // lblNonivoresEnergyAvg
            // 
            this.lblNonivoresEnergyAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNonivoresEnergyAvg.AutoSize = true;
            this.lblNonivoresEnergyAvg.Location = new System.Drawing.Point(622, 92);
            this.lblNonivoresEnergyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNonivoresEnergyAvg.Name = "lblNonivoresEnergyAvg";
            this.lblNonivoresEnergyAvg.Size = new System.Drawing.Size(66, 17);
            this.lblNonivoresEnergyAvg.TabIndex = 23;
            this.lblNonivoresEnergyAvg.Text = "InfoLabel";
            // 
            // lblHerbivoresEnergyAvg
            // 
            this.lblHerbivoresEnergyAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHerbivoresEnergyAvg.AutoSize = true;
            this.lblHerbivoresEnergyAvg.Location = new System.Drawing.Point(622, 64);
            this.lblHerbivoresEnergyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHerbivoresEnergyAvg.Name = "lblHerbivoresEnergyAvg";
            this.lblHerbivoresEnergyAvg.Size = new System.Drawing.Size(66, 17);
            this.lblHerbivoresEnergyAvg.TabIndex = 22;
            this.lblHerbivoresEnergyAvg.Text = "InfoLabel";
            // 
            // lblCarnivoresEnergyAvg
            // 
            this.lblCarnivoresEnergyAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarnivoresEnergyAvg.AutoSize = true;
            this.lblCarnivoresEnergyAvg.Location = new System.Drawing.Point(622, 36);
            this.lblCarnivoresEnergyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarnivoresEnergyAvg.Name = "lblCarnivoresEnergyAvg";
            this.lblCarnivoresEnergyAvg.Size = new System.Drawing.Size(66, 17);
            this.lblCarnivoresEnergyAvg.TabIndex = 21;
            this.lblCarnivoresEnergyAvg.Text = "InfoLabel";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 346);
            this.Controls.Add(this.lblPlantsEnergyAvg);
            this.Controls.Add(this.lblOmnivoresEnergyAvg);
            this.Controls.Add(this.lblNonivoresEnergyAvg);
            this.Controls.Add(this.lblHerbivoresEnergyAvg);
            this.Controls.Add(this.lblCarnivoresEnergyAvg);
            this.Controls.Add(this.lblPlantsEnergyTotal);
            this.Controls.Add(this.lblOmnivoresEnergyTotal);
            this.Controls.Add(this.lblNonivoresEnergyTotal);
            this.Controls.Add(this.lblHerbivoresEnergyTotal);
            this.Controls.Add(this.lblCarnivoresEnergyTotal);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(261, 278);
            this.Name = "SimulationForm";
            this.Text = "Simulatie";
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
        private System.Windows.Forms.Label lblCarnivoresEnergyTotal;
        private System.Windows.Forms.Label lblHerbivoresEnergyTotal;
        private System.Windows.Forms.Label lblNonivoresEnergyTotal;
        private System.Windows.Forms.Label lblOmnivoresEnergyTotal;
        private System.Windows.Forms.Label lblPlantsEnergyTotal;
        private System.Windows.Forms.Label lblPlantsEnergyAvg;
        private System.Windows.Forms.Label lblOmnivoresEnergyAvg;
        private System.Windows.Forms.Label lblNonivoresEnergyAvg;
        private System.Windows.Forms.Label lblHerbivoresEnergyAvg;
        private System.Windows.Forms.Label lblCarnivoresEnergyAvg;
    }
}