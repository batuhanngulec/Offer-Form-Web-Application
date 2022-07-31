using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1.Models
{
    public interface IDapperTools
    {
        #region generic repo

        T Get<T>(object id) where T : class;

        IEnumerable<T> GetAll<T>() where T : class;

        long Insert<T>(T obj) where T : class;

        long Insert<T>(IEnumerable<T> list) where T : class;

        bool Update<T>(T obj) where T : class;

        bool Update<T>(IEnumerable<T> list) where T : class;

        bool Delete<T>(T obj) where T : class;

        bool Delete<T>(IEnumerable<T> list) where T : class;

        bool DeleteAll<T>() where T : class;

        #endregion generic repo

        #region async generic repo

        Task<T> GetAsync<T>(object id) where T : class;

        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;

        Task<int> InsertAsync<T>(T obj) where T : class;

        Task<int> InsertAsync<T>(IEnumerable<T> list) where T : class;

        Task<bool> UpdateAsync<T>(T obj) where T : class;

        Task<bool> UpdateAsync<T>(IEnumerable<T> list) where T : class;

        Task<bool> DeleteAsync<T>(T obj) where T : class;

        Task<bool> DeleteAsync<T>(IEnumerable<T> list) where T : class;

        Task<bool> DeleteAllAsync<T>() where T : class;

        #endregion async generic repo

        #region db commands

        int Execute(string sql, object param = null);

        IEnumerable<T> Query<T>(string sql, object param = null) where T : class;

        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            object param = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class;
        IEnumerable<T1> QueryAsync<T1, T2>(string v, object p);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class;

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql,
           Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null)
           where TFirst : class
           where TSecond : class
           where TThird : class
           where TFourth : class
           where TFifth : class
           where TSixth : class
           where TReturn : class;


        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql,
           Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null)
           where TFirst : class
           where TSecond : class
           where TThird : class
           where TFourth : class
           where TFifth : class
           where TSixth : class
           where TSeventh : class
           where TReturn : class;

        IEnumerable<object> Query(string sql, object param = null);

        SqlMapper.GridReader QueryMultiple(string sql, object param = null);


        object ExecuteScalar(string sql, object param = null);
        #endregion db commands

        #region async db commands

        Task<int> ExecuteAsync(string sql, object param = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null) where T : class;

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
             Func<TFirst, TSecond, TReturn> map, object param = null)
             where TFirst : class
             where TSecond : class
             where TReturn : class;

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        Task<IEnumerable<object>> QueryAsync(string sql, object param = null);

        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null);

        #endregion async db commands
    }
}
