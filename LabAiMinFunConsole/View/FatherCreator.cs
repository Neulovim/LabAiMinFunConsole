using LabAiMinFunConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabAiMinFunConsole
{
    class FatherCreator
    {
        const double EPS = 0.0001;
        Random random = new Random();
        FunctionSumSquare function = new FunctionSumSquare();
        
        private int _dimension;
        public int Dimension
        {
            get { return _dimension; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be bigger 0");

                _dimension = value;
            }
        }

        public FatherCreator (int dimension)
        {
            Dimension = dimension;
        }

        public Father CreateFather(int number)
        {
            double[] coordinates = GetFatherCoordinates(number);
            Father father = new Father(coordinates, GetFatherCoordinatesValue(coordinates));
            return father;
        }

        private double[] GetFatherCoordinates(int number)
        {
            double[] coordinates = new double[Dimension];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = random.NextDouble() * EPS + number - random.NextDouble() * EPS;
            }
            return coordinates;
        }

        private double GetFatherCoordinatesValue(double[] coordinates)
        {
            return function.GetFunction(coordinates);
        }

    }
}
