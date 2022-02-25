using System.Reflection;

namespace ResolutionScaleSwitcher
{
    partial class ContextMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        /// private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem setDpi175;
        private System.Windows.Forms.ToolStripMenuItem setDpi200;
        private System.Windows.Forms.ToolStripMenuItem closeItem;
        private System.ComponentModel.IContainer components;

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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextMenu));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setDpi175 = new System.Windows.Forms.ToolStripMenuItem();
            this.setDpi200 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            // 
            // contextMenu1
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.setDpi175,
                this.setDpi200,
                new ToolStripSeparator(),
                this.closeItem,
            });
            this.contextMenu.Name = "contextMenu1";
            this.contextMenu.Size = new System.Drawing.Size(148, 80);
            // 
            // setDpi175
            // 
            this.setDpi175.Name = "setDpi175";
            this.setDpi175.Size = new System.Drawing.Size(147, 38);
            this.setDpi175.Text = "175%";
            this.setDpi175.Click += new System.EventHandler(this.set_dpi_175);
            // 
            // setDpi200
            // 
            this.setDpi200.Name = "setDpi200";
            this.setDpi200.Size = new System.Drawing.Size(147, 38);
            this.setDpi200.Text = "200%";
            this.setDpi200.Click += new System.EventHandler(this.set_dpi_200);
            // 
            // closeItem
            // 
            this.closeItem.Name = "closeItem";
            this.closeItem.Size = new System.Drawing.Size(147, 38);
            this.closeItem.Text = "Quit";
            this.closeItem.Click += new System.EventHandler(this.close);
            // 
            // notifyIcon1
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon.Text = "DPI Switcher";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon1_RightClick);
        }

        private void notifyIcon1_RightClick(object Sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
            {
                if (me.Button == MouseButtons.Right)
                {
                    MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                    mi.Invoke(this.notifyIcon, null);
                }
            }
        }

        private void close(object Sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}