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
    class ViewAccountDataViewModel : BindableBase
    {
        #region private Member
        UserControl CurrentPage;
        private ObservableCollection<Indigent> _list = new ObservableCollection<Indigent>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

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

        public DelegateCommand SearchAccountCommand { get; set; }
        public DelegateCommand EditAccountCommand { get; set; }
        public DelegateCommand ViewAccountCommand { get; set; }
        public DelegateCommand DeleteAccountCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region Search Account
        private void SearchAccountExecute()
        {

        }
        private bool SearchAccountCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Edit Account
        private void EditAccountExecute()
        {

        }
        private bool EditAccountCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region view Account
        private void ViewAccountExecute()
        {

        }
        private bool ViewAccountCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Delete Account
        private void DeleteAccountExecute()
        {

        }
        private bool DeleteAccountCanExecute()
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
        public ViewAccountDataViewModel(UserControl CP)
        {
            CurrentPage = CP;


            SearchAccountCommand = new DelegateCommand(SearchAccountExecute, SearchAccountCanExecute);
            EditAccountCommand = new DelegateCommand(EditAccountExecute, EditAccountCanExecute);
            ViewAccountCommand = new DelegateCommand(ViewAccountExecute, ViewAccountCanExecute);
            DeleteAccountCommand = new DelegateCommand(DeleteAccountExecute, DeleteAccountCanExecute);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
