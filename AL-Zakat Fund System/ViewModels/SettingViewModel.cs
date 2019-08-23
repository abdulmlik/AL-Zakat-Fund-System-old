using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class Office
    {
        public int a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public Office(int a_, string b_, string c_)
        {
            a = a_;
            b = b_;
            c = c_;
        }
    }
    class SettingViewModel : BindableBase
    {
        private static readonly KeyValuePair<int, string>[] tripLengthList = {
    new KeyValuePair<int, string>(0, "a"),
    new KeyValuePair<int, string>(30, "b"),
    new KeyValuePair<int, string>(50, "c"),
    new KeyValuePair<int, string>(100, "g"),
};
        public KeyValuePair<int, string>[] TripLengthList
        {
            get
            {
                return tripLengthList;
            }
        }

        private KeyValuePair<int, string> _FilterService;
        public KeyValuePair<int, string> FilterService
        {
            get
            {
                return _FilterService;
            }

            set { SetProperty(ref _FilterService, value); }
        }
        public ObservableCollection<Office> UripLengthList;

        private int _FilterService2;
        public int FilterService2
        {
            get
            {
                return _FilterService2;
            }

            set { SetProperty(ref _FilterService2, value); }
        }


        #region private Member

        private Window mWindow;
        private string _ServerName;
        private string _DataBase;
        private string _UserName;
        private string _Password;

        private bool _OptionAuthentication1;
        private bool _OptionAuthentication2;

        private Visibility _Authentication = Visibility.Collapsed;

        private bool _IsEnabled;

        #endregion

        #region private function

        private void GetSttingDatabase()
        {
            ServerName = Properties.Settings.Default.Server;
            DataBase = Properties.Settings.Default.DataBase;
            if (Properties.Settings.Default.Mode == "True")
            {
                OptionAuthentication1 = true;
            }
            else
            {
                OptionAuthentication2 = true;
            }
            UserName = Properties.Settings.Default.UserName;
            Password = Properties.Settings.Default.Password;
        }

        private void GetOffice()
        {
            DBConnection.CloseConnection();
            try
            {

            }catch(Exception ex)
            {

            }
            finally
            {

            }

            DBConnection.CloseConnection();
        }
        private void ConnectionStatus()
        {
            if (DBConnection.ConnectionStatus())
            {
                IsEnabled = true;
                MessageBox.Show("لا يوجد مشاكل في الاتصال بالخادم", "", MessageBoxButton.OK, MessageBoxImage.None,
                                MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                IsEnabled = false;
                MessageBox.Show("فشل النظام في تكوين اتصال الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

        }

        #endregion

        #region public properties
        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { SetProperty(ref _IsEnabled, value); }
        }
        public string ServerName
        {
            get { return _ServerName; }
            set { SetProperty(ref _ServerName, value); }
        }
        public string DataBase
        {
            get { return _DataBase; }
            set { SetProperty(ref _DataBase, value); }
        }
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
        public Visibility Authentication
        {
            get { return _Authentication; }
            set { SetProperty(ref _Authentication, value); }
        }

        public bool OptionAuthentication1
        {
            get { return _OptionAuthentication1; }
            set
            {
                SetProperty(ref _OptionAuthentication1, value);
                if (_OptionAuthentication1)
                {
                    //UserName = null;
                    //Password = null;
                    Authentication = Visibility.Collapsed;
                    OptionAuthentication2 = false;
                }
            }
        }
        public bool OptionAuthentication2
        {
            get { return _OptionAuthentication2; }
            set
            {
                SetProperty(ref _OptionAuthentication2, value);
                if (_OptionAuthentication2)
                {
                    Authentication = Visibility.Visible;
                    OptionAuthentication1 = false;
                }
            }
        }
        #endregion

        #region Delegate Command

        public DelegateCommand SaveSettingDBCommand { get; set; }
        public DelegateCommand SaveSettingOfficeCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        void SaveSettingDBExecute()
        {
            Properties.Settings.Default.Server = ServerName.Trim();
            Properties.Settings.Default.DataBase = DataBase.Trim();
            if (OptionAuthentication1)
            {
                Properties.Settings.Default.Mode = "True";
            }
            else
            {
                Properties.Settings.Default.Mode = "False";
                Properties.Settings.Default.UserName = UserName.Trim();
                Properties.Settings.Default.Password = Password.Trim();
            }
            Properties.Settings.Default.Save();
            ConnectionStatus();
        }

        void SaveSettingOfficeExecute()
        {

        }

        void CloseExecute()
        {
            mWindow.Close();
        }

        #endregion

        #region Construct
        /// <summary>
        /// Default Construct
        /// </summary>
        /// <param name="window"></param>
        public SettingViewModel(Window window)
        {
            mWindow = window;

            GetSttingDatabase();

            if (DBConnection.ConnectionStatus())
            {
                IsEnabled = true;
                GetOffice();
            }
            else
            {
                IsEnabled = false;
            }

            UripLengthList = new ObservableCollection<Office>();
            UripLengthList.Add(new Office(0, "a", "aa"));
            UripLengthList.Add(new Office(30, "b", "bb"));
            UripLengthList.Add(new Office(50, "c", "cc"));
            UripLengthList.Add(new Office(100, "g", "gg"));

            SaveSettingDBCommand = new DelegateCommand(SaveSettingDBExecute);
            SaveSettingOfficeCommand = new DelegateCommand(SaveSettingOfficeExecute);
            CloseCommand = new DelegateCommand(CloseExecute);
        }
        #endregion

    }
}
