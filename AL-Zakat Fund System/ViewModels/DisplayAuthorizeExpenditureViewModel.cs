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
    class DisplayAuthorizeExpenditureViewModel : AuthorizeExpenditure
    {
        #region private Member
        private Window CurrentWindow;

        #endregion

        #region private function

        #region Get AuthorizeExpenditure
        private void GetAuthorizeExpenditure()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayAEX2";
            
            DBConnection.cmd.Parameters.Add(new SqlParameter("@CommitteeDecisionNO", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@CommitteeDecisionNO"].Value = long.Parse(CommitteeDecisionNO);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();
                CommitteeDecisionNO = DBConnection.reader.GetInt64(0).ToString();
                FullName = DBConnection.reader.GetString(1);
                CategoryPoor2 = DBConnection.reader.GetString(2);
                TypeAssistance = DBConnection.reader.GetString(3);
                Amount = DBConnection.reader.GetDecimal(4).ToString();
                SDate = DBConnection.reader.GetDateTime(5);
                InstrumentNO2 = DBConnection.reader.GetString(6);
                InstrumentNO = DBConnection.reader.GetString(7);
                Courier_ssn2 = DBConnection.reader.GetString(8);
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
        public DisplayAuthorizeExpenditureViewModel(Window CW, string CDN_)
        {
            CurrentWindow = CW;
            CommitteeDecisionNO = CDN_;

            GetAuthorizeExpenditure();// ues CommitteeDecisionNO

            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
