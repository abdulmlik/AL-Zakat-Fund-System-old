using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Zakat_Fund_System.Models
{
    class Zakat : BindableBase
    {

        #region private Member

        protected int _Zakat_id;
        protected string _Name;
        protected string _Address;
        protected DateTime _SDate;
        protected string _Amount;
        protected string _ReceiptNO;
        protected byte _ZType;
        protected string _ZCalss;
        protected string _InstrumentNo;
        protected string _Phone;
        protected string _Email;
        protected byte _CaseDeposit;
        protected bool _Convrsion;
        protected long _Emp_ssn;

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

        public string Amount
        {
            get { return _Amount; }
            set { SetProperty(ref _Amount, value); }
        }

        public string ReceiptNO
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

        public string InstrumentNo
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

        #region Construct

        #region Construct without parameter
        public Zakat()
        {

        }
        #endregion

        #region Construct all parameter
        /// <summary>
        /// Construct all parameter
        /// </summary>
        /// <param name="Zakat_id_"></param>
        /// <param name="Name_"></param>
        /// <param name="Address_"></param>
        /// <param name="SDate_"></param>
        /// <param name="Amount_"></param>
        /// <param name="ReceiptNO_"></param>
        /// <param name="ZType_"></param>
        /// <param name="ZCalss_"></param>
        /// <param name="InstrumentNo_"></param>
        /// <param name="Phone_"></param>
        /// <param name="Email_"></param>
        /// <param name="CaseDeposit_"></param>
        /// <param name="Convrsion_"></param>
        /// <param name="Emp_ssn_"></param>
        public Zakat(int Zakat_id_, string Name_, string Address_, DateTime SDate_, string Amount_, string ReceiptNO_, byte ZType_, string ZCalss_, string InstrumentNo_, string Phone_, string Email_, byte CaseDeposit_, bool Convrsion_, long Emp_ssn_)
        {
            this.Zakat_id = Zakat_id_;
            this.Name = Name_;
            this.Address = Address_;
            this.SDate = SDate_;
            this.Amount = Amount_;
            this.ReceiptNO = ReceiptNO_;
            this.ZType = ZType_;
            this.ZCalss = ZCalss_;
            this.InstrumentNo = InstrumentNo_;
            this.Phone = Phone_;
            this.Email = Email_;
            this.CaseDeposit = CaseDeposit_;
            this.Convrsion = Convrsion_;
            this.Emp_ssn = Emp_ssn_;
        }
        #endregion

        #endregion
    }
}
