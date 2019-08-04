using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ViewRecordDataViewModel : BindableBase
    {
        #region private Member
        UserControl CurrentPage;
        private ObservableCollection<Record> _list = new ObservableCollection<Record>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

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

        public DelegateCommand SearchRecordCommand { get; set; }
        public DelegateCommand EditRecordCommand { get; set; }
        public DelegateCommand ViewRecordCommand { get; set; }
        public DelegateCommand DeleteRecordCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region Search Record
        private void SearchRecordExecute()
        {

        }
        private bool SearchRecordCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Edit Record
        private void EditRecordExecute()
        {

        }
        private bool EditRecordCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region view Record
        private void ViewRecordExecute()
        {

        }
        private bool ViewRecordCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Delete Record
        private void DeleteRecordExecute()
        {

        }
        private bool DeleteRecordCanExecute()
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
        public ViewRecordDataViewModel(UserControl CP)
        {
            CurrentPage = CP;


            SearchRecordCommand = new DelegateCommand(SearchRecordExecute, SearchRecordCanExecute);
            EditRecordCommand = new DelegateCommand(EditRecordExecute, EditRecordCanExecute);
            ViewRecordCommand = new DelegateCommand(ViewRecordExecute, ViewRecordCanExecute);
            DeleteRecordCommand = new DelegateCommand(DeleteRecordExecute, DeleteRecordCanExecute);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
