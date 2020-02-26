using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LabAiMinFunConsole.LabTwo.View
{
    class DataCreator
    {
        public void CreateData()
        {
            FileStream file = new FileStream(@"..\..\..\..\dataTwoLab.txt", FileMode.OpenOrCreate, FileAccess.Read);
            Console.WriteLine(file.CanRead.ToString());
            file.Close();   
        }
    }
}
