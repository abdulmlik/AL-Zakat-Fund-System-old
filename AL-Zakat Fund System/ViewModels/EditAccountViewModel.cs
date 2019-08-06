using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class EditAccountViewModel : Indigent
    {
        #region private Member

        Window CurrentWin;
        #endregion

        #region public properties

        #endregion

        #region Delegate Command

        public DelegateCommand UPdateAccountPoorDatabaesCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region update Account
        private void UPdateAccountPoorDatabaesExecute()
        {

        }
        private bool UPdateAccountPoorDatabaesCanExecute()
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
        public EditAccountViewModel(Window CW)
        {

            CurrentWin = CW;

            UPdateAccountPoorDatabaesCommand = new DelegateCommand(UPdateAccountPoorDatabaesExecute, UPdateAccountPoorDatabaesCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion
    }
}
