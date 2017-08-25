using ONI_Blueprint_Parser.Blueprint;
using ONI_Blueprint_Parser.Blueprint.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ONI_Blueprint_Parser
{
    public partial class ONI_BlueprintForm : Form
    {
        Parser.Parser bluePrintParser = new Parser.Parser();

        List<Blueprint.Blueprint> recentBlueprints;
        string currentBlueprintPath = "";

        public ONI_BlueprintForm()
        {
            InitializeComponent();

            recentBlueprints = new List<Blueprint.Blueprint>();
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
                Blueprint.Blueprint newBlueprint;
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

        private void LoadBlueprint(Blueprint.Blueprint blueprint)
        {
            DrawBlueprint(blueprint);
            drawingPanel.Refresh();
        }

        private void UpdateRecentlyOpened()
        {
            recentlyLoadedToolStripMenuItem.DropDownItems.Clear();

            foreach (Blueprint.Blueprint blueprint in recentBlueprints)
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

        #region Drawing Blueprints
        System.Drawing.Color regularTile = System.Drawing.Color.Beige;
        System.Drawing.Color headquarters = System.Drawing.Color.Red;
        private void DrawBlueprint(Blueprint.Blueprint blueprint)
        {
            drawingPanel.Controls.Clear();

            TableLayoutPanel blueprintCanvas = new TableLayoutPanel();
            blueprintCanvas.AutoSize = true;
            blueprintCanvas.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            blueprintCanvas.ColumnCount = blueprint.Size_X;
            for (int x = 0; x <= blueprintCanvas.ColumnCount; x++)
                blueprintCanvas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
            
            blueprintCanvas.RowCount = blueprint.Size_Y;
            for(int y = 0; y <= blueprintCanvas.RowCount; y++)
                blueprintCanvas.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
            
            drawingPanel.Controls.Add(blueprintCanvas);

            foreach (Building building in blueprint.Buildings)
            {
                Panel canvasBlock = new Panel();
                canvasBlock.Size = new System.Drawing.Size(25, 25);

                toolTip1.SetToolTip(canvasBlock, string.Format("{0} [{1},{2}]", building.ID.ToString(), building.Location_X, building.Location_Y));
                //canvasBlock.Dock = DockStyle.Fill;

                switch (building.ID)
                {
                    case Blueprint.EntityID.Tile:
                        canvasBlock.BackColor = regularTile;
                        break;
                    case Blueprint.EntityID.Headquarters:
                        canvasBlock.BackColor = headquarters;
                        break;
                    case Blueprint.EntityID.RationBox:
                        canvasBlock.BackColor = System.Drawing.Color.BlanchedAlmond;
                        break;
                    default:
                        canvasBlock.BackColor = System.Drawing.Color.DarkGray;
                        break;
                }

                blueprintCanvas.Controls.Add(canvasBlock,
                    building.Location_X + blueprint.X_NormalizeFactor,
                    building.Location_Y + blueprint.Y_NormalizeFactor);
            }

            //blueprint.Cells.Reverse();
            foreach (Cell cell in blueprint.Cells)
            {
                Panel canvasBlock = new Panel();
                canvasBlock.Size = new System.Drawing.Size(25, 25);
                toolTip1.SetToolTip(canvasBlock, string.Format("{0} [{1},{2}]", cell.Element.ToString(), cell.Location_X, cell.Location_Y));
                switch (cell.Element)
                {
                    case Element.Algae:
                        canvasBlock.BackColor = System.Drawing.Color.SeaGreen;
                        break;
                    case Element.Dirt:
                        canvasBlock.BackColor = System.Drawing.Color.RosyBrown;
                        break;
                    case Element.Obsidian:
                        canvasBlock.BackColor = System.Drawing.Color.Black;
                        break;
                    case Element.OxyRock:
                        canvasBlock.BackColor = System.Drawing.Color.Aquamarine;
                        break;
                    case Element.SandStone:
                        canvasBlock.BackColor = System.Drawing.Color.SandyBrown;
                        break;
                    case Element.IronOre:
                        canvasBlock.BackColor = System.Drawing.Color.IndianRed;
                        break;
                    case Element.Oxygen:
                        canvasBlock.BackColor = System.Drawing.Color.Cyan;
                        break;
                    case Element.SedimentaryRock:
                        canvasBlock.BackColor = System.Drawing.Color.BurlyWood;
                        break;
                    default:
                        break;
                }

                bool spaceIsTaken = false;

                foreach (Control c in blueprintCanvas.Controls)
                {
                    if (blueprintCanvas.GetColumn(c) == cell.Location_X + blueprint.X_NormalizeFactor &&
                        blueprintCanvas.GetRow(c) == cell.Location_Y + blueprint.Y_NormalizeFactor)
                        spaceIsTaken = true;
                }

                //if (cell.Element == Element.Oxygen)
                //    continue;

                if (spaceIsTaken == false)
                blueprintCanvas.Controls.Add(canvasBlock,
                    cell.Location_X + blueprint.X_NormalizeFactor,
                    cell.Location_Y + blueprint.Y_NormalizeFactor);
            }




            //blueprintCanvas.Dock = DockStyle.Fill;
            drawingPanel.Refresh();
        }

        #endregion

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
