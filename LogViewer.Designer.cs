﻿namespace LogViewer
{
    partial class LogViewer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lvMain = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboFilterSetting = new System.Windows.Forms.ComboBox();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.cbxHideBlankLines = new System.Windows.Forms.CheckBox();
            this.cbxIgnoreCase = new System.Windows.Forms.CheckBox();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuClose,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(152, 22);
            this.mnuOpen.Text = "&Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // lvMain
            // 
            this.lvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvMain.FullRowSelect = true;
            this.lvMain.HideSelection = false;
            this.lvMain.Location = new System.Drawing.Point(0, 80);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(648, 266);
            this.lvMain.TabIndex = 1;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Line Number";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Log Entry";
            this.columnHeader2.Width = 520;
            // 
            // cboFilterSetting
            // 
            this.cboFilterSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterSetting.FormattingEnabled = true;
            this.cboFilterSetting.Location = new System.Drawing.Point(288, 26);
            this.cboFilterSetting.Name = "cboFilterSetting";
            this.cboFilterSetting.Size = new System.Drawing.Size(142, 21);
            this.cboFilterSetting.TabIndex = 2;
            this.cboFilterSetting.SelectedIndexChanged += new System.EventHandler(this.cboFilterSetting_SelectedIndexChanged);
            // 
            // txtFilterText
            // 
            this.txtFilterText.Location = new System.Drawing.Point(436, 27);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Size = new System.Drawing.Size(168, 20);
            this.txtFilterText.TabIndex = 3;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            // 
            // lblResults
            // 
            this.lblResults.Location = new System.Drawing.Point(101, 22);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(181, 25);
            this.lblResults.TabIndex = 6;
            // 
            // cbxHideBlankLines
            // 
            this.cbxHideBlankLines.AutoSize = true;
            this.cbxHideBlankLines.Location = new System.Drawing.Point(298, 57);
            this.cbxHideBlankLines.Name = "cbxHideBlankLines";
            this.cbxHideBlankLines.Size = new System.Drawing.Size(106, 17);
            this.cbxHideBlankLines.TabIndex = 7;
            this.cbxHideBlankLines.Text = "Hide Blank Lines";
            this.cbxHideBlankLines.UseVisualStyleBackColor = true;
            this.cbxHideBlankLines.CheckedChanged += new System.EventHandler(this.cbxHideBlankLines_CheckedChanged);
            // 
            // cbxIgnoreCase
            // 
            this.cbxIgnoreCase.AutoSize = true;
            this.cbxIgnoreCase.Location = new System.Drawing.Point(455, 57);
            this.cbxIgnoreCase.Name = "cbxIgnoreCase";
            this.cbxIgnoreCase.Size = new System.Drawing.Size(83, 17);
            this.cbxIgnoreCase.TabIndex = 8;
            this.cbxIgnoreCase.Text = "Ignore Case";
            this.cbxIgnoreCase.UseVisualStyleBackColor = true;
            this.cbxIgnoreCase.CheckedChanged += new System.EventHandler(this.cbxIgnoreCase_CheckedChanged);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(152, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 348);
            this.Controls.Add(this.cbxIgnoreCase);
            this.Controls.Add(this.cbxHideBlankLines);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.txtFilterText);
            this.Controls.Add(this.cboFilterSetting);
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LogViewer";
            this.Text = "Log Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox cboFilterSetting;
        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.CheckBox cbxHideBlankLines;
        private System.Windows.Forms.CheckBox cbxIgnoreCase;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
    }
}

