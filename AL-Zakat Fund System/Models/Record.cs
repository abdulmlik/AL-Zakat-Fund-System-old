using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Zakat_Fund_System.Models
{
    class Record : BindableBase
    {

        #region private Member

        protected string _ID;
        protected DateTime _RDate;
        protected byte _RStatus;
        protected long _Scribe_ssn;
        protected string _Indigent_ssn;
        protected int _Office_no;


        private string _RStatus2;

        protected string _Name1;
        protected string _Name2;
        protected string _Name3;

        private string _Scribe_ssn2;
        private string _Office_no2;

        private string _TempID;

        #endregion

        #region public properties

        public string ID
        {
            get { return _ID; }
            set { SetProperty(ref _ID, value); }
        }
        public DateTime RDate
        {
            get { return _RDate; }
            set { SetProperty(ref _RDate, value); }
        }
        public byte RStatus
        {
            get { return _RStatus; }
            set { SetProperty(ref _RStatus, value); }
        }
        public string Indigent_ssn
        {
            get { return _Indigent_ssn; }
            set { SetProperty(ref _Indigent_ssn, value); }
        }
        public long Scribe_ssn
        {
            get { return _Scribe_ssn; }
            set { SetProperty(ref _Scribe_ssn, value); }
        }
        public int Office_no
        {
            get { return _Office_no; }
            set { SetProperty(ref _Office_no, value); }
        }

        public string RStatus2
        {
            get { return _RStatus2; }
            set { SetProperty(ref _RStatus2, value); }
        }

        public string Name1
        {
            get { return _Name1; }
            set { SetProperty(ref _Name1, value); }
        }
        public string Name2
        {
            get { return _Name2; }
            set { SetProperty(ref _Name2, value); }
        }
        public string Name3
        {
            get { return _Name3; }
            set { SetProperty(ref _Name3, value); }
        }
        public string Office_no2
        {
            get { return _Office_no2; }
            set { SetProperty(ref _Office_no2, value); }
        }
        public string Scribe_ssn2
        {
            get { return _Scribe_ssn2; }
            set { SetProperty(ref _Scribe_ssn2, value); }
        }
        public string TempID
        {
            get { return _TempID; }
            set { SetProperty(ref _TempID, value); }
        }

        #endregion

        #region Construct

        #region Construct without parameter
        public Record()
        {

        }
        #endregion

        #region Construct all parameter
        /// <summary>
        /// Construct all parameter
        /// </summary>
        /// <param name="ID_"></param>
        /// <param name="RDate_"></param>
        /// <param name="RStatus_"></param>
        /// <param name="Indigent_ssn_"></param>
        /// <param name="Office_no_"></param>
        public Record(string ID_, DateTime RDate_, byte RStatus_, long Scribe_ssn_, string Indigent_ssn_, int Office_no_)
        {
            this.ID = ID_;
            this.RDate = RDate_;
            this.RStatus = RStatus_;
            this.Scribe_ssn = Scribe_ssn_;
            this.Indigent_ssn = Indigent_ssn_;
            this.Office_no = Office_no_;
        }
        #endregion

        #endregion
    }
}
