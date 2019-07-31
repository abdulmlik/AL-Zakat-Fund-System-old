using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using AL_Zakat_Fund_System.Views;

namespace AL_Zakat_Fund_System.ViewModels
{
    class AddNewZakatViewModel : Zakat
    {
        #region private Member
        private string _globlNoPhone;
        UserControl CurrentPage;
        #endregion

        #region public properties

        public string GloblNoPhone
        {
            get { return _globlNoPhone; }
            set { SetProperty(ref _globlNoPhone, value); }
        }

        #endregion

        #region Delegate Command

        public DelegateCommand AddZakatDatabaseCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region save Zakat
        private void AddZakatDatabaseExecute()
        {

        }
        private bool AddZakatDatabaseCanExecute()
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
            Name = "";
            Address = "";
            SDate = DateTime.Now;
            Amount = "";
            ReceiptNO = "";
            ZType = 0;
            ZCalss = "";
            InstrumentNo = "";
            Phone = "";
            GloblNoPhone = "218";
            Email ="";

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
        public AddNewZakatViewModel(UserControl CP)
        {
            CurrentPage = CP;

            ZType = 0;
            GloblNoPhone = "218";
            SDate = DateTime.Now;

            AddZakatDatabaseCommand = new DelegateCommand(AddZakatDatabaseExecute,AddZakatDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
