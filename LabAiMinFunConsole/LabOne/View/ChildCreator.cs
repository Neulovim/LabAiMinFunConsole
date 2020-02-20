using System;
using System.Collections.Generic;
using LabAiMinFunConsole.LabOne.Model;

namespace LabAiMinFunConsole.LabOne.View
{
    class ChildCreator
    {
        private const int N = 5;      
        Random random = new Random();
        FunctionSumSquare function = new FunctionSumSquare();
        public double Radius { get; set; } = 0.0001;

        public Child Create(Father father)
        {
            double[] coordinates = GetChildCoordinates(father);
            Child child = new Child(coordinates, GetChildCoordinatesValue(coordinates), father);
            return child;
        }

        public List<Child> Create(List<Father> fathers)
        {
            int countChildren = fathers.Count * N;
            List<Child> children = new List<Child>(countChildren);

            int[] childrenDistribute = ToDistributeEvenChildren(countChildren);
            //int[] childrenDistribute = ToDistributeBetterMoreChildren(countChildren);

            for (int i = 0; i < fathers.Count; i++)
            {
                for (int j = 0; j < childrenDistribute[i]; j++)
                {
                    children.Add(Create(fathers[i]));
                }
            }
            /*
            Console.WriteLine();
            foreach (Child child in children)
            {
                Console.WriteLine($"child c: {child.Coordinates[0]}, {child.Coordinates[1]}, v: c:{child.CoordinatesValue}");
            }
            */
            return children;
        }

        private int[] ToDistributeEvenChildren(int countChildren)
        {
            int countFathers = Convert.ToInt32(countChildren / N);
            int[] evenParts = new int[countFathers];
            for (int i = 0; i < countFathers; i++)
            {
                evenParts[i] = N;
                //Console.WriteLine(evenPart[i]);
            }
            return evenParts;
        }

        //don't work need check distribute BetterMore the formula
        /*
        private int[] ToDistributeBetterMoreChildren(int countChildren)
        {
            int countFathers = Convert.ToInt32(countChildren / N);
            int[] partsBetterMore = new int[countFathers];
            for (int i = 0; i < countFathers; i++)
            {
                partsBetterMore[i] = Convert.ToInt32(countChildren * (countFathers / 10));
                Console.WriteLine(partsBetterMore[i]);
            }
            return partsBetterMore;
        }
        */
        private double[] GetChildCoordinates(Father father)
        {
            int count = father.Coordinates.Length;
            double[] coordinates = new double[count];
            for (int i = 0; i < count; i++)
            {
                coordinates[i] =  random.NextDouble() * Radius + father.Coordinates[i] - random.NextDouble() * Radius;
            }
            return coordinates;
        }

        private double GetChildCoordinatesValue(double[] coordinates)
        {
            return function.GetFunction(coordinates);
        }
    }
}
