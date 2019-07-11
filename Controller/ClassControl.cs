using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CanadaHousing.Controller
{
    public class ClassControl
    {
        public static IEnumerable<PropertyInfo> Visit(Type t)
        {
            var visitedTypes = new HashSet<Type>();
            var result = new List<PropertyInfo>();
            //InternalVisit(t, visitedTypes, result);
            return result;
        }

        private void InternalVisit(Type t, HashSet<Type> visitedTypes, IList<PropertyInfo> result)
        {
            if (visitedTypes.Contains(t))
            {
                return;
            }

            if (!IsPrimitive(t))
            {
                visitedTypes.Add(t);
                foreach (var property in t.GetProperties())
                {
                    if (IsPrimitive(property.PropertyType))
                    {
                        result.Add(property);
                    }
                    InternalVisit(property.PropertyType, visitedTypes, result);
                }
            }
        }

        public static String[] GetFields(Type t)
        {
            List<String> visitedTypes = new List<string>();
            List<String> result = new List<string>();

            if (!IsPrimitive(t))
            {
                visitedTypes.Add(t.Name);
                foreach (var property in t.GetProperties())
                {
                    if (IsPrimitive(property.PropertyType))
                    {
                        result.Add(property.Name);
                    }
                }
            }

            return result.ToArray();
        }

        public static String SqlInsertFromObject(Object o, Type t, String[] PlusFields = null, String[] PlusValues = null)
        {
            String SqlInsertBegin = String.Format("INSERT INTO md_{0} (", t.Name);
            String SqlInsertEnd = " VALUES (";

            Int32 Count = 0;
            String[] Fields = GetFields(t);
            foreach (String name in Fields)
            {
                Count++;
                try
                {

                    SqlInsertEnd += Formatter(
                            t.GetProperty(name).GetValue(o, null).GetType(),
                            t.GetProperty(name).GetValue(o, null).ToString(),
                            IsId(name), PutCommaIfNotLast(Fields, Count));

                    SqlInsertBegin += String.Format("{0}{1}", name, PutCommaIfNotLast(Fields, Count) ? "," : String.Empty);
                }
                catch (Exception ex)
                {

                }


            }

            return String.Concat(SqlInsertBegin, ") ", SqlInsertEnd, ");");
        }

        private static Boolean PutCommaIfNotLast(string[] fields, int count)
        {
            return fields.Count() != count;
        }

        private static bool IsId(string name)
        {
            return name.ToLower().Equals("id");
        }

        private static String Formatter(Type type, string v, Boolean isId = false, Boolean putComma = true)
        {
            if (type == typeof(String) && !isId)
            {
                return String.Format("'{0}'{1} ", v, putComma ? "," : String.Empty);
            }

            return String.Format("{0}{1} ", v, putComma ? "," : String.Empty); ;
        }

        private static bool IsPrimitive(Type t)
        {
            // TODO: put any type here that you consider as primitive as I didn't
            // quite understand what your definition of primitive type is
            return new[] {
            typeof(string),
            typeof(char),
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(ulong),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(DateTime),
        }.Contains(t);
        }
    }
}