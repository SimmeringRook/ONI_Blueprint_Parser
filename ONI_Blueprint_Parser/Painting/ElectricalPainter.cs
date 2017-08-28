using BlueprintResources;
using BlueprintResources.Buildings;
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
                if (building.ID == EntityID.Wire || building.ID == EntityID.HighWattageWire)
                {
                    int loc_X = (tileWidth * GetCanvasBlock_Column(building.Location.X, blueprintToPaint.X_NormalizeFactor)) - (tileWidth * building.Offset.X);
                    int loc_Y = (tileHeight * GetCanvasBlock_Row(building.Location.Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y)) - (tileHeight * building.Offset.Y);


                    blueprintCanvas.DrawImage(building.Sprite, loc_X, loc_Y, tileWidth * building.Size.Width, tileHeight * building.Size.Height);
                }
            }

            foreach (Building building in blueprintToPaint.Buildings)
            {
                if (building.ID == EntityID.WireBridge)
                {
                    int loc_X = (tileWidth * GetCanvasBlock_Column(building.Location.X, blueprintToPaint.X_NormalizeFactor)) - (tileWidth * building.Offset.X);
                    int loc_Y = (tileHeight * GetCanvasBlock_Row(building.Location.Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y)) - (tileHeight * building.Offset.Y);

                    blueprintCanvas.DrawImage(building.Sprite, loc_X, loc_Y, tileWidth * building.Size.Width, tileHeight * building.Size.Height);
                }
            }

            return paintedBlueprint;
        }
    }
}
