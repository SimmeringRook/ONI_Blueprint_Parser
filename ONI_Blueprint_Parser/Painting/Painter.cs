using BlueprintResources;
using BlueprintResources.Buildings;
using System;
using System.Windows.Forms;

namespace ONI_Blueprint_Parser.Painting
{
    class Painter
    {
        protected Blueprint blueprintToPaint;
        protected ToolTip iconToolTip;
        public Painter(Blueprint blueprintToPaint, ToolTip iconToolTip)
        {
            this.blueprintToPaint = blueprintToPaint;
            this.iconToolTip = iconToolTip;
        }

        /// <summary>
        /// Paints the blueprint on the canvas
        /// </summary>
        /// <returns></returns>
        internal TableLayoutPanel Paint()
        {
            TableLayoutPanel blueprintCanvas = BuildNewCanvas();
            
            AddCellsToCanvas(blueprintCanvas);

            
            //NOTE:: Everything up to this point should be standard,
            //regardless of tabPage being viewed;
            //The only differing call should be wether or not to paint:
            //Buidlings, Wires, Liquid Pipes, or Gas Pipes
            AddBuildingsToCanvas(blueprintCanvas);

            return blueprintCanvas;
        }

        #region Canvas
        /// <summary>
        /// Builds a new empty template of blueprintCanvas
        /// </summary>
        /// <returns></returns>
        protected TableLayoutPanel BuildNewCanvas()
        {
            TableLayoutPanel blueprintCanvas = new TableLayoutPanel();
            blueprintCanvas.AutoSize = true;
            blueprintCanvas.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            //Set the number of columns to the width of the blueprint
            blueprintCanvas.ColumnCount = blueprintToPaint.Size_X;
            for (int x = 0; x <= blueprintCanvas.ColumnCount; x++)
                blueprintCanvas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));

            //Set the number of rows to the height of the blueprint
            blueprintCanvas.RowCount = blueprintToPaint.Size_Y;
            for (int y = 0; y < blueprintCanvas.RowCount; y++)
                blueprintCanvas.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            return blueprintCanvas;
        }



        /// <summary>
        /// Paints each canvasBlock in the blueprintCanvas according to the <see cref="Cell"/>'s <seealso cref="Element"/>.
        /// </summary>
        /// <param name="blueprintCanvas"></param>
        protected void AddCellsToCanvas(TableLayoutPanel blueprintCanvas)
        {
            foreach (Cell cell in blueprintToPaint.Cells)
            {
                //Set up a new canvasBlock
                PictureBox canvasBlock = CreateNewCanvasBlock(cell.Element.Value);
                canvasBlock.Tag = string.Format("{0} [{1},{2}]", cell.Element.Value.ToString(), cell.Location_X, cell.Location_Y);
                //Set up mouse-over information
                iconToolTip.SetToolTip(canvasBlock, string.Format("{0} [{1},{2}]", cell.Element.Value.ToString(), cell.Location_X, cell.Location_Y));

                //Get the cell's position
                int canvasColumn = GetCanvasBlock_Column(cell.Location_X, blueprintToPaint.X_NormalizeFactor);
                int canvasRow = GetCanvasBlock_Row(cell.Location_Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y);

                
                //Assign the canvasBlock to the canvas
                blueprintCanvas.Controls.Add(canvasBlock, canvasColumn, canvasRow);
            }
        }

        /// <summary>
        /// Creates a new template of canvasBlock
        /// </summary>
        /// <param name="cellElement"></param>
        /// <returns></returns>
        protected PictureBox CreateNewCanvasBlock(Element cellElement)
        {
            PictureBox canvasBlock = new PictureBox();
            canvasBlock.SizeMode = PictureBoxSizeMode.StretchImage;
            canvasBlock.Dock = DockStyle.Fill;
            ColorCell(cellElement, canvasBlock);

            return canvasBlock;
        }

        /// <summary>
        /// Adds a back color to the canvasBlock for the corresponding <see cref="Element"/>
        /// </summary>
        /// <param name="elementInCell"></param>
        /// <param name="canvasBlock"></param>
        protected void ColorCell(Element elementInCell, PictureBox canvasBlock)
        {
            switch (elementInCell)
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
                case Element.Cuprite:
                    canvasBlock.BackColor = System.Drawing.Color.Crimson;
                    break;
                case Element.Wolframite:
                    canvasBlock.BackColor = System.Drawing.Color.DarkGray;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Attempts to load in the images for each building located inside the blueprint
        /// </summary>
        /// <param name="blueprintCanvas"></param>
        protected void AddBuildingsToCanvas(TableLayoutPanel blueprintCanvas)
        {
            /* The size blueprintCanvas.Controls will always be >= blueprintToPaint.Buildings */
            foreach (Control c in blueprintCanvas.Controls)
            {
                if (c is PictureBox)
                {
                    foreach (Building building in blueprintToPaint.Buildings)
                    {
                        //Get the building's position on the canvas
                        int canvasColumn = GetCanvasBlock_Column(building.Location_X, blueprintToPaint.X_NormalizeFactor);
                        int canvasRow = GetCanvasBlock_Row(building.Location_Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y);

                        if (blueprintCanvas.GetColumn(c) == canvasColumn && blueprintCanvas.GetRow(c) == canvasRow)
                        {
                            PictureBox canvasBlock = (PictureBox)c;

                            //Change mouse-over information to reflect details about the building
                            iconToolTip.SetToolTip(canvasBlock, string.Format("{0}\n{1} [{2},{3}]", building.ID.ToString(), building.Element.Value.ToString(), building.Location_X, building.Location_Y));

                            //Attempt to locate the building's asset and display it.
                            try
                            {
                                switch (building.ID.Value)
                                {
                                    case EntityID.Headquarters:
                                    case EntityID.RationBox:
                                    case EntityID.Tile:
                                        canvasBlock.Image = BuildingAssetManager.GetImage(building.ID.Value);
                                        break;
                                    default:
                                        break;
                                }

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Normalizes the X coordinate. (Locations are stored in the .yaml with negative numbers)
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="X_NormalizeFactor"></param>
        /// <returns></returns>
        protected static int GetCanvasBlock_Column(int locationX, int X_NormalizeFactor)
        {
            return locationX + X_NormalizeFactor;
        }


        /// <summary>
        /// Normalizes th Y coordinate, and inverts it.
        /// (Locations are stored in the .yaml with negative numbers, and the parser
        /// stores objects in reverse y-coordinate order)
        /// </summary>
        /// <param name="locationY"></param>
        /// <param name="Y_NormalizeFactor"></param>
        /// <returns></returns>
        protected static int GetCanvasBlock_Row(int locationY, int Y_NormalizeFactor, int maxY)
        {
            return (maxY - 1) - (locationY + Y_NormalizeFactor);
        }

        
    }
}
