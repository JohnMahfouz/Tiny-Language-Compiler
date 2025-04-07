namespace TinyCompiler
{
    partial class WindowForm
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
            this.tfSourceCode = new System.Windows.Forms.TextBox();
            this.btnCompile = new System.Windows.Forms.Button();
            this.tblTokens = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tfErrors = new System.Windows.Forms.TextBox();
            this.treePrase = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // tfSourceCode
            // 
            this.tfSourceCode.Location = new System.Drawing.Point(16, 32);
            this.tfSourceCode.Margin = new System.Windows.Forms.Padding(8);
            this.tfSourceCode.Multiline = true;
            this.tfSourceCode.Name = "tfSourceCode";
            this.tfSourceCode.Size = new System.Drawing.Size(400, 573);
            this.tfSourceCode.TabIndex = 0;
            this.tfSourceCode.WordWrap = false;
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(16, 615);
            this.btnCompile.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(200, 31);
            this.btnCompile.TabIndex = 3;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // tblTokens
            // 
            this.tblTokens.AllowUserToAddRows = false;
            this.tblTokens.AllowUserToDeleteRows = false;
            this.tblTokens.AllowUserToResizeRows = false;
            this.tblTokens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblTokens.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tblTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tblTokens.Location = new System.Drawing.Point(432, 32);
            this.tblTokens.Margin = new System.Windows.Forms.Padding(8);
            this.tblTokens.Name = "tblTokens";
            this.tblTokens.ReadOnly = true;
            this.tblTokens.RowHeadersWidth = 50;
            this.tblTokens.RowTemplate.Height = 24;
            this.tblTokens.Size = new System.Drawing.Size(400, 282);
            this.tblTokens.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Lexeme";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Token Class";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Source Code";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(429, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tokens";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(429, 322);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Errors";
            // 
            // tfErrors
            // 
            this.tfErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tfErrors.BackColor = System.Drawing.SystemColors.Control;
            this.tfErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tfErrors.ForeColor = System.Drawing.Color.Red;
            this.tfErrors.Location = new System.Drawing.Point(432, 348);
            this.tfErrors.Margin = new System.Windows.Forms.Padding(8);
            this.tfErrors.Multiline = true;
            this.tfErrors.Name = "tfErrors";
            this.tfErrors.ReadOnly = true;
            this.tfErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tfErrors.Size = new System.Drawing.Size(400, 257);
            this.tfErrors.TabIndex = 10;
            // 
            // treePrase
            // 
            this.treePrase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treePrase.Location = new System.Drawing.Point(848, 32);
            this.treePrase.Margin = new System.Windows.Forms.Padding(8);
            this.treePrase.Name = "treePrase";
            this.treePrase.Size = new System.Drawing.Size(400, 573);
            this.treePrase.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(845, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Parse Tree";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(221, 615);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(195, 31);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // WindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treePrase);
            this.Controls.Add(this.tfErrors);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblTokens);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.tfSourceCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindowForm";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.ShowIcon = false;
            this.Text = "Tiny Compiler (GUI)";
            ((System.ComponentModel.ISupportInitialize)(this.tblTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tfSourceCode;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.DataGridView tblTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tfErrors;
        private System.Windows.Forms.TreeView treePrase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
    }
}