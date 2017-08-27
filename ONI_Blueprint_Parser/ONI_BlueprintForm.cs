using BlueprintResources;
using ONI_Blueprint_Parser.Painting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ONI_Blueprint_Parser
{
    public partial class ONI_BlueprintForm : Form
    {
        Parser.Parser bluePrintParser = new Parser.Parser();

        List<Blueprint> recentBlueprints;
        string currentBlueprintPath = "";

        public ONI_BlueprintForm()
        {
            InitializeComponent();

            recentBlueprints = new List<Blueprint>();
        }

        #region Loading Blueprints
        private void newBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentBlueprintPath = dialog.FileName;
                    bluePrintParser.BlueprintPath = currentBlueprintPath;
                    AttemptLoadOfBlueprint();
                }
            }
        }

        private void AttemptLoadOfBlueprint()
        {
            try
            {
                Blueprint newBlueprint;
                if (bluePrintParser.GetBlueprint(out newBlueprint))
                {
                    recentBlueprints.Insert(0, newBlueprint);
                    UpdateRecentlyOpened();
                    LoadBlueprint(recentBlueprints[0]);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadBlueprint(Blueprint blueprint)
        {
            buildingTabPage.Controls.Clear();
            BitmapPainter blueprintPainter = new BuildingPainter(blueprint, iconToolTip);
            System.Drawing.Image paintedBlueprint = ((blueprintPainter as BuildingPainter).Paint());
            buildingTabPage.Controls.Add(new PictureBox()
                {
                    Image = paintedBlueprint,
                    Size = paintedBlueprint.Size,
                    BackColor = System.Drawing.Color.DimGray
                });

            electricTabPage.Controls.Clear();
            blueprintPainter = new ElectricalPainter(blueprint, iconToolTip, paintedBlueprint);
            paintedBlueprint = (blueprintPainter as ElectricalPainter).Paint();
            electricTabPage.Controls.Add(
                new PictureBox() {
                    Image = paintedBlueprint,
                    Size = paintedBlueprint.Size,
                    BackColor = System.Drawing.Color.DimGray
                });
        }

        private void UpdateRecentlyOpened()
        {
            recentlyLoadedToolStripMenuItem.DropDownItems.Clear();

            foreach (Blueprint blueprint in recentBlueprints)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = blueprint.Name;
                item.Click += new EventHandler(
                    (object sender, EventArgs e) => 
                    {
                        LoadBlueprint(blueprint);
                    });
                recentlyLoadedToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        #endregion

    }
}
