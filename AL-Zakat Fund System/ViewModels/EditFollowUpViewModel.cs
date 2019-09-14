using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AL_Zakat_Fund_System.Models;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace AL_Zakat_Fund_System.ViewModels
{
    class EditFollowUpViewModel : Follow_up
    {
        #region private Member

        Window CurrentWindow;
        private string DecisionNO2;


        private Employee _employee;
        private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();

        #endregion

        #region private Function

        #region Get Follow Up
        private void GetFollowUp()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayFollowUP3";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@DecisionNO"].Value = long.Parse(DecisionNO);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();
                DecisionNO2 = DBConnection.reader.GetInt64(0).ToString();
                ReceivedDate = DBConnection.reader.GetDateTime(1);
                if (DBConnection.reader.IsDBNull(2)) { VisitDate = null; }
                else { VisitDate = DBConnection.reader.GetDateTime(2); }
                if (DBConnection.reader.IsDBNull(3)) { DeliverDate = null; }
                else { DeliverDate = DBConnection.reader.GetDateTime(3); }
                
                Distance = DBConnection.reader.GetByte(4);
                FStatus = DBConnection.reader.GetByte(5);
                Scribe_ssn = DBConnection.reader.GetInt64(6);
                Observer_ssn = DBConnection.reader.GetInt64(7).ToString();
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

        #region Get Observer
        private void GetObserver()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_getEMPLOYEE";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;


            //int succ = 0;
            try
            {
                DBConnection.OpenConnection();
                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                // succ = 1 Success or succ = 0 fail or succ = 2 not found
                //succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                Employee TO;
                employees.Clear();

                while (DBConnection.reader.Read())
                {
                    TO = new Employee();
                    TO.Ssn = DBConnection.reader.GetInt64(0);
                    TO.FullName = DBConnection.reader.GetString(2);

                    employees.Add(TO);
                }

                employee = employees.Where(item => item.Ssn == long.Parse(Observer_ssn)).FirstOrDefault();//default select
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا في جلب البيانات المتابعين" + Environment.NewLine + "الخطا : " + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
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

        public Employee employee
        {
            get { return _employee; }
            set { SetProperty(ref _employee, value); }
        }
        public ObservableCollection<Employee> employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }

        #endregion

        #region Delegate Command
        public DelegateCommand UpdateDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        #endregion

        #region Execute and CanExecute Functions

        #region update Follow Up
        private void updateDatabaseExecute()
        {
            int succ = 0;

            if(FStatus == 2 && DeliverDate == null)
            {
                DeliverDate = DateTime.Now;
            }

            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_updateFollowUP1";
                
                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO2", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@ReceivedDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@VisitDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@DeliverDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Distance", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@FStatus", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Observer_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Scribe_ssn", SqlDbType.BigInt));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion

                #region set value in parameters 
                DBConnection.cmd.Parameters["@DecisionNO2"].Value = long.Parse(DecisionNO2);
                DBConnection.cmd.Parameters["@DecisionNO"].Value = long.Parse(DecisionNO);
                DBConnection.cmd.Parameters["@ReceivedDate"].Value = ReceivedDate;
                if (VisitDate == null)
                { DBConnection.cmd.Parameters["@VisitDate"].Value = DBNull.Value; }
                else
                { DBConnection.cmd.Parameters["@VisitDate"].Value = VisitDate; }
                if (DeliverDate == null)
                { DBConnection.cmd.Parameters["@DeliverDate"].Value = DBNull.Value; }
                else
                { DBConnection.cmd.Parameters["@DeliverDate"].Value = DeliverDate; }
                DBConnection.cmd.Parameters["@Distance"].Value = Distance;
                DBConnection.cmd.Parameters["@FStatus"].Value = FStatus;
                DBConnection.cmd.Parameters["@Observer_ssn"].Value = employee.Ssn;
                DBConnection.cmd.Parameters["@Scribe_ssn"].Value = Scribe_ssn;

                

                #endregion


                DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                DBConnection.cmd.ExecuteNonQuery();

                succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                #region  message box
                // It Was Stored in Database
                if (succ == 1)
                {
                    MessageBox.Show("تم حفظ التحديث بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // FOLLOW_UP is not found
                else if (succ == 2)
                {
                    MessageBox.Show("المتابعة غير موجودة", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // Ssn is not found
                else if (succ == 3)
                {
                    MessageBox.Show("المتابع غير موجودة", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // It is not Stored in Database
                else
                {
                    MessageBox.Show("لم يتم حفظ التحديث الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                #endregion
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
        public EditFollowUpViewModel(Window CW, string DN_)
        {
            CurrentWindow = CW;
            DecisionNO = DN_;

            
            GetFollowUp();// ues DecisionNO
            GetObserver();//use Observer_ssn form GetFollowUp

            UpdateDatabaseCommand = new DelegateCommand(updateDatabaseExecute, updateDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);

        }
        #endregion
    }
}
