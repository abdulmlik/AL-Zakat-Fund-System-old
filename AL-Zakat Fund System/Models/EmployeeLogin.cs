using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;


namespace AL_Zakat_Fund_System.Models
{
    class EmployeeLogin : BindableBase
    {
        #region private Member
        public string _UserName;
        public string _Password;
        #endregion

        #region public properties
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        #endregion
    }
}
