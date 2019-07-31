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
        
        protected int _FU_no;
        protected byte _DecisionNO;
        protected DateTime _LastConnection;
        protected string _Notice;
        protected string _Comment;
        protected DateTime _ReceivedDate;
        protected DateTime _VisitDate;
        protected DateTime _DeliverDate;
        protected byte _Distance;
        protected byte _FStatus;
        protected string _Emp_ssn;
        protected string _Indigent_ssn;

        #endregion

        #region public properties

        public int FU_no
        {
            get { return _FU_no; }
            set { SetProperty(ref _FU_no, value); }
        }
        public byte DecisionNO
        {
            get { return _DecisionNO; }
            set { SetProperty(ref _DecisionNO, value); }
        }
        public DateTime LastConnection
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
        public DateTime VisitDate
        {
            get { return _VisitDate; }
            set { SetProperty(ref _VisitDate, value); }
        }
        public DateTime DeliverDate
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
        public string Emp_ssn
        {
            get { return _Emp_ssn; }
            set { SetProperty(ref _Emp_ssn, value); }
        }
        public string Indigent_ssn
        {
            get { return _Indigent_ssn; }
            set { SetProperty(ref _Indigent_ssn, value); }
        }

        #endregion

        #region Construct

        #region Construct without parameter
        public Follow_up()
        {

        }
        #endregion

        #region Construct all parameter
        public Follow_up(int FU_no_, byte DecisionNO_, DateTime LastConnection_, string Notice_, string Comment_, DateTime ReceivedDate_, DateTime VisitDate_, DateTime DeliverDate_, byte Distance_, byte FStatus_, string Emp_ssn_, string Indigent_ssn_)
        {
            this.FU_no = FU_no_;
            this.DecisionNO = DecisionNO_;
            this.LastConnection = LastConnection_;
            this.Notice = Notice_;
            this.Comment = Comment_;
            this.ReceivedDate = ReceivedDate_;
            this.VisitDate = VisitDate_;
            this.DeliverDate = DeliverDate_;
            this.Distance = Distance_;
            this.FStatus = FStatus_;
            this.Emp_ssn = Emp_ssn_;
            this.Indigent_ssn = Indigent_ssn_;
        }
        #endregion

        #endregion
    }
}
