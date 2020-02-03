using LabAiMinFunConsole.Model;
using LabAiMinFunConsole.View;
using System;

namespace LabAiMinFunConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EvolutionCreator evolution = new EvolutionCreator();
            evolution.StartEvolution();
        }
    }
}
