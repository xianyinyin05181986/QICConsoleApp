using System;
using System.Data;
using System.IO;
using System.Linq;

namespace QICConsoleApp
{
    public class FileProcessor
    {
        private ICSVReader cSVReader;
        private IDataTableProcessor dataTableProcessor;

        public FileProcessor(ICSVReader cSVReader, IDataTableProcessor dataTableProcessor)
        {
            this.cSVReader = cSVReader;
            this.dataTableProcessor = dataTableProcessor;
        }

        public virtual string[] FindAbnormaValues(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            var columnName = fileName.ToLower().Contains("comm") ? "Price SOD" :"MOD Duration";
            return dataTableProcessor
                .GetAbnormalValuesFromDataTable(cSVReader.ConvertCSVtoDataTable(filePath), columnName)
                .Select(r=> $@"{fileName} {r}")
                .ToArray();
        }
    }
}
