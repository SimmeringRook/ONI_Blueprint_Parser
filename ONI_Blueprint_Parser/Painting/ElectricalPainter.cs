using BlueprintResources;
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

                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => 
                b.ID == EntityID.ManualGenerator ||
                b.ID == EntityID.Generator ||
                b.ID == EntityID.HydrogenGenerator ||
                b.ID == EntityID.MethaneGenerator ||
                b.ID == EntityID.Battery ||
                b.ID == EntityID.BatteryMedium ||
                b.ID == EntityID.PowerTransformer ||
                b.ID == EntityID.AirConditioner ||
                b.ID == EntityID.LiquidConditioner ||
                b.ID == EntityID.SpaceHeater ||
                b.ID == EntityID.LiquidHeater).ToList());

                DrawOutlines(blueprintCanvas, blueprintToPaint.Buildings.Where(b => 
                b.ID == EntityID.Switch ||
                b.ID == EntityID.TemperatureControlledSwitch ||
                b.ID == EntityID.PressureSwitchLiquid ||
                b.ID == EntityID.PressureSwitchGas).ToList());

            }
            return paintedBlueprint;
        }
    }
}
