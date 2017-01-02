namespace Life
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.eElements = new System.Windows.Forms.TextBox();
            this.eOmnivores = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eHerbivores = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eCarnivores = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eNonivores = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ePlants = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eObstacels = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aantal objecten";
            // 
            // eElements
            // 
            this.eElements.Location = new System.Drawing.Point(96, 6);
            this.eElements.Name = "eElements";
            this.eElements.Size = new System.Drawing.Size(83, 20);
            this.eElements.TabIndex = 1;
            this.eElements.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKeyPress);
            // 
            // eOmnivores
            // 
            this.eOmnivores.Location = new System.Drawing.Point(96, 32);
            this.eOmnivores.Name = "eOmnivores";
            this.eOmnivores.Size = new System.Drawing.Size(83, 20);
            this.eOmnivores.TabIndex = 3;
            this.eOmnivores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "% Omnivoren";
            // 
            // eHerbivores
            // 
            this.eHerbivores.Location = new System.Drawing.Point(96, 58);
            this.eHerbivores.Name = "eHerbivores";
            this.eHerbivores.Size = new System.Drawing.Size(83, 20);
            this.eHerbivores.TabIndex = 5;
            this.eHerbivores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "% Herbivoren";
            // 
            // eCarnivores
            // 
            this.eCarnivores.Location = new System.Drawing.Point(96, 84);
            this.eCarnivores.Name = "eCarnivores";
            this.eCarnivores.Size = new System.Drawing.Size(83, 20);
            this.eCarnivores.TabIndex = 7;
            this.eCarnivores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "% Carnivoren";
            // 
            // eNonivores
            // 
            this.eNonivores.Location = new System.Drawing.Point(96, 110);
            this.eNonivores.Name = "eNonivores";
            this.eNonivores.Size = new System.Drawing.Size(83, 20);
            this.eNonivores.TabIndex = 9;
            this.eNonivores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "% Nonivoren";
            // 
            // ePlants
            // 
            this.ePlants.Location = new System.Drawing.Point(96, 136);
            this.ePlants.Name = "ePlants";
            this.ePlants.Size = new System.Drawing.Size(83, 20);
            this.ePlants.TabIndex = 11;
            this.ePlants.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "% Planten";
            // 
            // eObstacels
            // 
            this.eObstacels.Location = new System.Drawing.Point(96, 162);
            this.eObstacels.Name = "eObstacels";
            this.eObstacels.Size = new System.Drawing.Size(83, 20);
            this.eObstacels.TabIndex = 13;
            this.eObstacels.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "% Obstakels";
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(15, 188);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(79, 23);
            this.bOk.TabIndex = 14;
            this.bOk.Text = "Maak";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(100, 188);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(79, 23);
            this.bCancel.TabIndex = 15;
            this.bCancel.Text = "Annuleer";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 223);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.eObstacels);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ePlants);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.eNonivores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eCarnivores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eHerbivores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eOmnivores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eElements);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "Instellingen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox eElements;
        private System.Windows.Forms.TextBox eOmnivores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox eHerbivores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eCarnivores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox eNonivores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ePlants;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox eObstacels;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
    }
}