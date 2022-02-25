namespace FDB.Apollo.IPT.App
{
    partial class ColorEditForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuMainFil = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSubmit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilePublish = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainViewAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainToolsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.lblID = new System.Windows.Forms.Label();
            this.lblColorDesc = new System.Windows.Forms.Label();
            this.lblAbbrv = new System.Windows.Forms.Label();
            this.lblBasicColorID = new System.Windows.Forms.Label();
            this.chkDoNotUse = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtAbbrv = new System.Windows.Forms.TextBox();
            this.txtBasicColorID = new System.Windows.Forms.TextBox();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFil,
            this.mnuMainView,
            this.mnuMainTools});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(407, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuMainFil
            // 
            this.mnuMainFil.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileEdit,
            this.mnuFileSave,
            this.mnuFileSubmit,
            this.mnuFilePublish});
            this.mnuMainFil.Name = "mnuMainFil";
            this.mnuMainFil.Size = new System.Drawing.Size(37, 20);
            this.mnuMainFil.Text = "File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(180, 22);
            this.mnuFileNew.Text = "New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(180, 22);
            this.mnuFileOpen.Text = "Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileEdit
            // 
            this.mnuFileEdit.Name = "mnuFileEdit";
            this.mnuFileEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuFileEdit.Size = new System.Drawing.Size(180, 22);
            this.mnuFileEdit.Text = "Edit";
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(180, 22);
            this.mnuFileSave.Text = "Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSubmit
            // 
            this.mnuFileSubmit.Name = "mnuFileSubmit";
            this.mnuFileSubmit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuFileSubmit.Size = new System.Drawing.Size(180, 22);
            this.mnuFileSubmit.Text = "Submit";
            // 
            // mnuFilePublish
            // 
            this.mnuFilePublish.Name = "mnuFilePublish";
            this.mnuFilePublish.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuFilePublish.Size = new System.Drawing.Size(180, 22);
            this.mnuFilePublish.Text = "Publish";
            // 
            // mnuMainView
            // 
            this.mnuMainView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainViewAudit});
            this.mnuMainView.Name = "mnuMainView";
            this.mnuMainView.Size = new System.Drawing.Size(44, 20);
            this.mnuMainView.Text = "View";
            // 
            // mnuMainViewAudit
            // 
            this.mnuMainViewAudit.Name = "mnuMainViewAudit";
            this.mnuMainViewAudit.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuMainViewAudit.Size = new System.Drawing.Size(122, 22);
            this.mnuMainViewAudit.Text = "Audit";
            this.mnuMainViewAudit.Click += new System.EventHandler(this.mnuMainViewAudit_Click);
            // 
            // mnuMainTools
            // 
            this.mnuMainTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainToolsRefresh});
            this.mnuMainTools.Name = "mnuMainTools";
            this.mnuMainTools.Size = new System.Drawing.Size(46, 20);
            this.mnuMainTools.Text = "Tools";
            // 
            // mnuMainToolsRefresh
            // 
            this.mnuMainToolsRefresh.Name = "mnuMainToolsRefresh";
            this.mnuMainToolsRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuMainToolsRefresh.Size = new System.Drawing.Size(132, 22);
            this.mnuMainToolsRefresh.Text = "Refresh";
            this.mnuMainToolsRefresh.Click += new System.EventHandler(this.mnuMainToolsRefresh_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 30);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 15);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            // 
            // lblColorDesc
            // 
            this.lblColorDesc.AutoSize = true;
            this.lblColorDesc.Location = new System.Drawing.Point(12, 59);
            this.lblColorDesc.Name = "lblColorDesc";
            this.lblColorDesc.Size = new System.Drawing.Size(67, 15);
            this.lblColorDesc.TabIndex = 2;
            this.lblColorDesc.Text = "Description";
            // 
            // lblAbbrv
            // 
            this.lblAbbrv.AutoSize = true;
            this.lblAbbrv.Location = new System.Drawing.Point(12, 88);
            this.lblAbbrv.Name = "lblAbbrv";
            this.lblAbbrv.Size = new System.Drawing.Size(75, 15);
            this.lblAbbrv.TabIndex = 3;
            this.lblAbbrv.Text = "Abbreviation";
            // 
            // lblBasicColorID
            // 
            this.lblBasicColorID.AutoSize = true;
            this.lblBasicColorID.Location = new System.Drawing.Point(12, 117);
            this.lblBasicColorID.Name = "lblBasicColorID";
            this.lblBasicColorID.Size = new System.Drawing.Size(80, 15);
            this.lblBasicColorID.TabIndex = 4;
            this.lblBasicColorID.Text = "Basic Color ID";
            // 
            // chkDoNotUse
            // 
            this.chkDoNotUse.AutoSize = true;
            this.chkDoNotUse.Location = new System.Drawing.Point(214, 29);
            this.chkDoNotUse.Name = "chkDoNotUse";
            this.chkDoNotUse.Size = new System.Drawing.Size(86, 19);
            this.chkDoNotUse.TabIndex = 5;
            this.chkDoNotUse.Text = "Do Not Use";
            this.chkDoNotUse.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(108, 27);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 23);
            this.txtID.TabIndex = 6;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(108, 56);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(268, 23);
            this.txtDesc.TabIndex = 7;
            // 
            // txtAbbrv
            // 
            this.txtAbbrv.Location = new System.Drawing.Point(108, 85);
            this.txtAbbrv.Name = "txtAbbrv";
            this.txtAbbrv.Size = new System.Drawing.Size(100, 23);
            this.txtAbbrv.TabIndex = 8;
            // 
            // txtBasicColorID
            // 
            this.txtBasicColorID.Location = new System.Drawing.Point(108, 114);
            this.txtBasicColorID.Name = "txtBasicColorID";
            this.txtBasicColorID.Size = new System.Drawing.Size(100, 23);
            this.txtBasicColorID.TabIndex = 9;
            // 
            // ColorEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 182);
            this.Controls.Add(this.txtBasicColorID);
            this.Controls.Add(this.txtAbbrv);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.chkDoNotUse);
            this.Controls.Add(this.lblBasicColorID);
            this.Controls.Add(this.lblAbbrv);
            this.Controls.Add(this.lblColorDesc);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "ColorEditForm";
            this.Text = "IPT Color";
            this.Load += new System.EventHandler(this.ColorEditForm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuMainFil;
        private ToolStripMenuItem mnuFileNew;
        private ToolStripMenuItem mnuFileOpen;
        private ToolStripMenuItem mnuFileEdit;
        private ToolStripMenuItem mnuFileSave;
        private ToolStripMenuItem mnuFileSubmit;
        private ToolStripMenuItem mnuFilePublish;
        private Label lblID;
        private Label lblColorDesc;
        private Label lblAbbrv;
        private Label lblBasicColorID;
        private CheckBox chkDoNotUse;
        private TextBox txtID;
        private TextBox txtDesc;
        private TextBox txtAbbrv;
        private ToolStripMenuItem mnuMainTools;
        private ToolStripMenuItem mnuMainToolsRefresh;
        private ToolStripMenuItem mnuMainView;
        private ToolStripMenuItem mnuMainViewAudit;
        private TextBox txtBasicColorID;
    }
}