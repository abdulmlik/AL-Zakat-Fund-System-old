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

        private string _EmpName;

        private Window mWindow;
        private object _Page;

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

        //private EditAccount PageEA;
        //private EditRecord PageER;
        //private ModifyZakat PageMZ;
        //private ModifyExchangePermission PageMEP;
        //private EditFollowUp PageEFUP;

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
        #endregion

        #region Delegate Command
        public DelegateCommand PageOpenAccountPoorCommand { get; set; }
        public DelegateCommand PageOpenRecordPoorCommand { get; set; }
        public DelegateCommand PageAddNewZakatCommand { get; set; }
        public DelegateCommand PageCreateExchangePermissionCommand { get; set; }
        public DelegateCommand PageDeliverRecordCommand { get; set; }

        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ContactStatusCommand { get; set; }

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
            Properties.Settings.Default.EmpName = "";
            Properties.Settings.Default.EmPassword = "";
            Properties.Settings.Default.EmpNo = 0;
            Properties.Settings.Default.EmpPriv = 0;
            Properties.Settings.Default.Save();

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
        #endregion

        #region functions change content of pages
        private void PageOpenAccountPoorExecute()
        {
            //true if first opening program or when you press a Close
            if (PageOAP == null || PageOAP.Content == null) { PageOAP = new OpenAccountPoor(); }
            Page = PageOAP;
        }
        private void PageOpenRecordPoorExecute()
        {
            if (PageORP == null || PageORP.Content == null) { PageORP = new OpenRecordPoor(); }
            Page = PageORP;
        }
        private void PageAddNewZakatExecute()
        {
            if (PageANZ == null || PageANZ.Content == null) { PageANZ = new AddNewZakat(); }
            Page = PageANZ;
        }
        private void PageCreateExchangePermissionExecute()
        {
            if (PageCEP == null || PageCEP.Content == null) { PageCEP = new CreateExchangePermission(); }
            Page = PageCEP;
        }
        private void PageDeliverRecordExecute()
        {
            if (PageDR == null || PageDR.Content == null) { PageDR = new DeliverRecord(); }
            Page = PageDR;
        }
        private void PageViewAccountDataExecute()
        {
            if (PageVAD == null || PageVAD.Content == null) { PageVAD = new ViewAccountData(); }
            Page = PageVAD;
        }
        private void PageViewExchangePermissionDataExecute()
        {
            if (PageVEPD == null || PageVEPD.Content == null) { PageVEPD = new ViewExchangePermissionData(); }
            Page = PageVEPD;
        }
        private void PageViewFollowUpDataExecute()
        {
            if (PageVFD == null || PageVFD.Content == null) { PageVFD = new ViewFollowUpData(); }
            Page = PageVFD;
        }
        private void PageViewFollowUpDataObserverExecute()
        {
            if (PageVFDO == null || PageVFDO.Content == null) { PageVFDO = new ViewFollowUpDataObserver(); }
            Page = PageVFDO;
        }
        private void PageViewRecordDataExecute()
        {
            if (PageVRD == null || PageVRD.Content == null) { PageVRD = new ViewRecordData(); }
            Page = PageVRD;
        }
        private void PageViewZakatDataExecute()
        {
            if (PageVZD == null || PageVZD.Content == null) { PageVZD = new ViewZakatData(); }
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

            EmpName = Properties.Settings.Default.EmpName;
            
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
        }
        #endregion
    }
}
