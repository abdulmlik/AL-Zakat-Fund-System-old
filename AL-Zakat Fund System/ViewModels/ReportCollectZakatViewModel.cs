﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ReportCollectZakatViewModel : BindableBase
    {
        #region private Member

        Window CurrentWindow;

        private DateTime _StartDate;
        private DateTime _EndDate;

        public CrystalDecisions.CrystalReports.Engine.ReportDocument MyReportSource { get; set; }


        #endregion

        #region private Function



        #endregion

        #region public properties

        public DateTime StartDate
        {
            get { return _StartDate; }
            set { SetProperty(ref _StartDate, value); }
        }
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { SetProperty(ref _EndDate, value); }
        }

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
        public ReportCollectZakatViewModel(Window CW)
        {
            CurrentWindow = CW;
        }

        #endregion
    }
}
