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

        private int _ID;
        private DateTime _RDate;
        private byte _RStatus;
        private long _Indigent_ssn;
        private int _Office_no;


        #endregion

        #region public properties

        public int ID
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
        public long Indigent_ssn
        {
            get { return _Indigent_ssn; }
            set { SetProperty(ref _Indigent_ssn, value); }
        }
        public int Office_no
        {
            get { return _Office_no; }
            set { SetProperty(ref _Office_no, value); }
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
        public Record(int ID_, DateTime RDate_, byte RStatus_, long Indigent_ssn_, int Office_no_)
        {
            this.ID = ID_;
            this.RDate = RDate_;
            this.RStatus = RStatus_;
            this.Indigent_ssn = Indigent_ssn_;
            this.Office_no = Office_no_;
        }
        #endregion

        #endregion
    }
}
