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

        protected List<Point> GetDrawPoints(Building conduit)
        {
            List<Point> drawPoints = new List<Point>();
            int topLeftCorner_X = tileWidth * GetCanvasBlock_Column(conduit.Location.X, blueprintToPaint.X_NormalizeFactor);
            int topLeftCorner_Y = tileHeight * GetCanvasBlock_Row(conduit.Location.Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y);

            Point origin = new Point((topLeftCorner_X + (tileWidth / 2)), (topLeftCorner_Y + (tileHeight / 2)));
            drawPoints.Add(origin);

            Point northConnection = new Point(origin.X, topLeftCorner_Y);
            Point southConnection = new Point(origin.X, topLeftCorner_Y + tileHeight);

            Point eastConnection = new Point(topLeftCorner_X + tileWidth, origin.Y);
            Point westConnection = new Point(topLeftCorner_X, origin.Y);

            switch (conduit.Connection)
            {
                case Connection.W:
                    drawPoints.Add(westConnection);
                    break;
                case Connection.E:
                    drawPoints.Add(eastConnection);
                    break;
                case Connection.EW:
                    drawPoints.Add(eastConnection);
                    drawPoints.Add(westConnection);
                    break;
                case Connection.N:
                    drawPoints.Add(northConnection);
                    break;
                case Connection.NW:
                    drawPoints.Add(northConnection);
                    drawPoints.Add(westConnection);
                    break;
                case Connection.NE:
                    drawPoints.Add(northConnection);
                    drawPoints.Add(eastConnection);
                    break;
                case Connection.NEW:
                    drawPoints.Add(northConnection);
                    drawPoints.Add(eastConnection);
                    drawPoints.Add(westConnection);
                    break;
                case Connection.S:
                    drawPoints.Add(southConnection);
                    break;
                case Connection.SW:
                    drawPoints.Add(southConnection);
                    drawPoints.Add(westConnection);
                    break;
                case Connection.ES:
                    drawPoints.Add(eastConnection);
                    drawPoints.Add(southConnection);
                    break;
                case Connection.ESW:
                    drawPoints.Add(eastConnection);
                    drawPoints.Add(southConnection);
                    drawPoints.Add(westConnection);
                    break;
                case Connection.NS:
                    drawPoints.Add(northConnection);
                    drawPoints.Add(southConnection);
                    break;
                case Connection.NSW:
                    drawPoints.Add(northConnection);
                    drawPoints.Add(southConnection);
                    drawPoints.Add(westConnection);
                    break;
                case Connection.NSE:
                    drawPoints.Add(northConnection);
                    drawPoints.Add(southConnection);
                    drawPoints.Add(eastConnection);
                    break;
                case Connection.NESW:
                    drawPoints.Add(northConnection);
                    drawPoints.Add(eastConnection);
                    drawPoints.Add(southConnection);
                    drawPoints.Add(westConnection);
                    break;
                case Connection.None:
                    drawPoints.Add(origin);
                    break;
                default:
                    break;
            }

            return drawPoints;
        }

        protected List<Point> GetBridgeDrawPoints(Building conduit)
        {
            List<Point> drawPoints = new List<Point>();
            int topLeftCorner_X = tileWidth * GetCanvasBlock_Column(conduit.Location.X, blueprintToPaint.X_NormalizeFactor);
            int topLeftCorner_Y = tileHeight * GetCanvasBlock_Row(conduit.Location.Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y);

            Point arcOrigin = new Point(topLeftCorner_X, topLeftCorner_Y);
            drawPoints.Add(arcOrigin);

            switch (conduit.Rotation)
            {
                case 90:
                case 270:
                    Point northOrigin = new Point(arcOrigin.X + (tileWidth / 2), arcOrigin.Y);
                    Point northEnd = new Point(northOrigin.X, northOrigin.Y - (tileHeight / 2));
                    Point southOrigin = new Point(arcOrigin.X + (tileWidth / 2), arcOrigin.Y + tileHeight);
                    Point southEnd = new Point(southOrigin.X, southOrigin.Y + (tileHeight / 2));

                    drawPoints.Add(northOrigin);
                    drawPoints.Add(northEnd);
                    drawPoints.Add(southOrigin);
                    drawPoints.Add(southEnd);
                    break;
                default:
                    Point eastOrigin = new Point(arcOrigin.X, arcOrigin.Y + (tileHeight / 2));
                    Point eastEnd = new Point(eastOrigin.X - (tileWidth / 2), eastOrigin.Y);
                    Point westOrigin = new Point(arcOrigin.X + tileWidth, arcOrigin.Y + (tileHeight / 2));
                    Point westEnd = new Point(westOrigin.X + (tileWidth / 2), westOrigin.Y);

                    drawPoints.Add(eastOrigin);
                    drawPoints.Add(eastEnd);
                    drawPoints.Add(westOrigin);
                    drawPoints.Add(westEnd);
                    break;
            }

            return drawPoints;
        }
    }
}
