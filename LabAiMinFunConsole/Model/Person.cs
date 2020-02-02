using System;
using System.Collections.Generic;
using System.Text;

namespace LabAiMinFunConsole
{
    abstract class Person
    {
        private double [] _coordinate;
        private double [] _coordinateValue;

        public Person(double [] coordinate, double [] coordinateValue)
        {
            _coordinate = coordinate;
            _coordinateValue = coordinateValue;
        }

        public double [] Coordinate
        {
            get
            {
                return _coordinate;
            }

            set
            {
                _coordinate = value;
            }
        }

        public double [] CoordinateValue
        {
            get
            {
                return _coordinateValue;
            }

            set
            {
                _coordinateValue = value;
            }
        }
    }
}
