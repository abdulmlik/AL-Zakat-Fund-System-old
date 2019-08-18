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
    class ViewFollowUpDataViewModel : Follow_up
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

        public DelegateCommand SearchFollowUpCommand { get; set; }
        public DelegateCommand EditFollowUpCommand { get; set; }
        public DelegateCommand ViewFollowUpCommand { get; set; }
        public DelegateCommand DeleteFollowUpCommand { get; set; }

        public DelegateCommand FirstCommand { get; set; }
        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand LastCommand { get; set; }



        #endregion

        #region Execute and CanExecute Functions

        #region Search FollowUp
        private void SearchFollowUpExecute()
        {

        }
        private bool SearchFollowUpCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Edit FollowUp
        private void EditFollowUpExecute()
        {

        }
        private bool EditFollowUpCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region view FollowUp
        private void ViewFollowUpExecute()
        {

        }
        private bool ViewFollowUpCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion
        #region Delete FollowUp
        private void DeleteFollowUpExecute()
        {

        }
        private bool DeleteFollowUpCanExecute()
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
        public ViewFollowUpDataViewModel(UserControl CP)
        {
            CurrentPage = CP;


            SearchFollowUpCommand = new DelegateCommand(SearchFollowUpExecute, SearchFollowUpCanExecute);
            EditFollowUpCommand = new DelegateCommand(EditFollowUpExecute, EditFollowUpCanExecute);
            ViewFollowUpCommand = new DelegateCommand(ViewFollowUpExecute, ViewFollowUpCanExecute);
            DeleteFollowUpCommand = new DelegateCommand(DeleteFollowUpExecute, DeleteFollowUpCanExecute);

            CancelCommand = new DelegateCommand(CancelExecute);

            FirstCommand = new DelegateCommand(FirstExecute);
            PreviousCommand = new DelegateCommand(PreviousExecute);
            NextCommand = new DelegateCommand(NextExecute);
            LastCommand = new DelegateCommand(LastExecute);
        }

        #endregion
    }
}
