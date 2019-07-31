using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AL_Zakat_Fund_System.Models;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class EditFollowUpViewModel : Follow_up
    {
        #region private Member
        Window CurrentWin;
        #endregion

        #region public properties

        #endregion

        #region Delegate Command

        public DelegateCommand UpdateFollowUPDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region update follow-UP
        private void UpdateFollowUPDatabaseExecute()
        {

        }
        private bool UpdateFollowUPDatabaseCanExecute()
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
        public EditFollowUpViewModel(Window CW)
        {

            CurrentWin = CW;

            UpdateFollowUPDatabaseCommand = new DelegateCommand(UpdateFollowUPDatabaseExecute, UpdateFollowUPDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
