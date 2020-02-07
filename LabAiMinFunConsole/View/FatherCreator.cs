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

        public Father Create(int number)
        {
            double[] coordinates = GetCoordinates(number);
            Father father = new Father(coordinates, GetCoordinatesValue(coordinates));
            return father;
        }
        public List<Father> Create()
        {
            int countFaters = GetCountFathers();
            List<Father> fathers = new List<Father>(countFaters);
            int[] firstCoordinates = ToDistributeEvenFathers(countFaters);
            for (int i = 0; i < countFaters; i++)
            {
                fathers.Add(Create(firstCoordinates[i]));
            }
            return fathers;
        }

        private int GetCountFathers()
        {
            Console.WriteLine("Enter count father:");
            int count = Convert.ToInt32(Console.ReadLine());
            return count > 0 ? count : count == 0 ? 1 : -count;
        }

        private int[] ToDistributeEvenFathers(int countFather)
        {
            int[] bounds = GetRangeFinder();
            int[] evenPart = new int[countFather];
            int range = bounds[1] - bounds[0] - 1;
            for (int i = 0; i < countFather; i++)
            {
                evenPart[i] = Convert.ToInt32(((i + 1) * range) / countFather) + bounds[0];
                //Console.WriteLine(evenPart[i]);
            }
            return evenPart;
        }

        private int[] GetRangeFinder()
        {
            int[] bounds = new int[2];
            Console.WriteLine("\nEnter range finder:");
            Console.WriteLine("lower bound: ");
            bounds[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("upper bound: ");
            bounds[1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return bounds;
        }

        private double[] GetCoordinates(int number)
        {
            double[] coordinates = new double[Dimension];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = random.NextDouble() * EPS + number - random.NextDouble() * EPS;
            }
            return coordinates;
        }

        private double GetCoordinatesValue(double[] coordinates)
        {
            return function.GetFunction(coordinates);
        }

        
        

    }
}
