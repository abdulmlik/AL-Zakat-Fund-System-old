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
    class DisplayRecordViewModel : Record
    {
        #region private Member
        private Window CurrentWindow;

        #endregion

        #region private function

        #region Get Record
        private void GetRecord()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayRecord2";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@ID"].Value = long.Parse(ID);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();
                ID = DBConnection.reader.GetInt64(0).ToString().Substring(4);
                RDate = DBConnection.reader.GetDateTime(1);
                Indigent_ssn = DBConnection.reader.GetString(2);
                RStatus2 = DBConnection.reader.GetString(3);
                Name1 = DBConnection.reader.GetString(4);
                Name2 = DBConnection.reader.GetString(5);
                Name3 = DBConnection.reader.GetString(6);
                Scribe_ssn2 = DBConnection.reader.GetString(7);
                Office_no2 = DBConnection.reader.GetString(8);
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
        public DisplayRecordViewModel(Window CW, string ID_)
        {
            CurrentWindow = CW;
            ID = ID_;

            GetRecord();// ues ID

            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
