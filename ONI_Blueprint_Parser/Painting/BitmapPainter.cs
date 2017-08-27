using System.Windows.Forms;
using BlueprintResources;
using System.Drawing;
using System.Drawing.Imaging;

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

        protected Image TintAsset(Image buildingAsset, Element element)
        {
            Bitmap tintedBackground = new Bitmap(tileWidth, tileHeight);
            
            for (int y = 0; y < tintedBackground.Height; y++)
            {
                for (int x = 0; x < tintedBackground.Width; x++)
                {
                    tintedBackground.SetPixel(x, y, ColorCell(element));
                }
            }

            Graphics merger = Graphics.FromImage(tintedBackground);
            merger.DrawImage(tintedBackground, 0, 0, 50, 50);
            merger.DrawImage(buildingAsset, 0, 0, 50, 50);

            return tintedBackground;
        }

        /// <summary>
        /// Adds a back color to the canvasBlock for the corresponding <see cref="Element"/>
        /// </summary>
        /// <param name="elementInCell"></param>
        /// <param name="canvasBlock"></param>
        protected Color ColorCell(Element elementInCell)
        {
            switch (elementInCell)
            {
                case Element.Algae:
                    return System.Drawing.Color.SeaGreen;
                case Element.Dirt:
                    return System.Drawing.Color.RosyBrown;
                case Element.Obsidian:
                    return System.Drawing.Color.Black;
                case Element.OxyRock:
                    return System.Drawing.Color.Aquamarine;
                case Element.SandStone:
                    return System.Drawing.Color.SandyBrown;
                case Element.IronOre:
                    return System.Drawing.Color.IndianRed;
                case Element.Oxygen:
                    return System.Drawing.Color.Cyan;
                case Element.SedimentaryRock:
                    return System.Drawing.Color.BurlyWood;
                case Element.Cuprite:
                    return System.Drawing.Color.Crimson;
                case Element.Wolframite:
                    return System.Drawing.Color.DarkGray;
                default:
                    return Color.Yellow;
            }
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

        protected Image ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }
    }
}
