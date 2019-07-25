using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Mvvm;

namespace AL_Zakat_Fund_System.ViewModels
{
    class AddNewZakatViewModel : Zakat
    {
        #region private Member

        #endregion

        #region public properties
        public int Zakat_id
        {
            get { return _Zakat_id; }
            set { SetProperty(ref _Zakat_id, value); }
        }

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        public string Address
        {
            get { return _Address; }
            set { SetProperty(ref _Address, value); }
        }

        public DateTime SDate
        {
            get { return _SDate; }
            set { SetProperty(ref _SDate, value); }
        }

        public decimal? Amount
        {
            get { return _Amount; }
            set { SetProperty(ref _Amount, value); }
        }

        public int ReceiptNO
        {
            get { return _ReceiptNO; }
            set { SetProperty(ref _ReceiptNO, value); }
        }

        public byte ZType
        {
            get { return _ZType; }
            set { SetProperty(ref _ZType, value); }
        }

        public string ZCalss
        {
            get { return _ZCalss; }
            set { SetProperty(ref _ZCalss, value); }
        }

        public int InstrumentNo
        {
            get { return _InstrumentNo; }
            set { SetProperty(ref _InstrumentNo, value); }
        }

        public string Phone
        {
            get { return _Phone; }
            set { SetProperty(ref _Phone, value); }
        }

        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        public byte CaseDeposit
        {
            get { return _CaseDeposit; }
            set { SetProperty(ref _CaseDeposit, value); }
        }

        public bool Convrsion
        {
            get { return _Convrsion; }
            set { SetProperty(ref _Convrsion, value); }
        }

        public long Emp_ssn
        {
            get { return _Emp_ssn; }
            set { SetProperty(ref _Emp_ssn, value); }
        }
        #endregion

        #region Delegate Command

        #endregion

        #region Execute and CanExecute Functions

        #endregion

        #region Construct

        #endregion
    }
}
