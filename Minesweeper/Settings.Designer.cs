namespace Minesweeper
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Button();
            this.numberBombs = new System.Windows.Forms.NumericUpDown();
            this.numberCols = new System.Windows.Forms.NumericUpDown();
            this.numberRows = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numberBombs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberRows)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of bombs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Columns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rows";
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(101, 184);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(75, 23);
            this.play.TabIndex = 4;
            this.play.Text = "Play!";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // numberBombs
            // 
            this.numberBombs.Location = new System.Drawing.Point(152, 30);
            this.numberBombs.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numberBombs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberBombs.Name = "numberBombs";
            this.numberBombs.Size = new System.Drawing.Size(120, 20);
            this.numberBombs.TabIndex = 5;
            this.numberBombs.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numberCols
            // 
            this.numberCols.Location = new System.Drawing.Point(152, 66);
            this.numberCols.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numberCols.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberCols.Name = "numberCols";
            this.numberCols.Size = new System.Drawing.Size(120, 20);
            this.numberCols.TabIndex = 5;
            this.numberCols.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numberRows
            // 
            this.numberRows.Location = new System.Drawing.Point(152, 100);
            this.numberRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numberRows.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberRows.Name = "numberRows";
            this.numberRows.Size = new System.Drawing.Size(120, 20);
            this.numberRows.TabIndex = 5;
            this.numberRows.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.numberRows);
            this.Controls.Add(this.numberCols);
            this.Controls.Add(this.numberBombs);
            this.Controls.Add(this.play);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numberBombs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.NumericUpDown numberBombs;
        private System.Windows.Forms.NumericUpDown numberCols;
        private System.Windows.Forms.NumericUpDown numberRows;
    }
}