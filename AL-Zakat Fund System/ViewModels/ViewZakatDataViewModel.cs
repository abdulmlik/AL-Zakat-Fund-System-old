using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AL_Zakat_Fund_System.Models;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ViewZakatDataViewModel : BindableBase
    {
        #region private Member
        UserControl CurrentPage;
        private ObservableCollection<Zakat> _list = new ObservableCollection<Zakat>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

        #region fill Observable Collection list
        private void FillList()
        {
            DBConnection.OpenConnection();

            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayZakat";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            Zakat TZ;

            try
            {
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
                    TZ.Colle_ssn2 = DBConnection.reader.GetString(13);
                    TZ.Office_no2 = DBConnection.reader.GetString(14);

                    list.Add(TZ);
                }
            }
            catch(Exception ex)
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
            set { SetProperty(ref _SearchText, value); }
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
        #endregion

        #region Delegate Command 

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand SearchZakatCommand { get; set; }
        public DelegateCommand EditZakatCommand { get; set; }
        public DelegateCommand ViewZakatCommand { get; set; }
        public DelegateCommand DeleteZakatCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region Search Zakat
        private void SearchZakatExecute()
        {

        }
        private bool SearchZakatCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Edit Zakat
        private void EditZakatExecute()
        {

        }
        private bool EditZakatCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region view Zakat
        private void ViewZakatExecute()
        {

        }
        private bool ViewZakatCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Delete Zakat
        private void DeleteZakatExecute()
        {

        }
        private bool DeleteZakatCanExecute()
        {
            if (true)
            {

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
        public ViewZakatDataViewModel(UserControl CP)
        {
            CurrentPage = CP;

            FillList();

            SearchZakatCommand = new DelegateCommand(SearchZakatExecute, SearchZakatCanExecute);
            EditZakatCommand = new DelegateCommand(EditZakatExecute, EditZakatCanExecute);
            ViewZakatCommand = new DelegateCommand(ViewZakatExecute, ViewZakatCanExecute);
            DeleteZakatCommand = new DelegateCommand(DeleteZakatExecute, DeleteZakatCanExecute);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
