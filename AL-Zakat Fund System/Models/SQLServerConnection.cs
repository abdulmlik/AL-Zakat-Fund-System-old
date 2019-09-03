using System;

//MessageBox
using System.Windows;

// Data Base
using System.Data;
using System.Data.SqlClient;

// App.config
using System.Configuration;

namespace AL_Zakat_Fund_System.Models
{
    public class DBConnection
    {

        #region private function
        /// <summary>
        /// Get Connection String  From App.config
        /// </summary>
        /// <returns>Connection String</returns>
        private static string GetConnectionString()
        {
            string mode = Properties.Settings.Default.Mode;
            string conString;

            //Windows Authentication
            if (mode == "True")
            {
                conString = string.Format(ConfigurationManager.ConnectionStrings["conString"].ConnectionString,
                                            @Properties.Settings.Default.Server, @Properties.Settings.Default.DataBase);
            }//SQL Server Authentication
            else
            {
                conString = string.Format(ConfigurationManager.ConnectionStrings["conString2"].ConnectionString,
                                            @Properties.Settings.Default.Server, @Properties.Settings.Default.DataBase,
                                            @Properties.Settings.Default.UserName, @Properties.Settings.Default.Password);
            }

            return conString;
        }

        /// <summary>
        /// clear Member
        /// </summary>
        private static void Clear()
        {
            sql = "";
            con = new SqlConnection();
            cmd = new SqlCommand("", con);
            reader  = null;
            dt  = null;
            da  = null;
        }
        #endregion

        #region public Member
        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader reader;
        public static DataTable dt;
        public static SqlDataAdapter da;
        #endregion

        #region Open and Close Connection
        /// <summary>
        /// Open Connection
        /// </summary>
        public static bool OpenConnection()
        {
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionString();
                    con.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("فشل النظام في تكوين اتصال" + Environment.NewLine +
                                "وصف : " + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return false;
            }
            return true;
        }//end open connection

        /// <summary>
        /// Close Connection
        /// </summary>
        public static void CloseConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)//not 
            {
                MessageBox.Show("فشل  في اقفال الاتصال" + Environment.NewLine +
                                "وصف : " + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                Clear();   
            }
        }//end Close connection
        #endregion

        #region Connection Status

        /// <summary>
        /// Connection Status
        /// </summary>
        /// <returns> true When you can contact the Server</returns>
        public static bool ConnectionStatus()
        {
            try
            {
                con.ConnectionString = GetConnectionString() + "Connect Timeout=4;";
                con.Open();
                con.Close();
                Clear();
            }
            catch
            {
                return false;
            }
            return true;
        }//end open connection
        
        #endregion

    }// end class

}//end namespace