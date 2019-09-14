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
    class ViewFollowUpDataViewModel : Follow_up
    {
        #region private Member
        private UserControl CurrentPage;
        private Window mWindow;
        private ObservableCollection<Follow_up> _list = new ObservableCollection<Follow_up>();
        private ObservableCollection<Follow_up> _list2 = new ObservableCollection<Follow_up>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

        private Follow_up _SelectItem;

        #endregion

        #region private function

        #region fill Observable Collection list
        private void FillList()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;

            if (Properties.Settings.Default.nameBranch == Properties.Settings.Default.nameOffice)
            {
                DBConnection.cmd.CommandText = "sp_displayFollowUPBranch";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Branch", SqlDbType.Int));
                DBConnection.cmd.Parameters["@Branch"].Value = Properties.Settings.Default.Branch;
            }
            else
            {
                DBConnection.cmd.CommandText = "sp_displayFollowUPOffice";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office", SqlDbType.Int));
                DBConnection.cmd.Parameters["@Office"].Value = Properties.Settings.Default.Office;
            }

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            Follow_up TR;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TR = new Follow_up();
                    TR.DecisionNO = DBConnection.reader.GetInt64(0).ToString();
                    TR.fullname = DBConnection.reader.GetString(1);
                    TR.ReceivedDate = DBConnection.reader.GetDateTime(2);
                    TR.VisitDate2 = DBConnection.reader.GetString(3);
                    TR.DeliverDate2 = DBConnection.reader.GetString(4);
                    TR.Distance2 = DBConnection.reader.GetString(5);
                    TR.FStatus2 = DBConnection.reader.GetString(6);
                    TR.Scribe_ssn2 = DBConnection.reader.GetString(7);
                    TR.Observer_ssn = DBConnection.reader.GetString(8);


                    list.Add(TR);
                }
                _list2.Clear();
                _list2.AddRange(list.ToList<Follow_up>());
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

        public ObservableCollection<Follow_up> list
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
                    Regex regEx = new Regex(_SearchText.ToString(), RegexOptions.IgnoreCase);//
                    list = new ObservableCollection<Follow_up>(_list2.Where(item => regEx.IsMatch(item.DecisionNO) || regEx.IsMatch(item.fullname) || regEx.IsMatch(item.ReceivedDate.ToString("dd/MM/yyyy")) ||
                                                            regEx.IsMatch(item.VisitDate2) || regEx.IsMatch(item.DeliverDate2) || regEx.IsMatch(item.Distance2) || regEx.IsMatch(item.FStatus2) ||
                                                            regEx.IsMatch(item.Observer_ssn) || regEx.IsMatch(item.Scribe_ssn2)).ToList<Follow_up>());

                }
                else
                {
                    SelectItem = null;
                    list.Clear();
                    list.AddRange(_list2.ToList<Follow_up>());
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
        public Follow_up SelectItem
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

        #region ReFresh Follow_up
        private void ReFreshExecute()
        {
            FillList();
            SearchText = "";
            SelectItem = null;
        }
        #endregion

        #region Edit Follow_up
        private void EditExecute()
        {
            EditFollowUp view = new EditFollowUp();
            view.DataContext = new EditFollowUpViewModel(view, SelectItem.DecisionNO);
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

        #region view Follow_up
        private void ViewExecute()
        {
            DisplayFollowUp view = new DisplayFollowUp();
            view.DataContext = new DisplayFollowUpViewModel(view, SelectItem.DecisionNO);
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

        #region Delete Follow_up
        private void DeleteExecute()
        {
            MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف المتابعة رقم " + SelectItem.DecisionNO + " الخاص ب" + SelectItem.fullname + Environment.NewLine + "في حال ضغط على نعم سيتم حذف المتابعة نهائيا",
                                                        "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                int succ = 0;
                try
                {

                    DBConnection.OpenConnection();

                    DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DBConnection.cmd.CommandText = "sp_deleteFollowUP";

                    DBConnection.cmd.Parameters.Add(new SqlParameter("@DecisionNO", SqlDbType.BigInt));
                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

                    DBConnection.cmd.Parameters["@DecisionNO"].Value = long.Parse(SelectItem.DecisionNO);
                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();
                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("لم يتم حذف المتابعة الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                finally
                {
                    DBConnection.CloseConnection();

                    if (succ == 1)
                    {
                        MessageBox.Show("تم حذف المتابعةالخاص ب  " + SelectItem.fullname + " بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        FillList();
                    }
                    else if (succ == 2)
                    {
                        MessageBox.Show("لم يتم العثور على المتابعة رقم : " + SelectItem.DecisionNO, "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("لم يتم حذف المتابعة الخاص ب : " + SelectItem.fullname, "", MessageBoxButton.OK, MessageBoxImage.Error,
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
        public ViewFollowUpDataViewModel(UserControl CP, Window window)
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
