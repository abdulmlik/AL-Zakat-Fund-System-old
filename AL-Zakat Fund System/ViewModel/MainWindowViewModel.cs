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
        public MainWindowViewModel()
        {
            _Page = new UserControl1();
            
            click_1 = new DelegateCommand(cPage);
            click_2 = new DelegateCommand(cPage2);
        }

        public UserControl1ViewModel p1 = new UserControl1ViewModel();
        public UserControl2ViewModel p2 = new UserControl2ViewModel();


        private object _Page;
        public object fff
        {
            get
            {
                return _Page;
            }
            set
            {
                SetProperty(ref _Page, value);
                _Page = value;
            }
        }

        private object _te;
        public object te
        {
            get
            {
                return _te;
            }
            set
            {
                SetProperty(ref _te, value);
            }
        }

        public DelegateCommand click_1 { get; set; }
        public DelegateCommand click_2 { get; set; }

        private void cPage()
        {
            fff = new UserControl1();
        }
        private void cPage2()
        {
            fff = new UserControl2();
        }

    }
}
