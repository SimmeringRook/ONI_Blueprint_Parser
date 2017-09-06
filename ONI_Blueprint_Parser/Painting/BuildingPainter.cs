using System.Windows.Forms;
using BlueprintResources;
using System.Drawing;
using BlueprintResources.Buildings;
using System.Linq;
using System.Collections.Generic;

namespace ONI_Blueprint_Parser.Painting
{
    class BuildingPainter : BitmapPainter
    {
        public BuildingPainter(Blueprint blueprintToPaint, ToolTip iconToolTip) : base(blueprintToPaint, iconToolTip)
        {

        }

        public new Image Paint()
        {
            Image blueprintBase = base.Paint();

            using (Graphics blueprintCanvas = Graphics.FromImage(blueprintBase))
            {
                blueprintCanvas.Clear(Color.Transparent);

                DrawBuildings(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.GasConduit || b.ID == EntityID.InsulatedGasConduit).ToList());
                DrawBuildings(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.LiquidConduit || b.ID == EntityID.InsulatedLiquidConduit).ToList());
                DrawBuildings(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.Wire || b.ID == EntityID.HighWattageWire).ToList());

                DrawBuildings(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.GasConduitBridge).ToList());
                DrawBuildings(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.LiquidConduitBridge).ToList());
                DrawBuildings(blueprintCanvas, blueprintToPaint.Buildings.Where(b => b.ID == EntityID.WireBridge).ToList());

                DrawBuildings(blueprintCanvas, blueprintToPaint.Buildings.Where(b => 
                b.ID != EntityID.GasConduit &&
                b.ID != EntityID.InsulatedGasConduit && 
                b.ID != EntityID.GasConduitBridge &&
                b.ID != EntityID.LiquidConduit &&
                b.ID != EntityID.InsulatedLiquidConduit &&
                b.ID != EntityID.LiquidConduitBridge &&
                b.ID != EntityID.Wire &&
                b.ID != EntityID.HighWattageWire &&
                b.ID != EntityID.WireBridge
                ).ToList());

            }
            return blueprintBase;
        }

        protected void DrawBuildings(Graphics blueprintCanvas, List<Building> buildingsToDraw)
        {
            foreach (Building building in buildingsToDraw)
            {
                Point spriteLocation = GetNormalizedPoint(building);
                Size paintSize = new Size(tileWidth * building.Size.Width, tileHeight * building.Size.Height);

                blueprintCanvas.DrawImage(GetRotatedImage(building.Sprite, building.Rotation), spriteLocation.X, spriteLocation.Y, paintSize.Width, paintSize.Height);
            }
        }
    }
}
