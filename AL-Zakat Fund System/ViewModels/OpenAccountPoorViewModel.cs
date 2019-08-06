using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;

namespace AL_Zakat_Fund_System.ViewModels
{
    class OpenAccountPoorViewModel : Indigent
    {
        #region private Member
        UserControl CurrentPage;
        #endregion

        #region public properties

        #endregion

        #region Delegate Command

        public DelegateCommand OpenAccountPoorDatabaseCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region save AccountPoor
        private void OpenAccountPoorDatabaseExecute()
        {

        }
        private bool OpenAccountPoorDatabaseCanExecute()
        {
            if (true)
            {

            }
            return true;
        }
        #endregion

        #region Reset
        private void ResetExecute()
        {
            Ssn = "";
            Date = DateTime.Now;
            RequestStatus = 0;
            FName = "";
            MName = "";
            GName = "";
            LName = "";
            MotherName = "";
            BirthDate = DateTime.Now;
            PlaceOfBirth = "";
            TypeAssistance = "";
            SocialStatus = 0;
            Nationality = "";
            BrochureFamilyNO = "";
            BFDate = DateTime.Now;
            BFPlace = "";
            FamilyPaperNO = "";
            NumberOfChildren = "";
            PersonalCardNO = "";
            PassportNO = "";
            City = "";
            Municipality = "";
            Locality = "";
            Street = "";
            NearestMosque = "";
            DialCode = "";
            Number = "";
            Email = "";
            Job = "";
            Salary = "";
            SourceOFSalary = "";
            HousingCase = 0;
            TypeHousing = 0;
            Transportation = 0;
            TCase = 0;
            LSComment = "";
            ChronicDisease = 0;
            HSComment = "";
            Gender = true;
        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            CurrentPage.Content = null;
        }
        #endregion

        #endregion

        #region Construct
        public OpenAccountPoorViewModel(UserControl CP)
        {
            CurrentPage = CP;


            Date = DateTime.Now;
            RequestStatus = 0;
            DialCode = "218";

            OpenAccountPoorDatabaseCommand = new DelegateCommand(OpenAccountPoorDatabaseExecute, OpenAccountPoorDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
