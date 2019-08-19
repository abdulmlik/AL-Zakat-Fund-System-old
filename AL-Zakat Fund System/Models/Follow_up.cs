using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Zakat_Fund_System.Models
{
    class Follow_up : BindableBase
    {
        #region private Member
        
        protected string _DecisionNO;
        protected DateTime? _LastConnection;
        protected string _Notice;
        protected string _Comment;
        protected DateTime _ReceivedDate;
        protected DateTime? _VisitDate;
        protected DateTime? _DeliverDate;
        protected byte _Distance;
        protected byte _FStatus;
        protected string _Observer_ssn;
        protected long _Scribe_ssn;

        private string _LastConnection2;
        private string _VisitDate2;
        private string _DeliverDate2;
        private string _Distance2;
        private string _FStatus2;
        private string _fullname;
        private string _Scribe_ssn2;
        private string _Phone;
        private string _Office; 
        #endregion

        #region public properties

        public string DecisionNO
        {
            get { return _DecisionNO; }
            set { SetProperty(ref _DecisionNO, value); }
        }
        public DateTime? LastConnection
        {
            get { return _LastConnection; }
            set { SetProperty(ref _LastConnection, value); }
        }
        public string Notice
        {
            get { return _Notice; }
            set { SetProperty(ref _Notice, value); }
        }
        public string Comment
        {
            get { return _Comment; }
            set { SetProperty(ref _Comment, value); }
        }
        public DateTime ReceivedDate
        {
            get { return _ReceivedDate; }
            set { SetProperty(ref _ReceivedDate, value); }
        }
        public DateTime? VisitDate
        {
            get { return _VisitDate; }
            set { SetProperty(ref _VisitDate, value); }
        }
        public DateTime? DeliverDate
        {
            get { return _DeliverDate; }
            set { SetProperty(ref _DeliverDate, value); }
        }
        public byte Distance
        {
            get { return _Distance; }
            set { SetProperty(ref _Distance, value); }
        }
        public byte FStatus
        {
            get { return _FStatus; }
            set { SetProperty(ref _FStatus, value); }
        }
        public string Observer_ssn
        {
            get { return _Observer_ssn; }
            set { SetProperty(ref _Observer_ssn, value); }
        }
        public long Scribe_ssn
        {
            get { return _Scribe_ssn; }
            set { SetProperty(ref _Scribe_ssn, value); }
        }

        //
        public string LastConnection2
        {
            get { return _LastConnection2; }
            set { SetProperty(ref _LastConnection2, value); }
        }
        public string VisitDate2
        {
            get { return _VisitDate2; }
            set { SetProperty(ref _VisitDate2, value); }
        }
        public string DeliverDate2
        {
            get { return _DeliverDate2; }
            set { SetProperty(ref _DeliverDate2, value); }
        }
        public string Distance2
        {
            get { return _Distance2; }
            set { SetProperty(ref _Distance2, value); }
        }
        public string FStatus2
        {
            get { return _FStatus2; }
            set { SetProperty(ref _FStatus2, value); }
        }
        public string fullname
        {
            get { return _fullname; }
            set { SetProperty(ref _fullname, value); }
        }
        public string Scribe_ssn2
        {
            get { return _Scribe_ssn2; }
            set { SetProperty(ref _Scribe_ssn2, value); }
        }
        public string Phone
        {
            get { return _Phone; }
            set { SetProperty(ref _Phone, value); }
        }
        public string Office
        {
            get { return _Office; }
            set { SetProperty(ref _Office, value); }
        }
        #endregion

        #region Construct

        #region Construct without parameter
        public Follow_up()
        {

        }
        #endregion

        #region Construct all parameter
        /// <summary>
        /// Construct all parameter
        /// </summary>
        /// <param name="DecisionNO_"></param>
        /// <param name="LastConnection_"></param>
        /// <param name="Notice_"></param>
        /// <param name="Comment_"></param>
        /// <param name="ReceivedDate_"></param>
        /// <param name="VisitDate_"></param>
        /// <param name="DeliverDate_"></param>
        /// <param name="Distance_"></param>
        /// <param name="FStatus_"></param>
        /// <param name="Observer_ssn_"></param>
        /// <param name="Scribe_ssn_"></param>
        public Follow_up(string DecisionNO_, DateTime LastConnection_, string Notice_, string Comment_, DateTime ReceivedDate_, DateTime VisitDate_, DateTime DeliverDate_, byte Distance_, byte FStatus_, string Observer_ssn_, long Scribe_ssn_)
        {
            this.DecisionNO = DecisionNO_;
            this.LastConnection = LastConnection_;
            this.Notice = Notice_;
            this.Comment = Comment_;
            this.ReceivedDate = ReceivedDate_;
            this.VisitDate = VisitDate_;
            this.DeliverDate = DeliverDate_;
            this.Distance = Distance_;
            this.FStatus = FStatus_;
            this.Observer_ssn = Observer_ssn_;
            this.Scribe_ssn = Scribe_ssn_;
        }
        #endregion

        #endregion
    }
}
