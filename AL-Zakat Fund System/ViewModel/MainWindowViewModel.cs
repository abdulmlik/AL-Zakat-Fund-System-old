using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using AL_Zakat_Fund_System.Views;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModel
{
    class MainWindowViewModel : BindableBase
    {

        #region name regin
        #endregion

        #region private Member

        private Window mWindow;
        private object _Page;

        #endregion

        //private object _te;
        //public object te
        //{
        //    get
        //    {
        //        return _te;
        //    }
        //    set
        //    {
        //        SetProperty(ref _te, value);
        //    }
        //}

        #region public properties
        public object Page
        {
            get { return _Page; }
            set { SetProperty(ref _Page, value); }
        }
        #endregion


        #region Delegate Command
        public DelegateCommand Command1 { get; set; }
        public DelegateCommand Command2 { get; set; }
        public DelegateCommand Command3 { get; set; }
        public DelegateCommand Command4 { get; set; }
        public DelegateCommand Command5 { get; set; }

        #endregion

        #region Execute and CanExecute Functions
        private void Execute1()
        {
            Page = new UserControl1();
        }
        private void Execute2()
        {
            Page = new UserControl2();
        }
        #endregion

        #region Construct
        /// <summary>
        /// Default Construct
        /// </summary>
        /// <param name="window"></param>
        public MainWindowViewModel(Window window)
        {
            mWindow = window;
            Page = new UserControl1();

            Command1 = new DelegateCommand(Execute1);
            Command2 = new DelegateCommand(Execute2);
        }
        #endregion
    }
}
