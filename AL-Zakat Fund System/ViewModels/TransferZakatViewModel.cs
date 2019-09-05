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
    class TransferZakatViewModel : BindableBase
    {
        #region private Member
        private UserControl CurrentPage;
        private Window mWindow;
        private ObservableCollection<Zakat> _list = new ObservableCollection<Zakat>();
        private ObservableCollection<Zakat> _list2 = new ObservableCollection<Zakat>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

        private Zakat _SelectItem;

        #endregion
        
        #region private function

        #region fill Observable Collection list
        private void FillList()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayZakat4";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            Zakat TZ;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TZ = new Zakat();
                    TZ.Zakat_id = DBConnection.reader.GetInt32(0);
                    TZ.Name = DBConnection.reader.GetString(1);
                    TZ.Address = DBConnection.reader.GetString(2);
                    TZ.SDate = DBConnection.reader.GetDateTime(3);
                    TZ.Amount = DBConnection.reader.GetDecimal(4).ToString();
                    TZ.ReceiptNO = DBConnection.reader.GetInt32(5).ToString();
                    TZ.ZType2 = DBConnection.reader.GetString(6);
                    TZ.ZCalss = DBConnection.reader.GetString(7);
                    TZ.InstrumentNo = DBConnection.reader.GetString(8);
                    TZ.Phone = DBConnection.reader.GetString(9);
                    TZ.Email = DBConnection.reader.GetString(10);
                    TZ.CaseDeposit2 = DBConnection.reader.GetString(11);
                    TZ.Convrsion2 = DBConnection.reader.GetString(12);
                    TZ.Collector2 = DBConnection.reader.GetString(13);
                    TZ.Activity2 = DBConnection.reader.GetString(14);
                    TZ.Migration2 = DBConnection.reader.GetString(15);
                    TZ.Colle_ssn2 = DBConnection.reader.GetString(16);
                    TZ.Office_no2 = DBConnection.reader.GetString(17);

                    list.Add(TZ);
                }
                _list2.Clear();
                _list2.AddRange(list.ToList<Zakat>());
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

        public ObservableCollection<Zakat> list
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
                    list = new ObservableCollection<Zakat>(_list2.Where(item => regEx.IsMatch(item.Name) || regEx.IsMatch(item.Address) || regEx.IsMatch(item.SDate.ToString("dd/MM/yyyy")) ||
                                                            regEx.IsMatch(item.Amount) || regEx.IsMatch(item.ReceiptNO) || regEx.IsMatch(item.ZType2) || regEx.IsMatch(item.ZCalss) ||
                                                            regEx.IsMatch(item.InstrumentNo) || regEx.IsMatch(item.Phone) || regEx.IsMatch(item.Email) || regEx.IsMatch(item.CaseDeposit2) ||
                                                            regEx.IsMatch(item.Convrsion2) || regEx.IsMatch(item.Collector2) || regEx.IsMatch(item.Activity2) || regEx.IsMatch(item.Migration2)
                                                            || regEx.IsMatch(item.Colle_ssn2) || regEx.IsMatch(item.Office_no2)).ToList<Zakat>());
                }
                else
                {
                    SelectItem = null;
                    list.Clear();
                    list.AddRange(_list2.ToList<Zakat>());
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
        public Zakat SelectItem
        {
            get { return _SelectItem; }
            set { SetProperty(ref _SelectItem, value); }
        }
        #endregion

        #region Delegate Command 

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand ReFreshZakatCommand { get; set; }
        public DelegateCommand EditZakatCommand { get; set; }
        public DelegateCommand ViewZakatCommand { get; set; }
        public DelegateCommand TransferZakatCommand { get; set; }
        public DelegateCommand TransferAllZakatCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region ReFresh Zakat
        private void ReFreshZakatExecute()
        {
            FillList();
            SearchText = "";
            SelectItem = null;
        }
        #endregion

        #region Edit Zakat
        private void EditZakatExecute()
        {
            ModifyZakat view = new ModifyZakat();
            view.DataContext = new ModifyZakatViewModel(view, SelectItem.Zakat_id);
            view.Owner = mWindow;
            bool? result = view.ShowDialog();
            if (result == true)
            {
                ReFreshZakatExecute();
            }
        }
        private bool EditZakatCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region view Zakat
        private void ViewZakatExecute()
        {
            DisplayZakat view = new DisplayZakat();
            view.DataContext = new DisplayZakatViewModel(view, SelectItem.Zakat_id);
            view.Owner = mWindow;
            view.Show();

        }
        private bool ViewZakatCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Transfer Zakat
        private void TransferZakatExecute()
        {
            MessageBoxResult result = MessageBox.Show("هل انت متأكد من تحويل الزكاة رقم " + SelectItem.Zakat_id.ToString() + " إلى حساب المصارف",
                                                        "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                int succ = 0;
                try
                {

                    DBConnection.OpenConnection();

                    DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DBConnection.cmd.CommandText = "sp_TransferZakat";

                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

                    DBConnection.cmd.Parameters["@Id"].Value = SelectItem.Zakat_id;
                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();
                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("لم يتم تحويل الزكاة إلى حساب المصارف الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                finally
                {
                    DBConnection.CloseConnection();

                    if (succ == 1)
                    {
                        MessageBox.Show("تم تحويل الزكاة رقم " + SelectItem.Zakat_id.ToString() + " إلى حساب المصارف بنجاح");
                        FillList();
                    }
                    else if (succ == 2)
                    {
                        MessageBox.Show("لم يتم العثور على الزكاة رقم : " + SelectItem.Zakat_id.ToString());
                    }
                    else if (succ == 3)
                    {
                        MessageBox.Show("الزكاة رقم ( " + SelectItem.Zakat_id.ToString() + " ) لم يتم تصديقها بعد");
                    }
                    else
                    {
                        MessageBox.Show("لم يتم تحويل الزكاة رقم ( " + SelectItem.Zakat_id.ToString() + " ) إلى حساب المصارف");
                    }
                }//end finally
            }
        }
        private bool TransferZakatCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Transfer All Zakat
        private void TransferAllZakatExecute()
        {
            MessageBoxResult result = MessageBox.Show("هل انت متأكد من تحويل جميع الزكاة المصدق عليها إلى حساب المصارف",
                                                        "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                int succ = 0;
                try
                {

                    DBConnection.OpenConnection();

                    DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DBConnection.cmd.CommandText = "sp_TransferAllZakat";

                    DBConnection.cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

                    DBConnection.cmd.Parameters["@count"].Direction = ParameterDirection.Output;
                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();
                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("لم يتم تحويل الزكاة إلى حساب المصارف الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                finally
                {
                    DBConnection.CloseConnection();

                    if (succ == 1)
                    {
                        MessageBox.Show("تم تحويل " + (int)DBConnection.cmd.Parameters["@count"].Value + " زكاة إلى حساب المصارف بنجاح");
                        FillList();
                    }
                    else if (succ == 2)
                    {
                        MessageBox.Show("لم يتم العثور على زكاة يمكن تحويلها إلى حساب المصارف");
                    }
                    else
                    {
                        MessageBox.Show("لم يتم تحويل الزكاة إلى حساب المصارف");
                    }
                }//end finally
            }
        }
        private bool TransferAllZakatCanExecute()
        {
            //if (SelectItem == null)
            //{
            //    return false;
            //}
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
        public TransferZakatViewModel(UserControl CP, Window window)
        {
            CurrentPage = CP;
            mWindow = window;

            FillList();

            ReFreshZakatCommand = new DelegateCommand(ReFreshZakatExecute);
            EditZakatCommand = new DelegateCommand(EditZakatExecute, EditZakatCanExecute).ObservesProperty(() => SelectItem);
            ViewZakatCommand = new DelegateCommand(ViewZakatExecute, ViewZakatCanExecute).ObservesProperty(() => SelectItem);
            //TransferZakatCommand = new DelegateCommand(TransferZakatExecute, TransferZakatCanExecute).ObservesProperty(() => SelectItem);
            //TransferAllZakatCommand = new DelegateCommand(TransferAllZakatExecute, TransferAllZakatCanExecute).ObservesProperty(() => SelectItem);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
