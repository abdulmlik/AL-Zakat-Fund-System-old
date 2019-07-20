using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Zakat_Fund_System.Models
{
    class Indigent : BindableBase
    {

        #region private Member

        private long _Ssn;
        private byte _RequestStatus;
        private string _FullName;
        private string _MName;
        private DateTime _BirthDate;
        private string _PlaceOfBirth;
        private string _TypeAssistance;
        private byte _SocialStatus;
        private string _Nationality;
        private int _BrochureFamilyNO;
        private DateTime _BFDate;
        private string _BFPlace;
        private int _FamilyPaperNO;
        private int _PersonalCardNO;
        private int _PassportNO;
        private string _Address;
        private string _Street;
        private string _NearestMosque;
        private string _Phone;
        private string _Email;
        private string _Job;
        private decimal _Salary;
        private string _SourceOFSalary;
        private byte _HousingCase;
        private byte _TypeHousing;
        private byte _Transportation;
        private byte _TCase;
        private string _LSComment;
        private byte _ChronicDisease;
        private string _HSComment;
        private bool _Gender;
        private long _Emp_ssn;
        private int _Office_no;

        #endregion

        #region public properties

        public long Ssn
        {
            get { return _Ssn; }
            set { SetProperty(ref _Ssn, value); }
        }
        public byte RequestStatus
        {
            get { return _RequestStatus; }
            set { SetProperty(ref _RequestStatus, value); }
        }
        public string FullName
        {
            get { return _FullName; }
            set { SetProperty(ref _FullName, value); }
        }
        public string MName
        {
            get { return _MName; }
            set { SetProperty(ref _MName, value); }
        }
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { SetProperty(ref _BirthDate, value); }
        }
        public string PlaceOfBirth
        {
            get { return _PlaceOfBirth; }
            set { SetProperty(ref _PlaceOfBirth, value); }
        }
        public string TypeAssistance
        {
            get { return _TypeAssistance; }
            set { SetProperty(ref _TypeAssistance, value); }
        }
        public byte SocialStatus
        {
            get { return _SocialStatus; }
            set { SetProperty(ref _SocialStatus, value); }
        }
        public string Nationality
        {
            get { return _Nationality; }
            set { SetProperty(ref _Nationality, value); }
        }
        public int BrochureFamilyNO
        {
            get { return _BrochureFamilyNO; }
            set { SetProperty(ref _BrochureFamilyNO, value); }
        }
        public DateTime BFDate
        {
            get { return _BFDate; }
            set { SetProperty(ref _BFDate, value); }
        }
        public string BFPlace
        {
            get { return _BFPlace; }
            set { SetProperty(ref _BFPlace, value); }
        }
        public int FamilyPaperNO
        {
            get { return _FamilyPaperNO; }
            set { SetProperty(ref _FamilyPaperNO, value); }
        }
        public int PersonalCardNO
        {
            get { return _PersonalCardNO; }
            set { SetProperty(ref _PersonalCardNO, value); }
        }
        public int PassportNO
        {
            get { return _PassportNO; }
            set { SetProperty(ref _PassportNO, value); }
        }
        public string Address
        {
            get { return _Address; }
            set { SetProperty(ref _Address, value); }
        }
        public string Street
        {
            get { return _Street; }
            set { SetProperty(ref _Street, value); }
        }
        public string NearestMosque
        {
            get { return _NearestMosque; }
            set { SetProperty(ref _NearestMosque, value); }
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
        public string Job
        {
            get { return _Job; }
            set { SetProperty(ref _Job, value); }
        }
        public decimal Salary
        {
            get { return _Salary; }
            set { SetProperty(ref _Salary, value); }
        }
        public string SourceOFSalary
        {
            get { return _SourceOFSalary; }
            set { SetProperty(ref _SourceOFSalary, value); }
        }   
        public byte HousingCase
        {
            get { return _HousingCase; }
            set { SetProperty(ref _HousingCase, value); }
        }
        public byte TypeHousing
        {
            get { return _TypeHousing; }
            set { SetProperty(ref _TypeHousing, value); }
        }
        public byte Transportation
        {
            get { return _Transportation; }
            set { SetProperty(ref _Transportation, value); }
        }
        public byte TCase
        {
            get { return _TCase; }
            set { SetProperty(ref _TCase, value); }
        }
        public string LSComment
        {
            get { return _LSComment; }
            set { SetProperty(ref _LSComment, value); }
        }
        public byte ChronicDisease
        {
            get { return _ChronicDisease; }
            set { SetProperty(ref _ChronicDisease, value); }
        }
        public string HSComment
        {
            get { return _HSComment; }
            set { SetProperty(ref _HSComment, value); }
        }
        public bool Gender
        {
            get { return _Gender; }
            set { SetProperty(ref _Gender, value); }
        }
        public long Emp_ssn
        {
            get { return _Emp_ssn; }
            set { SetProperty(ref _Emp_ssn, value); }
        }
        public int Office_no
        {
            get { return _Office_no; }
            set { SetProperty(ref _Office_no, value); }
        }

        #endregion

        #region Construct

        #region Construct without parameter
        public Indigent()
        {

        }
        #endregion

        #region Construct all parameters

        /// <summary>
        ///  Construct parameter
        /// </summary>
        /// <param name="Ssn_"></param>
        /// <param name="RequestStatus_"></param>
        /// <param name="FullName_"></param>
        /// <param name="MName_"></param>
        /// <param name="BirthDate_"></param>
        /// <param name="PlaceOfBirth_"></param>
        /// <param name="TypeAssistance_"></param>
        /// <param name="SocialStatus_"></param>
        /// <param name="Nationality_"></param>
        /// <param name="BrochureFamilyNO_"></param>
        /// <param name="BFDate_"></param>
        /// <param name="BFPlace_"></param>
        /// <param name="FamilyPaperNO_"></param>
        /// <param name="PersonalCardNO_"></param>
        /// <param name="PassportNO_"></param>
        /// <param name="Address_"></param>
        /// <param name="Street_"></param>
        /// <param name="NearestMosque_"></param>
        /// <param name="Phone_"></param>
        /// <param name="Email_"></param>
        /// <param name="Job_"></param>
        /// <param name="Salary_"></param>
        /// <param name="SourceOFSalary_"></param>
        /// <param name="HousingCase_"></param>
        /// <param name="TypeHousing_"></param>
        /// <param name="Transportation_"></param>
        /// <param name="TCase_"></param>
        /// <param name="LSComment_"></param>
        /// <param name="ChronicDisease_"></param>
        /// <param name="HSComment_"></param>
        /// <param name="Gender_"></param>
        /// <param name="Emp_ssn_"></param>
        /// <param name="Office_no_"></param>
        public Indigent(long Ssn_, byte RequestStatus_, string FullName_, string MName_, DateTime BirthDate_, string PlaceOfBirth_, string TypeAssistance_, byte SocialStatus_, string Nationality_, int BrochureFamilyNO_, DateTime BFDate_, string BFPlace_, int FamilyPaperNO_, int PersonalCardNO_, int PassportNO_, string Address_, string Street_, string NearestMosque_, string Phone_, string Email_, string Job_, decimal Salary_, string SourceOFSalary_, byte HousingCase_, byte TypeHousing_, byte Transportation_, byte TCase_, string LSComment_, byte ChronicDisease_, string HSComment_, bool Gender_, long Emp_ssn_, int Office_no_)
        {
            this.Ssn = Ssn_;
            this.RequestStatus = RequestStatus_;
            this.FullName = FullName_;
            this.MName = MName_;
            this.BirthDate = BirthDate_;
            this.PlaceOfBirth = PlaceOfBirth_;
            this.TypeAssistance = TypeAssistance_;
            this.SocialStatus = SocialStatus_;
            this.Nationality = Nationality_;
            this.BrochureFamilyNO = BrochureFamilyNO_;
            this.BFDate = BFDate_;
            this.BFPlace = BFPlace_;
            this.FamilyPaperNO = FamilyPaperNO_;
            this.PersonalCardNO = PersonalCardNO_;
            this.PassportNO = PassportNO_;
            this.Address = Address_;
            this.Street = Street_;
            this.NearestMosque = NearestMosque_;
            this.Phone = Phone_;
            this.Email = Email_;
            this.Job = Job_;
            this.Salary = Salary_;
            this.SourceOFSalary = SourceOFSalary_;
            this.HousingCase = HousingCase_;
            this.TypeHousing = TypeHousing_;
            this.Transportation = Transportation_;
            this.TCase = TCase_;
            this.LSComment = LSComment_;
            this.ChronicDisease = ChronicDisease_;
            this.HSComment = HSComment_;
            this.Gender = Gender_;
            this.Emp_ssn = Emp_ssn_;
            this.Office_no = Office_no_;
        }
        #endregion

        #endregion

    }
}
