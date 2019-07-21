using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using AL_Zakat_Fund_System.Views;
using AL_Zakat_Fund_System.Models;

namespace AL_Zakat_Fund_System.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        #region private Member

        private Window mWindow;
        private object _Page;

        private OpenAccountPoor PageOAP = new OpenAccountPoor();
        private OpenRecordPoor PageORP = new OpenRecordPoor();
        private AddNewZakat PageANZ = new AddNewZakat();

        #endregion

        #region public properties
        public object Page
        {
            get { return _Page; }
            set { SetProperty(ref _Page, value); }
        }
        #endregion

        #region Delegate Command
        public DelegateCommand Command1 { get; set; }
        public DelegateCommand Command2 { get; set; }
        public DelegateCommand Command3 { get; set; }
        public DelegateCommand Command4 { get; set; }
        public DelegateCommand Command5 { get; set; }

        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ContactStatusCommand { get; set; }
        #endregion

        #region Execute and CanExecute Functions

        #region functions file meun
        private void LogOut()
        {
            loginWindow LWindow = new loginWindow();
            @Properties.Settings.Default.EmpName = "";
            @Properties.Settings.Default.EmPassword = "";
            @Properties.Settings.Default.EmpPriv = 0;
            mWindow.Close();
            LWindow.ShowDialog();
        }
        private void ContactStatus()
        {
            if(DBConnection.OpenConnection())
            {
                MessageBox.Show("لا يوجد مشاكل في الاتصال بالخادم", "", MessageBoxButton.OK, MessageBoxImage.None,
                                MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DBConnection.CloseConnection();
            }

        }
        #endregion

        #region functions change content of pages
        private void Execute1()
        {
            Page = PageOAP;
        }
        private void Execute2()
        {
            Page = PageORP;
        }
        #endregion

        #endregion

        #region Construct
        /// <summary>
        /// Default Construct
        /// </summary>
        /// <param name="window"></param>
        public MainWindowViewModel(Window window)
        {
            mWindow = window;
            Page = PageANZ;

            Command1 = new DelegateCommand(Execute1);
            Command2 = new DelegateCommand(Execute2);
            LogoutCommand = new DelegateCommand(LogOut);
            ContactStatusCommand = new DelegateCommand(ContactStatus);
        }
        #endregion
    }
}
