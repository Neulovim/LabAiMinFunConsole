using LabAiMinFunConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabAiMinFunConsole.View
{
    class EvolutionCreator
    {
        private const int N = 5;
        private const double ALPHA = 0.00000001;
        private int iteration = 1;

        public void StartEvolution()
        {
            List<Father> fathers = GetFathersFirstDistribution();
            
            double sumFathersOld;
            double sumFathersYung;

            while (true)
            {
                sumFathersOld = CalculateSumFathersCoordinateValue(fathers);


                /*
                if (Math.Abs(fathers[0].CoordinatesValue - fathers[3].CoordinatesValue) < ALPHA)
                {
                    min = Math.Abs(fathers[0].CoordinatesValue - fathers[3].CoordinatesValue);
                    if (min < ALPHA && tmp < ALPHA)
                    {
                        
                        iterationWalkingOnTheSpot += 1;
                        Console.WriteLine($"iteration: {iteration}, value: {fathers[0].CoordinatesValue}");                        
                    }
                    else
                    {
                        iterationWalkingOnTheSpot = 0;
                    }
                    Console.WriteLine(iterationWalkingOnTheSpot);
                }
                
                if (Math.Abs(fathers[0].CoordinatesValue - fathers[3].CoordinatesValue) < ALPHA)
                {
                    Console.WriteLine($"iteration: {iteration}, value: {fathers[0].CoordinatesValue}");
                    break;
                }
                
                Console.WriteLine("Sorted");
                foreach (Father f in fathersSorted)
                    Console.WriteLine($"father c: {f.Coordinates[0]}, {f.Coordinates[1]}, v: c:{f.CoordinatesValue}");
                */
                //List<Child> children = GetChildren(GetSortedList(fathers));
                List<Child> children = GetChildren(Sorter<Father>.GetSortedList(fathers));
                for (int i = 0; i < fathers.Count; i++)
                {
                    fathers[i].Coordinates = children[i].Coordinates;
                    fathers[i].CoordinatesValue = children[i].CoordinatesValue;
                }
                sumFathersYung = CalculateSumFathersCoordinateValue(fathers);
                fathers = Sorter<Father>.GetSortedList(fathers);
                if (Math.Abs(sumFathersYung - sumFathersOld) < ALPHA)
                {
                    Console.Write($"iteration: {iteration}, value: " + String.Format("{0:0.##########################}", fathers[0].CoordinatesValue));
                    
                    break;
                }

                /*
                Console.WriteLine("New");
                foreach (Father f in fathers)
                    Console.WriteLine($"father c: {f.Coordinates[0]}, {f.Coordinates[1]}, v: c:{f.CoordinatesValue}");
                */
                
                iteration += 1;
            }
        }

        private double CalculateSumFathersCoordinateValue(List<Father> fathers)
        {
            double sum = 0;
            foreach (Father father in fathers)
            {
                sum += father.CoordinatesValue;
            }
            return sum;
        }

        private List<Child> GetChildren(List<Father> fathers)
        {
            ChildCreator childCreator = new ChildCreator();
            int countChildren = fathers.Count * N;
            List<Child> children = new List<Child>(countChildren);
            
            int[] childrenDistribute = ToDistributeEvenChildren(countChildren);
            //int[] childrenDistribute = ToDistributeBetterMoreChildren(countChildren);

            for (int i = 0; i < fathers.Count; i++)
            {
                for (int j = 0; j < childrenDistribute[i]; j++)
                {
                    children.Add(childCreator.CreateChild(fathers[i]));
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
         
        private List<Father> GetFathersFirstDistribution()
        {
            FatherCreator fatherCreator = new FatherCreator(GetDimension());
            int countFaters = GetCountFathers();
            List<Father> fathers = new List<Father>(countFaters);
            int[] firstCoordinates = ToDistributeEvenFathers(countFaters);
            for (int i = 0; i < countFaters; i++)
            {
                fathers.Add(fatherCreator.CreateFather(firstCoordinates[i]));
            }
            /*
            Console.WriteLine();
            foreach (Father father in fathers)
            {
                Console.WriteLine($"father c: {father.Coordinates[0]}, {father.Coordinates[1]}, v: c:{father.CoordinatesValue}");
            }
            */
            return fathers;
        }

        private int GetDimension()
        {
            Console.WriteLine("Enter dimension:");
            int dimension = Convert.ToInt32(Console.ReadLine());
            return dimension > 0 ? dimension : dimension == 0 ? 1 : -dimension;
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
                evenPart[i] = Convert.ToInt32((( i + 1) * range) / countFather) + bounds[0];
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



    }
}
