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
    class DeliverRecordViewModel : Follow_up
    {
        #region private Member
        UserControl CurrentPage;
        #endregion

        #region public properties

        #endregion

        #region Delegate Command

        public DelegateCommand DeliverRecordDatabaseCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region save Deliver Record
        private void DeliverRecordDatabaseExecute()
        {

        }
        private bool DeliverRecordDatabaseCanExecute()
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
            ReceivedDate = DateTime.Now;
            Distance = 0;
            Observer_ssn = "";
            DecisionNO = "";
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
        public DeliverRecordViewModel(UserControl CP)
        {
            CurrentPage = CP;

            ReceivedDate = DateTime.Now;
            Distance = 0;

            DeliverRecordDatabaseCommand = new DelegateCommand(DeliverRecordDatabaseExecute, DeliverRecordDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion
    }
}
