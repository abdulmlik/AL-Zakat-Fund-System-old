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
        protected string _City;
        protected string _Municipality;
        protected string _Locality;
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
        protected byte _Collector;
        protected bool _Activity;
        protected bool _Migration;
        protected DateTime? _MigrationDate;
        protected long _Colle_ssn;
        protected int _Office_no;

        //temp
        protected bool _ConvrsionTemp;
        // display
        protected string _Address;
        protected string _ZType2;
        protected string _CaseDeposit2;
        protected string _Convrsion2;
        protected string _Collector2;
        protected string _Activity2;
        protected string _Migration2;
        protected string _MigrationDate2;
        protected string _Colle_ssn2;
        protected string _Office_no2;
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

        public string City
        {
            get { return _City; }
            set { SetProperty(ref _City, value); }
        }
        public string Municipality
        {
            get { return _Municipality; }
            set { SetProperty(ref _Municipality, value); }
        }
        public string Locality
        {
            get { return _Locality; }
            set { SetProperty(ref _Locality, value); }
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
        public byte Collector
        {
            get { return _Collector; }
            set { SetProperty(ref _Collector, value); }
        }

        public bool Activity
        {
            get { return _Activity; }
            set { SetProperty(ref _Activity, value); }
        }

        public bool Migration
        {
            get { return _Migration; }
            set { SetProperty(ref _Migration, value); }
        }
        public DateTime? MigrationDate
        {
            get { return _MigrationDate; }
            set { SetProperty(ref _MigrationDate, value); }
        }

        public long Colle_ssn
        {
            get { return _Colle_ssn; }
            set { SetProperty(ref _Colle_ssn, value); }
        }
        public int Office_no
        {
            get { return _Office_no; }
            set { SetProperty(ref _Office_no, value); }
        }



        //
        public bool ConvrsionTemp
        {
            get { return _ConvrsionTemp; }
            set { SetProperty(ref _ConvrsionTemp, value); }
        }

        //
        public string Address
        {
            get { return _Address; }
            set { SetProperty(ref _Address, value); }
        }
        public string ZType2
        {
            get { return _ZType2; }
            set { SetProperty(ref _ZType2, value); }
        }
        public string CaseDeposit2
        {
            get { return _CaseDeposit2; }
            set { SetProperty(ref _CaseDeposit2, value); }
        }
        public string Convrsion2
        {
            get { return _Convrsion2; }
            set { SetProperty(ref _Convrsion2, value); }
        }
        public string Collector2
        {
            get { return _Collector2; }
            set { SetProperty(ref _Collector2, value); }
        }

        public string Activity2
        {
            get { return _Activity2; }
            set { SetProperty(ref _Activity2, value); }
        }

        public string Migration2
        {
            get { return _Migration2; }
            set { SetProperty(ref _Migration2, value); }
        }
        public string MigrationDate2
        {
            get { return _MigrationDate2; }
            set { SetProperty(ref _MigrationDate2, value); }
        }
        public string Colle_ssn2
        {
            get { return _Colle_ssn2; }
            set { SetProperty(ref _Colle_ssn2, value); }
        }
        public string Office_no2
        {
            get { return _Office_no2; }
            set { SetProperty(ref _Office_no2, value); }
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
        /// <param name="City_"></param>
        /// <param name="Municipality_"></param>
        /// <param name="Locality_"></param>
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
        public Zakat(int Zakat_id_, string Name_, string City_, string Municipality_, string Locality_, DateTime SDate_, string Amount_, string ReceiptNO_, byte ZType_, string ZCalss_, string InstrumentNo_, string Phone_, string Email_, byte CaseDeposit_, bool Convrsion_, long Colle_ssn_, int Office_no_)
        {
            this.Zakat_id = Zakat_id_;
            this.Name = Name_;
            this.City = City_;
            this.Municipality = Municipality_;
            this.Locality = Locality_;
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
            this.Colle_ssn = Colle_ssn_;
            this.Office_no = Office_no_;
        }
        #endregion

        #endregion
    }

    // class use to get data for report
    class ZakatTemp : BindableBase
    {

        #region private Member

        protected DateTime _SDate;
        protected decimal _Amount;
        protected byte _Collector;
        protected DateTime? _MigrationDate;

        #endregion

        #region public properties
        
        public DateTime SDate
        {
            get { return _SDate; }
            set { SetProperty(ref _SDate, value); }
        }
        public decimal Amount
        {
            get { return _Amount; }
            set { SetProperty(ref _Amount, value); }
        }
        public byte Collector
        {
            get { return _Collector; }
            set { SetProperty(ref _Collector, value); }
        }
        public DateTime? MigrationDate
        {
            get { return _MigrationDate; }
            set { SetProperty(ref _MigrationDate, value); }
        }
        
        #endregion
        
    }
}
