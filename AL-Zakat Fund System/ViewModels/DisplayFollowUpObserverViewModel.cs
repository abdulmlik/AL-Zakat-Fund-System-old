using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using Prism.Commands;


namespace AL_Zakat_Fund_System.ViewModels
{
    class DisplayFollowUpObserverViewModel : Follow_up
    {
        #region private Member
        private Window CurrentWindow;

        #endregion

        #region private function

        #region Get Follow Up
        private void GetFollowUp()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayFollowUPObserver2";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@DecisionNO"].Value = long.Parse(DecisionNO);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();
                DecisionNO = DBConnection.reader.GetInt64(0).ToString();
                Distance2 = DecisionNO.Substring(0, 4);//useing like record date
                FStatus2 = DecisionNO.Substring(4);//useing like Record no
                fullname = DBConnection.reader.GetString(1);
                Phone = DBConnection.reader.GetString(2);
                Office = DBConnection.reader.GetString(3);
                LastConnection2 = DBConnection.reader.GetString(4);
                Notice = DBConnection.reader.GetString(5);
                Comment = DBConnection.reader.GetString(6);
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

        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region Cancel
        private void CancelExecute()
        {
            CurrentWindow.Close();
        }
        #endregion

        #endregion

        #region Construct
        public DisplayFollowUpObserverViewModel(Window CW, string DN_)
        {
            CurrentWindow = CW;
            DecisionNO = DN_;

            GetFollowUp();// ues DecisionNO

            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
