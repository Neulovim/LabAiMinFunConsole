using System;
using System.Collections.Generic;
using System.Text;
using LabAiMinFunConsole.View;

namespace LabAiMinFunConsole.Controller
{
    static class EvolutionStarter
    {
        public static void Start()
        {
            EvolutionCreator evolution = new EvolutionCreator();
            evolution.StartEvolution();
        }
    }
}
