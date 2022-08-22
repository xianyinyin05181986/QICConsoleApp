using System;
using System.Data;
using System.Linq;

namespace QICConsoleApp
{
    public class DataTableProcessor : IDataTableProcessor
    {
        public double GetMedianFromDataTable(DataTable dt, string columnName)
        {
            //extract data from datacolumn and build and a double array
            double[] values =
             Array.ConvertAll<DataRow, double>(
               dt.Select(),
               delegate (DataRow row) { if (double.TryParse(row[columnName].ToString(), out double result)) { return result; } else return 0; }
             );
            return GetMedianFromArray(values);
        }

        protected double GetMedianFromDataRows(DataRow[] rows, string columnName)
        { //extract data from datacolumn and build and a double array
            double[] values =
             Array.ConvertAll<DataRow, double>(
               rows,
               delegate (DataRow row) { return Convert.ToDouble(row[columnName]); }
             );
            return GetMedianFromArray(values);
        }

        public double GetMedianFromArray(double[] values)
        {
            double median;
            //sort the array
            Array.Sort(values);
            if (values.Length % 2 != 0)
            {
                median = values[values.Length / 2];
            }
            else
            {
                int middle = values.Length / 2;
                double first = values[middle];
                double second = values[middle - 1];
                median = (first + second) / 2;
            }
            return median;
        }

        public string[] GetAbnormalValuesFromDataTable(DataTable dt, string columnName)
        {
            var median = GetMedianFromDataTable(dt, columnName);
            return dt.Rows
              .Cast<DataRow>()
              .Where(dr =>
              {
                  try
                  {
                      var val = ConvertStringtoDouble(dr[columnName].ToString());
                      return (Math.Abs(val - median) / median) > 0.2;
                  }
                  catch (Exception ex)
                  {
                      throw ex;
                  }
              })
              .Select(row => $@" {row["Date"]} {row[columnName]} {median}")
              .ToArray();
        }

        private static double ConvertStringtoDouble(string strNum)
        {
            if (double.TryParse(strNum, out double result)) { return result; } else return 0;
            // return 0 will give errors
        }
    }
}