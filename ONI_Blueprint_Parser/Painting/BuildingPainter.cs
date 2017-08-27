using System;
using System.Windows.Forms;
using BlueprintResources;
using System.Drawing;
using BlueprintResources.Buildings;

namespace ONI_Blueprint_Parser.Painting
{
    class BuildingPainter : BitmapPainter
    {
        public BuildingPainter(Blueprint blueprintToPaint, ToolTip iconToolTip) : base(blueprintToPaint, iconToolTip)
        {

        }

        public new Image Paint()
        {
            Image blueprintBase = base.Paint();
            Graphics blueprintCanvas = Graphics.FromImage(blueprintBase);
            blueprintCanvas.Clear(Color.Transparent);

            foreach (Building building in blueprintToPaint.Buildings)
            {
                int loc_X = tileWidth * GetCanvasBlock_Column(building.Location_X, blueprintToPaint.X_NormalizeFactor);
                int loc_Y = tileHeight * GetCanvasBlock_Row(building.Location_Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y);

                try
                {
                    if (building.ID.Value == EntityID.Headquarters || building.ID.Value == EntityID.RationBox || building.ID.Value == EntityID.Tile)
                    {
                        Image buildingAsset = BuildingAssetManager.GetImage(building);
                        switch (building.ID.Value)
                        {
                            case EntityID.Headquarters:
                                blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y, tileWidth * 4, tileHeight * 4);
                                break;
                            case EntityID.RationBox:
                                blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y, tileWidth * 2, tileHeight);
                                break;
                            case EntityID.Tile:
                                blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y, tileWidth, tileHeight);
                                break;
                            default:
                                break;
                        }
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Bitmap: " + e.Message);
                }
            }

            return blueprintBase;
        }
    }
}
