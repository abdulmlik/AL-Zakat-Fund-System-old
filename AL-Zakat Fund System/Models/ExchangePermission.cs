using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Zakat_Fund_System.Models
{
    class ExchangePermission : BindableBase
    {
        #region private Member

        protected string _CommitteeDecisionNO;
        protected byte _CategoryPoor;
        protected string _TypeAssistance;
        protected string _Amount;
        protected DateTime _SDate;
        protected string _InstrumentNO;
        protected string _Indigent_ssn;

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
        public string Indigent_ssn
        {
            get { return _Indigent_ssn; }
            set { SetProperty(ref _Indigent_ssn, value); }
        }

        #endregion

        #region Construct

        #region Construct without parameter
        public ExchangePermission()
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
        public ExchangePermission(string CommitteeDecisionNO_, byte CategoryPoor_, string TypeAssistance_, string Amount_, DateTime SDate_, string InstrumentNO_, string Indigent_ssn_)
        {
            this.CommitteeDecisionNO = CommitteeDecisionNO_;
            this.CategoryPoor = CategoryPoor_;
            this.TypeAssistance = TypeAssistance_;
            this.Amount = Amount_;
            this.SDate = SDate_;
            this.InstrumentNO = InstrumentNO_;
            this.Indigent_ssn = Indigent_ssn_;
        }
        #endregion

        #endregion
    }
}
