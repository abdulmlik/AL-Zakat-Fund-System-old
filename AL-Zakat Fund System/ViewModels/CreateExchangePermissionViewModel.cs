using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class CreateExchangePermissionViewModel : AuthorizeExpenditure
    {
        #region private Member
        UserControl CurrentPage;
        #endregion

        #region public properties
        
        #endregion

        #region Delegate Command
        public DelegateCommand CreateAuthorizeExpenditureDatabaseCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        #endregion

        #region Execute and CanExecute Functions

        #region save Authorize Expenditure
        private void CreateAuthorizeExpenditureDatabaseExecute()
        {
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_insertAEX";


                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@CommitteeDecisionNO", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@CategoryPoor", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@TypeAssistance", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@SDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@InstrumentNO", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Courier_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Record_id", SqlDbType.BigInt));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion

                #region set value in parameters 
                DBConnection.cmd.Parameters["@CommitteeDecisionNO"].Value = long.Parse(SDate.Year + CommitteeDecisionNO);
                DBConnection.cmd.Parameters["@CategoryPoor"].Value = CategoryPoor;
                DBConnection.cmd.Parameters["@TypeAssistance"].Value = TypeAssistance;
                DBConnection.cmd.Parameters["@Amount"].Value = Amount;
                DBConnection.cmd.Parameters["@SDate"].Value = SDate;

                DBConnection.cmd.Parameters["@InstrumentNO"].IsNullable = true;
                if (InstrumentNO != null)
                { DBConnection.cmd.Parameters["@InstrumentNO"].Value = int.Parse(InstrumentNO); }
                else
                { DBConnection.cmd.Parameters["@InstrumentNO"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@Courier_ssn"].Value = Properties.Settings.Default.EmpNo;
                DBConnection.cmd.Parameters["@Record_id"].Value = Record_id;

                #endregion

                DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                DBConnection.cmd.ExecuteNonQuery();

                succ = (int)DBConnection.cmd.Parameters["@Success"].Value;


                #region message box
                // It Was Stored in Database
                if (succ == 1)
                {
                    MessageBox.Show("تم الصرف بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else if (succ == 2)
                {
                    MessageBox.Show("رقم المحضر غير موجود", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // It is not Stored in Database
                else
                {
                    MessageBox.Show("لم يتم  الصرف الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("لم يتم  الصرف الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + "الخطأ : " + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }
        private bool CreateAuthorizeExpenditurenDatabaseCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion

        #region Reset
        private void ResetExecute()
        {
            SDate = DateTime.Now;
            Amount = "";
            CommitteeDecisionNO = "";
            CategoryPoor = 0;
            TypeAssistance = "";
            InstrumentNO = "";
            Record_id = "";

        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            CurrentPage.Content = null;
        }
        #endregion

        #endregion

        #region Construct
        public CreateExchangePermissionViewModel(UserControl CP)
        {
            CurrentPage = CP;

            CategoryPoor = 0;
            SDate = DateTime.Now;

            CreateAuthorizeExpenditureDatabaseCommand = new DelegateCommand(CreateAuthorizeExpenditureDatabaseExecute, CreateAuthorizeExpenditurenDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);

        }
        #endregion
    }
}
