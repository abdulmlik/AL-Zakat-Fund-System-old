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
    class EditRecordViewModel : Record
    {
        #region private Member
        
        Window CurrentWindow;

        #endregion

        #region private Function

        #region Get Record
        private void GetRecord()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayRecord3";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@ID"].Value = long.Parse(ID);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();

                TempID = DBConnection.reader.GetInt64(0).ToString();
                ID = TempID.Substring(4);
                RDate = DBConnection.reader.GetDateTime(1);
                Indigent_ssn = DBConnection.reader.GetInt64(2).ToString();
                RStatus = DBConnection.reader.GetByte(3);
                Name1 = DBConnection.reader.IsDBNull(4) ? null : DBConnection.reader.GetString(4);
                Name2 = DBConnection.reader.IsDBNull(5) ? null : DBConnection.reader.GetString(5);
                Name3 = DBConnection.reader.IsDBNull(6) ? null : DBConnection.reader.GetString(6);
                Scribe_ssn = DBConnection.reader.GetInt64(7);
                Office_no = DBConnection.reader.GetInt32(8);
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

        public DelegateCommand UPdateRecordPoorDatabaesCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region update Record
        private void UPdateRecordPoorDatabaesExecute()
        {
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_updateRecord";

                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@TempID", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@RDate", SqlDbType.DateTime));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@RStatus", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Indigent_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Name1", SqlDbType.NVarChar, 62));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Name2", SqlDbType.NVarChar, 62));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Name3", SqlDbType.NVarChar, 62));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion

                #region set value in parameters 
                DBConnection.cmd.Parameters["@TempID"].Value = long.Parse(TempID);
                DBConnection.cmd.Parameters["@ID"].Value = long.Parse(RDate.Year.ToString() + ID);
                DBConnection.cmd.Parameters["@RDate"].Value = RDate;
                DBConnection.cmd.Parameters["@RStatus"].Value = RStatus;
                
                DBConnection.cmd.Parameters["@Indigent_ssn"].Value = long.Parse(Indigent_ssn);
                
                DBConnection.cmd.Parameters["@Name1"].IsNullable = true;
                if (Name1 != null)
                { DBConnection.cmd.Parameters["@Name1"].Value = Name1; }
                else
                { DBConnection.cmd.Parameters["@Name1"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@Name2"].IsNullable = true;
                if (Name2 != null)
                { DBConnection.cmd.Parameters["@Name2"].Value = Name2; }
                else
                { DBConnection.cmd.Parameters["@Name2"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@Name3"].IsNullable = true;
                if (Name3 != null)
                { DBConnection.cmd.Parameters["@Name3"].Value = Name3; }
                else
                { DBConnection.cmd.Parameters["@Name3"].Value = DBNull.Value; }

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
                    MessageBox.Show("المحضر غير موجودة", "", MessageBoxButton.OK, MessageBoxImage.Error,
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
        private bool UPdateRecordPoorDatabaesCanExecute()
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
        public EditRecordViewModel(Window CW, string ID_)
        {
            CurrentWindow = CW;
            ID = ID_;

            GetRecord();// ues ID

            UPdateRecordPoorDatabaesCommand = new DelegateCommand(UPdateRecordPoorDatabaesExecute, UPdateRecordPoorDatabaesCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion        
    }
}
