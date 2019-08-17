using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class DisplayZakatViewModel : Zakat
    {
        #region private Member
        private Window CurrentWindow;

        #region Get Zakat
        private void GetZakat()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayZakat2";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@ID"].Value = Zakat_id;
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;
            
            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();
                Zakat_id = DBConnection.reader.GetInt32(0);
                Name = DBConnection.reader.GetString(1);
                Address = DBConnection.reader.GetString(2);
                SDate = DBConnection.reader.GetDateTime(3);
                Amount = DBConnection.reader.GetDecimal(4).ToString();
                ReceiptNO = DBConnection.reader.GetInt32(5).ToString();
                ZType2 = DBConnection.reader.GetString(6);
                ZCalss = DBConnection.reader.GetString(7);
                InstrumentNo = DBConnection.reader.GetString(8);
                Phone = DBConnection.reader.GetString(9);
                Email = DBConnection.reader.GetString(10);
                CaseDeposit2 = DBConnection.reader.GetString(11);
                Convrsion2 = DBConnection.reader.GetString(12);
                Colle_ssn2 = DBConnection.reader.GetString(13);
                Office_no2 = DBConnection.reader.GetString(14);
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
        public DisplayZakatViewModel(Window CW,int zakat_id)
        {
            CurrentWindow = CW;
            Zakat_id = zakat_id;

            GetZakat();// ues Zakat_id

            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
