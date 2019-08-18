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
    class ViewRecordDataViewModel : Record
    {

        #region private Member
        private UserControl CurrentPage;
        private Window mWindow;
        private ObservableCollection<Record> _list = new ObservableCollection<Record>();
        private ObservableCollection<Record> _list2 = new ObservableCollection<Record>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

        private Record _SelectItem;

        #endregion

        #region private function

        #region fill Observable Collection list
        private void FillList()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayRecord";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            Record TR;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TR = new Record();
                    TR.ID = DBConnection.reader.GetInt64(0).ToString();
                    TR.RDate = DBConnection.reader.GetDateTime(1);
                    TR.Indigent_ssn = DBConnection.reader.GetString(2);
                    TR.RStatus2 = DBConnection.reader.GetString(3);
                    TR.Name1 = DBConnection.reader.GetString(4);
                    TR.Name2 = DBConnection.reader.GetString(5);
                    TR.Name3 = DBConnection.reader.GetString(6);
                    TR.Scribe_ssn2 = DBConnection.reader.GetString(7);
                    TR.Office_no2 = DBConnection.reader.GetString(8);
                    

                    list.Add(TR);
                }
                _list2.Clear();
                _list2.AddRange(list.ToList<Record>());
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

        public ObservableCollection<Record> list
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
                    list = new ObservableCollection<Record>(_list2.Where(item => regEx.IsMatch(item.ID) || regEx.IsMatch(item.Indigent_ssn) || regEx.IsMatch(item.RDate.ToString("dd/MM/yyyy")) ||
                                                            regEx.IsMatch(item.Scribe_ssn2) || regEx.IsMatch(item.Office_no2) || regEx.IsMatch(item.Name1) || regEx.IsMatch(item.Name2) ||
                                                            regEx.IsMatch(item.Name3) || regEx.IsMatch(item.RStatus2)).ToList<Record>());

                }
                else
                {
                    SelectItem = null;
                    list.Clear();
                    list.AddRange(_list2.ToList<Record>());
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
        public Record SelectItem
        {
            get { return _SelectItem; }
            set { SetProperty(ref _SelectItem, value); }
        }
        #endregion

        #region Delegate Command 

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand ReFreshRecordCommand { get; set; }
        public DelegateCommand EditRecordCommand { get; set; }
        public DelegateCommand ViewRecordCommand { get; set; }
        public DelegateCommand DeleteRecordCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region ReFresh Record
        private void ReFreshRecordExecute()
        {
            FillList();
            SearchText = "";
            SelectItem = null;
        }
        #endregion

        #region Edit Record
        private void EditRecordExecute()
        {
            EditRecord view = new EditRecord();
            view.DataContext = new EditRecordViewModel(view, SelectItem.ID);
            view.Owner = mWindow;
            bool? result = view.ShowDialog();
            if (result == true)
            {
                ReFreshRecordExecute();
            }
        }
        private bool EditRecordCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region view Account
        private void ViewRecordExecute()
        {
            DisplayRecord view = new DisplayRecord();
            view.DataContext = new DisplayRecordViewModel(view, SelectItem.ID);
            view.Owner = mWindow;
            bool? result = view.ShowDialog();
            if (result == true)
            { }

        }
        private bool ViewRecordCanExecute()
        {
            if (SelectItem == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Delete Account
        private void DeleteRecordExecute()
        {
            MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف المحضر رقم " + SelectItem.ID + " الخاص ب" + SelectItem.Indigent_ssn + Environment.NewLine+ "حذف المحضر يترتب عليه حذف المتابعة الخاصة به ووضع الصرف تحت مجهول" + Environment.NewLine + "في حال ضغط على نعم سيتم حذف الملف نهائيا",
                                                        "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                int succ = 0;
                try
                {

                    DBConnection.OpenConnection();

                    DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                    DBConnection.cmd.CommandText = "sp_deleteRecord";

                    DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
                    DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

                    DBConnection.cmd.Parameters["@ID"].Value = long.Parse(SelectItem.ID);
                    DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                    DBConnection.cmd.ExecuteNonQuery();
                    succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("لم يتم حذف المحضر الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                        MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                finally
                {
                    DBConnection.CloseConnection();

                    if (succ == 1)
                    {
                        MessageBox.Show("تم حذف المحضر الخاص ب  " + SelectItem.Indigent_ssn + " بنجاح");
                        FillList();
                    }
                    else if (succ == 2)
                    {
                        MessageBox.Show("لم يتم العثور على المحضر رقم : " + SelectItem.ID);
                    }
                    else
                    {
                        MessageBox.Show("لم يتم حذف المحضر الخاص ب : " + SelectItem.Indigent_ssn);
                    }
                }//end finally
            }
        }
        private bool DeleteRecordCanExecute()
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
        public ViewRecordDataViewModel(UserControl CP, Window window)
        {
            CurrentPage = CP;
            mWindow = window;

            FillList();

            ReFreshRecordCommand = new DelegateCommand(ReFreshRecordExecute);
            EditRecordCommand = new DelegateCommand(EditRecordExecute, EditRecordCanExecute).ObservesProperty(() => SelectItem);
            ViewRecordCommand = new DelegateCommand(ViewRecordExecute, ViewRecordCanExecute).ObservesProperty(() => SelectItem);
            DeleteRecordCommand = new DelegateCommand(DeleteRecordExecute, DeleteRecordCanExecute).ObservesProperty(() => SelectItem);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
