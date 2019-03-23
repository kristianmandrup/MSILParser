namespace MSILParser
{
    partial class Form1
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
            this.btnParse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblTrials = new System.Windows.Forms.Label();
            this.txtMsil = new System.Windows.Forms.TextBox();
            this.lblMsil = new System.Windows.Forms.Label();
            this.lblExpression = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.btnParse.Location = new System.Drawing.Point(370, 22);
            this.btnParse.Name = "button1";
            this.btnParse.Size = new System.Drawing.Size(127, 29);
            this.btnParse.TabIndex = 0;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.textBox1.Location = new System.Drawing.Point(12, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 83);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "(a * 1.5) + 2 * (4 / 11.3)";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(569, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(112, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(367, 58);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(0, 13);
            this.lblResults.TabIndex = 6;
            // 
            // lblTrials
            // 
            this.lblTrials.AutoSize = true;
            this.lblTrials.Location = new System.Drawing.Point(517, 25);
            this.lblTrials.Name = "lblTrials";
            this.lblTrials.Size = new System.Drawing.Size(56, 13);
            this.lblTrials.TabIndex = 7;
            this.lblTrials.Text = "# of trials: ";
            // 
            // txtMsil
            // 
            this.txtMsil.AcceptsReturn = true;
            this.txtMsil.AcceptsTab = true;
            this.txtMsil.BackColor = System.Drawing.SystemColors.Window;
            this.txtMsil.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsil.Location = new System.Drawing.Point(12, 136);
            this.txtMsil.MaxLength = 200000;
            this.txtMsil.Multiline = true;
            this.txtMsil.Name = "txtMsil";
            this.txtMsil.ReadOnly = true;
            this.txtMsil.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsil.Size = new System.Drawing.Size(669, 306);
            this.txtMsil.TabIndex = 8;
            // 
            // lblMsil
            // 
            this.lblMsil.AutoSize = true;
            this.lblMsil.Location = new System.Drawing.Point(12, 120);
            this.lblMsil.Name = "lblMsil";
            this.lblMsil.Size = new System.Drawing.Size(44, 13);
            this.lblMsil.TabIndex = 9;
            this.lblMsil.Text = "IL Code";
            // 
            // lblExpression
            // 
            this.lblExpression.AutoSize = true;
            this.lblExpression.Location = new System.Drawing.Point(12, 6);
            this.lblExpression.Name = "lblExpression";
            this.lblExpression.Size = new System.Drawing.Size(58, 13);
            this.lblExpression.TabIndex = 10;
            this.lblExpression.Text = "Expression";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 450);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblExpression);
            this.Controls.Add(this.lblMsil);
            this.Controls.Add(this.txtMsil);
            this.Controls.Add(this.lblTrials);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnParse);
            this.Name = "Form1";
            this.Text = "MSIL Expression Compiler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblTrials;
        private System.Windows.Forms.TextBox txtMsil;
        private System.Windows.Forms.Label lblMsil;
        private System.Windows.Forms.Label lblExpression;
    }
}

