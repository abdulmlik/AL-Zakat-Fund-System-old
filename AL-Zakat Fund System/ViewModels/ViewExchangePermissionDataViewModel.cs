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
    class ViewExchangePermissionDataViewModel : AuthorizeExpenditure
    {
        #region private Member
        private UserControl CurrentPage;
        private Window mWindow;
        private ObservableCollection<AuthorizeExpenditure> _list = new ObservableCollection<AuthorizeExpenditure>();
        private ObservableCollection<AuthorizeExpenditure> _list2 = new ObservableCollection<AuthorizeExpenditure>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

        private AuthorizeExpenditure _SelectItem;

        #endregion

        #region private function

        #region fill Observable Collection list
        private void FillList()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayAEX";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            AuthorizeExpenditure TR;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TR = new AuthorizeExpenditure();
                    TR.CommitteeDecisionNO = DBConnection.reader.GetInt64(0).ToString();
                    TR.FullName = DBConnection.reader.GetString(1);
                    TR.CategoryPoor2 = DBConnection.reader.GetString(2);
                    TR.TypeAssistance = DBConnection.reader.GetString(3);
                    TR.Amount = DBConnection.reader.GetDecimal(4).ToString();
                    TR.SDate = DBConnection.reader.GetDateTime(5);
                    TR.InstrumentNO2 = DBConnection.reader.GetString(6);
                    TR.InstrumentNO = DBConnection.reader.GetString(7);
                    TR.Comment = DBConnection.reader.GetString(8);
                    TR.Courier_ssn2 = DBConnection.reader.GetString(9);


                    list.Add(TR);
                }
                _list2.Clear();
                _list2.AddRange(list.ToList<AuthorizeExpenditure>());
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

        public ObservableCollection<AuthorizeExpenditure> list
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
                    list = new ObservableCollection<AuthorizeExpenditure>(_list2.Where(item => regEx.IsMatch(item.CommitteeDecisionNO) || regEx.IsMatch(item.FullName) || regEx.IsMatch(item.SDate.ToString("dd/MM/yyyy")) ||
                                                            regEx.IsMatch(item.CategoryPoor2) || regEx.IsMatch(item.TypeAssistance) || regEx.IsMatch(item.Amount) || regEx.IsMatch(item.InstrumentNO2) ||
                                                            regEx.IsMatch(item.InstrumentNO) || regEx.IsMatch(item.Courier_ssn2)).ToList<AuthorizeExpenditure>());

                }
                else
                {
                    SelectItem = null;
                    list.Clear();
                    list.AddRange(_list2.ToList<AuthorizeExpenditure>());
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
        public AuthorizeExpenditure SelectItem
        {
            get { return _SelectItem; }
            set { SetProperty(ref _SelectItem, value); }
        }
        #endregion

        #region Delegate Command 

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand ReFreshCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand ViewCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region ReFresh Authorize Expenditure
        private void ReFreshExecute()
        {
            FillList();
            SearchText = "";
            SelectItem = null;
        }
        #endregion

        #region Edit Authorize Expenditure
        private void EditExecute()
        {
            ModifyExchangePermission view = new ModifyExchangePermission();
            view.DataContext = new ModifyExchangePermissionViewModel(view, SelectItem.CommitteeDecisionNO);
            view.Owner = mWindow;
            bool? result = view.ShowDialog();
            if (result == true)
            {
                ReFreshExecute();
            }
        }
        private bool EditCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region view Authorize Expenditure
        private void ViewExecute()
        {
            DisplayAuthorizeExpenditure view = new DisplayAuthorizeExpenditure();
            view.DataContext = new DisplayAuthorizeExpenditureViewModel(view, SelectItem.CommitteeDecisionNO);
            view.Owner = mWindow;
            bool? result = view.ShowDialog();
            if (result == true)
            { }

        }
        private bool ViewCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Delete Authorize Expenditure
        private void DeleteExecute()
        {
            MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف إذن الصرف رقم " + SelectItem.CommitteeDecisionNO + " الخاص ب" + SelectItem.FullName + Environment.NewLine + "في حال ضغط على نعم سيتم حذف إذن الصرف نهائيا",
                                                        "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                int succ = 0;
                try
                {

                    DBConnection.OpenConnection();

                    DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DBConnection.cmd.CommandText = "sp_deleteAEX";

                    DBConnection.cmd.Parameters.Add(new SqlParameter("@CommitteeDecisionNO", SqlDbType.BigInt));
                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

                    DBConnection.cmd.Parameters["@CommitteeDecisionNO"].Value = long.Parse(SelectItem.CommitteeDecisionNO);
                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();
                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("لم يتم حذف إذن الصرف الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                finally
                {
                    DBConnection.CloseConnection();

                    if (succ == 1)
                    {
                        MessageBox.Show("تم حذف إذن الصرف الخاص ب  " + SelectItem.FullName + " بنجاح","", MessageBoxButton.OK, MessageBoxImage.None,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        FillList();
                    }
                    else if (succ == 2)
                    {
                        MessageBox.Show("لم يتم العثور على إذن الصرف رقم : " + SelectItem.CommitteeDecisionNO, "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("لم يتم حذف إذن الصرف الخاص ب : " + SelectItem.FullName, "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }//end finally
            }
        }
        private bool DeleteCanExecute()
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
        public ViewExchangePermissionDataViewModel(UserControl CP, Window window)
        {
            CurrentPage = CP;
            mWindow = window;

            FillList();


            ReFreshCommand = new DelegateCommand(ReFreshExecute);
            EditCommand = new DelegateCommand(EditExecute, EditCanExecute).ObservesProperty(() => SelectItem);
            ViewCommand = new DelegateCommand(ViewExecute, ViewCanExecute).ObservesProperty(() => SelectItem);
            DeleteCommand = new DelegateCommand(DeleteExecute, DeleteCanExecute).ObservesProperty(() => SelectItem);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion

    }
}
