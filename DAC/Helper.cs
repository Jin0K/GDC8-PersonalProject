using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    public static class Helper
    {
        /// <summary>
        /// DataReader => List<VO>로 변환해서 반환하는 메서드
        /// </summary>
        /// <typeparam name="T">DTO or VO</typeparam>
        /// <param name="dr">Get Data from DB</param>
        /// <returns></returns>
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            try
            {
                List<T> list = new List<T>();
                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (System.Reflection.PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        //프로퍼티는 존재하는데, reader안에 조회된 컬럼이 없는 경우
                        //reader에 조회된 컬럼은 있는데, 프로퍼티는 정의되지 않은 경우
                        if (ContainsColumn(dr, prop.Name))
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, dr[prop.Name], null);
                            }
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception err)
            {
                //select 한 컬럼의 타입과 VO클래스의 속성타입이 맞지 않을경우
                //select 한 컬러명과 VO클래스의 속성명이 다른 경우
                string msg = err.Message;
                return null;
            }
        }

        /// <summary>
        /// DataTable => List<VO>로 변환해서 반환하는 메서드
        /// </summary>
        /// <typeparam name="T">DTO or VO class</typeparam>
        /// <param name="table">Get Data From DB</param>
        /// <returns></returns>
        public static List<T> DataTableMapToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        private static bool ContainsColumn(IDataReader reader, string columnName)
        {
            foreach (DataRow row in reader.GetSchemaTable().Rows)
            {
                if (row["ColumnName"].ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// DataReader => VO로 변환해서 반환하는 메서드
        /// </summary>
        /// <typeparam name="T">DTO or VO</typeparam>
        /// <param name="dr">Get Data from DB</param>
        /// <returns></returns>
        public static T DataReaderMapToT<T>(IDataReader dr) where T : new()
        {
            try
            {
                //T list = new List<T>();
                T obj = default(T);
                //if (dr.Read())
                //{
                    obj = Activator.CreateInstance<T>();
                    foreach (System.Reflection.PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        //프로퍼티는 존재하는데, reader안에 조회된 컬럼이 없는 경우
                        //reader에 조회된 컬럼은 있는데, 프로퍼티는 정의되지 않은 경우
                        if (ContainsColumn(dr, prop.Name))
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                            {
                                if (!DBNull.Value.Equals(dr[prop.Name]))
                                {
                                    prop.SetValue(obj, dr[prop.Name], null);
                                }
                            }
                        }
                    }
                //}
                return obj;
            }
            catch (Exception err)
            {
                //select 한 컬럼의 타입과 VO클래스의 속성타입이 맞지 않을경우
                //select 한 컬러명과 VO클래스의 속성명이 다른 경우
                string msg = err.Message;
                return default(T);
            }
        }
        
    }

