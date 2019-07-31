using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using AL_Zakat_Fund_System.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class loginWindowViewModel : BindableBase
    {
        #region private Member

        private Window mWindow;
        private string _UserName;
        private string _Password;
        private bool IsEnabled = true;

        #endregion

        #region public properties
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        #endregion

        #region Delegate Command
        public DelegateCommand loginCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region login function
        private void loginExecute()
        {
            int priv = 0;
            bool succ = false;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_login";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@EmpName", SqlDbType.VarChar, 30));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 30));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@EmpPriv", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit));
                DBConnection.cmd.Parameters["@EmpName"].Value = UserName;
                DBConnection.cmd.Parameters["@pass"].Value = Password;
                DBConnection.cmd.Parameters["@EmpPriv"].Direction = ParameterDirection.Output;
                DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                DBConnection.cmd.ExecuteNonQuery();

                succ = (bool)DBConnection.cmd.Parameters["@Success"].Value;
                priv = (succ) ? (int)DBConnection.cmd.Parameters["@EmpPriv"].Value : 0;


                //you have not been successfully logged in
                if (succ)
                {
                    Properties.Settings.Default.EmpName = UserName;
                    Properties.Settings.Default.EmPassword = Password;
                    Properties.Settings.Default.EmpNo = 0;
                    Properties.Settings.Default.EmpPriv = priv;
                    Properties.Settings.Default.Save();

                    //Create the MainWindow should be under Settings
                    MainWindow mainWindow = new MainWindow();
                    mWindow.Close();
                    mainWindow.ShowDialog();
                }
                // Sign in Successfully
                else
                {
                    MessageBox.Show("اسم المستخدم او كلمة السر غير صحيحة", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
           

}
        private bool loginCanExecute()
        {
            if ( string.IsNullOrWhiteSpace(UserName) || string.IsNullOrEmpty(UserName)
                || string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(Password) )
            { IsEnabled = false; }
            else
            {
                IsEnabled = true;
            }
            return IsEnabled;
        }
        #endregion

        #endregion

        #region Construct
        /// <summary>
        /// Default Construct
        /// </summary>
        /// <param name="window"></param>
        public loginWindowViewModel(Window window)
        {
            mWindow = window;

            loginCommand = new DelegateCommand(loginExecute, loginCanExecute).ObservesProperty(() => UserName).ObservesProperty(() => Password);
        }
        #endregion

    }
}
