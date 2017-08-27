using BlueprintResources;
using BlueprintResources.Buildings;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ONI_Blueprint_Parser.Painting
{
    class ElectricalPainter : BitmapPainter
    {
        private Image paintedBlueprint;
        public ElectricalPainter(Blueprint blueprintToPaint, ToolTip iconToolTip, Image paintedBlueprint) : base(blueprintToPaint, iconToolTip)
        {
            this.paintedBlueprint = (Image)paintedBlueprint.Clone();
        }

        public new Image Paint()
        {
            Graphics blueprintCanvas = Graphics.FromImage(paintedBlueprint);
            blueprintCanvas.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

            foreach (Building building in blueprintToPaint.Buildings)
            {
                if (building.ID.Value == EntityID.Wire)
                {
                    int loc_X = tileWidth * GetCanvasBlock_Column(building.Location_X, blueprintToPaint.X_NormalizeFactor);
                    int loc_Y = tileHeight * GetCanvasBlock_Row(building.Location_Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y);

                    try
                    {
                        Image buildingAsset = BuildingAssetManager.GetImage(building);
                        blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y, tileWidth, tileHeight);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Bitmap: " + e.Message);
                    }
                }

                
            }

            return paintedBlueprint;
        }
    }
}
