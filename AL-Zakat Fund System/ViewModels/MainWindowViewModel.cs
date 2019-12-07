using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using Microsoft.Win32;
using AL_Zakat_Fund_System.Views;
using AL_Zakat_Fund_System.Models;
using AL_Zakat_Fund_System.Views.UserControlBackground;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Input;

namespace AL_Zakat_Fund_System.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        #region private Member

        private string _EmpName;

        private Window mWindow;
        private object _Page;

        private Cursor _Cursor;

        #region Button SideBar ,When Click
        private Thickness ZeroBorderThickness = new Thickness(0);
        private Thickness LeftBorderThickness = new Thickness(0, 0, 10, 0);
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
        private Thickness _TransferZakatBorderThickness;
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

        #region add pages 
        private OpenAccountPoor PageOAP;
        private OpenRecordPoor PageORP;
        private AddNewZakat PageANZ;
        private CreateExchangePermission PageCEP;
        private DeliverRecord PageDR;
        #endregion

        #region view pages control
        private ViewAccountData PageVAD;
        private ViewExchangePermissionData PageVEPD;
        private ViewFollowUpData PageVFD;
        private ViewFollowUpDataObserver PageVFDO;
        private ViewRecordData PageVRD;
        private ViewZakatData PageVZD;

        private TransferZakat PageTZD;
        #endregion

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
            TransferZakatBorderThickness = ZeroBorderThickness;
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            // Handle closing logic, set e.Cancel as needed
            try
            {
                Properties.Settings.Default.EmpName = "";
                Properties.Settings.Default.EmPassword = "";
                Properties.Settings.Default.EmpNo = 0;
                Properties.Settings.Default.EmpPriv = 0;
                Properties.Settings.Default.Save();
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
        public Cursor Cursor
        {
            get { return _Cursor; }
            set { SetProperty(ref _Cursor, value); }
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
        public Thickness TransferZakatBorderThickness
        {
            get { return _TransferZakatBorderThickness; }
            set { SetProperty(ref _TransferZakatBorderThickness, value); }
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

        #region add page Command
        public DelegateCommand PageOpenAccountPoorCommand { get; set; }
        public DelegateCommand PageOpenRecordPoorCommand { get; set; }
        public DelegateCommand PageAddNewZakatCommand { get; set; }
        public DelegateCommand PageCreateExchangePermissionCommand { get; set; }
        public DelegateCommand PageDeliverRecordCommand { get; set; }
        #endregion

        #region file meun Command
        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ContactStatusCommand { get; set; }
        public DelegateCommand<string> GetPrivCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand DatabaseBackupCommand { get; set; }
        public DelegateCommand DatabaseRestoreCommand { get; set; }
        #endregion

        #region view page Command
        public DelegateCommand PageTransferZakatDataCommand { get; set; }

        public DelegateCommand PageViewAccountDataCommand { get; set; }
        public DelegateCommand PageViewExchangePermissionDataCommand { get; set; }
        public DelegateCommand PageViewFollowUpDataCommand { get; set; }
        public DelegateCommand PageViewFollowUpDataObserverCommand { get; set; }
        public DelegateCommand PageViewRecordDataCommand { get; set; }
        public DelegateCommand PageViewZakatDataCommand { get; set; }
        #endregion

        #region Report Window Command

        #region Report Zakat
        public DelegateCommand ReportZakatCommand { get; set; }
        public DelegateCommand ReportCollectZakatCommand { get; set; }
        public DelegateCommand ReportNumberZakatCommand { get; set; }
        #endregion

        #region Report Expenses
        public DelegateCommand ReportExpensesCommand { get; set; }
        #endregion

        #region Report Social Research
        public DelegateCommand ReportSocialResearchCommand { get; set; }
        #endregion

        #region Report Applicant
        public DelegateCommand ReportApplicantCommand { get; set; }
        #endregion

        #endregion

        #endregion

        #region Execute and CanExecute Functions

        #region functions file meun

        #region LogOut
        private void LogOut()
        {
            Cursor saveCursor = Cursor;
            //Cursor = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;

            Properties.Settings.Default.EmpName = "";
            Properties.Settings.Default.EmPassword = "";
            Properties.Settings.Default.EmpNo = 0;
            Properties.Settings.Default.EmpPriv = 0;
            Properties.Settings.Default.Save();

            loginWindow LWindow = new loginWindow();
            mWindow.Close();

            //Cursor = saveCursor;
            Mouse.OverrideCursor = saveCursor;

            LWindow.ShowDialog();
        }
        #endregion

        #region Contact Status
        private void ContactStatus()
        {
            Cursor saveCursor = Cursor;
            //Cursor = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;

            if (DBConnection.ConnectionStatus())
            {
                MessageBox.Show("لا يوجد مشاكل في الاتصال بالخادم", "", MessageBoxButton.OK, MessageBoxImage.None,
                                MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

            //Cursor = saveCursor;
            Mouse.OverrideCursor = saveCursor;
        }
        #endregion

        #region Get Priv
        private void GetPrivExecute(string sender)
        {
            Page = null;
            ZeroThickness();
            GetPriv(int.Parse(sender));
        }
        #endregion

        #region Close
        private void CloseExecute()
        {
            mWindow.Close();
        }
        #endregion

        #region Database Backup
        private void DatabaseBackupExecute()
        {
            SaveFileDialog FilePath = new SaveFileDialog();
            FilePath.InitialDirectory = @"D:\";
            FilePath.FileName = "ZakatDB_" + DateTime.Now.ToShortDateString().Replace('/', '-') + "_"
                                 + DateTime.Now.ToLongTimeString().Replace(':', '-').Replace("PM", "").Replace("AM", "").Trim();
            FilePath.Filter = "Text Files (*.bak)|*.bak|All Files|*.*";

            bool? result = FilePath.ShowDialog();
            if (result == true)
            {
                Cursor saveCursor = Cursor;
                //Cursor = Cursors.Wait;
                Mouse.OverrideCursor = Cursors.Wait;
                int succ = 0;
                try
                {
                    DBConnection.OpenConnection();

                    DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DBConnection.cmd.CommandText = "sp_Backup";

                    DBConnection.cmd.Parameters.Add(new SqlParameter("@FilePath", SqlDbType.NVarChar,500));
                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                    
                    DBConnection.cmd.Parameters["@FilePath"].Value = FilePath.FileName;

                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();

                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;


                    if (succ == 1)
                    {
                        MessageBox.Show("تم أخد النسخة الإحتياطية بنجاح");
                    }
                    else if (succ == 0)
                    {
                        throw new Exception("مشكلة في تنفيذ الاجراء المخزن الرجاء التأكد من اختيار قرص غير قرص C");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("لم يتم أخد النسخة الإحتياطية " + Environment.NewLine + "الخطا :" + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
                //Cursor = saveCursor;
                Mouse.OverrideCursor = saveCursor;
            }
        }
        private bool DatabaseBackupCanExecute()
        {
            return DBConnection.ConnectionStatus();
        }
        #endregion

        #region Database Restore
        private void DatabaseRestoreExecute()
        {
            OpenFileDialog FilePath = new OpenFileDialog();
            FilePath.InitialDirectory = @"D:\";
            FilePath.Filter = "Text Files (*.bak)|*.bak|All Files|*.*";

            MessageBoxResult result1 = MessageBox.Show("لإسترجاع النسخة الإحتياطية الرجاء التأكد من إغلاق جميع الإتصالات بالسيرفر", "", MessageBoxButton.YesNo, MessageBoxImage.Question
                                                            , MessageBoxResult.No, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result1 == MessageBoxResult.Yes)
            {
                bool? result = FilePath.ShowDialog();
                if (result == true)
                {
                    Cursor saveCursor = Cursor;
                    //Cursor = Cursors.Wait;
                    Mouse.OverrideCursor = Cursors.Wait;

                    int succ = 0;
                    try
                    {
                        DBConnection.OpenConnection();

                        DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                        DBConnection.cmd.CommandText = "sp_Restore";

                        DBConnection.cmd.Parameters.Add(new SqlParameter("@FilePath", SqlDbType.NVarChar, 255));
                        DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

                        DBConnection.cmd.Parameters["@FilePath"].Value = FilePath.FileName;

                        DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                        DBConnection.cmd.ExecuteNonQuery();

                        succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                        if (succ == 1)
                        {
                            MessageBox.Show("تم إسترجاع النسخة الإحتياطية بنجاح");
                        }
                        else if (succ == 0)
                        {
                            throw new Exception("مشكلة في تنفيذ الاجراء المخزن تأكد من إغلاق جميع الإتصالات بالسيرفر");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("لم يتم إسترجاع النسخة الإحتياطية" + Environment.NewLine + "الخطا :" + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    finally
                    {
                        DBConnection.CloseConnection();
                    }
                    //Cursor = saveCursor;
                    Mouse.OverrideCursor = saveCursor;
                }
            }
        }
        private bool DatabaseRestoreCanExecute()
        {
            return DBConnection.ConnectionStatus() && Properties.Settings.Default.EmpPriv == 10;
        }
        #endregion

        #endregion

        #region functions change content of pages
        private void PageOpenAccountPoorExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            OpenAccountBorderThickness = LeftBorderThickness;
            //true if first opening program or when you press a Close
            if (PageOAP == null || PageOAP.Content == null) { PageOAP = new OpenAccountPoor(); }
            PageOAP.DataContext = new OpenAccountPoorViewModel(PageOAP, this);
            Page = PageOAP;

            Cursor = saveCursor;
        }
        private void PageOpenRecordPoorExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            OpenRecordBorderThickness = LeftBorderThickness;
            if (PageORP == null || PageORP.Content == null) { PageORP = new OpenRecordPoor(); }
            PageORP.DataContext = new OpenRecordPoorViewModel(PageORP, this);
            Page = PageORP;

            Cursor = saveCursor;
        }
        private void PageAddNewZakatExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            AddNewZakatBorderThickness = LeftBorderThickness;
            if (PageANZ == null || PageANZ.Content == null) { PageANZ = new AddNewZakat(); }
            PageANZ.DataContext = new AddNewZakatViewModel(PageANZ, this);
            Page = PageANZ;

            Cursor = saveCursor;
        }
        private void PageCreateExchangePermissionExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            CreateAuthorizeExpenditureBorderThickness = LeftBorderThickness;
            if (PageCEP == null || PageCEP.Content == null) { PageCEP = new CreateExchangePermission(); }
            PageCEP.DataContext = new CreateExchangePermissionViewModel(PageCEP, this);
            Page = PageCEP;

            Cursor = saveCursor;
        }
        private void PageDeliverRecordExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            DeliverRecordBorderThickness = LeftBorderThickness;
            if (PageDR == null || PageDR.Content == null) { PageDR = new DeliverRecord(); }
            PageDR.DataContext = new DeliverRecordViewModel(PageDR, this);
            Page = PageDR;

            Cursor = saveCursor;
        }
        private void PageViewAccountDataExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            ViewAccountBorderThickness = LeftBorderThickness;
            PageVAD = new ViewAccountData();
            PageVAD.DataContext = new ViewAccountDataViewModel(PageVAD, mWindow);
            Page = PageVAD;

            Cursor = saveCursor;
        }
        private void PageViewExchangePermissionDataExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            ViewAuthorizeExpenditureBorderThickness = LeftBorderThickness;
            PageVEPD = new ViewExchangePermissionData();
            PageVEPD.DataContext = new ViewExchangePermissionDataViewModel(PageVEPD, mWindow);
            Page = PageVEPD;

            Cursor = saveCursor;
        }
        private void PageViewFollowUpDataExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            ViewFollowUpBorderThickness = LeftBorderThickness;
            PageVFD = new ViewFollowUpData();
            PageVFD.DataContext = new ViewFollowUpDataViewModel(PageVFD, mWindow);
            Page = PageVFD;

            Cursor = saveCursor;
        }
        private void PageViewFollowUpDataObserverExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            ViewFollowUpObserverBorderThickness = LeftBorderThickness;
            PageVFDO = new ViewFollowUpDataObserver();
            PageVFDO.DataContext = new ViewFollowUpDataObserverViewModel(PageVFDO, mWindow);
            Page = PageVFDO;

            Cursor = saveCursor;
        }
        private void PageViewRecordDataExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            ViewRecordBorderThickness = LeftBorderThickness;
            PageVRD = new ViewRecordData();
            PageVRD.DataContext = new ViewRecordDataViewModel(PageVRD, mWindow);
            Page = PageVRD;

            Cursor = saveCursor;
        }
        private void PageViewZakatDataExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            ViewZakatBorderThickness = LeftBorderThickness;
            PageVZD = new ViewZakatData();
            PageVZD.DataContext = new ViewZakatDataViewModel(PageVZD, mWindow);
            Page = PageVZD;

            Cursor = saveCursor;
        }
        private void PageTransferZakatDataExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ZeroThickness();
            TransferZakatBorderThickness = LeftBorderThickness;
            PageTZD = new TransferZakat();
            PageTZD.DataContext = new TransferZakatViewModel(PageTZD, mWindow);
            Page = PageTZD;

            Cursor = saveCursor;
        }

        #endregion

        #region Report Window

        #region Zakat
        private void ReportZakatExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ReportZakat PageRZ = new ReportZakat();
            PageRZ.DataContext = new ReportZakatViewModel(PageRZ);
            PageRZ.Owner = mWindow;
            bool? result = PageRZ.ShowDialog();
            if (result == true)
            { }

            Cursor = saveCursor;
        }
        private void ReportCollectZakatExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ReportCollectZakat PageRCZ = new ReportCollectZakat();
            PageRCZ.DataContext = new ReportCollectZakatViewModel(PageRCZ);
            PageRCZ.Owner = mWindow;
            bool? result = PageRCZ.ShowDialog();
            if (result == true)
            { }

            Cursor = saveCursor;
        }
        private void ReportNumberZakatExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ReportNumberZakat PageRNZ = new ReportNumberZakat();
            PageRNZ.DataContext = new ReportNumberZakatViewModel(PageRNZ);
            PageRNZ.Owner = mWindow;
            bool? result = PageRNZ.ShowDialog();
            if (result == true)
            { }

            Cursor = saveCursor;
        }
        #endregion

        #region Expenses 
        private void ReportExpensesExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ReportExpenses PageRE = new ReportExpenses();
            PageRE.DataContext = new ReportExpensesViewModel(PageRE);
            PageRE.Owner = mWindow;
            bool? result = PageRE.ShowDialog();
            if (result == true)
            { }

            Cursor = saveCursor;
        }
        #endregion

        #region Social Research
        private void ReportSocialResearchExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ReportSocialResearch PageRSR = new ReportSocialResearch();
            PageRSR.DataContext = new ReportSocialResearchViewModel(PageRSR);
            PageRSR.Owner = mWindow;
            bool? result = PageRSR.ShowDialog();
            if (result == true)
            { }

            Cursor = saveCursor;
        }
        #endregion

        #region Applicant
        private void ReportApplicantExecute()
        {
            Cursor saveCursor = Cursor;
            Cursor = Cursors.Wait;

            ReportApplicant PageRA = new ReportApplicant();
            PageRA.DataContext = new ReportApplicantViewModel(PageRA);
            PageRA.Owner = mWindow;
            bool? result = PageRA.ShowDialog();
            if (result == true)
            { }

            Cursor = saveCursor;
        }
        #endregion

        #endregion

        #endregion

        #region Construct
        /// <summary>
        /// Default Construct
        /// </summary>
        /// <param name="window">Current Window</param>
        public MainWindowViewModel(Window window)
        {
            mWindow = window;

            Cursor = Cursors.Arrow;

            // Name Employee
            EmpName = Properties.Settings.Default.EmpName;

            // priv Employee
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

            PageTransferZakatDataCommand = new DelegateCommand(PageTransferZakatDataExecute);

            LogoutCommand = new DelegateCommand(LogOut);
            ContactStatusCommand = new DelegateCommand(ContactStatus);
            GetPrivCommand = new DelegateCommand<string>(GetPrivExecute);
            CloseCommand = new DelegateCommand(CloseExecute);
            DatabaseBackupCommand = new DelegateCommand(DatabaseBackupExecute,DatabaseBackupCanExecute);
            DatabaseRestoreCommand = new DelegateCommand(DatabaseRestoreExecute, DatabaseRestoreCanExecute);

            ReportZakatCommand = new DelegateCommand(ReportZakatExecute);
            ReportCollectZakatCommand = new DelegateCommand(ReportCollectZakatExecute);
            ReportNumberZakatCommand = new DelegateCommand(ReportNumberZakatExecute);
            
            ReportExpensesCommand = new DelegateCommand(ReportExpensesExecute);
            ReportSocialResearchCommand = new DelegateCommand(ReportSocialResearchExecute);
            ReportApplicantCommand = new DelegateCommand(ReportApplicantExecute);

        }
        #endregion
    }
}