/*
created by zou jian
*/
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace MvcHelper
{
    public static 
        class DataRowExtension
    {
        public static IEnumerable<Hashtable> ToHashTable(this IEnumerable<DataRow> rows)
        {
            if (rows.Count() == 0) return null;
            var names = rows.First().Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
            return rows.Select(dataRow => dataRow.ToHashTable(names)).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static Hashtable ToHashTable(this DataRow row)
        {
            var columnsNames = row.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
            return row.ToHashTable(columnsNames);
        }

        /// <summary>
        /// convert DataRow to HashTable 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnsNames">columns names</param>
        /// <returns></returns>
        private static Hashtable ToHashTable(this DataRow row, IEnumerable<string> columnsNames)
        {
            var hashTable = new Hashtable();
            columnsNames.ToList().ForEach(c =>
                                     {
                                         hashTable[c] = row[c];
                                     });
            return hashTable;
        }

        public static Hashtable ToFlexigridObject(this IEnumerable<DataRow> rows, int page, int total, string primayKey)
        {
            var rowList = new List<Hashtable>();
            var json = new Hashtable
                                 {
                                     {"page", page},
                                     {"total", total},
                                     {"rows", rowList}
                                 };
            rows.ToList().ForEach(c => rowList.Add(new Hashtable
                                                       {
                                                           {"id", c[primayKey].ToString()},
                                                           {"cell", c.ItemArray}
                                                       }));
            return json;
        }
    }
}