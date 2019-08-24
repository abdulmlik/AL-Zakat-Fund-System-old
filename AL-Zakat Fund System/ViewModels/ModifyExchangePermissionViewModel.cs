using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AL_Zakat_Fund_System.Models;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ModifyExchangePermissionViewModel : AuthorizeExpenditure
    {
        #region private Member

        Window CurrentWindow;

        #endregion

        #region private Function

        #region Get Record
        private void GetAuthorizeExpenditure()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayAEX3";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@CommitteeDecisionNO", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@CommitteeDecisionNO"].Value = long.Parse(CommitteeDecisionNO);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            
            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();
                TempCDN = DBConnection.reader.GetInt64(0).ToString();
                CommitteeDecisionNO = TempCDN.Substring(4);
                CategoryPoor = DBConnection.reader.GetByte(1);
                TypeAssistance = DBConnection.reader.GetString(2);
                Amount = DBConnection.reader.GetDecimal(3).ToString();
                SDate = DBConnection.reader.GetDateTime(4);
                InstrumentNO = DBConnection.reader.IsDBNull(5) ? null : DBConnection.reader.GetInt32(5).ToString();
                Comment = DBConnection.reader.IsDBNull(6) ? null : DBConnection.reader.GetString(6);
                Record_id = DBConnection.reader.GetInt64(7).ToString();
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
        public DelegateCommand updateDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        #endregion

        #region Execute and CanExecute Functions

        #region update AuthorizeExpenditure
        private void updateDatabaseExecute()
        {
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_updateAEX";

                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@TempCDN", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@CommitteeDecisionNO", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@CategoryPoor", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@TypeAssistance", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@SDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@InstrumentNO", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Comment", SqlDbType.NText));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Record_id", SqlDbType.BigInt));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion

                #region set value in parameters 
                DBConnection.cmd.Parameters["@TempCDN"].Value = long.Parse(TempCDN);
                DBConnection.cmd.Parameters["@CommitteeDecisionNO"].Value = long.Parse(SDate.Year + CommitteeDecisionNO);
                DBConnection.cmd.Parameters["@CategoryPoor"].Value = CategoryPoor;
                DBConnection.cmd.Parameters["@TypeAssistance"].Value = TypeAssistance;
                DBConnection.cmd.Parameters["@Amount"].Value = decimal.Parse(Amount);
                DBConnection.cmd.Parameters["@SDate"].Value = SDate;

                DBConnection.cmd.Parameters["@InstrumentNO"].IsNullable = true;
                if (string.IsNullOrEmpty(InstrumentNO) || string.IsNullOrWhiteSpace(InstrumentNO))
                { DBConnection.cmd.Parameters["@InstrumentNO"].Value = DBNull.Value; }
                else
                { DBConnection.cmd.Parameters["@InstrumentNO"].Value = int.Parse(InstrumentNO); }

                DBConnection.cmd.Parameters["@Comment"].IsNullable = true;
                if (string.IsNullOrEmpty(Comment) || string.IsNullOrWhiteSpace(Comment))
                { DBConnection.cmd.Parameters["@Comment"].Value = DBNull.Value; }
                else
                { DBConnection.cmd.Parameters["@Comment"].Value = Comment; }

                DBConnection.cmd.Parameters["@Record_id"].Value = int.Parse(Record_id);

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
                //AUTHORIZE EXPENDITURE is Already exists
                else if (succ == 2)
                {
                    MessageBox.Show("رقم قرار اللجنة غير موجود", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                //record is not exist
                else if (succ == 3)
                {
                    MessageBox.Show("رقم المحضر غير موجود", "", MessageBoxButton.OK, MessageBoxImage.Error,
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
        public ModifyExchangePermissionViewModel(Window CW, string CDN_)
        {
            CurrentWindow = CW;
            CommitteeDecisionNO = CDN_;


            GetAuthorizeExpenditure();// ues ID
            updateDatabaseCommand = new DelegateCommand(updateDatabaseExecute, updateDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);

        }
        #endregion
    }
}
