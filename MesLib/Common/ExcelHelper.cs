using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;

namespace Common
{
    /// <summary>
    /// Excel和DataTable互转类
    /// </summary>
    public static class ExcelHelper
    {
        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="fileName">要导入的含有绝对路径的文件名</param>
        /// <param name="data">要导入的数据</param>
        /// <param name="isCapitalSave">DataTable的Capital是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名行)</returns>
        public static int DataTableToExcel(string fileName, string sheetName, bool isCapitalSave,DataTable data)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            IWorkbook workbook = null;
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isCapitalSave == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
                //return -1;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中,首行caption，第二行title
        /// </summary>
        /// <param name="fileName">要导入的Excel的含绝对路径的文件名</param>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isHeadRead">是否读取表头</param>
        /// <param name="index">数据起始行，第一行为0行</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable ExcelToDataTable(string fileName,string sheetName, bool isHeadRead,int index)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = index;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                //如果页不空
                if (sheet != null)
                {
                    IRow capitalRow = sheet.GetRow(0);
                    IRow titleRow = sheet.GetRow(1);
                    int cellCount = titleRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    for (int i = titleRow.FirstCellNum; i < cellCount; i++)
                    {
                        ICell titleCell = titleRow.GetCell(i);
                        DataColumn dc = new DataColumn(titleCell == null ? string.Empty : GetCellValue(titleCell));
                        if (isHeadRead)
                        {
                            ICell capitalCell = capitalRow.GetCell(i);
                            dc.Caption = capitalCell == null ? string.Empty : GetCellValue(capitalCell);
                        }
                        data.Columns.Add(dc);
                    }

                    //最后一行的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 将excel中的数据导入到DataTable中,首行title，第二行capital
        /// </summary>
        /// <param name="fileName">要导入的Excel的含绝对路径的文件名</param>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isHeadRead">是否读取表头</param>
        /// <param name="index">数据起始行，第一行为0行</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable ExcelToDataTableExchange(string fileName, string sheetName, bool isHeadRead, int index)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = index;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                //如果页不空
                if (sheet != null)
                {
                    IRow capitalRow = sheet.GetRow(1);
                    IRow titleRow = sheet.GetRow(0);
                    int cellCount = titleRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    for (int i = titleRow.FirstCellNum; i < cellCount; i++)
                    {
                        ICell titleCell = titleRow.GetCell(i);
                        DataColumn dc = new DataColumn(titleCell == null ? string.Empty : GetCellValue(titleCell));
                        if (isHeadRead)
                        {
                            ICell capitalCell = capitalRow.GetCell(i);
                            dc.Caption = capitalCell == null ? string.Empty : GetCellValue(capitalCell);
                        }
                        data.Columns.Add(dc);
                    }

                    //最后一行的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取单元格数值
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <returns>单元格数值</returns>
        private static string GetCellValue(ICell cell)
        {
            cell.SetCellType(CellType.String);
            return cell.StringCellValue;
        }

        /// <summary>
        /// 多个单元格的写入
        /// </summary>
        /// <param name="sourceFilePathAndFullName">源文件带路径全名</param>
        /// <param name="destinyFilePathAndFullName">目标文件带路径全名</param>
        /// <param name="sheetName">sheet页名称</param>
        /// <param name="rowIndexs">行索引，从0开始</param>
        /// <param name="colIndexs">列索引，从0开始</param>
        /// <param name="values">待写入的目标值</param>
        /// <returns>返回写入结果</returns>
        public static string WriteValue2Cell(string sourceFilePathAndFullName, string destinyFilePathAndFullName, string sheetName, List<int> rowIndexs, List<int> colIndexs, List<object> values)
        {
            if (rowIndexs==null||colIndexs==null||values==null)
            {
                return "Orignal data could not be empty!";
            }
            if (rowIndexs.Count != colIndexs.Count || colIndexs.Count != values.Count || values.Count != rowIndexs.Count)
            {
                return "Orignal data quantity does not match!";
            }
            IWorkbook workbook = GetWorkbook(sourceFilePathAndFullName);
            if (workbook == null)
            {
                return "Could not read workbook!";
            }
            if (string.IsNullOrEmpty(sheetName))
            {
                return "Sheet name could not be empty!";
            }
            ISheet sheet = GetSheet(workbook, sheetName);
            if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
            {
                return string.Format("Sheet:{0} do not exist!", sheetName);
            }

            bool res = false;
            for (int i= 0; i < values.Count; i++)
            {
                ICell cell = GetCell(sheet, rowIndexs[i], colIndexs[i]);
                if (cell == null)
                {
                    continue;
                }
                if (WriteCell(cell,values[i]))
                {
                    res = true;
                }
            }
            if (res)
            {
                if (SaveWorkbook(workbook, destinyFilePathAndFullName))
                {
                    return "Success";
                }
                return "Save this file fail!";
            }
            return "Could not write the values!!";
        }
        
        /// <summary>
        /// 单个单元格的写入
        /// </summary>
        /// <param name="sourceFilePathAndFullName">源文件带路径全名</param>
        /// <param name="destinyFilePathAndFullName">目标文件带路径全名</param>
        /// <param name="sheetName">sheet页名称</param>
        /// <param name="rowIndex">行索引，从0开始</param>
        /// <param name="colIndex">列索引，从0开始</param>
        /// <param name="value">待写入的目标值</param>
        /// <returns>返回写入结果</returns>
        public static string WriteValue2Cell(string sourceFilePathAndFullName,string destinyFilePathAndFullName, string sheetName, int rowIndex,int colIndex, object value) 
        {
            IWorkbook workbook = GetWorkbook(sourceFilePathAndFullName);
            if (workbook==null)
            {
                return "Could not read workbook!";
            }
            if (string.IsNullOrEmpty(sheetName))
            {
                return "Sheet name could not be empty!";
            }
            ISheet sheet = GetSheet(workbook, sheetName);
            if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
            {
                return string.Format("Sheet:{0} do not exist!", sheetName);
            }
            ICell cell=GetCell(sheet, rowIndex, colIndex);
            if (cell==null)
            {
                return string.Format("Row:{0}-Column:{1} could not read!",rowIndex.ToString(),colIndex.ToString());
            }
            if (WriteCell(cell, value))
            {
                if (SaveWorkbook(workbook, destinyFilePathAndFullName))
                {
                    return "Success";
                }
                return "Save this file fail!";
            }
            return "Could not write the value to cell!";
        }

        /// <summary>
        /// 根据源文件全路径获取工作簿
        /// </summary>
        /// <param name="sourceFilePathAndFullName">源文件全路径</param>
        /// <returns>工作簿</returns>
        public static IWorkbook GetWorkbook(string sourceFilePathAndFullName)
        {
            IWorkbook workbook = null;
            FileStream fs = null;
            try
            {
                using (fs = new FileStream(sourceFilePathAndFullName, FileMode.Open, FileAccess.Read))
                {
                    if (sourceFilePathAndFullName.IndexOf(".xlsx") > 0) // 2007版本
                    { workbook = new XSSFWorkbook(fs); }
                    else if (sourceFilePathAndFullName.IndexOf(".xls") > 0) // 2003版本
                    { workbook = new HSSFWorkbook(fs); }
                }
            }
            catch (Exception)
            {
                fs.Close();
                fs.Dispose();
            }            
            return workbook;
        }

        /// <summary>
        /// 根据工作簿获取sheet页
        /// </summary>
        /// <param name="workbook">工作簿</param>
        /// <param name="sheetName">sheet页</param>
        /// <returns>sheet页</returns>
        public static ISheet GetSheet(IWorkbook workbook, string sheetName)
        {
            ISheet sheet = null;
            if (workbook==null)
            {
                return sheet;
            }
            if (string.IsNullOrEmpty(sheetName))
            {
                return sheet;
            }
            return workbook.GetSheet(sheetName);
        }

        /// <summary>
        /// 获取单元格
        /// </summary>
        /// <param name="sheet">sheet页</param>
        /// <param name="rowIndex">行序号，从0开始</param>
        /// <param name="colIndex">列序号，从0开始</param>
        /// <returns>单元格</returns>
        public static ICell GetCell(ISheet sheet, int rowIndex, int colIndex)
        {
            ICell cell = null;
            if (sheet==null)
            {
                return cell;
            }
            IRow row = sheet.GetRow(rowIndex);
            if (row==null)
            {
                row = sheet.CreateRow(rowIndex);
            }
            cell = row.GetCell(colIndex);
            if (cell==null)
            {
                cell = row.CreateCell(colIndex);
            }
            return cell;
        }

        /// <summary>
        /// 写入单元格值
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="value">待写入值</param>
        /// <returns>写入结果</returns>
        public static bool WriteCell(ICell cell, object value)
        {
            if (cell==null)
            {
                return false;
            }
            try
            {
                cell.SetCellValue(value.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 工作簿保存
        /// </summary>
        /// <param name="workbook">待保存的工作簿</param>
        /// <param name="destinyFilePathAndFullName">目标路径</param>
        /// <returns>保存结果</returns>
        public static bool SaveWorkbook(IWorkbook workbook, string destinyFilePathAndFullName)
        {
            MemoryStream ms = new MemoryStream();
            FileStream fs=null;
            try
            {
                workbook.Write(ms);
                var buf = ms.ToArray();
                using ( fs= new FileStream(destinyFilePathAndFullName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
                return true;
            }
            catch (Exception)
            {
                fs.Close();
                fs.Dispose();
                return false;
            }            
        }
    }
}
