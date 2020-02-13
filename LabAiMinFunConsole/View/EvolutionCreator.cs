using LabAiMinFunConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabAiMinFunConsole.View
{
    class EvolutionCreator
    {
        
        private const double ALPHA = 0.00000001;
        private int iteration = 1;

        public void StartEvolution()
        {
            FatherCreator fatherCreator = new FatherCreator(GetDimension());
            ChildCreator childCreator = new ChildCreator();
            List<Father> fathers = fatherCreator.Create();
            
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
                List<Child> children = childCreator.Create(Sorter<Father>.GetSortedList(fathers));
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
                //fatherCreator.Radius = 1 / Math.Pow(1000, iteration);
                //childCreator.Radius = 1 / Math.Pow(1000, iteration);
                
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

        

        private int GetDimension()
        {
            Console.WriteLine("Enter dimension:");
            int dimension = Convert.ToInt32(Console.ReadLine());
            return dimension > 0 ? dimension : dimension == 0 ? 1 : -dimension;
        }

        

        



    }
}
