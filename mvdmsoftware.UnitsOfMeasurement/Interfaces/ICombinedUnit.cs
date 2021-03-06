namespace mvdmsoftware.UnitsOfMeasurement.Interfaces
{
    public interface ICombinedUnit : IUnit
    {
        IUnit NumeratorUnit { get; }
        IUnit DenominatorUnit { get; }

        new ICombinedQuantity GetQuantity();
    }
}