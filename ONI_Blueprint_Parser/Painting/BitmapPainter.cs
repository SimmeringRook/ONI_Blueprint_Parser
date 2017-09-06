using System.Windows.Forms;
using BlueprintResources;
using System.Drawing;
using System.Drawing.Imaging;
using BlueprintResources.Buildings;
using System.Collections.Generic;

namespace ONI_Blueprint_Parser.Painting
{
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

        protected void DrawOutlines(Graphics blueprintCanvas, List<Building> buildingsToDraw)
        {
            foreach (Building building in buildingsToDraw)
            {
                Point spriteLocation = GetNormalizedPoint(building);
                Size paintSize = new Size(tileWidth * building.Size.Width, tileHeight * building.Size.Height);

                blueprintCanvas.DrawImage(GetRotatedImage(building.Sprite_Outline, building.Rotation), spriteLocation.X, spriteLocation.Y, paintSize.Width, paintSize.Height);
            }
        }

        protected Point GetNormalizedPoint(Building building)
        {
            if (building.Rotation == 90 || building.Rotation == 270)
            {
                int rot_X = (tileWidth * GetCanvasBlock_Column(building.Location.X, blueprintToPaint.X_NormalizeFactor)) - (tileWidth * building.Offset.X);
                int rot_Y = (tileHeight * GetCanvasBlock_Row(building.Location.Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y)) - (tileHeight * building.Offset.Y) + tileHeight;

                return new Point(rot_X, rot_Y);
            }
            int loc_X = (tileWidth * GetCanvasBlock_Column(building.Location.X, blueprintToPaint.X_NormalizeFactor)) - (tileWidth * building.Offset.X);
            int loc_Y = (tileHeight * GetCanvasBlock_Row(building.Location.Y, blueprintToPaint.Y_NormalizeFactor, blueprintToPaint.Size_Y)) - (tileHeight * building.Offset.Y);

            return new Point(loc_X, loc_Y);
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

        protected Image GetRotatedImage(Image sprite, int rotation)
        {
            var rotatedSprite = (Image)sprite.Clone();

            switch (rotation)
            {
                case 90:
                    rotatedSprite.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 180:
                    rotatedSprite.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 270:
                    rotatedSprite.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                default:
                    break;
            }

            return rotatedSprite;
        }
    }
}
