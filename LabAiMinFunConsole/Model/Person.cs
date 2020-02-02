using System;
using System.Collections.Generic;
using System.Text;

namespace LabAiMinFunConsole
{
    abstract class Person
    {
        private double[] _coordinates;
        private double _coordinatesValue;

        public Person(double[] coordinates, double coordinatesValue)
        {
            _coordinates = coordinates;
            _coordinatesValue = coordinatesValue;
        }

        public double[] Coordinates
        {
            get
            {
                return _coordinates;
            }

            set
            {
                _coordinates = value;
            }
        }

        public double CoordinatesValue
        {
            get
            {
                return _coordinatesValue;
            }

            set
            {
                _coordinatesValue = value;
            }
        }
    }
}
