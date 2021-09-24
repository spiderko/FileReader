using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FileReader.Application.Services
{
    public class DataTableService : IDataTableService
    {
        public DataTable ConvertListToDataTable<T>(List<T> list)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            var intProp = new List<string>() { "Xref", "Yref", "Day", "Month", "Year", "Value" };
            var dateProp = new List<string>() { "Date", "Created" };
            var guidProp = new List<string>() { "Id" };

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                if(dateProp.Contains(prop.Name))
                {
                    dataTable.Columns.Add(prop.Name, typeof(DateTime));
                    continue;
                }

                if (intProp.Contains(prop.Name))
                {
                    dataTable.Columns.Add(prop.Name, typeof(int));
                    continue;
                }

                if (guidProp.Contains(prop.Name))
                {
                    dataTable.Columns.Add(prop.Name, typeof(Guid));
                    continue;
                }

                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in list)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Xref"].SetOrdinal(1);
            dataTable.Columns["Yref"].SetOrdinal(2);
            dataTable.Columns["Date"].SetOrdinal(3);
            dataTable.Columns["Day"].SetOrdinal(4);
            dataTable.Columns["Month"].SetOrdinal(5);
            dataTable.Columns["Year"].SetOrdinal(6);
            dataTable.Columns["Value"].SetOrdinal(7);
            dataTable.Columns["Created"].SetOrdinal(8);

            return dataTable;
        }
    }
}
