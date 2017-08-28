using BlueprintResources;
using BlueprintResources.Buildings;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ONI_Blueprint_Parser.Painting
{
    class LiquidPainter : BitmapPainter
    {
        private Image paintedBlueprint;
        public LiquidPainter(Blueprint blueprintToPaint, ToolTip iconToolTip, Image paintedBlueprint) : base(blueprintToPaint, iconToolTip)
        {
            this.paintedBlueprint = (Image)paintedBlueprint.Clone();
        }

        public new Image Paint()
        {
            using (Graphics blueprintCanvas = Graphics.FromImage(paintedBlueprint))
            {
                blueprintCanvas.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

                Pen liquidPen = new Pen(Color.SkyBlue, 4f);
                Pen insulatedliquidPen = new Pen(Color.Yellow, 8f);

                foreach (Building building in blueprintToPaint.Buildings)
                {
                    if (building.ID == EntityID.LiquidConduit || 
                        building.ID == EntityID.InsulatedLiquidConduit)
                    {
                        List<Point> drawPoints = GetDrawPoints(building);
                        Point origin = drawPoints[0];

                        for (int i = 1; i < drawPoints.Count; i++)
                        {
                            if (building.ID == EntityID.InsulatedLiquidConduit)
                                blueprintCanvas.DrawLine(insulatedliquidPen, origin, drawPoints[i]);
                            blueprintCanvas.DrawLine(liquidPen, origin, drawPoints[i]);
                        }
                    }
                    else if (building.ID == EntityID.LiquidConduitBridge)
                    {
                        List<Point> drawPoints = GetBridgeDrawPoints(building);
                        Point arcOrigin = drawPoints[0];

                        if (building.Rotation == 90 || building.Rotation == 270)
                            blueprintCanvas.DrawArc(liquidPen, arcOrigin.X, arcOrigin.Y, tileWidth, tileHeight, 90, 180);
                        else
                            blueprintCanvas.DrawArc(liquidPen, arcOrigin.X, arcOrigin.Y, tileWidth, tileHeight, 0, 180);

                        for (int i = 1; i < drawPoints.Count; i +=2)
                            blueprintCanvas.DrawLine(liquidPen, drawPoints[i], drawPoints[i+1]);
                    }
                }
            }
            return paintedBlueprint;
        }
    }
}
