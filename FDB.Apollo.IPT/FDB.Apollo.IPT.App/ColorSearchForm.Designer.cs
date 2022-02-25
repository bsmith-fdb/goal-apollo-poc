namespace FDB.Apollo.IPT.App
{
    partial class ColorSearchForm
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
            this.grdData = new System.Windows.Forms.DataGridView();
            this.grdDataColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColAbbrv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColDoNotUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColBasicColorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColLastModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColLastModifyUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColPublishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColPublishUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdDataColWipStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblTotalRowCount = new System.Windows.Forms.Label();
            this.rdoWIP = new System.Windows.Forms.RadioButton();
            this.rdoPublished = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToResizeRows = false;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdDataColID,
            this.grdDataColDesc,
            this.grdDataColAbbrv,
            this.grdDataColDoNotUse,
            this.grdDataColBasicColorID,
            this.grdDataColLastModifyDate,
            this.grdDataColLastModifyUser,
            this.grdDataColPublishDate,
            this.grdDataColPublishUser,
            this.grdDataColWipStatus});
            this.grdData.Location = new System.Drawing.Point(12, 41);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersVisible = false;
            this.grdData.RowTemplate.Height = 25;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(1039, 390);
            this.grdData.TabIndex = 0;
            this.grdData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grdColor_RowsAdded);
            this.grdData.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grdColor_RowsRemoved);
            this.grdData.DoubleClick += new System.EventHandler(this.grdColor_DoubleClick);
            this.grdData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdData_KeyDown);
            // 
            // grdDataColID
            // 
            this.grdDataColID.HeaderText = "Color ID";
            this.grdDataColID.Name = "grdDataColID";
            this.grdDataColID.ReadOnly = true;
            // 
            // grdDataColDesc
            // 
            this.grdDataColDesc.HeaderText = "Color Description";
            this.grdDataColDesc.Name = "grdDataColDesc";
            this.grdDataColDesc.ReadOnly = true;
            // 
            // grdDataColAbbrv
            // 
            this.grdDataColAbbrv.HeaderText = "Color Abbreviation";
            this.grdDataColAbbrv.Name = "grdDataColAbbrv";
            this.grdDataColAbbrv.ReadOnly = true;
            // 
            // grdDataColDoNotUse
            // 
            this.grdDataColDoNotUse.HeaderText = "Color Do Not Use";
            this.grdDataColDoNotUse.Name = "grdDataColDoNotUse";
            this.grdDataColDoNotUse.ReadOnly = true;
            // 
            // grdDataColBasicColorID
            // 
            this.grdDataColBasicColorID.HeaderText = "Basic Color ID";
            this.grdDataColBasicColorID.Name = "grdDataColBasicColorID";
            this.grdDataColBasicColorID.ReadOnly = true;
            // 
            // grdDataColLastModifyDate
            // 
            this.grdDataColLastModifyDate.HeaderText = "Last Modify Date";
            this.grdDataColLastModifyDate.Name = "grdDataColLastModifyDate";
            this.grdDataColLastModifyDate.ReadOnly = true;
            // 
            // grdDataColLastModifyUser
            // 
            this.grdDataColLastModifyUser.HeaderText = "Last Modify User";
            this.grdDataColLastModifyUser.Name = "grdDataColLastModifyUser";
            this.grdDataColLastModifyUser.ReadOnly = true;
            // 
            // grdDataColPublishDate
            // 
            this.grdDataColPublishDate.HeaderText = "Publish Date";
            this.grdDataColPublishDate.Name = "grdDataColPublishDate";
            this.grdDataColPublishDate.ReadOnly = true;
            // 
            // grdDataColPublishUser
            // 
            this.grdDataColPublishUser.HeaderText = "Publish User";
            this.grdDataColPublishUser.Name = "grdDataColPublishUser";
            this.grdDataColPublishUser.ReadOnly = true;
            // 
            // grdDataColWipStatus
            // 
            this.grdDataColWipStatus.HeaderText = "WIP Status";
            this.grdDataColWipStatus.Name = "grdDataColWipStatus";
            this.grdDataColWipStatus.ReadOnly = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(108, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load All Colors";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblTotalRowCount
            // 
            this.lblTotalRowCount.AutoSize = true;
            this.lblTotalRowCount.Location = new System.Drawing.Point(126, 16);
            this.lblTotalRowCount.Name = "lblTotalRowCount";
            this.lblTotalRowCount.Size = new System.Drawing.Size(78, 15);
            this.lblTotalRowCount.TabIndex = 2;
            this.lblTotalRowCount.Text = "Row Count: 0";
            // 
            // rdoWIP
            // 
            this.rdoWIP.AutoSize = true;
            this.rdoWIP.Checked = true;
            this.rdoWIP.Location = new System.Drawing.Point(311, 14);
            this.rdoWIP.Name = "rdoWIP";
            this.rdoWIP.Size = new System.Drawing.Size(46, 19);
            this.rdoWIP.TabIndex = 3;
            this.rdoWIP.TabStop = true;
            this.rdoWIP.Text = "WIP";
            this.rdoWIP.UseVisualStyleBackColor = true;
            this.rdoWIP.CheckedChanged += new System.EventHandler(this.rdoWIP_CheckedChanged);
            // 
            // rdoPublished
            // 
            this.rdoPublished.AutoSize = true;
            this.rdoPublished.Location = new System.Drawing.Point(379, 14);
            this.rdoPublished.Name = "rdoPublished";
            this.rdoPublished.Size = new System.Drawing.Size(77, 19);
            this.rdoPublished.TabIndex = 4;
            this.rdoPublished.Text = "Published";
            this.rdoPublished.UseVisualStyleBackColor = true;
            // 
            // ColorSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 443);
            this.Controls.Add(this.rdoPublished);
            this.Controls.Add(this.rdoWIP);
            this.Controls.Add(this.lblTotalRowCount);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grdData);
            this.Name = "ColorSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IPT Color Search";
            this.Shown += new System.EventHandler(this.ColorSearchForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView grdData;
        private Button btnLoad;
        private DataGridViewTextBoxColumn grdDataColID;
        private DataGridViewTextBoxColumn grdDataColDesc;
        private DataGridViewTextBoxColumn grdDataColAbbrv;
        private DataGridViewTextBoxColumn grdDataColDoNotUse;
        private DataGridViewTextBoxColumn grdDataColBasicColorID;
        private Label lblTotalRowCount;
        private DataGridViewTextBoxColumn grdDataColLastModifyDate;
        private DataGridViewTextBoxColumn grdDataColLastModifyUser;
        private DataGridViewTextBoxColumn grdDataColPublishDate;
        private DataGridViewTextBoxColumn grdDataColPublishUser;
        private DataGridViewTextBoxColumn grdDataColWipStatus;
        private RadioButton rdoWIP;
        private RadioButton rdoPublished;
    }
}