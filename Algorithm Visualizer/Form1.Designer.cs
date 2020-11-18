
namespace Algorithm_Visualizer
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.shuffle = new System.Windows.Forms.Button();
            this.sort = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.AlgorithmChoice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // shuffle
            // 
            this.shuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shuffle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shuffle.Location = new System.Drawing.Point(0, 1);
            this.shuffle.Name = "shuffle";
            this.shuffle.Size = new System.Drawing.Size(403, 34);
            this.shuffle.TabIndex = 0;
            this.shuffle.Text = "Shuffle";
            this.shuffle.UseVisualStyleBackColor = true;
            this.shuffle.Click += new System.EventHandler(this.shuffle_Click);
            // 
            // sort
            // 
            this.sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sort.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sort.Location = new System.Drawing.Point(400, 1);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(400, 34);
            this.sort.TabIndex = 1;
            this.sort.Text = "Sort";
            this.sort.UseVisualStyleBackColor = true;
            this.sort.Click += new System.EventHandler(this.sort_Click);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(0, 68);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(800, 339);
            this.canvas.TabIndex = 2;
            this.canvas.TabStop = false;
            // 
            // AlgorithmChoice
            // 
            this.AlgorithmChoice.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmChoice.FormattingEnabled = true;
            this.AlgorithmChoice.ItemHeight = 30;
            this.AlgorithmChoice.Items.AddRange(new object[] {
            "Bubble Sort",
            "Quick Sort",
            "Insertion Sort"});
            this.AlgorithmChoice.Location = new System.Drawing.Point(0, 32);
            this.AlgorithmChoice.Name = "AlgorithmChoice";
            this.AlgorithmChoice.Size = new System.Drawing.Size(800, 38);
            this.AlgorithmChoice.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 409);
            this.Controls.Add(this.AlgorithmChoice);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.shuffle);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button shuffle;
        private System.Windows.Forms.Button sort;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ComboBox AlgorithmChoice;
    }
}

