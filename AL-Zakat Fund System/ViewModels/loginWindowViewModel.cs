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
        private void loginExecute()
        {
            //you have not been successfully logged in
            if (false) return;
            // Sign in Successfully
            else
            {
                MainWindow mainWindow = new MainWindow();
                @Properties.Settings.Default.EmpName = UserName;
                @Properties.Settings.Default.EmPassword = Password;
                @Properties.Settings.Default.EmpPriv = 1;
                mWindow.Close();
                mainWindow.ShowDialog();
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
