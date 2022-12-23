namespace Vista
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.intJugar = new System.Windows.Forms.Button();
            this.numberPlayer = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // intJugar
            // 
            this.intJugar.Location = new System.Drawing.Point(632, 380);
            this.intJugar.Name = "intJugar";
            this.intJugar.Size = new System.Drawing.Size(108, 34);
            this.intJugar.TabIndex = 1;
            this.intJugar.Text = "Jugar";
            this.intJugar.UseVisualStyleBackColor = true;
            this.intJugar.Click += new System.EventHandler(this.intJugar_Click);
            // 
            // numberPlayer
            // 
            this.numberPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.numberPlayer.Location = new System.Drawing.Point(553, 380);
            this.numberPlayer.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numberPlayer.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberPlayer.Name = "numberPlayer";
            this.numberPlayer.Size = new System.Drawing.Size(55, 34);
            this.numberPlayer.TabIndex = 2;
            this.numberPlayer.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(196, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número de Jugadores:";
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberPlayer);
            this.Controls.Add(this.intJugar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakes and Laders";
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button intJugar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numberPlayer;
    }
}