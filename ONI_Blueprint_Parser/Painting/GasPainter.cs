using BlueprintResources;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ONI_Blueprint_Parser.Painting
{
    class GasPainter : BitmapPainter
    {
        private Image paintedBlueprint;
        public GasPainter(Blueprint blueprintToPaint, ToolTip iconToolTip, Image paintedBlueprint) : base(blueprintToPaint, iconToolTip)
        {
            this.paintedBlueprint = (Image)paintedBlueprint.Clone();
        }

        public new Image Paint()
        {
            using (Graphics blueprintCanvas = Graphics.FromImage(paintedBlueprint))
            {
                blueprintCanvas.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.GasConduit || b.ID == EntityID.InsulatedGasConduit).ToList());
                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.GasConduitBridge).ToList());

                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b =>
                b.ID == EntityID.GasPump ||
                b.ID == EntityID.GasValve ||
                b.ID == EntityID.GasVent ||
                b.ID == EntityID.GasFilter ||
                b.ID == EntityID.AirConditioner).ToList());
            }
            return paintedBlueprint;
        }
    }
}
