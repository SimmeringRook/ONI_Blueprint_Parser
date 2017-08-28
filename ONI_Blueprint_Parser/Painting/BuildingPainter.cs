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
                int loc_X = (tileWidth * GetCanvasBlock_Column(building.Location.X, blueprintToPaint.X_NormalizeFactor)) - (tileWidth * building.Offset.X);
                int loc_Y = (tileHeight * GetCanvasBlock_Row(building.Location.Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y)) - (tileHeight * building.Offset.Y);

                try
                {
                    if (building.ID == EntityID.Headquarters || 
                        building.ID == EntityID.RationBox || 
                        building.ID == EntityID.Tile || 
                        building.ID == EntityID.BatteryMedium)
                    {
                        blueprintCanvas.DrawImage(building.Sprite, loc_X, loc_Y, tileWidth * building.Size.Width, tileHeight * building.Size.Height);
                        //Image buildingAsset = BuildingAssetManager.GetImage(building);
                        //switch (building.ID.Value)
                        //{
                        //    case EntityID.Headquarters:
                        //        blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y, tileWidth * 4, tileHeight * 4);
                        //        break;
                        //    case EntityID.RationBox:
                        //        blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y - tileHeight, tileWidth * 2, tileHeight * 2);
                        //        break;
                        //    case EntityID.Tile:
                        //        blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y, tileWidth, tileHeight);
                        //        break;
                        //    case EntityID.BatteryMedium:
                        //        blueprintCanvas.DrawImage(buildingAsset, loc_X, loc_Y - tileHeight, tileWidth * 2, tileHeight * 2);
                        //        break;
                        //    case EntityID.WireBridge:
                        //        blueprintCanvas.DrawImage(buildingAsset, loc_X - tileWidth, loc_Y, tileWidth * 3, tileHeight);
                        //        break;
                        //    default:
                        //        break;
                        //}
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
