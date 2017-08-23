using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace windfree.common.windfree.util
{
    class ObjectUtil
    {
        public static List<T> ToList<T>(DataTable dt) where T : new()
        {
            List<T> objList = new List<T>();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            //read object field names and type.
            var objFieldNames = typeof(T).GetProperties(flags).Cast<PropertyInfo>().
                                Select(item => new
                                {
                                    Name = item.Name,
                                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
                                }).ToList();

            // Read Datatable column names and types
            var dtlFieldNames = dt.Columns.Cast<DataColumn>().
                                 Select(item => new {
                                     Name = item.ColumnName,
                                     Type = item.DataType
                                 }).ToList();

            foreach (DataRow dataRow in dt.Rows)
            {
                var classObj = new T();
                foreach (var dtField in dtlFieldNames)
                {
                    PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);
                    var field = objFieldNames.Find(x => x.Name == dtField.Name);

                    if (field != null)
                    {
                        if (propertyInfos.PropertyType == typeof(DateTime))
                        {
                            propertyInfos.SetValue(classObj, ConvertToDateTime(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(int))
                        {
                            propertyInfos.SetValue(classObj, ConvertToInt(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(long))
                        {
                            propertyInfos.SetValue(classObj, ConvertToLong(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(decimal))
                        {
                            propertyInfos.SetValue(classObj, ConvertToDecimal(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(double))
                        {
                            propertyInfos.SetValue(classObj, ConvertToDouble(dataRow[dtField.Name]), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(String))
                        {
                            if (dataRow[dtField.Name].GetType() == typeof(DateTime))
                            {
                                propertyInfos.SetValue(classObj, ConvertToDateString(dataRow[dtField.Name]), null);
                            }
                            else
                            {
                                propertyInfos.SetValue(classObj, ConvertToString(dataRow[dtField.Name]), null);
                            }
                        }
                    }
                }

                objList.Add(classObj);
            }
            return objList;
        }

        private static string ConvertToDateString(object date)
        {
            if (date == null)
                return string.Empty;

            return Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static string ConvertToString(object value)
        {
            return Convert.ToString(NullUtil.IsDBNull(value, 0));
        }

        private static int ConvertToInt(object value)
        {
            return Convert.ToInt32(NullUtil.IsDBNull(value, 0));
        }

        private static long ConvertToLong(object value)
        {
            return Convert.ToInt64(NullUtil.IsDBNull(value, 0));
        }

        private static decimal ConvertToDecimal(object value)
        {
            return Convert.ToDecimal(NullUtil.IsDBNull(value, 0));
        }

        private static double ConvertToDouble(object value)
        {
            return Convert.ToDouble(NullUtil.IsDBNull(value, 0));
        }

        private static DateTime ConvertToDateTime(object date)
        {
            return Convert.ToDateTime(NullUtil.IsDBNull(date, "1970101"));
        }

        public static DataTable ToDataTable(DataGridView grid, bool checkOnly = true)
        {
            DataTable dt = new DataTable();
            try
            {
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    DataColumn dtCol = new DataColumn(col.Name);
                    dtCol.Caption = col.HeaderText;
                    dt.Columns.Add(dtCol);
                }

                object[] cellValues = new object[dt.Columns.Count];


                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["colChk"].Value != null && (bool)row.Cells["colChk"].Value)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            cellValues[i] = row.Cells[i].Value;
                        }
                        dt.Rows.Add(cellValues);
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);

            }
            return dt;
        }
    }

}
