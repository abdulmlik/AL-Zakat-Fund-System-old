using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;


namespace AL_Zakat_Fund_System.Models
{
    class Employee : BindableBase
    {
        #region private Member
        private string _UserName;
        private string _Password;
        private string _Lname;
        private string _Address;
        private string _Phone;
        private string _Email;
        private int _degree;
        private DateTime _BirthDate;
        private bool _StillWorking;
        private int _Job;
        private int _Manager;
        private string _Deprtment;
        private string _Office;
        #endregion

        #region public properties
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }

        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        public string Lname
        {
            get { return _Lname; }
            set { SetProperty(ref _Lname, value); }
        }

        public string Address
        {
            get { return _Address; }
            set { SetProperty(ref _Address, value); }
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

        public int Degree
        {
            get { return _degree; }
            set { SetProperty(ref _degree, value); }
        }

        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { SetProperty(ref _BirthDate, value); }
        }

        public bool StillWorking
        {
            get { return _StillWorking; }
            set { SetProperty(ref _StillWorking, value); }
        }

        public int Job
        {
            get { return _Job; }
            set { SetProperty(ref _Job, value); }
        }

        public int Manager
        {
            get { return _Manager; }
            set { SetProperty(ref _Manager, value); }
        }

        public string Deprtment
        {
            get { return _Deprtment; }
            set { SetProperty(ref _Deprtment, value); }
        }

        public string Office
        {
            get { return _Office; }
            set { SetProperty(ref _Office, value); }
        }
        #endregion
    }
}
