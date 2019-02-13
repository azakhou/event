namespace EventViewerViewer
{
    partial class DelXmlElement
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
            this.btn_Delele = new System.Windows.Forms.Button();
            this.dgv_xml = new DataGridViewEx();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xml)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Delele
            // 
            this.btn_Delele.Location = new System.Drawing.Point(172, 284);
            this.btn_Delele.Name = "btn_Delele";
            this.btn_Delele.Size = new System.Drawing.Size(75, 23);
            this.btn_Delele.TabIndex = 1;
            this.btn_Delele.Text = "削除";
            this.btn_Delele.UseVisualStyleBackColor = true;
            this.btn_Delele.Click += new System.EventHandler(this.btn_Delele_Click);
            // 
            // dgv_xml
            // 
            this.dgv_xml.Location = new System.Drawing.Point(12, 12);
            this.dgv_xml.Name = "dgv_xml";
            this.dgv_xml.RowTemplate.Height = 21;
            this.dgv_xml.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_xml.Size = new System.Drawing.Size(235, 266);
            this.dgv_xml.TabIndex = 0;
            this.dgv_xml.DataSourceChanged += new System.EventHandler(this.dgv_xml_DataSourceChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(13, 285);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "リセット";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // DelXmlElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 316);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_Delele);
            this.Controls.Add(this.dgv_xml);
            this.Name = "DelXmlElement";
            this.Text = "DelXmlElement";
            this.Load += new System.EventHandler(this.DelXmlElement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xml)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewEx dgv_xml;
        private System.Windows.Forms.Button btn_Delele;
        private System.Windows.Forms.Button btn_clear;
    }
}