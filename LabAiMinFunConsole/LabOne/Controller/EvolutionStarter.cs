using LabAiMinFunConsole.LabOne.View;

namespace LabAiMinFunConsole.LabOne.Controller
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
