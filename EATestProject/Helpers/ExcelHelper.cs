using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace EAAutoFramework.Helpers
{
    public class ExcelHelper
    {
        private static List<DataCollesctionHelper> _dataColl = new List<DataCollesctionHelper>();

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //iterate through the rows and columns of the Table 
            for (int row = 1; row < table.Rows.Count; row++)
            {
                for (int column = 0; column < table.Columns.Count; column++)
                {
                    DataCollesctionHelper dtTable = new DataCollesctionHelper()
                    {
                        rowNumber = row,
                        colNum = table.Columns[column].ColumnName,
                        colVal = table.Rows[row - 1][column].ToString()
                    };

                    //add all data for each row
                    _dataColl.Add(dtTable);
                }
            }
        }

        private static DataTable ExcelToDataTable(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    DataTableCollection table = result.Tables;
                    DataTable resultTable = table["Sheet1"];

                    return resultTable;
                }
            }

            //FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //excelReader.IsFirstRowAsColumnNames = true;
            //DataSet result = excelReader.AsDataSet();
            //DataTableCollection table = result.Tables;
            //DataTable resultTable = table["Sheet1"];

            //return resultTable;

        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in _dataColl
                               where colData.colVal == columnName && colData.rowNumber == rowNumber
                               select colData.colVal).SingleOrDefault();

                //var datas = dataCol.where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault();

                return data;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


    }
}
