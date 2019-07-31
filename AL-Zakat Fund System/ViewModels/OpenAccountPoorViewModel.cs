using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AL_Zakat_Fund_System.Models;

namespace AL_Zakat_Fund_System.ViewModels
{
    class OpenAccountPoorViewModel : Indigent
    {
        #region private Member
        UserControl CurrentPage;
        #endregion

        #region public properties

        #endregion

        #region Delegate Command

        #endregion

        #region Execute and CanExecute Functions

        #endregion

        #region Construct
        public OpenAccountPoorViewModel(UserControl CP)
        {
            CurrentPage = CP;
        }
        #endregion
    }
}
