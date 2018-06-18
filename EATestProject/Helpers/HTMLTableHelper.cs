using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public class HTMLTableHelper
    {
        private static List<TableDatacollectionHelpers> _tableDatacollectionHelpers;

        public static void ReadTable(IWebElement table)
        {
            _tableDatacollectionHelpers = new List<TableDatacollectionHelpers>();
            var columns = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));
                if(colDatas.Count != 0)
                {
                    foreach (var colValue in colDatas)
                    {
                        _tableDatacollectionHelpers.Add(new TableDatacollectionHelpers
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ?
                                        columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });
                    }
                }
            }

        }

        private static ColumnSpecialValue GetControl(IWebElement colValue)
        {
            ColumnSpecialValue columnSpecialValue = null;
            if (colValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = colValue.FindElements(By.TagName("a")),
                    ControlType = "hyperLink"
                };
            }
            if (colValue.FindElements(By.TagName("input")).Count>0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = colValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }
            return columnSpecialValue;
        }

        public static void PerformActionOnCell(string columnIndex, string refColumnName,string refColumnValue, string controlToOperate = null)
        {
            foreach (int  rowNumber in GetDynamicRowNumber(refColumnName,refColumnValue))
            {
                var cell = (from e in _tableDatacollectionHelpers
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();
                if (controlToOperate != null && cell!= null)
                {
                    if (cell.ControlType == "hyperLink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.Text == controlToOperate
                                               select c).SingleOrDefault();
                        returnedControl?.Click();
                    }
                    if (cell.ControlType=="input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.GetAttribute("value") == controlToOperate
                                               select c).SingleOrDefault();
                        returnedControl?.Click();
                    }
                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            //dynamic row
            foreach (var table in _tableDatacollectionHelpers)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                {
                    yield return table.RowNumber;
                }
            }
        }
    }
}
