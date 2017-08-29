using BlueprintResources;
using BlueprintResources.Buildings;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            using (Graphics blueprintCanvas = Graphics.FromImage(paintedBlueprint))
            {
                blueprintCanvas.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.Wire || b.ID == EntityID.HighWattageWire).ToList());
                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.WireBridge).ToList());
            }
            return paintedBlueprint;
        }

        protected void DrawOutlines(Graphics blueprintCanvas, List<Building> buildingsToDraw)
        {
            foreach (Building building in buildingsToDraw)
            {
                Point spriteLocation = GetNormalizedPoint(building);
                Size paintSize = new Size(tileWidth * building.Size.Width, tileHeight * building.Size.Height);

                blueprintCanvas.DrawImage(GetRotatedImage(building.Sprite_Outline, building.Rotation), spriteLocation.X, spriteLocation.Y, paintSize.Width, paintSize.Height);
            }
        }
    }
}
