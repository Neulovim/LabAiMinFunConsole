using LabAiMinFunConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabAiMinFunConsole.View
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
