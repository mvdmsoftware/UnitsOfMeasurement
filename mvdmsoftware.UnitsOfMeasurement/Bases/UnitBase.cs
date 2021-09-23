﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using FormatWith;
using Ridder.UnitsOfMeasurement.Interfaces;
using Ridder.UnitsOfMeasurement.Resources.UnitsFormatting;
using Ridder.UnitsOfMeasurement.Resources.UnitSymbols;

namespace Ridder.UnitsOfMeasurement.Bases
{
    public abstract class UnitBase<TEnum> : IUnit<TEnum> 
        where TEnum : Enum
    {
        private readonly IQuantity<TEnum> _quantity;

        public string Identifier { get; }
        public TEnum Type { get; }

        protected UnitBase(IQuantity<TEnum> quantity, TEnum type)
        {
            _quantity = quantity;

            Type = type;
            Identifier = type.ToString();
        }

        public abstract Task<double> FromStandardUnit(double value, DateTimeOffset timestamp);
        public abstract Task<double> ToStandardUnit(double value, DateTimeOffset timestamp);

        IQuantity IUnit.GetQuantity()
        {
            return GetQuantity();
        }

        public IQuantity<TEnum> GetQuantity()
        {
            return _quantity;
        }

        public string GetSymbol(CultureInfo cultureInfo)
        {
            var symbol = UnitSymbols.ResourceManager.GetString(Identifier, cultureInfo);

            if (symbol == null)
                throw new KeyNotFoundException($"No symbol found for unit {Identifier}");

            return symbol;
        }

        public string GetFormattedValue(double value, CultureInfo cultureInfo)
        {
            var symbol = GetSymbol(cultureInfo);
            var format = UnitsFormatting.ResourceManager.GetString(Identifier, cultureInfo);

            if (format == null)
                format = UnitsFormatting.ResourceManager.GetString(name: "_Default", cultureInfo);

            var formattedValue = format.FormatWith(new {
                v = value,
                sym = symbol
            });

            return formattedValue;
        }
    }
}