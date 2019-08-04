using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using AL_Zakat_Fund_System.Models;

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
