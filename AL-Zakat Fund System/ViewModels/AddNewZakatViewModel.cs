using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using AL_Zakat_Fund_System.Views;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class AddNewZakatViewModel : Zakat
    {
        #region private Member

        private string _globlNoPhone;
        UserControl CurrentPage;
        private MainWindowViewModel mainWindowVM;

        #endregion

        #region public properties

        public string GloblNoPhone
        {
            get { return _globlNoPhone; }
            set { SetProperty(ref _globlNoPhone, value); }
        }

        #endregion

        #region Delegate Command

        public DelegateCommand AddZakatDatabaseCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region save Zakat
        private void AddZakatDatabaseExecute()
        {
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_insertZakat";

                #region Create Parameters
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

                    DBConnection.cmd.Parameters["@CaseDeposit"].Value = 2;
                    DBConnection.cmd.Parameters["@Convrsion"].Value = 0;
                    DBConnection.cmd.Parameters["@Collector"].Value = Collector;
                    DBConnection.cmd.Parameters["@Activity"].Value = Activity;

                    DBConnection.cmd.Parameters["@Migration"].Value = 0;

                    DBConnection.cmd.Parameters["@Colle_ssn"].Value = Properties.Settings.Default.EmpNo;
                    DBConnection.cmd.Parameters["@Office_no"].Value = Properties.Settings.Default.Office;
                    #endregion

                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();

                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;
                }



                // It Was Stored in Database
                if (succ == 1)
                {
                    MessageBox.Show("تم حفظ الزكاة بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // It is not Stored in Database
                else
                {
                    MessageBox.Show("لم يتم حفظ الزكاة الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("لم يتم حفظ الزكاة الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

        }
        private bool AddZakatDatabaseCanExecute()
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
            Name = "";
            City = "";
            Municipality = "";
            Locality = "";
            Activity = false;
            SDate = DateTime.Now;
            Amount = "";
            ReceiptNO = "";
            ZType = 0;
            ZCalss = "";
            Collector = 0;
            InstrumentNo = "";
            Phone = "";
            GloblNoPhone = "218";
            Email ="";

        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            mainWindowVM.ZeroThickness();
            CurrentPage.Content = null;
        }
        #endregion

        #endregion

        #region Construct
        public AddNewZakatViewModel(UserControl CP, MainWindowViewModel mainWindowVM_)
        {
            CurrentPage = CP;
            mainWindowVM = mainWindowVM_;
            ZType = 0;
            Collector = 0;
            Activity = false;
            GloblNoPhone = "218";
            SDate = DateTime.Now;

            AddZakatDatabaseCommand = new DelegateCommand(AddZakatDatabaseExecute,AddZakatDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
