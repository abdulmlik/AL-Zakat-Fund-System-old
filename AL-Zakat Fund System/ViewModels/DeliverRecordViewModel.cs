using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using AL_Zakat_Fund_System.Views.UserControlBackground;
using Prism.Commands;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class DeliverRecordViewModel : Follow_up
    {
        #region private Member
        private UserControl CurrentPage;
        private MainWindowViewModel mainWindowVM;
        #endregion

        #region public properties

        #endregion

        #region Delegate Command

        public DelegateCommand DeliverRecordDatabaseCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region save Deliver Record
        private void DeliverRecordDatabaseExecute()
        {
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_insertFollowUP";


                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@LastConnection", SqlDbType.DateTime));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Notice", SqlDbType.NText));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Comment", SqlDbType.NText));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@ReceivedDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@VisitDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@DeliverDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Distance", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@FStatus", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Scribe_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Observer_ssn", SqlDbType.BigInt));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion

                #region set value in parameters 
                DBConnection.cmd.Parameters["@DecisionNO"].Value = long.Parse(DecisionNO);
                DBConnection.cmd.Parameters["@LastConnection"].Value = DBNull.Value;
                DBConnection.cmd.Parameters["@Notice"].Value = DBNull.Value;
                DBConnection.cmd.Parameters["@Comment"].Value = DBNull.Value;
                DBConnection.cmd.Parameters["@ReceivedDate"].Value = ReceivedDate;
                DBConnection.cmd.Parameters["@VisitDate"].Value = DBNull.Value;
                DBConnection.cmd.Parameters["@DeliverDate"].Value = DBNull.Value;

                DBConnection.cmd.Parameters["@Distance"].Value = Distance;
                DBConnection.cmd.Parameters["@FStatus"].Value = 0;

                DBConnection.cmd.Parameters["@Scribe_ssn"].Value = Properties.Settings.Default.EmpNo;
                DBConnection.cmd.Parameters["@Observer_ssn"].Value = long.Parse(Observer_ssn);

               

                #endregion

                DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                DBConnection.cmd.ExecuteNonQuery();

                succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                #region messge box
                // It Was Stored in Database
                if (succ == 1)
                {
                    MessageBox.Show("تم تحويل المحضر للمتابعة بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                //record is not exist
                else if (succ == 2)
                {
                    MessageBox.Show("رقم المحضر غير موجود", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // follow up Already exist
                else if (succ == 3)
                {
                    MessageBox.Show("المحظر حول للمتابعة بالفعل", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // EMPLOYEE is not exist
                else if (succ == 4)
                {
                    MessageBox.Show("رقم المتابع غير موجود", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // It is not Stored in Database
                else
                {
                    MessageBox.Show("لم يتم  تحويل المحضر للمتابعة الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("لم يتم  تحويل المحضر للمتابعة الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + "الخطأ : " + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

        }
        private bool DeliverRecordDatabaseCanExecute()
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
            ReceivedDate = DateTime.Now;
            Distance = 0;
            Observer_ssn = "";
            DecisionNO = "";
        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            mainWindowVM.ZeroThickness();
            mainWindowVM.Page = new mainScribe();// chang page
            CurrentPage.Content = null;// delete page
        }
        #endregion

        #endregion

        #region Construct
        public DeliverRecordViewModel(UserControl CP, MainWindowViewModel mainWindowVM_)
        {
            CurrentPage = CP;
            mainWindowVM = mainWindowVM_;

            ReceivedDate = DateTime.Now;
            Distance = 0;

            DeliverRecordDatabaseCommand = new DelegateCommand(DeliverRecordDatabaseExecute, DeliverRecordDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion
    }
}
