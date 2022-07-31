using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Deneme1.Models
{
    public class DBTools
    {
        public static String connstr;
        static DataSet dt;
        static SqlDataAdapter adap;
        public static SqlConnection conn = new SqlConnection(connstr);
        static SqlCommand cmd = null;
        public static int cust_cag = 0;

        public static string Kullanici;
        public static string Kullanici_Kodu;
        public static string Kul_Sifre;
        public static int Kullanici_ID;
        public static string SirketKodu;
        public static string SirketAdi;
        public static string Sirket_Database;
        public static string Demirbas_Database;

        public static int Tek_Sirket;
        public static int Tek_Sube;
        public static int Tek_RapSube;
        public static int Tek_Departman;

        public static int User_Sirket;
        public static string User_Sube;
        public static string User_RapSube;
        public static string User_Departman;

        public static string Form_Header = "";
        public static int change_User_Time;
        public static int change_User_Kalan;
        public static bool change_User_Onay = false;

        public static bool execcmd(String cmds)
        {
            try
            {
                //dbtools.change_User_Kalan = dbtools.change_User_Time;

                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                conn.Open();
                cmd = new SqlCommand("set dateformat dmy ; " + cmds, conn);
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        //////////////////////////////////

        public static DataTable cmdTable(SqlCommand cmd)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //////////////////////////////////

        public static DataTable cmdTable(SqlCommand cmd, SqlConnection cnn)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                cmd.Connection = cnn;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cnn.Close();
            }
        }

        //////////////////////////////////

        public static String CheckDB()
        {
            try
            {
                //dbtools.change_User_Kalan = dbtools.change_User_Time;

                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                conn.Open();
                conn.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //////////////////////////////

        public static String SelectTekData(String querytable, String where, String istenendeger)
        {
            // dbtools.change_User_Kalan = dbtools.change_User_Time;

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            try
            {
                dt = new DataSet();
                String str2 = "select " + istenendeger + " from " + querytable + " " + where;
                adap = new SqlDataAdapter(str2, conn);
                adap.Fill(dt, "tbl1");
                String str3;
                if (dt.Tables["tbl1"].Rows.Count > 0)
                {
                    str3 = dt.Tables["tbl1"].Rows[0][0].ToString();
                }
                else
                {
                    str3 = "";
                }
                return str3;
            }
            catch
            {
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        /// ////////////////////

        public static String DegerGetir(String sql)
        {
            //dbtools.change_User_Kalan = dbtools.change_User_Time;

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            try
            {
                dt = new DataSet();
                String str2 = "set dateformat dmy ; " + sql;
                adap = new SqlDataAdapter(str2, conn);

                adap.Fill(dt, "tbl1");
                String str3;
                if (dt.Tables["tbl1"].Rows.Count > 0)
                {
                    str3 = dt.Tables["tbl1"].Rows[0][0].ToString();
                }
                else
                {
                    str3 = "";
                }
                return str3;
            }
            finally
            {
                conn.Close();
            }
        }

        ///////////////////////////////////////

        public static DataTable SelectTable(String sql1)
        {
            //dbtools.change_User_Kalan = dbtools.change_User_Time;
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            try
            {
                dt = new DataSet();
                adap = new SqlDataAdapter("set dateformat dmy ; " + sql1, conn);
                adap.Fill(dt, "q");
                return dt.Tables["q"];
            }
            finally
            {
                conn.Close();
            }
        }

        ///////////////////////////////////////

        public static DataSet SelectTableSet(String sql1)
        {
            //dbtools.change_User_Kalan = dbtools.change_User_Time;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            try
            {

                dt = new DataSet();
                adap = new SqlDataAdapter("set dateformat dmy ; " + sql1, conn);
                adap.Fill(dt, "q");
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }



    }
}