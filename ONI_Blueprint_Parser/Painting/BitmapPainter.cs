using System.Windows.Forms;
using BlueprintResources;
using System.Drawing;
using System.Drawing.Imaging;
using BlueprintResources.Buildings;
using System.Collections.Generic;

namespace ONI_Blueprint_Parser.Painting
{
    /// <summary>
    /// https://chrisbitting.com/2013/11/08/overlaying-compositing-images-using-c-system-drawing/
    /// </summary>
    class BitmapPainter
    {
        protected int tileWidth = 50;
        protected int tileHeight = 50;

        protected Blueprint blueprintToPaint;
        protected ToolTip iconToolTip;

        public BitmapPainter(Blueprint blueprintToPaint, ToolTip iconToolTip)
        {
            this.blueprintToPaint = blueprintToPaint;
            this.iconToolTip = iconToolTip;
        }

        /// <summary>
        /// Paints the blueprint on the canvas
        /// </summary>
        /// <returns></returns>
        protected Image Paint()
        {
            Bitmap paintedBlueprint = new Bitmap(tileWidth * blueprintToPaint.Size_X, tileHeight * blueprintToPaint.Size_Y, PixelFormat.Format32bppArgb);
            Graphics blueprintCanvas = Graphics.FromImage(paintedBlueprint);
            
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
