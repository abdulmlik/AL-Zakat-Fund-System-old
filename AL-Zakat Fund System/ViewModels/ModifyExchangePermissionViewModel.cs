using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AL_Zakat_Fund_System.Models;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ModifyExchangePermissionViewModel : ExchangePermission
    {
        #region private Member
        Window CurrentWin;
        #endregion

        #region public properties

        #endregion

        #region Delegate Command
        public DelegateCommand updateExchangePermissionDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        #endregion

        #region Execute and CanExecute Functions

        #region update Exchange Permission
        private void updateExchangePermissionDatabaseExecute()
        {

        }
        private bool updateExchangePermissionDatabaseCanExecute()
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
        public ModifyExchangePermissionViewModel(Window CW)
        {
            CurrentWin = CW;

            updateExchangePermissionDatabaseCommand = new DelegateCommand(updateExchangePermissionDatabaseExecute, updateExchangePermissionDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);

        }
        #endregion
    }
}
