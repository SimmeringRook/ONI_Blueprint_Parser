namespace BlueprintResources
{
    public enum EntityID
    {
        #region Base
        Tile,
        Ladder,
        MeshTile,
        GasPermeableMembrane,
        InsulationTile,
        StorageLocker,
        Door,
        ManualPressureDoor,
        PressureDoor,
        #endregion

        #region Oxygen
        MineralDeoxidizer,
        AlgaeHabitat,
        Electrolyzer,
        AirFilter,
        CO2Scrubber,
        #endregion

        #region Power
        ManualGenerator,
        Generator,
        HydrogenGenerator,
        MethaneGenerator,
        Wire,
        HighWattageWire,
        WireBridge,
        Battery,
        BatteryMedium,
        PowerTransformer,
        Switch,
        TemperatureControlledSwitch,
        PressureSwitchLiquid,
        PressureSwitchGas,
        #endregion

        #region Food
        RationBox,
        Refrigerator,
        MicrobeMusher,
        CookingStation,
        PlanterBox,
        FarmTile,
        HydroponicFarm,
        #endregion

        #region Plumbing
        LiquidConduit,
        Outhouse,
        FlushToilet,
        Shower,
        LiquidPumpingStation,
        BottleEmptier,
        InsulatedLiquidConduit,
        LiquidConduitBridge,
        LiquidPump,
        LiquidValve,
        LiquidFilter,
        LiquidVent,
        #endregion

        #region Ventilation
        GasConduit,
        InsulatedGasConduit,
        GasConduitBridge,
        GasPump,
        GasValve,
        GasVent,
        GasFilter,
        #endregion

        #region Utilities
        LiquidCooledFan,
        AirConditioner,
        LiquidConditioner,
        SpaceHeater,
        OreScrubber,
        LiquidHeater,
        #endregion

        #region Refinement
        AlgaeDistillery,
        Compost,
        WaterPurifier,
        FertilizerMaker,
        #endregion

        #region Medicine
        WashBasin,
        HandSanitizer,
        MedicalBed,
        MedicalCot,
        #endregion

        #region Station
        AdvancedResearchCenter,
        ClothingFabricator,
        ResearchCenter,
        #endregion

        #region Furniture
        Bed,
        MassageTable,
        DiningTable,
        FloorLamp,
        CeilingLight,
        #endregion

        #region Decor
        Sculpture,
        Grave,
        FlowerVase,
        Canvas,
        #endregion

        FieldRation,
        Headquarters,
        None
    }
}
