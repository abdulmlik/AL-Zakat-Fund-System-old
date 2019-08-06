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

        private string _Ssn;
        private DateTime _Date;
        private byte _RequestStatus;
        private string _FName;
        private string _MName;
        private string _GName;
        private string _LName;
        private string _MotherName;
        private DateTime _BirthDate;
        private string _PlaceOfBirth;
        private string _TypeAssistance;
        private byte _SocialStatus;
        private string _Nationality;
        private string _BrochureFamilyNO;
        private DateTime _BFDate;
        private string _BFPlace;
        private string _FamilyPaperNO;
        private string _NumberOfChildren;
        private string _PersonalCardNO;
        private string _PassportNO;
        private string _City;
        private string _Municipality;
        private string _Locality;
        private string _Street;
        private string _NearestMosque;
        private string _DialCode;
        private string _Number;
        private string _Email;
        private string _Job;
        private string _Salary;
        private string _SourceOFSalary;
        private byte _HousingCase;
        private byte _TypeHousing;
        private byte _Transportation;
        private byte _TCase;
        private string _LSComment;
        private byte _ChronicDisease;
        private string _HSComment;
        private bool _Gender;
        private long _Scribe_ssn;
        private int _Office_no;

        #endregion

        #region public properties

        public string Ssn
        {
            get { return _Ssn; }
            set { SetProperty(ref _Ssn, value); }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { SetProperty(ref _Date, value); }
        }
        public byte RequestStatus
        {
            get { return _RequestStatus; }

            set { SetProperty(ref _RequestStatus, value); }
        }
        public string FName
        {
            get { return _FName; }
            set { SetProperty(ref _FName, value); }
        }
        public string MName
        {
            get { return _MName; }
            set { SetProperty(ref _MName, value); }
        }
        public string GName
        {
            get { return _GName; }
            set { SetProperty(ref _GName, value); }
        }
        public string LName
        {
            get { return _LName; }
            set { SetProperty(ref _LName, value); }
        }
        public string MotherName
        {
            get { return _MotherName; }
            set { SetProperty(ref _MotherName, value); }
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
        public string BrochureFamilyNO
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
        public string FamilyPaperNO
        {
            get { return _FamilyPaperNO; }
            set { SetProperty(ref _FamilyPaperNO, value); }
        }
        public string NumberOfChildren
        {
            get { return _NumberOfChildren; }
            set { SetProperty(ref _NumberOfChildren, value); }
        }
        public string PersonalCardNO
        {
            get { return _PersonalCardNO; }
            set { SetProperty(ref _PersonalCardNO, value); }
        }
        public string PassportNO
        {
            get { return _PassportNO; }
            set { SetProperty(ref _PassportNO, value); }
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
        public string DialCode
        {
            get { return _DialCode; }
            set { SetProperty(ref _DialCode, value); }
        }
        public string Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
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
        public string Salary
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

        #endregion

        #region Construct

        #region Construct without parameter
        public Indigent()
        {

        }
        #endregion

        #region Construct all parameters

        /// <summary>
        /// Construct all parameters
        /// </summary>
        /// <param name="Ssn_"></param>
        /// <param name="RequestStatus_"></param>
        /// <param name="FName_"></param>
        /// <param name="MName_"></param>
        /// <param name="GName_"></param>
        /// <param name="LName_"></param>
        /// <param name="MotherName_"></param>
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
        /// <param name="City_"></param>
        /// <param name="Municipality_"></param>
        /// <param name="Locality_"></param>
        /// <param name="Street_"></param>
        /// <param name="NearestMosque_"></param>
        /// <param name="DialCode_"></param>
        /// <param name="Number_"></param>
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
        /// <param name="Scribe_ssn_"></param>
        /// <param name="Office_no_"></param>
        public Indigent(string Ssn_, byte RequestStatus_, string FName_, string MName_, string GName_, string LName_, string MotherName_, DateTime BirthDate_
            , string PlaceOfBirth_, string TypeAssistance_, byte SocialStatus_, string Nationality_, string BrochureFamilyNO_, DateTime BFDate_, string BFPlace_
            , string FamilyPaperNO_, string PersonalCardNO_, string PassportNO_, string City_, string Municipality_, string Locality_, string Street_, string NearestMosque_
            , string DialCode_, string Number_, string Email_, string Job_, string Salary_, string SourceOFSalary_, byte HousingCase_, byte TypeHousing_, byte Transportation_, byte TCase_
            , string LSComment_, byte ChronicDisease_, string HSComment_, bool Gender_, long Scribe_ssn_, int Office_no_)
        {
            this.Ssn = Ssn_;
            this.RequestStatus = RequestStatus_;
            this.FName = FName_;
            this.MName = MName_;
            this.GName = GName_;
            this.LName = LName_;
            this.MotherName = MotherName_;
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
            this.City = City_;
            this.Municipality = Municipality_;
            this.Locality = Locality_;
            this.Street = Street_;
            this.NearestMosque = NearestMosque_;
            this.DialCode = DialCode_;
            this.Number = Number_;
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
            this.Scribe_ssn = Scribe_ssn_;
            this.Office_no = Office_no_;
        }
        #endregion

        #endregion

    }
}
