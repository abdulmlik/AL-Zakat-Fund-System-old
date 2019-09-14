using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using System.Windows.Controls;
using Prism.Commands;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class EditFollowUpObserverViewModel : Follow_up
    {
        #region private Member

        Window CurrentWindow;
        private string DecisionNO2;

        #endregion

        #region private Function

        #region Get Follow Up
        private void GetFollowUp()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayFollowUPObserver3";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@DecisionNO"].Value = long.Parse(DecisionNO);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();
                DecisionNO2 = DBConnection.reader.GetInt64(0).ToString();
                if (DBConnection.reader.IsDBNull(1)) { LastConnection = null; }
                else { LastConnection = DBConnection.reader.GetDateTime(1); }
                Notice = DBConnection.reader.IsDBNull(2)? null : DBConnection.reader.GetString(2);
                Comment = DBConnection.reader.IsDBNull(3) ? null : DBConnection.reader.GetString(3);
                fullname = DBConnection.reader.GetString(4);
                Observer_ssn = DBConnection.reader.GetInt64(5).ToString();
                Phone = DBConnection.reader.GetString(6);
                Email = DBConnection.reader.GetString(7);

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا في جلب البيانات" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }
        #endregion

        #endregion

        #region public properties

        #endregion

        #region Delegate Command
        public DelegateCommand UpdateDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        #endregion

        #region Execute and CanExecute Functions

        #region update Follow Up
        private void updateDatabaseExecute()
        {
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_updateFollowUPObserver";

                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@LastConnection", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Notice", SqlDbType.NText));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Comment", SqlDbType.NText));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion

                #region set value in parameters
                DBConnection.cmd.Parameters["@DecisionNO"].Value = long.Parse(DecisionNO);
                if (LastConnection == null)
                { DBConnection.cmd.Parameters["@LastConnection"].Value = DBNull.Value; }
                else
                { DBConnection.cmd.Parameters["@LastConnection"].Value = LastConnection; }
                if (string.IsNullOrEmpty(Notice) || string.IsNullOrWhiteSpace(Notice))
                { DBConnection.cmd.Parameters["@Notice"].Value = DBNull.Value; }
                else
                { DBConnection.cmd.Parameters["@Notice"].Value = Notice; }
                if (string.IsNullOrEmpty(Comment) || string.IsNullOrWhiteSpace(Comment))
                { DBConnection.cmd.Parameters["@Comment"].Value = DBNull.Value; }
                else
                { DBConnection.cmd.Parameters["@Comment"].Value = Comment; }



                #endregion


                DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                DBConnection.cmd.ExecuteNonQuery();

                succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                // It Was Stored in Database
                if (succ == 1)
                {
                    MessageBox.Show("تم حفظ التحديث بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                //
                else if (succ == 2)
                {
                    MessageBox.Show("المتابعة غير موجودة", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // It is not Stored in Database
                else
                {
                    MessageBox.Show("لم يتم حفظ التحديث الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("لم يتم حفظ التحديث الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
                if (succ == 1)
                {
                    CurrentWindow.DialogResult = true;
                    CurrentWindow.Close();
                }
            }
        }
        private bool updateDatabaseCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            CurrentWindow.Close();
        }
        #endregion

        #endregion

        #region Construct
        public EditFollowUpObserverViewModel(Window CW, string DN_)
        {
            CurrentWindow = CW;
            DecisionNO = DN_;


            GetFollowUp();// ues DN
            UpdateDatabaseCommand = new DelegateCommand(updateDatabaseExecute, updateDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);

        }
        #endregion
    }
}
