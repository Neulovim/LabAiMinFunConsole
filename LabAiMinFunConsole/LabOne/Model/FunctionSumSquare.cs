namespace LabAiMinFunConsole.LabOne.Model
{
    class FunctionSumSquare
    {
        public double GetFunction(double[] coordinates)
        {       
            double coordinatesValue = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinatesValue += coordinates[i] * coordinates[i];
            }
            return coordinatesValue;
        }
    }
}
