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
    class ViewExchangePermissionDataViewModel : BindableBase
    {
        #region private Member
        UserControl CurrentPage;
        private ObservableCollection<AuthorizeExpenditure> _list = new ObservableCollection<AuthorizeExpenditure>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

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

        public DelegateCommand SearchExchangePermissionCommand { get; set; }
        public DelegateCommand EditExchangePermissionCommand { get; set; }
        public DelegateCommand ViewExchangePermissionCommand { get; set; }
        public DelegateCommand DeleteExchangePermissionCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region Search ExchangePermission
        private void SearchExchangePermissionExecute()
        {

        }
        private bool SearchExchangePermissionCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Edit ExchangePermission
        private void EditExchangePermissionExecute()
        {

        }
        private bool EditExchangePermissionCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region view ExchangePermission
        private void ViewExchangePermissionExecute()
        {

        }
        private bool ViewExchangePermissionCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Delete ExchangePermission
        private void DeleteExchangePermissionExecute()
        {

        }
        private bool DeleteExchangePermissionCanExecute()
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
        public ViewExchangePermissionDataViewModel(UserControl CP)
        {
            CurrentPage = CP;


            SearchExchangePermissionCommand = new DelegateCommand(SearchExchangePermissionExecute, SearchExchangePermissionCanExecute);
            EditExchangePermissionCommand = new DelegateCommand(EditExchangePermissionExecute, EditExchangePermissionCanExecute);
            ViewExchangePermissionCommand = new DelegateCommand(ViewExchangePermissionExecute, ViewExchangePermissionCanExecute);
            DeleteExchangePermissionCommand = new DelegateCommand(DeleteExchangePermissionExecute, DeleteExchangePermissionCanExecute);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
