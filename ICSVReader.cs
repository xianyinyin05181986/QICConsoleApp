using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QICConsoleApp
{
    public interface ICSVReader
    {
        DataTable ConvertCSVtoDataTable(string strFilePath);
    }

}
