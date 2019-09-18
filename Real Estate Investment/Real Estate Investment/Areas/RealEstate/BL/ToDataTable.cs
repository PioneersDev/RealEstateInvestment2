using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RealEstateInvestment.Areas.RealEstate.BL
{
    public static class ToDataTable
    {
        public static DataTable ListToDataTable<T>(this List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int columnIndex = 0;
            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                tb.Columns[prop.Name].SetOrdinal(columnIndex);
                columnIndex++;
            }
            if (items != null)
            {
                foreach (var item in items)
                {
                    var values = new object[props.Length];
                    for (var i = 0; i < props.Length; i++)
                    {
                        values[i] = props[i].GetValue(item, null);
                    }
                    tb.Rows.Add(values);
                }
            }
            return tb;
        }

        public static DataTable ObjectToDataTable<T>(this T obj)
        {
            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int columnIndex = 0;
            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                tb.Columns[prop.Name].SetOrdinal(columnIndex);
                columnIndex++;
            }
            if (obj != null)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(obj, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }
    }
}