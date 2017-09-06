using BlueprintResources;
using System.Drawing;
using System.Linq;
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

                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.LiquidConduit || b.ID == EntityID.InsulatedLiquidConduit).ToList());
                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.LiquidConduitBridge).ToList());

                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b =>
                b.ID == EntityID.FlushToilet ||
                b.ID == EntityID.Shower ||
                b.ID == EntityID.LiquidPump ||
                b.ID == EntityID.LiquidValve ||
                b.ID == EntityID.LiquidFilter ||
                b.ID == EntityID.LiquidVent ||
                b.ID == EntityID.LiquidConditioner).ToList());

            }
            return paintedBlueprint;
        }
    }
}
