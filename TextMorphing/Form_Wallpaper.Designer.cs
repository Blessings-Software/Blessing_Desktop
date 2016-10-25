﻿namespace YoutubeWallpaper
{
    partial class Form_Wallpaper
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
            this.components = new System.ComponentModel.Container();
            this.webBrowser_page = new System.Windows.Forms.WebBrowser();
            this.panel_cursor = new System.Windows.Forms.Panel();
            this.timer_check = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // webBrowser_page
            // 
            this.webBrowser_page.AllowWebBrowserDrop = false;
            this.webBrowser_page.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser_page.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_page.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser_page.MinimumSize = new System.Drawing.Size(18, 16);
            this.webBrowser_page.Name = "webBrowser_page";
            this.webBrowser_page.ScrollBarsEnabled = false;
            this.webBrowser_page.Size = new System.Drawing.Size(521, 317);
            this.webBrowser_page.TabIndex = 0;
            this.webBrowser_page.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser_page.WebBrowserShortcutsEnabled = false;
            // 
            // panel_cursor
            // 
            this.panel_cursor.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel_cursor.Location = new System.Drawing.Point(0, 0);
            this.panel_cursor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_cursor.Name = "panel_cursor";
            this.panel_cursor.Size = new System.Drawing.Size(10, 10);
            this.panel_cursor.TabIndex = 1;
            this.panel_cursor.Visible = false;
            // 
            // timer_check
            // 
            this.timer_check.Interval = 1000;
            this.timer_check.Tick += new System.EventHandler(this.timer_check_Tick);
            // 
            // Form_Wallpaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(521, 317);
            this.Controls.Add(this.panel_cursor);
            this.Controls.Add(this.webBrowser_page);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Wallpaper";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wallpaper";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Wallpaper_FormClosing);
            this.Load += new System.EventHandler(this.Form_Wallpaper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser_page;
        private System.Windows.Forms.Panel panel_cursor;
        private System.Windows.Forms.Timer timer_check;
    }
}