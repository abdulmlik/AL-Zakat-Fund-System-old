using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AL_Zakat_Fund_System.Views;

namespace AL_Zakat_Fund_System.ViewModels
{
    class NumberZakatViewModel
    {
        //    public CrystalDecisions.CrystalReports.Engine.ReportDocument Report { get; set; }

        #region private Member
            
        Window CurrentWindow;

        public CrystalDecisions.CrystalReports.Engine.ReportDocument MyReportSource { get; set; }
        
        #endregion

        #region public properties

        #endregion

        #region Delegate Command

        #endregion

        #region Execute and CanExecute Functions


        #region Cancel
        private void CancelExecute()
        {
            CurrentWindow.Close();// close window
        }
        #endregion

        #endregion

        #region Construct
        public NumberZakatViewModel(Window CW)
        {
            CurrentWindow = CW;
        }

        #endregion
    }
}
