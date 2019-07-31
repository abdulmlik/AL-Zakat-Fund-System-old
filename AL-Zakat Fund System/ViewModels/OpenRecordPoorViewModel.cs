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
    class OpenRecordPoorViewModel : Record
    {
        #region private Member

        private string _Name1;
        private string _Name2;
        private string _Name3;

        UserControl CurrentPage;

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

        public DelegateCommand AddRecordPoorDatabaesCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region save Record
        private void AddRecordPoorDatabaesExecute()
        {

        }
        private bool AddRecordPoorDatabaesCanExecute()
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
            Name1 = "";
            Name2 = "";
            Name3 = "";
            ID = "";
            RDate = DateTime.Now;
            RStatus = 0;
            Indigent_ssn = "";
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
        public OpenRecordPoorViewModel(UserControl CP)
        {
            CurrentPage = CP;

            RDate = DateTime.Now;
            RStatus = 0;

            AddRecordPoorDatabaesCommand = new DelegateCommand(AddRecordPoorDatabaesExecute, AddRecordPoorDatabaesCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }
        #endregion
    }
}
