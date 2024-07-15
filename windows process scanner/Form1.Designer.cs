namespace windows_process_scanner
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
            if (disposing)
            {
                components?.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Highlight_checkbox = new System.Windows.Forms.ToolStripMenuItem();
            this.runAsAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button_refresh = new System.Windows.Forms.ToolStripButton();
            this.Terminate_button = new System.Windows.Forms.ToolStripButton();
            this.textBox_filter = new System.Windows.Forms.ToolStripTextBox();
            this.button_applyFilter = new System.Windows.Forms.ToolStripButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Memory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_validate_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_validate_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_validate_signature = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TerminateMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1087, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.endTaskToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // endTaskToolStripMenuItem
            // 
            this.endTaskToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("endTaskToolStripMenuItem.Image")));
            this.endTaskToolStripMenuItem.Name = "endTaskToolStripMenuItem";
            this.endTaskToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.endTaskToolStripMenuItem.Text = "End Task";
            this.endTaskToolStripMenuItem.Click += new System.EventHandler(this.endTaskToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Highlight_checkbox,
            this.runAsAdminToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // Highlight_checkbox
            // 
            this.Highlight_checkbox.CheckOnClick = true;
            this.Highlight_checkbox.Name = "Highlight_checkbox";
            this.Highlight_checkbox.Size = new System.Drawing.Size(181, 26);
            this.Highlight_checkbox.Text = "Sort Process";
            this.Highlight_checkbox.Click += new System.EventHandler(this.Highlight_checkbox_Click);
            // 
            // runAsAdminToolStripMenuItem
            // 
            this.runAsAdminToolStripMenuItem.Name = "runAsAdminToolStripMenuItem";
            this.runAsAdminToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.runAsAdminToolStripMenuItem.Text = "Run as admin";
            this.runAsAdminToolStripMenuItem.Click += new System.EventHandler(this.runAsAdminToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button_refresh,
            this.Terminate_button,
            this.textBox_filter,
            this.button_applyFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1087, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button_refresh
            // 
            this.button_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_refresh.Image")));
            this.button_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(29, 24);
            this.button_refresh.Text = "Refresh";
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // Terminate_button
            // 
            this.Terminate_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Terminate_button.Image = ((System.Drawing.Image)(resources.GetObject("Terminate_button.Image")));
            this.Terminate_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Terminate_button.Name = "Terminate_button";
            this.Terminate_button.Size = new System.Drawing.Size(29, 24);
            this.Terminate_button.Text = "Terminate";
            this.Terminate_button.Click += new System.EventHandler(this.Terminate_button_Click_1);
            // 
            // textBox_filter
            // 
            this.textBox_filter.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_filter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(100, 27);
            this.textBox_filter.Click += new System.EventHandler(this.textBox_filter_Click);
            // 
            // button_applyFilter
            // 
            this.button_applyFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_applyFilter.Image = global::windows_process_scanner.Properties.Resources.search_icon_png;
            this.button_applyFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_applyFilter.Name = "button_applyFilter";
            this.button_applyFilter.Size = new System.Drawing.Size(29, 24);
            this.button_applyFilter.Text = "Search";
            this.button_applyFilter.Click += new System.EventHandler(this.button_applyFilter_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_ID,
            this.columnHeader_Path,
            this.columnHeader_Memory,
            this.columnHeader_validate_name,
            this.columnHeader_validate_path,
            this.columnHeader_validate_signature});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1063, 621);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "Name";
            this.columnHeader_Name.Width = 100;
            // 
            // columnHeader_ID
            // 
            this.columnHeader_ID.Text = "PID";
            this.columnHeader_ID.Width = 40;
            // 
            // columnHeader_Path
            // 
            this.columnHeader_Path.Text = "Path";
            this.columnHeader_Path.Width = 100;
            // 
            // columnHeader_Memory
            // 
            this.columnHeader_Memory.Text = "Memory Usage";
            this.columnHeader_Memory.Width = 90;
            // 
            // columnHeader_validate_name
            // 
            this.columnHeader_validate_name.Text = "Pocess Name Evaluation";
            this.columnHeader_validate_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_validate_name.Width = 150;
            // 
            // columnHeader_validate_path
            // 
            this.columnHeader_validate_path.Text = "Exucutable Path Evaluation";
            this.columnHeader_validate_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_validate_path.Width = 150;
            // 
            // columnHeader_validate_signature
            // 
            this.columnHeader_validate_signature.Text = "Digital Signature Evaluation";
            this.columnHeader_validate_signature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_validate_signature.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TerminateMenuItem
            // 
            this.TerminateMenuItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TerminateMenuItem.Name = "TerminateMenuItem";
            this.TerminateMenuItem.Size = new System.Drawing.Size(61, 4);
            this.TerminateMenuItem.Opening += new System.ComponentModel.CancelEventHandler(this.TerminateMenuItem_Opening);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 704);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Process Scanner and Verifier";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Highlight_checkbox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton button_refresh;
        private System.Windows.Forms.ToolStripButton Terminate_button;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_ID;
        private System.Windows.Forms.ColumnHeader columnHeader_Path;
        private System.Windows.Forms.ColumnHeader columnHeader_Memory;
        private System.Windows.Forms.ColumnHeader columnHeader_validate_name;
        private System.Windows.Forms.ColumnHeader columnHeader_validate_path;
        private System.Windows.Forms.ColumnHeader columnHeader_validate_signature;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem runAsAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox textBox_filter;
        private System.Windows.Forms.ToolStripButton button_applyFilter;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TerminateMenuItem;
    }
}

