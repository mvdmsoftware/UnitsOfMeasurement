using System;
using System.Globalization;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Interfaces;
using Ridder.UnitsOfMeasurement.Quantities;

namespace Ridder.UnitsOfMeasurement.Units
{
    /// <summary>
    /// This unit is used for values that do not have a quantity.
    /// We've created a <see cref="ScalarQuantity"/> and <see cref="ScalarUnit"/> for these cases.
    /// </summary>
    public class ScalarUnit : IUnit
    {
        private readonly IQuantity _quantity;

        internal ScalarUnit(IQuantity quantity)
        {
            _quantity = quantity;
        }

        /// <inheritdoc/>
        public string Identifier { get; } = "Scalar";

        /// <inheritdoc/>
        public IQuantity GetQuantity()
        {
            return _quantity;
        }

        /// <inheritdoc/>
        public Task<double> FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value);
        }

        /// <inheritdoc/>
        public Task<double> ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value);
        }

        /// <inheritdoc/>
        public string GetSymbol(CultureInfo cultureInfo)
        {
            return string.Empty;
        }

        /// <inheritdoc/>
        public string GetFormattedValue(double value, CultureInfo cultureInfo)
        {
            return value.ToString(cultureInfo);
        }
    }
}