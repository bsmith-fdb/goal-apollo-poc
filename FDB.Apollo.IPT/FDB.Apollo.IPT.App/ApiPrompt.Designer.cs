namespace FDB.Apollo.IPT.App
{
    partial class ApiPrompt
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
            this.lblSelect = new System.Windows.Forms.Label();
            this.lstSelect = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(12, 9);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(110, 15);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select API Base URL";
            // 
            // lstSelect
            // 
            this.lstSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelect.FormattingEnabled = true;
            this.lstSelect.IntegralHeight = false;
            this.lstSelect.ItemHeight = 15;
            this.lstSelect.Location = new System.Drawing.Point(12, 27);
            this.lstSelect.Name = "lstSelect";
            this.lstSelect.Size = new System.Drawing.Size(505, 143);
            this.lstSelect.TabIndex = 1;
            this.lstSelect.DoubleClick += new System.EventHandler(this.lstSelect_DoubleClick);
            // 
            // ApiPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 182);
            this.ControlBox = false;
            this.Controls.Add(this.lstSelect);
            this.Controls.Add(this.lblSelect);
            this.Name = "ApiPrompt";
            this.Text = "ApiPrompt";
            this.Load += new System.EventHandler(this.ApiPrompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSelect;
        private ListBox lstSelect;
    }
}