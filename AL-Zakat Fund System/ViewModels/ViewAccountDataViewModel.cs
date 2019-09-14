using AL_Zakat_Fund_System.Models;
using AL_Zakat_Fund_System.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ViewAccountDataViewModel : Indigent
    {
        #region private Member
        private UserControl CurrentPage;
        private Window mWindow;
        private ObservableCollection<Indigent> _list = new ObservableCollection<Indigent>();
        private ObservableCollection<Indigent> _list2 = new ObservableCollection<Indigent>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

        private Indigent _SelectItem;

        #endregion

        #region private function

        #region fill Observable Collection list
        private void FillList()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;

            if (Properties.Settings.Default.nameBranch == Properties.Settings.Default.nameOffice)
            {
                DBConnection.cmd.CommandText = "sp_displayIndigentBranch";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Branch", SqlDbType.Int));
                DBConnection.cmd.Parameters["@Branch"].Value = Properties.Settings.Default.Branch;
            }
            else
            {
                DBConnection.cmd.CommandText = "sp_displayIndigentOffice";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office", SqlDbType.Int));
                DBConnection.cmd.Parameters["@Office"].Value = Properties.Settings.Default.Office;
            }

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            Indigent TI;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TI = new Indigent();
                    TI.Ssn = DBConnection.reader.GetInt64(0).ToString();
                    TI.SDate = DBConnection.reader.GetDateTime(1);
                    TI.RequestStatus2 = DBConnection.reader.GetString(2);
                    TI.FName = DBConnection.reader.GetString(3);
                    TI.MName = DBConnection.reader.GetString(4);
                    TI.GName = DBConnection.reader.GetString(5);
                    TI.LName = DBConnection.reader.GetString(6);
                    TI.MotherName = DBConnection.reader.GetString(7);
                    TI.DialCode = DBConnection.reader.GetString(8);
                    TI.Number = DBConnection.reader.GetString(9);
                    TI.TypeAssistance = DBConnection.reader.GetString(10);
                    TI.SocialStatus2 = DBConnection.reader.GetString(11);
                    TI.Nationality = DBConnection.reader.GetString(12);
                    TI.PersonalCardNO = DBConnection.reader.GetString(13);
                    TI.PassportNO = DBConnection.reader.GetString(14);
                    TI.Email = DBConnection.reader.GetString(15);
                    TI.Gender2 = DBConnection.reader.GetString(16);
                    TI.Scribe_ssn2 = DBConnection.reader.GetString(17);
                    TI.Office_no2 = DBConnection.reader.GetString(18);

                    list.Add(TI);
                }
                _list2.Clear();
                _list2.AddRange(list.ToList<Indigent>());
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا في عرض البيانات" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
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

        public ObservableCollection<Indigent> list
        {
            get { return _list; }
            set { SetProperty(ref _list, value); }
        }
        public string SearchText
        {
            get { return _SearchText; }
            set
            {

                if (_SearchText == value) return;


                value = value.Replace('\\', '/');

                SetProperty(ref _SearchText, value);


                if (!string.IsNullOrWhiteSpace(_SearchText) && !string.IsNullOrEmpty(_SearchText))
                {
                    SelectItem = null;
                    Regex regEx = new Regex(_SearchText.ToString(), RegexOptions.IgnoreCase);
                    list = new ObservableCollection<Indigent>(_list2.Where(item => regEx.IsMatch(item.Ssn) || regEx.IsMatch(item.FullName) || regEx.IsMatch(item.SDate.ToString("dd/MM/yyyy")) ||
                                                            regEx.IsMatch(item.RequestStatus2) || regEx.IsMatch(item.MotherName) || regEx.IsMatch(item.TypeAssistance) || regEx.IsMatch(item.SocialStatus2) ||
                                                            regEx.IsMatch(item.Nationality) || regEx.IsMatch(item.Phone) || regEx.IsMatch(item.Email) || regEx.IsMatch(item.PassportNO) ||
                                                            regEx.IsMatch(item.Gender2) || regEx.IsMatch(item.Scribe_ssn2) || regEx.IsMatch(item.Office_no2)).ToList<Indigent>());
                    
                }
                else
                {
                    SelectItem = null;
                    list.Clear();
                    list.AddRange(_list2.ToList<Indigent>());
                }
            }
        }
        public int Start
        {
            get { return _Start; }
            set { SetProperty(ref _Start, value); }
        }
        public int End
        {
            get { return _End; }
            set { SetProperty(ref _End, value); }
        }
        public int TotalItems
        {
            get { return _TotalItems; }
            set { SetProperty(ref _TotalItems, value); }
        }
        public Indigent SelectItem
        {
            get { return _SelectItem; }
            set { SetProperty(ref _SelectItem, value); }
        }
        #endregion

        #region Delegate Command 

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand ReFreshAccountCommand { get; set; }
        public DelegateCommand EditAccountCommand { get; set; }
        public DelegateCommand ViewAccountCommand { get; set; }
        public DelegateCommand DeleteAccountCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region ReFresh Account
        private void ReFreshAccountExecute()
        {
            FillList();
            SearchText = "";
            SelectItem = null;
        }
        #endregion

        #region Edit Account
        private void EditAccountExecute()
        {
            EditAccount view = new EditAccount();
            view.DataContext = new EditAccountViewModel(view, SelectItem.Ssn);
            view.Owner = mWindow;
            bool? result = view.ShowDialog();
            if (result == true)
            {
                ReFreshAccountExecute();
            }
        }
        private bool EditAccountCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region view Account
        private void ViewAccountExecute()
        {
            DisplayAccount view = new DisplayAccount();
            view.DataContext = new DisplayAccountViewModel(view, SelectItem.Ssn);
            view.Owner = mWindow;
            bool? result = view.ShowDialog();
            if (result == true)
            {}

        }
        private bool ViewAccountCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Delete Account
        private void DeleteAccountExecute()
        {
            MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف ملف المحتاج " + SelectItem.FullName + Environment.NewLine + "في حال ضغط على نعم سيتم حذف الملف نهائيا",
                                                        "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                int succ = 0;
                try
                {

                    DBConnection.OpenConnection();

                    DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DBConnection.cmd.CommandText = "sp_deleteIndigent";

                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Ssn", SqlDbType.BigInt));
                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

                    DBConnection.cmd.Parameters["@Ssn"].Value = long.Parse(SelectItem.Ssn);
                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();
                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("لم يتم حذف الملف الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                finally
                {
                    DBConnection.CloseConnection();

                    if (succ == 1)
                    {
                        MessageBox.Show("تم حذف ملف  " + SelectItem.FullName + " بنجاح");
                        FillList();
                    }
                    else if (succ == 2)
                    {
                        MessageBox.Show("لم يتم العثور على ملف : " + SelectItem.FullName);
                    }
                    else
                    {
                        MessageBox.Show("لم يتم حذف ملف : " + SelectItem.FullName + Environment.NewLine + "قد يكون لديه محاضر يرجى حذف المحاضره تم اعد حذفه");
                    }
                }//end finally
            }
        }
        private bool DeleteAccountCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            CurrentPage.Content = null;
        }
        #endregion

        #region NaviGate
        private void FirstExecute()
        {

        }
        private void PreviousExecute()
        {

        }
        private void NextExecute()
        {

        }
        private void LastExecute()
        {

        }
        #endregion

        #endregion

        #region Construct
        public ViewAccountDataViewModel(UserControl CP, Window window)
        {
            CurrentPage = CP;
            mWindow = window;

            FillList();

            ReFreshAccountCommand = new DelegateCommand(ReFreshAccountExecute);
            EditAccountCommand = new DelegateCommand(EditAccountExecute, EditAccountCanExecute).ObservesProperty(() => SelectItem);
            ViewAccountCommand = new DelegateCommand(ViewAccountExecute, ViewAccountCanExecute).ObservesProperty(() => SelectItem);
            DeleteAccountCommand = new DelegateCommand(DeleteAccountExecute, DeleteAccountCanExecute).ObservesProperty(() => SelectItem);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
        
    }
}
