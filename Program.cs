using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QICConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Folder
            string folderDirectory = @"C:\Users\xiany\Downloads\Sample Files\Sample Files\";
            
            //Files
            string[] files = { "comm_01.csv", "comm_02.csv", "comm_03.csv", "mod_01.csv", "mod_02.csv", "mod_03.csv" };

            var processor = new FileProcessor(new CSVReader(), new DataTableProcessor());
            foreach (var file in files)
            {
                foreach (var str in processor.FindAbnormaValues($@"{folderDirectory}{file}"))
                {
                    Console.WriteLine(str);
                }
            }
            Console.ReadLine();

        }
    }
}
