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
    class ViewFollowUpDataObserverViewModel : BindableBase
    {
        #region private Member
        UserControl CurrentPage;
        private ObservableCollection<Follow_up> _list = new ObservableCollection<Follow_up>();
        private string _SearchText;
        private int _Start;
        private int _End;
        private int _TotalItems;

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

        public DelegateCommand SearchFollowUpObserverCommand { get; set; }
        public DelegateCommand EditFollowUpObserverCommand { get; set; }
        public DelegateCommand ViewFollowUpObserverCommand { get; set; }
        public DelegateCommand DeleteFollowUpObserverCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region Search FollowUpObserver
        private void SearchFollowUpObserverExecute()
        {

        }
        private bool SearchFollowUpObserverCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Edit FollowUpObserver
        private void EditFollowUpObserverExecute()
        {

        }
        private bool EditFollowUpObserverCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region view FollowUpObserver
        private void ViewFollowUpObserverExecute()
        {

        }
        private bool ViewFollowUpObserverCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Delete FollowUpObserver
        private void DeleteFollowUpObserverExecute()
        {

        }
        private bool DeleteFollowUpObserverCanExecute()
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
        public ViewFollowUpDataObserverViewModel(UserControl CP)
        {
            CurrentPage = CP;


            SearchFollowUpObserverCommand = new DelegateCommand(SearchFollowUpObserverExecute, SearchFollowUpObserverCanExecute);
            EditFollowUpObserverCommand = new DelegateCommand(EditFollowUpObserverExecute, EditFollowUpObserverCanExecute);
            ViewFollowUpObserverCommand = new DelegateCommand(ViewFollowUpObserverExecute, ViewFollowUpObserverCanExecute);
            DeleteFollowUpObserverCommand = new DelegateCommand(DeleteFollowUpObserverExecute, DeleteFollowUpObserverCanExecute);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
