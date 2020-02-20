using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabAiMinFunConsole.LabOne.Model;

namespace LabAiMinFunConsole.LabOne.View
{
    class EvolutionCreator
    {
        private readonly int _timeStopMilliseconds = 1500;
        private double alpha = 0.00000001;//0.00000001;
        private int iteration = 1;

        public void StartEvolution()
        {
            FatherCreator fatherCreator = new FatherCreator(GetDimension());
            ChildCreator childCreator = new ChildCreator();
            List<Father> fathers = fatherCreator.Create();
            
            double sumFathersOld;
            double sumFathersYung;
            Task t = Task.Run(() => {
                while (true)
                {
                    //sumFathersOld = CalculateSumFathersCoordinateValue(fathers);
                    List<Child> children = childCreator.Create(Sorter<Father>.GetSortedList(fathers));
                    for (int i = 0; i < fathers.Count; i++)
                    {
                        fathers[i].Coordinates = children[i].Coordinates;
                        fathers[i].CoordinatesValue = children[i].CoordinatesValue;
                    }
                    //sumFathersYung = CalculateSumFathersCoordinateValue(fathers);
                    fathers = Sorter<Father>.GetSortedList(fathers);
                    /*
                    if (Math.Abs(sumFathersYung - sumFathersOld) < alpha)
                    {
                        Console.Write($"iteration: {iteration}, value: " + String.Format("{0:0.##########################}", fathers[0].CoordinatesValue));

                        break;
                    }
                    */
                    //fatherCreator.Radius = iteration;
                    //childCreator.Radius = iteration; //1 / Math.Pow(1000, iteration);
                    //alpha = alpha / iteration;
                    //fatherCreator.Radius = alpha / iteration;
                    childCreator.Radius -= alpha / (iteration * 100);
                    iteration += 1;
                }
            });
            TimeSpan ts = TimeSpan.FromMilliseconds(_timeStopMilliseconds);
            if (!t.Wait(ts))
            {
                foreach (var coordinate in fathers[0].Coordinates)
                {
                    Console.WriteLine($"coordinate: {coordinate}");
                }
                
                Console.WriteLine($"iteration: {iteration}, value: " + String.Format("{0:0.##########################}", fathers[0].CoordinatesValue));
                Console.WriteLine($"time (milliseconds): {_timeStopMilliseconds}");
            }
                
            
        }
        /*
        private double CalculateSumFathersCoordinateValue(List<Father> fathers)
        {
            double sum = 0;
            foreach (Father father in fathers)
            {
                sum += father.CoordinatesValue;
            }
            return sum;
        }
        */
        private int GetDimension()
        {
            Console.WriteLine("Enter dimension:");
            int dimension = Convert.ToInt32(Console.ReadLine());
            return dimension > 0 ? dimension : dimension == 0 ? 1 : -dimension;
        }
    }
}
