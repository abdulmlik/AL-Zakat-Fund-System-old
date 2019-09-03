using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{

    class SettingViewModel : BindableBase
    {
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

        private Office _office;
        private ObservableCollection<Office> _offices = new ObservableCollection<Office>();

        #endregion

        #region private function

        #region Get Stting Database
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
        #endregion

        #region Get Offices
        private void GetOffice()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_getOffice";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;


            //int succ = 0;
            try
            {
                DBConnection.OpenConnection();
                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                // succ = 1 Success or succ = 0 fail or succ = 2 not found
                //succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                Office TO;
                offices.Clear();
                
                while (DBConnection.reader.Read())
                {
                    TO = new Office(DBConnection.reader.GetInt32(0), DBConnection.reader.GetString(1),
                                            DBConnection.reader.GetInt32(2), DBConnection.reader.GetString(3));
                    
                    offices.Add(TO);
                }
                
                office = offices.Where(item => item.office_no == Properties.Settings.Default.Office).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا في جلب البيانات المكاتب" + Environment.NewLine +"الخطا : "+ ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }
        #endregion

        #region Connection Status
        private void ConnectionStatus()
        {
            if (DBConnection.ConnectionStatus())
            {
                IsEnabled = true;
                GetOffice();
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

        public Office office
        {
            get { return _office; }
            set { SetProperty(ref _office, value); }
        }
        public ObservableCollection<Office> offices
        {
            get { return _offices; }
            set { SetProperty(ref _offices, value); }
        }
        #endregion

        #region Delegate Command

        public DelegateCommand SaveSettingDBCommand { get; set; }
        public DelegateCommand SaveSettingOfficeCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region Save Setting DataBase
        void SaveSettingDBExecute()
        {
            // Trim() remove Space from the side
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
                Properties.Settings.Default.Password = Password;
            }
            Properties.Settings.Default.Save();
            ConnectionStatus();
        }
        #endregion

        #region Save Setting Office
        void SaveSettingOfficeExecute()
        {
            // Trim() remove Space from the side
            Properties.Settings.Default.Office = office.office_no;
            Properties.Settings.Default.nameOffice = office.nameOffice;
            Properties.Settings.Default.Branch = office.branch_no;
            Properties.Settings.Default.nameBranch = office.nameBranch;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Close
        void CloseExecute()
        {
            mWindow.Close();
        }
        #endregion

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

            SaveSettingDBCommand = new DelegateCommand(SaveSettingDBExecute);
            SaveSettingOfficeCommand = new DelegateCommand(SaveSettingOfficeExecute);
            CloseCommand = new DelegateCommand(CloseExecute);
        }
        #endregion

    }
}
