using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using System.Windows.Controls;
using Prism.Commands;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class EditFollowUpObserverViewModel : Follow_up
    {
        #region private Member

        Window CurrentWin;
        private string _Indigent_name;
        private string _Indigent_ssn;

        #endregion

        #region public properties
        public string Indigent_name
        {
            get { return _Indigent_name; }
            set { SetProperty(ref _Indigent_name, value); }
        }
        public string Indigent_ssn
        {
            get { return _Indigent_ssn; }
            set { SetProperty(ref _Indigent_ssn, value); }
        }
        #endregion

        #region Delegate Command

        public DelegateCommand upDateFollowUpObserverDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region update Follow-Up
        private void upDateFollowUpObserverDatabaseExecute()
        {

        }
        private bool upDateFollowUpObserverDatabaseCanExecute()
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
            CurrentWin.Close();
        }
        #endregion

        #endregion
        
        #region Construct
        public EditFollowUpObserverViewModel(Window CW)
        {
            CurrentWin = CW;

            //Indigent_name
            //Indigent_ssn
            //LastConnection = 
            //DecisionNO
            //Notice
            //Comment


            upDateFollowUpObserverDatabaseCommand = new DelegateCommand(upDateFollowUpObserverDatabaseExecute, upDateFollowUpObserverDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion
    }
}
