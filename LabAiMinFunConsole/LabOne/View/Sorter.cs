using System.Collections.Generic;
using System.Linq;
using LabAiMinFunConsole.LabOne.Model;

namespace LabAiMinFunConsole.LabOne.View
{
    static class Sorter<T> where T: Person
    {
        public static List<T> GetSortedList(List<T> people)
        {
            IOrderedEnumerable<T> peopleSorted = from person in people
                                                 orderby person.CoordinatesValue
                                                 select person;
            return peopleSorted.ToList();
        }
    }
}
