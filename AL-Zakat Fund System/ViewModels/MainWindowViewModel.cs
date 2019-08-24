using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using AL_Zakat_Fund_System.Views;
using AL_Zakat_Fund_System.Models;
using AL_Zakat_Fund_System.Views.UserControlBackground;

namespace AL_Zakat_Fund_System.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        #region private Member

        private string _EmpName;
        
        private Window mWindow;
        private object _Page;

        #region Button SideBar ,When Click
        private Thickness ZeroBorderThickness = new Thickness(0);
        private Thickness LeftBorderThickness = new Thickness(0,0,10,0);
        private Thickness _OpenAccountBorderThickness;
        private Thickness _ViewAccountBorderThickness;
        private Thickness _OpenRecordBorderThickness;
        private Thickness _ViewRecordBorderThickness;
        private Thickness _DeliverRecordBorderThickness;
        private Thickness _ViewFollowUpBorderThickness;
        private Thickness _AddNewZakatBorderThickness;
        private Thickness _ViewZakatBorderThickness;
        private Thickness _CreateAuthorizeExpenditureBorderThickness;
        private Thickness _ViewAuthorizeExpenditureBorderThickness;
        private Thickness _ViewFollowUpObserverBorderThickness;
        private Thickness _ViewAlertBorderThickness;
        #endregion

        #region User Priv
        private Visibility _Collector;
        private Visibility _Courier;
        private Visibility _Scribe;
        private Visibility _Observer;
        private Visibility _Supervisor;
        #endregion

        #region reason not use this method because they causes slow startup

        //private OpenAccountPoor PageOAP = new OpenAccountPoor();
        //private OpenRecordPoor PageORP = new OpenRecordPoor();
        //private AddNewZakat PageANZ = new AddNewZakat();
        //private CreateExchangePermission PageCEP = new CreateExchangePermission();
        //private DeliverRecord PageDR = new DeliverRecord();

        //private ViewAccountData PageVAD = new ViewAccountData();
        //private ViewExchangePermissionData PageVEPD = new ViewExchangePermissionData();
        //private ViewFollowUpData PageVFD = new ViewFollowUpData();
        //private ViewFollowUpDataObserver PageVFDO = new ViewFollowUpDataObserver();
        //private ViewRecordData PageVRD = new ViewRecordData();
        //private ViewZakatData PageVZD = new ViewZakatData();

        #endregion

        #region Page Content
        private OpenAccountPoor PageOAP;
        private OpenRecordPoor PageORP;
        private AddNewZakat PageANZ;
        private CreateExchangePermission PageCEP;
        private DeliverRecord PageDR;

        private ViewAccountData PageVAD;
        private ViewExchangePermissionData PageVEPD;
        private ViewFollowUpData PageVFD;
        private ViewFollowUpDataObserver PageVFDO;
        private ViewRecordData PageVRD;
        private ViewZakatData PageVZD;

        #endregion

        #endregion

        #region private function

        private void GetPriv(int priv)
        {
            switch (priv)
            {
                case 1:
                    Page = new mainCollector();// main page for user
                    Collector = Visibility.Visible;
                    Courier = Scribe = Observer = Visibility.Collapsed;
                    break;
                case 2:
                    Page = new mainCourier();
                    Courier = Visibility.Visible;
                    Collector = Scribe = Observer = Visibility.Collapsed;
                    break;
                case 3:
                    Page = new mainScribe();
                    Scribe = Visibility.Visible;
                    Courier = Collector = Observer = Visibility.Collapsed;
                    break;
                case 4:
                    Page = new mainObserver();
                    Observer = Visibility.Visible;
                    Courier = Scribe = Collector = Visibility.Collapsed;
                    break;
            }

        }

        public void ZeroThickness()
        {
            OpenAccountBorderThickness = ZeroBorderThickness;
            ViewAccountBorderThickness = ZeroBorderThickness;
            OpenRecordBorderThickness = ZeroBorderThickness;
            ViewRecordBorderThickness = ZeroBorderThickness;
            DeliverRecordBorderThickness = ZeroBorderThickness;
            ViewFollowUpBorderThickness = ZeroBorderThickness;
            AddNewZakatBorderThickness = ZeroBorderThickness;
            ViewZakatBorderThickness = ZeroBorderThickness;
            CreateAuthorizeExpenditureBorderThickness = ZeroBorderThickness;
            ViewAuthorizeExpenditureBorderThickness = ZeroBorderThickness;
            ViewFollowUpObserverBorderThickness = ZeroBorderThickness;
            ViewAlertBorderThickness = ZeroBorderThickness;
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            // Handle closing logic, set e.Cancel as needed
            try
            {
                //Properties.Settings.Default.EmpName = "";
                //Properties.Settings.Default.EmPassword = "";
                //Properties.Settings.Default.EmpNo = 0;
                //Properties.Settings.Default.EmpPriv = 0;
                //Properties.Settings.Default.Save();
            }
            catch
            {
                //e.Cancel = true;
            }
            finally
            {
            }
        }

        #endregion

        #region public properties
        public string EmpName
        {
            get { return _EmpName; }
            set { SetProperty(ref _EmpName, value); }
        }
        public object Page
        {
            get { return _Page; }
            set { SetProperty(ref _Page, value); }
        }


        #region Button SideBar ,When Click
        public Thickness OpenAccountBorderThickness
        {
            get { return _OpenAccountBorderThickness; }
            set { SetProperty(ref _OpenAccountBorderThickness, value); }
        }
        public Thickness ViewAccountBorderThickness
        {
            get { return _ViewAccountBorderThickness; }
            set { SetProperty(ref _ViewAccountBorderThickness, value); }
        }
        public Thickness OpenRecordBorderThickness
        {
            get { return _OpenRecordBorderThickness; }
            set { SetProperty(ref _OpenRecordBorderThickness, value); }
        }
        public Thickness ViewRecordBorderThickness
        {
            get { return _ViewRecordBorderThickness; }
            set { SetProperty(ref _ViewRecordBorderThickness, value); }
        }
        public Thickness DeliverRecordBorderThickness
        {
            get { return _DeliverRecordBorderThickness; }
            set { SetProperty(ref _DeliverRecordBorderThickness, value); }
        }
        public Thickness ViewFollowUpBorderThickness
        {
            get { return _ViewFollowUpBorderThickness; }
            set { SetProperty(ref _ViewFollowUpBorderThickness, value); }
        }
        public Thickness AddNewZakatBorderThickness
        {
            get { return _AddNewZakatBorderThickness; }
            set { SetProperty(ref _AddNewZakatBorderThickness, value); }
        }
        public Thickness ViewZakatBorderThickness
        {
            get { return _ViewZakatBorderThickness; }
            set { SetProperty(ref _ViewZakatBorderThickness, value); }
        }
        public Thickness CreateAuthorizeExpenditureBorderThickness
        {
            get { return _CreateAuthorizeExpenditureBorderThickness; }
            set { SetProperty(ref _CreateAuthorizeExpenditureBorderThickness, value); }
        }
        public Thickness ViewAuthorizeExpenditureBorderThickness
        {
            get { return _ViewAuthorizeExpenditureBorderThickness; }
            set { SetProperty(ref _ViewAuthorizeExpenditureBorderThickness, value); }
        }
        public Thickness ViewFollowUpObserverBorderThickness
        {
            get { return _ViewFollowUpObserverBorderThickness; }
            set { SetProperty(ref _ViewFollowUpObserverBorderThickness, value); }
        }
        public Thickness ViewAlertBorderThickness
        {
            get { return _ViewAlertBorderThickness; }
            set { SetProperty(ref _ViewAlertBorderThickness, value); }
        }
        #endregion

        #region User Priv
        public Visibility Collector
        {
            get { return _Collector; }
            set { SetProperty(ref _Collector, value); }
        }
        public Visibility Courier
        {
            get { return _Courier; }
            set { SetProperty(ref _Courier, value); }
        }
        public Visibility Scribe
        {
            get { return _Scribe; }
            set { SetProperty(ref _Scribe, value); }
        }
        public Visibility Observer
        {
            get { return _Observer; }
            set { SetProperty(ref _Observer, value); }
        }
        public Visibility Supervisor
        {
            get { return _Supervisor; }
            set { SetProperty(ref _Supervisor, value); }
        }
        #endregion

        #endregion

        #region Delegate Command
        public DelegateCommand PageOpenAccountPoorCommand { get; set; }
        public DelegateCommand PageOpenRecordPoorCommand { get; set; }
        public DelegateCommand PageAddNewZakatCommand { get; set; }
        public DelegateCommand PageCreateExchangePermissionCommand { get; set; }
        public DelegateCommand PageDeliverRecordCommand { get; set; }

        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ContactStatusCommand { get; set; }
        public DelegateCommand<string> GetPrivCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand PageViewAccountDataCommand { get; set; }
        public DelegateCommand PageViewExchangePermissionDataCommand { get; set; }
        public DelegateCommand PageViewFollowUpDataCommand { get; set; }
        public DelegateCommand PageViewFollowUpDataObserverCommand { get; set; }
        public DelegateCommand PageViewRecordDataCommand { get; set; }
        public DelegateCommand PageViewZakatDataCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region functions file meun
        private void LogOut()
        {
            //Properties.Settings.Default.EmpName = "";
            //Properties.Settings.Default.EmPassword = "";
            //Properties.Settings.Default.EmpNo = 0;
            //Properties.Settings.Default.EmpPriv = 0;
            //Properties.Settings.Default.Save();

            loginWindow LWindow = new loginWindow();
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

        void GetPrivExecute(string sender)
        {
            Page = null;
            ZeroThickness();
            GetPriv(int.Parse(sender));
        }
        void CloseExecute()
        {
            mWindow.Close();
        }
        #endregion

        #region functions change content of pages
        private void PageOpenAccountPoorExecute()
        {
            ZeroThickness();
            OpenAccountBorderThickness = LeftBorderThickness;
            //true if first opening program or when you press a Close
            if (PageOAP == null || PageOAP.Content == null) { PageOAP = new OpenAccountPoor(); }
            PageOAP.DataContext = new OpenAccountPoorViewModel(PageOAP, this);
            Page = PageOAP;
        }
        private void PageOpenRecordPoorExecute()
        {
            ZeroThickness();
            OpenRecordBorderThickness = LeftBorderThickness;
            if (PageORP == null || PageORP.Content == null) { PageORP = new OpenRecordPoor(); }
            PageORP.DataContext = new OpenRecordPoorViewModel(PageORP, this);
            Page = PageORP;
        }
        private void PageAddNewZakatExecute()
        {
            ZeroThickness();
            AddNewZakatBorderThickness = LeftBorderThickness;
            if (PageANZ == null || PageANZ.Content == null) { PageANZ = new AddNewZakat(); }
            PageANZ.DataContext = new AddNewZakatViewModel(PageANZ, this);
            Page = PageANZ;
        }
        private void PageCreateExchangePermissionExecute()
        {
            ZeroThickness();
            CreateAuthorizeExpenditureBorderThickness = LeftBorderThickness;
            if (PageCEP == null || PageCEP.Content == null) { PageCEP = new CreateExchangePermission(); }
            PageCEP.DataContext = new CreateExchangePermissionViewModel(PageCEP, this);
            Page = PageCEP;
        }
        private void PageDeliverRecordExecute()
        {
            ZeroThickness();
            DeliverRecordBorderThickness = LeftBorderThickness;
            if (PageDR == null || PageDR.Content == null) { PageDR = new DeliverRecord(); }
            PageDR.DataContext = new DeliverRecordViewModel(PageDR, this);
            Page = PageDR;
        }
        private void PageViewAccountDataExecute()
        {
            ZeroThickness();
            ViewAccountBorderThickness = LeftBorderThickness;
            PageVAD = new ViewAccountData();
            PageVAD.DataContext = new ViewAccountDataViewModel(PageVAD, mWindow);
            Page = PageVAD;
        }
        private void PageViewExchangePermissionDataExecute()
        {
            ZeroThickness();
            ViewAuthorizeExpenditureBorderThickness = LeftBorderThickness;
            PageVEPD = new ViewExchangePermissionData();
            PageVEPD.DataContext = new ViewExchangePermissionDataViewModel(PageVEPD, mWindow);
            Page = PageVEPD;
        }
        private void PageViewFollowUpDataExecute()
        {
            ZeroThickness();
            ViewFollowUpBorderThickness = LeftBorderThickness;
            PageVFD = new ViewFollowUpData();
            PageVFD.DataContext = new ViewFollowUpDataViewModel(PageVFD, mWindow);
            Page = PageVFD;
        }
        private void PageViewFollowUpDataObserverExecute()
        {
            ZeroThickness();
            ViewFollowUpObserverBorderThickness = LeftBorderThickness;
            PageVFDO = new ViewFollowUpDataObserver();
            PageVFDO.DataContext = new ViewFollowUpDataObserverViewModel(PageVFDO, mWindow);
            Page = PageVFDO;
        }
        private void PageViewRecordDataExecute()
        {
            ZeroThickness();
            ViewRecordBorderThickness = LeftBorderThickness;
            PageVRD = new ViewRecordData();
            PageVRD.DataContext = new ViewRecordDataViewModel(PageVRD, mWindow);
            Page = PageVRD;
        }
        private void PageViewZakatDataExecute()
        {
            ZeroThickness();
            ViewZakatBorderThickness = LeftBorderThickness;
            PageVZD = new ViewZakatData();
            PageVZD.DataContext = new ViewZakatDataViewModel(PageVZD, mWindow);
            Page = PageVZD;
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

            // Name Employee
            EmpName = Properties.Settings.Default.EmpName;

            if (Properties.Settings.Default.EmpPriv == 10)
            {
                GetPriv(3);
            }
            else
            {
                GetPriv(Properties.Settings.Default.EmpPriv);
                Supervisor = Visibility.Collapsed;
            }

            // When close window call OnWindowClosing function
            mWindow.Closing += OnWindowClosing;

            

            //Create Commands
            PageOpenAccountPoorCommand = new DelegateCommand(PageOpenAccountPoorExecute);
            PageOpenRecordPoorCommand = new DelegateCommand(PageOpenRecordPoorExecute);
            PageAddNewZakatCommand = new DelegateCommand(PageAddNewZakatExecute);
            PageCreateExchangePermissionCommand = new DelegateCommand(PageCreateExchangePermissionExecute);
            PageDeliverRecordCommand = new DelegateCommand(PageDeliverRecordExecute);

            PageViewAccountDataCommand = new DelegateCommand(PageViewAccountDataExecute);
            PageViewExchangePermissionDataCommand = new DelegateCommand(PageViewExchangePermissionDataExecute);
            PageViewFollowUpDataCommand = new DelegateCommand(PageViewFollowUpDataExecute);
            PageViewFollowUpDataObserverCommand = new DelegateCommand(PageViewFollowUpDataObserverExecute);
            PageViewRecordDataCommand = new DelegateCommand(PageViewRecordDataExecute);
            PageViewZakatDataCommand = new DelegateCommand(PageViewZakatDataExecute);

            LogoutCommand = new DelegateCommand(LogOut);
            ContactStatusCommand = new DelegateCommand(ContactStatus);
            GetPrivCommand = new DelegateCommand<string>(GetPrivExecute);
            CloseCommand = new DelegateCommand(CloseExecute);
        }
        #endregion
    }
}
