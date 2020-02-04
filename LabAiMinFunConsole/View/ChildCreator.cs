﻿using LabAiMinFunConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabAiMinFunConsole.View
{
    class ChildCreator
    {
        const double EPS = 0.0001;
        Random random = new Random();
        FunctionSumSquare function = new FunctionSumSquare();
        public Child CreateChild(Father father)
        {
            double[] coordinates = GetChildCoordinates(father);
            Child child = new Child(coordinates, GetChildCoordinatesValue(coordinates), father);
            return child;
        }

        private double[] GetChildCoordinates(Father father)
        {
            int count = father.Coordinates.Length;
            double[] coordinates = new double[count];
            for (int i = 0; i < count; i++)
            {
                coordinates[i] =  random.NextDouble() * EPS + father.Coordinates[i] - random.NextDouble() * EPS;
            }
            return coordinates;
        }

        private double GetChildCoordinatesValue(double[] coordinates)
        {
            return function.GetFunction(coordinates);
        }
    }
}
