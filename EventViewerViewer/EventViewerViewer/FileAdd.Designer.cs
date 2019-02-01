namespace EventViewerViewer
{
    partial class FileAdd
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
            this.txt_FName = new System.Windows.Forms.TextBox();
            this.btn_Fadd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_FName
            // 
            this.txt_FName.Location = new System.Drawing.Point(12, 12);
            this.txt_FName.Name = "txt_FName";
            this.txt_FName.Size = new System.Drawing.Size(359, 19);
            this.txt_FName.TabIndex = 0;
            // 
            // btn_Fadd
            // 
            this.btn_Fadd.Location = new System.Drawing.Point(377, 8);
            this.btn_Fadd.Name = "btn_Fadd";
            this.btn_Fadd.Size = new System.Drawing.Size(75, 23);
            this.btn_Fadd.TabIndex = 1;
            this.btn_Fadd.Text = "追加";
            this.btn_Fadd.UseVisualStyleBackColor = true;
            this.btn_Fadd.Click += new System.EventHandler(this.btn_Fadd_Click);
            // 
            // FileAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 40);
            this.Controls.Add(this.btn_Fadd);
            this.Controls.Add(this.txt_FName);
            this.MaximumSize = new System.Drawing.Size(482, 79);
            this.MinimumSize = new System.Drawing.Size(482, 79);
            this.Name = "FileAdd";
            this.Text = "FileAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FName;
        private System.Windows.Forms.Button btn_Fadd;
    }
}