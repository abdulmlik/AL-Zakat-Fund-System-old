using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_Zakat_Fund_System.Models;
using Prism.Mvvm;

namespace AL_Zakat_Fund_System.ViewModels
{
    class AddNewZakatViewModel : BindableBase
    {
        #region private Member
        Zakat zakat = new Zakat();
        #endregion

        #region public properties
        public int Zakat_id
        {
            get { return zakat.Zakat_id; }
            set { SetProperty(ref zakat.Zakat_id, value); }
        }

        public string Name
        {
            get { return zakat.Name; }
            set { SetProperty(ref zakat.Name, value); }
        }

        public string Address
        {
            get { return zakat.Address; }
            set { SetProperty(ref zakat.Address, value); }
        }

        public DateTime SDate
        {
            get { return zakat.SDate; }
            set { SetProperty(ref zakat.SDate, value); }
        }

        public decimal Amount
        {
            get { return zakat.Amount; }
            set { SetProperty(ref zakat.Amount, value); }
        }

        public int ReceiptNO
        {
            get { return zakat.ReceiptNO; }
            set { SetProperty(ref zakat.ReceiptNO, value); }
        }

        public byte ZType
        {
            get { return zakat.ZType; }
            set { SetProperty(ref zakat.ZType, value); }
        }

        public string ZCalss
        {
            get { return zakat.ZCalss; }
            set { SetProperty(ref zakat.ZCalss, value); }
        }

        public int InstrumentNo
        {
            get { return zakat.InstrumentNo; }
            set { SetProperty(ref zakat.InstrumentNo, value); }
        }

        public string Phone
        {
            get { return zakat.Phone; }
            set { SetProperty(ref zakat.Phone, value); }
        }

        public string Email
        {
            get { return zakat.Email; }
            set { SetProperty(ref zakat.Email, value); }
        }

        public byte CaseDeposit
        {
            get { return zakat.CaseDeposit; }
            set { SetProperty(ref zakat.CaseDeposit, value); }
        }
        public bool Convrsion
        {
            get { return zakat.Convrsion; }
            set { SetProperty(ref zakat.Convrsion, value); }
        }
        public long Emp_ssn
        {
            get { return zakat.Emp_ssn; }
            set { SetProperty(ref zakat.Emp_ssn, value); }
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
