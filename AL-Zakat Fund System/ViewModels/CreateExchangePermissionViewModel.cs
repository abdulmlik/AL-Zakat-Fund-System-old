using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System.Windows.Controls;

namespace AL_Zakat_Fund_System.ViewModels
{
    class CreateExchangePermissionViewModel : ExchangePermission
    {
        #region private Member
        UserControl CurrentPage;
        #endregion

        #region public properties
        
        #endregion

        #region Delegate Command
        public DelegateCommand CreateExchangePermissionDatabaseCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        #endregion

        #region Execute and CanExecute Functions

        #region save Exchange Permission
        private void CreateExchangePermissionDatabaseExecute()
        {

        }
        private bool CreateExchangePermissionDatabaseCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion

        #region Reset
        private void ResetExecute()
        {
            SDate = DateTime.Now;
            Amount = "";
            CommitteeDecisionNO = "";
            CategoryPoor = 0;
            TypeAssistance = "";
            InstrumentNO = "";
            RecrodID = "";

        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            CurrentPage.Content = null;
        }
        #endregion

        #endregion

        #region Construct
        public CreateExchangePermissionViewModel(UserControl CP)
        {
            CurrentPage = CP;

            CategoryPoor = 0;
            SDate = DateTime.Now;

            CreateExchangePermissionDatabaseCommand = new DelegateCommand(CreateExchangePermissionDatabaseExecute, CreateExchangePermissionDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);

        }
        #endregion
    }
}
