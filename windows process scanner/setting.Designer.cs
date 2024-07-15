namespace windows_process_scanner
{
    partial class setting
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
            this.listboxname = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxPath = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addname = new System.Windows.Forms.Button();
            this.remove_name = new System.Windows.Forms.Button();
            this.addPath = new System.Windows.Forms.Button();
            this.removePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listboxname
            // 
            this.listboxname.FormattingEnabled = true;
            this.listboxname.ItemHeight = 16;
            this.listboxname.Location = new System.Drawing.Point(27, 61);
            this.listboxname.Name = "listboxname";
            this.listboxname.Size = new System.Drawing.Size(335, 308);
            this.listboxname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Process Name";
            // 
            // listBoxPath
            // 
            this.listBoxPath.FormattingEnabled = true;
            this.listBoxPath.ItemHeight = 16;
            this.listBoxPath.Location = new System.Drawing.Point(416, 61);
            this.listBoxPath.Name = "listBoxPath";
            this.listBoxPath.Size = new System.Drawing.Size(335, 308);
            this.listBoxPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(514, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Process Path";
            // 
            // addname
            // 
            this.addname.Location = new System.Drawing.Point(27, 375);
            this.addname.Name = "addname";
            this.addname.Size = new System.Drawing.Size(80, 39);
            this.addname.TabIndex = 4;
            this.addname.Text = "Add";
            this.addname.UseVisualStyleBackColor = true;
            this.addname.Click += new System.EventHandler(this.addname_Click);
            // 
            // remove_name
            // 
            this.remove_name.Location = new System.Drawing.Point(280, 375);
            this.remove_name.Name = "remove_name";
            this.remove_name.Size = new System.Drawing.Size(80, 39);
            this.remove_name.TabIndex = 5;
            this.remove_name.Text = "Remove";
            this.remove_name.UseVisualStyleBackColor = true;
            this.remove_name.Click += new System.EventHandler(this.remove_name_Click);
            // 
            // addPath
            // 
            this.addPath.Location = new System.Drawing.Point(416, 375);
            this.addPath.Name = "addPath";
            this.addPath.Size = new System.Drawing.Size(80, 39);
            this.addPath.TabIndex = 6;
            this.addPath.Text = "Add";
            this.addPath.UseVisualStyleBackColor = true;
            this.addPath.Click += new System.EventHandler(this.addPath_Click);
            // 
            // removePath
            // 
            this.removePath.Location = new System.Drawing.Point(671, 375);
            this.removePath.Name = "removePath";
            this.removePath.Size = new System.Drawing.Size(80, 39);
            this.removePath.TabIndex = 7;
            this.removePath.Text = "Remove";
            this.removePath.UseVisualStyleBackColor = true;
            this.removePath.Click += new System.EventHandler(this.removePath_Click);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removePath);
            this.Controls.Add(this.addPath);
            this.Controls.Add(this.remove_name);
            this.Controls.Add(this.addname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listboxname);
            this.MaximizeBox = false;
            this.Name = "setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listboxname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addname;
        private System.Windows.Forms.Button remove_name;
        private System.Windows.Forms.Button addPath;
        private System.Windows.Forms.Button removePath;
    }
}