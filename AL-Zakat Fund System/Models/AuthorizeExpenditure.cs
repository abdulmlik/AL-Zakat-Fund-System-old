using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Zakat_Fund_System.Models
{
    class AuthorizeExpenditure : BindableBase
    {
        #region private Member

        protected string _CommitteeDecisionNO;
        protected byte _CategoryPoor;
        protected string _TypeAssistance;
        protected string _Amount;
        protected DateTime _SDate;
        protected string _InstrumentNO;
        protected long _Courier_ssn;
        protected string _Record_id;
        private string _Comment;

        private string _CategoryPoor2;
        private string _FullName;
        private string _InstrumentNO2;
        private string _Courier_ssn2;
        private string _TempCDN;
        #endregion

        #region public properties

        public string CommitteeDecisionNO
        {
            get { return _CommitteeDecisionNO; }
            set { SetProperty(ref _CommitteeDecisionNO, value); }
        }
        public byte CategoryPoor
        {
            get { return _CategoryPoor; }
            set { SetProperty(ref _CategoryPoor, value); }
        }
        public string CategoryPoor2
        {
            get { return _CategoryPoor2; }
            set { SetProperty(ref _CategoryPoor2, value); }
        }
        public string TypeAssistance
        {
            get { return _TypeAssistance; }
            set { SetProperty(ref _TypeAssistance, value); }
        }
        public string Amount
        {
            get { return _Amount; }
            set { SetProperty(ref _Amount, value); }
        }
        public DateTime SDate
        {
            get { return _SDate; }
            set { SetProperty(ref _SDate, value); }
        }
        public string InstrumentNO
        {
            get { return _InstrumentNO; }
            set { SetProperty(ref _InstrumentNO, value); }
        }
        public string Comment
        {
            get { return _Comment; }
            set { SetProperty(ref _Comment, value); }
        }
        public long Courier_ssn
        {
            get { return _Courier_ssn; }
            set { SetProperty(ref _Courier_ssn, value); }
        }
        public string Record_id
        {
            get { return _Record_id; }
            set { SetProperty(ref _Record_id, value); }
        }
        public string FullName
        {
            get { return _FullName; }
            set { SetProperty(ref _FullName, value); }
        }
        public string Courier_ssn2
        {
            get { return _Courier_ssn2; }
            set { SetProperty(ref _Courier_ssn2, value); }
        }
        public string InstrumentNO2
        {
            get { return _InstrumentNO2; }
            set { SetProperty(ref _InstrumentNO2, value); }
        }
        public string TempCDN
        {
            get { return _TempCDN; }
            set { SetProperty(ref _TempCDN, value); }
        }
        
        #endregion

        #region Construct

        #region Construct without parameter
        public AuthorizeExpenditure()
        {

        }
        #endregion

        #region Construct all parameter
        /// <summary>
        /// Construct all parameter
        /// </summary>
        /// <param name="CommitteeDecisionNO_"></param>
        /// <param name="CategoryPoor_"></param>
        /// <param name="TypeAssistance_"></param>
        /// <param name="Amount_"></param>
        /// <param name="SDate_"></param>
        /// <param name="InstrumentNO_"></param>
        /// <param name="Indigent_ssn_"></param>
        public AuthorizeExpenditure(string CommitteeDecisionNO_, byte CategoryPoor_, string TypeAssistance_, string Amount_, DateTime SDate_, string InstrumentNO_, string RecrodID_)
        {
            this.CommitteeDecisionNO = CommitteeDecisionNO_;
            this.CategoryPoor = CategoryPoor_;
            this.TypeAssistance = TypeAssistance_;
            this.Amount = Amount_;
            this.SDate = SDate_;
            this.InstrumentNO = InstrumentNO_;
            this.Record_id = RecrodID_;
        }
        #endregion

        #endregion
    }

    // class use to get data for report
    class AuthorizeExpenditureTemp : BindableBase
    {
        #region private Member

        private byte _CategoryPoor;
        private decimal _Amount;
        private DateTime _SDate;
        private bool _InstrumentNO;
        private long? _Record_id;

        #endregion

        #region public properties
        public byte CategoryPoor
        {
            get { return _CategoryPoor; }
            set { SetProperty(ref _CategoryPoor, value); }
        }
        public decimal Amount
        {
            get { return _Amount; }
            set { SetProperty(ref _Amount, value); }
        }
        public DateTime SDate
        {
            get { return _SDate; }
            set { SetProperty(ref _SDate, value); }
        }
        public bool InstrumentNO
        {
            get { return _InstrumentNO; }
            set { SetProperty(ref _InstrumentNO, value); }
        }
        public long? Record_id
        {
            get { return _Record_id; }
            set { SetProperty(ref _Record_id, value); }
        }

        #endregion
    }
}
