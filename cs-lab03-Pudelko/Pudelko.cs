using System;
using System.Collections.Generic;
using System.Text;

namespace cs_lab03_Pudelko
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {
        // 0. Podstawowe zmienne

        private readonly double _a = 0.1;
        private readonly double _b = 0.1;
        private readonly double _c = 0.1;

        // 3. Zaimplementuj properties
        public double A => Truncate(_a);
        public double B => Truncate(_b);
        public double C => Truncate(_c);

        private double Truncate(double number)
        {
            return Math.Truncate(number * 1000) / 1000;
        }

        private readonly UnitOfMeasure _unit;

        public enum UnitOfMeasure
        {
            milimeter,
            centimeter,
            meter
        };

        // 1. Ograniczenia wymiarów
        private void DimensionRestrictions( double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException();

            if (a > 10 || b > 10 || c > 10)
                throw new ArgumentOutOfRangeException();
        }

        // 2. Tworzenie obiektu Pudelko - do zrobienia: Jeśli podano mniej niż 3 wartości liczbowe, pozostałe przyjmuje się jako 10 cm.
        public Pudelko(double a, double b, double c, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            _a = ConvertToMeters(a, unit);
            _b = ConvertToMeters(b, unit);
            _c = ConvertToMeters(c, unit);
            _unit = unit;

            DimensionRestrictions(a, b, c);
        }

        private double ConvertToMeters(double number, UnitOfMeasure unit)
        {
            switch (unit)
            {
                case UnitOfMeasure.milimeter:
                    return number / 1000;
                case UnitOfMeasure.centimeter:
                    return number / 100;
                default:
                    return number;
            }
        }

        // 4. Przesłonić ToString

        public override string ToString()
        {
            return $"{A:0.000} m × {B:0.000} m × {C:0.000} m";
        }















    }
}

