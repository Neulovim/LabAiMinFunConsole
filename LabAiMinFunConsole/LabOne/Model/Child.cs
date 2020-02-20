namespace LabAiMinFunConsole.LabOne.Model
{
    class Child : Person
    {
        private Father _father;
        public Child(double[] coordinates, double coordinatesValue, Father father) : base(coordinates, coordinatesValue)
        {
            _father = father;
        }
        public Father Father
        {
            get
            {
                return _father;
            }

            set
            {
                _father = value;
            }
        }
    }
}
