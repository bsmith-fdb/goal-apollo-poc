namespace FDB.Apollo.IPT.App
{
    partial class AuditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdAudit = new System.Windows.Forms.DataGridView();
            this.grdAuditColProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdAuditColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAudit
            // 
            this.grdAudit.AllowUserToAddRows = false;
            this.grdAudit.AllowUserToDeleteRows = false;
            this.grdAudit.AllowUserToResizeRows = false;
            this.grdAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAudit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdAuditColProperty,
            this.grdAuditColValue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAudit.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAudit.Location = new System.Drawing.Point(0, 0);
            this.grdAudit.Name = "grdAudit";
            this.grdAudit.ReadOnly = true;
            this.grdAudit.RowHeadersVisible = false;
            this.grdAudit.RowTemplate.Height = 25;
            this.grdAudit.Size = new System.Drawing.Size(308, 306);
            this.grdAudit.TabIndex = 0;
            // 
            // grdAuditColProperty
            // 
            this.grdAuditColProperty.HeaderText = "Property";
            this.grdAuditColProperty.Name = "grdAuditColProperty";
            this.grdAuditColProperty.ReadOnly = true;
            // 
            // grdAuditColValue
            // 
            this.grdAuditColValue.HeaderText = "Value";
            this.grdAuditColValue.Name = "grdAuditColValue";
            this.grdAuditColValue.ReadOnly = true;
            // 
            // AuditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 306);
            this.Controls.Add(this.grdAudit);
            this.Name = "AuditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audit Viewer";
            this.Load += new System.EventHandler(this.AuditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView grdAudit;
        private DataGridViewTextBoxColumn grdAuditColProperty;
        private DataGridViewTextBoxColumn grdAuditColValue;
    }
}