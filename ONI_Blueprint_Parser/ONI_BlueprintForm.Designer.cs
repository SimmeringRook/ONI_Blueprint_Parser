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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.blueprintTabControl = new System.Windows.Forms.TabControl();
            this.buildingTabPage = new System.Windows.Forms.TabPage();
            this.drawingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.electricTabPage = new System.Windows.Forms.TabPage();
            this.liquidTabPage = new System.Windows.Forms.TabPage();
            this.gasTabPage = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.blueprintTabControl.SuspendLayout();
            this.buildingTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1590, 40);
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
            // blueprintTabControl
            // 
            this.blueprintTabControl.Controls.Add(this.buildingTabPage);
            this.blueprintTabControl.Controls.Add(this.electricTabPage);
            this.blueprintTabControl.Controls.Add(this.liquidTabPage);
            this.blueprintTabControl.Controls.Add(this.gasTabPage);
            this.blueprintTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueprintTabControl.Location = new System.Drawing.Point(0, 40);
            this.blueprintTabControl.Name = "blueprintTabControl";
            this.blueprintTabControl.SelectedIndex = 0;
            this.blueprintTabControl.Size = new System.Drawing.Size(1590, 1076);
            this.blueprintTabControl.TabIndex = 1;
            // 
            // buildingTabPage
            // 
            this.buildingTabPage.Controls.Add(this.drawingPanel);
            this.buildingTabPage.Location = new System.Drawing.Point(8, 39);
            this.buildingTabPage.Name = "buildingTabPage";
            this.buildingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.buildingTabPage.Size = new System.Drawing.Size(1574, 1029);
            this.buildingTabPage.TabIndex = 0;
            this.buildingTabPage.Text = "Buildings";
            this.buildingTabPage.UseVisualStyleBackColor = true;
            // 
            // drawingPanel
            // 
            this.drawingPanel.AutoScroll = true;
            this.drawingPanel.BackColor = System.Drawing.SystemColors.Window;
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(3, 3);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1568, 1023);
            this.drawingPanel.TabIndex = 2;
            // 
            // electricTabPage
            // 
            this.electricTabPage.Location = new System.Drawing.Point(8, 39);
            this.electricTabPage.Name = "electricTabPage";
            this.electricTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.electricTabPage.Size = new System.Drawing.Size(850, 566);
            this.electricTabPage.TabIndex = 1;
            this.electricTabPage.Text = "Electrical";
            this.electricTabPage.UseVisualStyleBackColor = true;
            // 
            // liquidTabPage
            // 
            this.liquidTabPage.Location = new System.Drawing.Point(8, 39);
            this.liquidTabPage.Name = "liquidTabPage";
            this.liquidTabPage.Size = new System.Drawing.Size(850, 566);
            this.liquidTabPage.TabIndex = 2;
            this.liquidTabPage.Text = "Liquid";
            this.liquidTabPage.UseVisualStyleBackColor = true;
            // 
            // gasTabPage
            // 
            this.gasTabPage.Location = new System.Drawing.Point(8, 39);
            this.gasTabPage.Name = "gasTabPage";
            this.gasTabPage.Size = new System.Drawing.Size(1574, 1029);
            this.gasTabPage.TabIndex = 3;
            this.gasTabPage.Text = "Gas";
            this.gasTabPage.UseVisualStyleBackColor = true;
            // 
            // ONI_BlueprintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 1116);
            this.Controls.Add(this.blueprintTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ONI_BlueprintForm";
            this.Text = "ONI Blueprint Previewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.blueprintTabControl.ResumeLayout(false);
            this.buildingTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentlyLoadedToolStripMenuItem;
        private System.Windows.Forms.ToolTip iconToolTip;
        private System.Windows.Forms.TabControl blueprintTabControl;
        private System.Windows.Forms.TabPage buildingTabPage;
        private System.Windows.Forms.FlowLayoutPanel drawingPanel;
        private System.Windows.Forms.TabPage electricTabPage;
        private System.Windows.Forms.TabPage liquidTabPage;
        private System.Windows.Forms.TabPage gasTabPage;
    }
}

