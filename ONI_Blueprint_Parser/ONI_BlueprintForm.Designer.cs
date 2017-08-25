namespace ONI_Blueprint_Parser
{
    partial class ONI_BlueprintForm
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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlueprintToolStripMenuItem,
            this.recentlyLoadedToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(78, 36);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // newBlueprintToolStripMenuItem
            // 
            this.newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            this.newBlueprintToolStripMenuItem.Size = new System.Drawing.Size(289, 38);
            this.newBlueprintToolStripMenuItem.Text = "New Blueprint";
            this.newBlueprintToolStripMenuItem.Click += new System.EventHandler(this.newBlueprintToolStripMenuItem_Click);
            // 
            // recentlyLoadedToolStripMenuItem
            // 
            this.recentlyLoadedToolStripMenuItem.Name = "recentlyLoadedToolStripMenuItem";
            this.recentlyLoadedToolStripMenuItem.Size = new System.Drawing.Size(289, 38);
            this.recentlyLoadedToolStripMenuItem.Text = "Recently Loaded";
            // 
            // ONI_BlueprintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 653);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ONI_BlueprintForm";
            this.Text = "ONI Blueprint Previewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentlyLoadedToolStripMenuItem;
    }
}

