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
            bool succ = false;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_insertZakat";

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
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Colle_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office_no", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit));

                Decimal Amount_Filter;
                int ReceiptNO_Filter, InstrumentNo_Filter;
                if (Decimal.TryParse(Amount, out Amount_Filter) && int.TryParse(ReceiptNO, out ReceiptNO_Filter) 
                    && (int.TryParse(InstrumentNo, out InstrumentNo_Filter) || InstrumentNo == null))
                {
                    if (InstrumentNo == null)
                    {
                        InstrumentNo_Filter = -1;
                    }
                    DBConnection.cmd.Parameters["@Name"].Value = Name;
                    DBConnection.cmd.Parameters["@City"].Value = City;
                    DBConnection.cmd.Parameters["@Municipality"].Value = Municipality;
                    DBConnection.cmd.Parameters["@Locality"].Value = Locality;
                    DBConnection.cmd.Parameters["@SDate"].Value = SDate;
                    DBConnection.cmd.Parameters["@Amount"].Value = Amount_Filter;
                    DBConnection.cmd.Parameters["@ReceiptNO"].Value = ReceiptNO_Filter;
                    DBConnection.cmd.Parameters["@ZType"].Value = ZType;
                    DBConnection.cmd.Parameters["@ZCalss"].Value = ZCalss;
                    DBConnection.cmd.Parameters["@InstrumentNo"].Value = InstrumentNo_Filter;
                    DBConnection.cmd.Parameters["@Phone"].Value = GloblNoPhone + Phone;
                    DBConnection.cmd.Parameters["@Email"].Value = Email;
                    DBConnection.cmd.Parameters["@CaseDeposit"].Value = 1;
                    DBConnection.cmd.Parameters["@Convrsion"].Value = 0;
                    DBConnection.cmd.Parameters["@Colle_ssn"].Value = Properties.Settings.Default.EmpNo;
                    DBConnection.cmd.Parameters["@Office_no"].Value = 2;

                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();

                    succ = (bool)DBConnection.cmd.Parameters["@Success"].Value;
                }
                


                //you have not been successfully logged in
                if (succ)
                {
                    MessageBox.Show("تم حفظ الزكاة بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // Sign in Successfully
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
            SDate = DateTime.Now;
            Amount = "";
            ReceiptNO = "";
            ZType = 0;
            ZCalss = "";
            InstrumentNo = "";
            Phone = "";
            GloblNoPhone = "218";
            Email ="";

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
        public AddNewZakatViewModel(UserControl CP)
        {
            CurrentPage = CP;

            ZType = 0;
            GloblNoPhone = "218";
            SDate = DateTime.Now;

            AddZakatDatabaseCommand = new DelegateCommand(AddZakatDatabaseExecute,AddZakatDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
