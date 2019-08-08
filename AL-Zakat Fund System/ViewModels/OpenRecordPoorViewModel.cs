using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class OpenRecordPoorViewModel : Record
    {
        #region private Member

        private string _Name1;
        private string _Name2;
        private string _Name3;

        UserControl CurrentPage;

        #endregion

        #region public properties
        public string Name1
        {
            get { return _Name1; }
            set { SetProperty(ref _Name1, value); }
        }
        public string Name2
        {
            get { return _Name2; }
            set { SetProperty(ref _Name2, value); }
        }
        public string Name3
        {
            get { return _Name3; }
            set { SetProperty(ref _Name3, value); }
        }
        #endregion

        #region Delegate Command

        public DelegateCommand AddRecordPoorDatabaesCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region save Record
        private void AddRecordPoorDatabaesExecute()
        {
            bool succ = false;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_insertRecord";


                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@RDate", SqlDbType.DateTime));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@RStatus", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Scribe_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Indigent_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office_no", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Name1", SqlDbType.NVarChar, 62));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Name2", SqlDbType.NVarChar, 62));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Name3", SqlDbType.NVarChar, 62));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit));
                #endregion

                #region set value in parameters 
                DBConnection.cmd.Parameters["@ID"].Value = long.Parse( RDate.Year.ToString() + ID);
                DBConnection.cmd.Parameters["@RDate"].Value = RDate;
                DBConnection.cmd.Parameters["@RStatus"].Value = RStatus;

                DBConnection.cmd.Parameters["@Scribe_ssn"].Value = Properties.Settings.Default.EmpNo;
                DBConnection.cmd.Parameters["@Indigent_ssn"].Value = long.Parse(Indigent_ssn);
                DBConnection.cmd.Parameters["@Office_no"].Value = 2;// Properties.Settings.Default.Office;

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

                succ = (bool)DBConnection.cmd.Parameters["@Success"].Value;


                // It Was Stored in Database
                if (succ)
                {
                    MessageBox.Show("تم فتح محضر للمحتاج بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // It is not Stored in Database
                else
                {
                    MessageBox.Show("لم يتم  فتح محضر للمحتاج الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("لم يتم  فتح محضر للمحتاج الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + "الخطأ : " + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

        }
        private bool AddRecordPoorDatabaesCanExecute()
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
            Name1 = "";
            Name2 = "";
            Name3 = "";
            ID = "";
            RDate = DateTime.Now;
            RStatus = 0;
            Indigent_ssn = "";
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
        public OpenRecordPoorViewModel(UserControl CP)
        {
            CurrentPage = CP;

            RDate = DateTime.Now;
            RStatus = 0;

            AddRecordPoorDatabaesCommand = new DelegateCommand(AddRecordPoorDatabaesExecute, AddRecordPoorDatabaesCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion
    }
}
