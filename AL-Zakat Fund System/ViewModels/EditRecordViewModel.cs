using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class EditRecordViewModel : Record
    {
        #region private Member

        private string _Name1;
        private string _Name2;
        private string _Name3;

        Window CurrentWin;

        #endregion

        #region public properties
        public string Name1
        {
            get { return _Name1; }
            set { SetProperty(ref _Name1, value); }
        }
        public string Name2
        {
            get { return _Name2; }
            set { SetProperty(ref _Name2, value); }
        }
        public string Name3
        {
            get { return _Name3; }
            set { SetProperty(ref _Name3, value); }
        }
        #endregion

        #region Delegate Command

        public DelegateCommand UPdateRecordPoorDatabaesCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region update Record
        private void UPdateRecordPoorDatabaesExecute()
        {

        }
        private bool UPdateRecordPoorDatabaesCanExecute()
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
        public EditRecordViewModel(Window CW)
        {

            CurrentWin = CW;

            UPdateRecordPoorDatabaesCommand = new DelegateCommand(UPdateRecordPoorDatabaesExecute, UPdateRecordPoorDatabaesCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion
    }
}
