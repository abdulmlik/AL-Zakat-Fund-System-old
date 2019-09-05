using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ModifyZakatViewModel : Zakat
    {
        #region private Member
        private string _globlNoPhone;
        Window CurrentWindow;

        #endregion

        #region private Function

        #region Get Zakat
        private void GetZakat()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayZakat3";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@ID"].Value = Zakat_id;
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                #region read data
                DBConnection.reader.Read();
                Zakat_id = DBConnection.reader.GetInt32(0);
                Name = DBConnection.reader.IsDBNull(1) ? null : DBConnection.reader.GetString(1);
                City = DBConnection.reader.IsDBNull(2) ? null : DBConnection.reader.GetString(2);
                Municipality = DBConnection.reader.IsDBNull(3) ? null : DBConnection.reader.GetString(3);
                Locality = DBConnection.reader.IsDBNull(4) ? null : DBConnection.reader.GetString(4);
                SDate = DBConnection.reader.GetDateTime(5);
                Amount = DBConnection.reader.GetDecimal(6).ToString();
                ReceiptNO = DBConnection.reader.GetInt32(7).ToString();
                ZType = DBConnection.reader.GetByte(8);
                ZCalss = DBConnection.reader.GetString(9);
                InstrumentNo = DBConnection.reader.IsDBNull(10) ? null : DBConnection.reader.GetString(10);
                GloblNoPhone = DBConnection.reader.IsDBNull(11) ? null : DBConnection.reader.GetString(11).Substring(0, 3);
                Phone = DBConnection.reader.IsDBNull(11) ? null : DBConnection.reader.GetString(11).Substring(3);
                Email = DBConnection.reader.IsDBNull(12) ? null : DBConnection.reader.GetString(12);
                CaseDeposit = DBConnection.reader.GetByte(13);
                Convrsion = DBConnection.reader.GetBoolean(14);
                Collector = DBConnection.reader.GetByte(15);
                Activity = DBConnection.reader.GetBoolean(16);
                Migration = DBConnection.reader.GetBoolean(17);
                if (DBConnection.reader.IsDBNull(18))
                {
                    MigrationDate = null;
                }
                else
                {
                    MigrationDate = DBConnection.reader.GetDateTime(18);
                }
                Colle_ssn = DBConnection.reader.GetInt64(19);
                Office_no = DBConnection.reader.GetInt32(20);
                #endregion
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

        public string GloblNoPhone
        {
            get { return _globlNoPhone; }
            set { SetProperty(ref _globlNoPhone, value); }
        }

        #endregion

        #region Delegate Command

        public DelegateCommand ModifyZakatDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region update Zakat
        private void ModifyZakatDatabaseExecute()
        {
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_updateZakat";

                #region Create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 60));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Municipality", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Locality", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@SDate", SqlDbType.DateTime));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@ReceiptNO", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@ZType", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@ZCalss", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@InstrumentNo", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.VarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@CaseDeposit", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Convrsion", SqlDbType.Bit));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Collector", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Activity", SqlDbType.Bit));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Migration", SqlDbType.Bit));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@MigrationDate", SqlDbType.DateTime));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Colle_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office_no", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion


                Decimal Amount_Filter;
                int ReceiptNO_Filter, InstrumentNo_Filter;
                if (Decimal.TryParse(Amount, out Amount_Filter) && int.TryParse(ReceiptNO, out ReceiptNO_Filter)
                    && (int.TryParse(InstrumentNo, out InstrumentNo_Filter) || InstrumentNo == null))
                {
                    if (InstrumentNo == null)
                    {
                        InstrumentNo_Filter = -1;
                    }

                    #region set value to Parameters
                    DBConnection.cmd.Parameters["@Id"].Value = Zakat_id;

                    DBConnection.cmd.Parameters["@Name"].IsNullable = true;
                    if (Name != null)
                    { DBConnection.cmd.Parameters["@Name"].Value = Name; }
                    else
                    { DBConnection.cmd.Parameters["@Name"].Value = DBNull.Value; }

                    DBConnection.cmd.Parameters["@City"].IsNullable = true;
                    if (City != null)
                    { DBConnection.cmd.Parameters["@City"].Value = City; }
                    else
                    { DBConnection.cmd.Parameters["@City"].Value = DBNull.Value; }

                    DBConnection.cmd.Parameters["@Municipality"].IsNullable = true;
                    if (Municipality != null)
                    { DBConnection.cmd.Parameters["@Municipality"].Value = Municipality; }
                    else
                    { DBConnection.cmd.Parameters["@Municipality"].Value = DBNull.Value; }

                    DBConnection.cmd.Parameters["@Locality"].IsNullable = true;
                    if (Locality != null)
                    { DBConnection.cmd.Parameters["@Locality"].Value = Locality; }
                    else
                    { DBConnection.cmd.Parameters["@Locality"].Value = DBNull.Value; }

                    DBConnection.cmd.Parameters["@SDate"].Value = SDate;
                    DBConnection.cmd.Parameters["@Amount"].Value = Amount_Filter;
                    DBConnection.cmd.Parameters["@ReceiptNO"].Value = ReceiptNO_Filter;
                    DBConnection.cmd.Parameters["@ZType"].Value = ZType;
                    DBConnection.cmd.Parameters["@ZCalss"].Value = ZCalss;

                    DBConnection.cmd.Parameters["@InstrumentNo"].IsNullable = true;
                    if (InstrumentNo != null)
                    { DBConnection.cmd.Parameters["@InstrumentNo"].Value = InstrumentNo; }
                    else
                    { DBConnection.cmd.Parameters["@InstrumentNo"].Value = DBNull.Value; }

                    DBConnection.cmd.Parameters["@Phone"].IsNullable = true;
                    if (Phone != null)
                    { DBConnection.cmd.Parameters["@Phone"].Value = GloblNoPhone + Phone; }
                    else
                    { DBConnection.cmd.Parameters["@Phone"].Value = DBNull.Value; }

                    DBConnection.cmd.Parameters["@Email"].IsNullable = true;
                    if (Email != null)
                    { DBConnection.cmd.Parameters["@Email"].Value = Email; }
                    else
                    { DBConnection.cmd.Parameters["@Email"].Value = DBNull.Value; }

                    DBConnection.cmd.Parameters["@CaseDeposit"].Value = CaseDeposit;
                    DBConnection.cmd.Parameters["@Convrsion"].Value = Convrsion;

                    DBConnection.cmd.Parameters["@Collector"].Value = Collector;
                    DBConnection.cmd.Parameters["@Activity"].Value = Activity;

                    //Activity == 1
                    if (Convrsion && Convrsion != ConvrsionTemp)
                    {
                        //yare  month
                        if (SDate.Year < DateTime.Now.Year || (SDate.Year == DateTime.Now.Year && SDate.Month < DateTime.Now.Month))
                        {
                            DBConnection.cmd.Parameters["@Migration"].Value = 1;
                            DBConnection.cmd.Parameters["@MigrationDate"].Value = DateTime.Now;
                        }
                        else
                        {
                            DBConnection.cmd.Parameters["@Migration"].Value = 0;
                            DBConnection.cmd.Parameters["@MigrationDate"].Value = DBNull.Value;
                        }
                    }
                    else if (Migration)
                    {
                        DBConnection.cmd.Parameters["@Migration"].Value = 1;
                        DBConnection.cmd.Parameters["@MigrationDate"].Value = MigrationDate;
                    }
                    else
                    {
                        DBConnection.cmd.Parameters["@Migration"].Value = 0;
                        DBConnection.cmd.Parameters["@MigrationDate"].Value = DBNull.Value;
                    }
                    

                    DBConnection.cmd.Parameters["@Colle_ssn"].Value = Properties.Settings.Default.EmpNo;
                    DBConnection.cmd.Parameters["@Office_no"].Value = Office_no;
                    #endregion

                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();

                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;
                }
               

                // It Was Stored in Database
                if (succ == 1)
                {
                    MessageBox.Show("تم حفظ التحديث بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                //
                else if(succ == 2)
                {
                    MessageBox.Show("الزكاة غير موجودة", "", MessageBoxButton.OK, MessageBoxImage.Error,
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
                if(succ == 1)
                {
                    CurrentWindow.DialogResult = true;
                    CurrentWindow.Close();
                }
            }
        }
        private bool ModifyZakatDatabaseCanExecute()
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
        public ModifyZakatViewModel(Window CW, int zakat_id)
        {
            
            CurrentWindow = CW;
            Zakat_id = zakat_id;

            GetZakat();// Useing Zakat_id

            ModifyZakatDatabaseCommand = new DelegateCommand(ModifyZakatDatabaseExecute, ModifyZakatDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
