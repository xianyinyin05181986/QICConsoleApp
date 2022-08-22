using System.Data;

namespace QICConsoleApp
{
    public interface IDataTableProcessor
    {
        string[] GetAbnormalValuesFromDataTable(DataTable dt, string columnName);
    }


   
}