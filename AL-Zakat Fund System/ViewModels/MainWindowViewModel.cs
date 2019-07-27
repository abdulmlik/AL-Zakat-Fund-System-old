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

        #region reason not use this method because they consume a lot of memory

        //private OpenAccountPoor PageOAP = new OpenAccountPoor();
        //private OpenRecordPoor PageORP = new OpenRecordPoor();
        //private AddNewZakat PageANZ = new AddNewZakat();
        //private CreateExchangePermission PageCEP = new CreateExchangePermission();
        //private DeliverRecord PageDR = new DeliverRecord();

        #endregion

        private OpenAccountPoor PageOAP;
        private OpenRecordPoor PageORP;
        private AddNewZakat PageANZ;
        private CreateExchangePermission PageCEP;
        private DeliverRecord PageDR;

        //private EditAccount PageEA;
        //private EditRecord PageER;
        //private ModifyZakat PageMZ;
        //private ModifyExchangePermission PageMEP;
        //private EditFollowUp PageEFUP;

        #endregion

        #region public properties
        public object Page
        {
            get { return _Page; }
            set { SetProperty(ref _Page, value); }
        }
        #endregion

        #region Delegate Command
        public DelegateCommand PageOpenAccountPoorCommand { get; set; }
        public DelegateCommand PageOpenRecordPoorCommand { get; set; }
        public DelegateCommand PageAddNewZakatCommand { get; set; }
        public DelegateCommand PageCommand { get; set; }
        public DelegateCommand PageCommand5 { get; set; }

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
        private void PageOpenAccountPoorExecute()
        {
            Page = PageOAP;
        }
        private void PageOpenRecordPoorExecute()
        {
            Page = PageORP;
        }
        private void PageAddNewZakatExecute()
        {
            Page = PageANZ;
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
            PageOAP = new OpenAccountPoor();
            //PageORP = new OpenRecordPoor();
            //PageANZ = new AddNewZakat();
            //PageCEP = new CreateExchangePermission();
            //PageDR = new DeliverRecord();

            //PageER;
            //PageMZ;
            //PageMEP;
            //PageEFUP;
            
            //PageOAP = new OpenAccountPoor();
            Page = PageOAP;
            PageOpenAccountPoorCommand = new DelegateCommand(PageOpenAccountPoorExecute);
            PageOpenRecordPoorCommand = new DelegateCommand(PageOpenRecordPoorExecute);
            PageAddNewZakatCommand = new DelegateCommand(PageAddNewZakatExecute);
            LogoutCommand = new DelegateCommand(LogOut);
            ContactStatusCommand = new DelegateCommand(ContactStatus);
        }
        #endregion
    }
}
