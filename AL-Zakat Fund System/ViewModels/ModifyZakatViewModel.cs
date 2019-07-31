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
    class ModifyZakatViewModel : Zakat
    {
        #region private Member
        private string _globlNoPhone;
        Window CurrentWin;
        #endregion

        #region public properties

        public string GloblNoPhone
        {
            get { return _globlNoPhone; }
            set { SetProperty(ref _globlNoPhone, value); }
        }

        #endregion

        #region Delegate Command

        public DelegateCommand ModifyZakatDatabaseCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region update Zakat
        private void ModifyZakatDatabaseExecute()
        {

        }
        private bool ModifyZakatDatabaseCanExecute()
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
        public ModifyZakatViewModel(Window CW)
        {
            CurrentWin = CW;

            ModifyZakatDatabaseCommand = new DelegateCommand(ModifyZakatDatabaseExecute, ModifyZakatDatabaseCanExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
