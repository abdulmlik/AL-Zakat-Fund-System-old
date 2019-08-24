using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class OpenAccountPoorViewModel : Indigent
    {
        #region private Member
        private UserControl CurrentPage;
        private MainWindowViewModel mainWindowVM;
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
            int succ = 0;
            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.CommandType = CommandType.StoredProcedure;
                DBConnection.cmd.CommandText = "sp_insertIndigent";


                //int PassportNO_Filter, PersonalCardNO_Filter, FamilyPaperNO_Filter;
                //sbyte NumberOfChildren_Filter;
                //decimal Salary_Filter;
                //PassportNO_Filter = (PassportNO ==  null) ? -1 : int.Parse(PassportNO);
                //PersonalCardNO_Filter = (PersonalCardNO == null) ? -1 : int.Parse(PersonalCardNO);
                //FamilyPaperNO_Filter = (FamilyPaperNO == null) ? -1 : int.Parse(FamilyPaperNO);
                //Salary_Filter = (Salary == null) ? 0 : decimal.Parse(Salary);
                //if (string.IsNullOrWhiteSpace(NumberOfChildren))
                //{ NumberOfChildren_Filter = 0; }
                //else
                //{ NumberOfChildren_Filter = sbyte.Parse(NumberOfChildren); }

                #region create Parameters
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@SDate", SqlDbType.DateTime));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@RequestStatus", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@MName", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@GName", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.NVarChar, 62));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@TypeAssistance", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@SocialStatus", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@BrochureFamilyNO", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@PersonalCardNO", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@PassportNO", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Bit));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Scribe_ssn", SqlDbType.BigInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office_no", SqlDbType.Int));

                DBConnection.cmd.Parameters.Add(new SqlParameter("@BFDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@BFPlace", SqlDbType.NVarChar, 30));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@FamilyPaperNO", SqlDbType.Int));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.Date));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@PlaceOfBirth", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@NumberOfChildren", SqlDbType.TinyInt));

                DBConnection.cmd.Parameters.Add(new SqlParameter("@Job", SqlDbType.NVarChar, 20));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Salary", SqlDbType.SmallMoney));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@SourceOFSalary", SqlDbType.NVarChar, 40));

                DBConnection.cmd.Parameters.Add(new SqlParameter("@HousingCase", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@TypeHousing", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Transportation", SqlDbType.Bit));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@TCase", SqlDbType.TinyInt));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@LSComment", SqlDbType.NText));

                DBConnection.cmd.Parameters.Add(new SqlParameter("@ChronicDisease", SqlDbType.Bit));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@HSComment", SqlDbType.NText));


                DBConnection.cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Municipality", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Locality", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 40));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@NearestMosque", SqlDbType.NVarChar, 40));

                DBConnection.cmd.Parameters.Add(new SqlParameter("@DialCode", SqlDbType.VarChar, 3));
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Number", SqlDbType.VarChar, 10));
                

                
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
                #endregion

                #region parameters indigent
                DBConnection.cmd.Parameters["@Ssn"].Value = Ssn;
                DBConnection.cmd.Parameters["@SDate"].Value = SDate;
                DBConnection.cmd.Parameters["@RequestStatus"].Value = RequestStatus;
                DBConnection.cmd.Parameters["@FName"].Value = FName;
                DBConnection.cmd.Parameters["@MName"].Value = MName;
                DBConnection.cmd.Parameters["@GName"].Value = GName;
                DBConnection.cmd.Parameters["@LName"].Value = LName;
                DBConnection.cmd.Parameters["@MotherName"].Value = MotherName;

                DBConnection.cmd.Parameters["@TypeAssistance"].IsNullable = true;
                if (TypeAssistance != null)
                {
                    DBConnection.cmd.Parameters["@TypeAssistance"].Value = TypeAssistance;
                }
                else
                {
                    DBConnection.cmd.Parameters["@TypeAssistance"].Value = DBNull.Value;
                }
                
                DBConnection.cmd.Parameters["@SocialStatus"].IsNullable = true;
                DBConnection.cmd.Parameters["@SocialStatus"].Value = SocialStatus;

                DBConnection.cmd.Parameters["@Nationality"].IsNullable = true;
                if (Nationality !=  null)
                {
                    DBConnection.cmd.Parameters["@Nationality"].Value = Nationality;
                }
                else
                {
                    DBConnection.cmd.Parameters["@Nationality"].Value = DBNull.Value;
                }

                DBConnection.cmd.Parameters["@PersonalCardNO"].IsNullable = true;
                if (PersonalCardNO !=  null)
                {
                    DBConnection.cmd.Parameters["@PersonalCardNO"].Value = PersonalCardNO;
                }
                else
                {
                    DBConnection.cmd.Parameters["@PersonalCardNO"].Value = DBNull.Value;
                }

                DBConnection.cmd.Parameters["@PassportNO"].IsNullable = true;
                if (PersonalCardNO !=  null)
                {
                    DBConnection.cmd.Parameters["@PassportNO"].Value = PassportNO;
                }
                else
                {
                    DBConnection.cmd.Parameters["@PassportNO"].Value = DBNull.Value;
                }

                DBConnection.cmd.Parameters["@Email"].IsNullable = true;
                if (Email !=  null)
                {
                    DBConnection.cmd.Parameters["@Email"].Value = Email;
                }
                else
                {
                    DBConnection.cmd.Parameters["@Email"].Value = DBNull.Value;
                }

                DBConnection.cmd.Parameters["@Gender"].IsNullable = true;
                DBConnection.cmd.Parameters["@Gender"].Value = Gender;

                DBConnection.cmd.Parameters["@Scribe_ssn"].Value = Properties.Settings.Default.EmpNo;
                DBConnection.cmd.Parameters["@Office_no"].Value = Properties.Settings.Default.Office;
                #endregion

                #region parameters Brochure Family
                DBConnection.cmd.Parameters["@BrochureFamilyNO"].IsNullable = true;
                if (BrochureFamilyNO !=  null)
                { DBConnection.cmd.Parameters["@BrochureFamilyNO"].Value = BrochureFamilyNO; }
                else
                { DBConnection.cmd.Parameters["@BrochureFamilyNO"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@BFDate"].IsNullable = true;
                if (BFDate !=  null)
                { DBConnection.cmd.Parameters["@BFDate"].Value = BFDate; }
                else
                { DBConnection.cmd.Parameters["@BFDate"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@BFPlace"].IsNullable = true;
                if (BFPlace !=  null)
                { DBConnection.cmd.Parameters["@BFPlace"].Value = BFPlace; }
                else
                { DBConnection.cmd.Parameters["@BFPlace"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@FamilyPaperNO"].IsNullable = true;
                if (FamilyPaperNO !=  null)
                { DBConnection.cmd.Parameters["@FamilyPaperNO"].Value = FamilyPaperNO; }
                else
                { DBConnection.cmd.Parameters["@FamilyPaperNO"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@BirthDate"].IsNullable = true;
                if (BirthDate !=  null)
                { DBConnection.cmd.Parameters["@BirthDate"].Value = BirthDate; }
                else
                { DBConnection.cmd.Parameters["@BirthDate"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@PlaceOfBirth"].IsNullable = true;
                if (PlaceOfBirth !=  null)
                { DBConnection.cmd.Parameters["@PlaceOfBirth"].Value = PlaceOfBirth; }
                else
                { DBConnection.cmd.Parameters["@PlaceOfBirth"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@NumberOfChildren"].IsNullable = true;
                if (NumberOfChildren !=  null)
                { DBConnection.cmd.Parameters["@NumberOfChildren"].Value = NumberOfChildren; }
                else
                { DBConnection.cmd.Parameters["@NumberOfChildren"].Value = DBNull.Value; }
                #endregion

                #region parameters Job
                DBConnection.cmd.Parameters["@Job"].IsNullable = true;
                if (Job !=  null)
                { DBConnection.cmd.Parameters["@Job"].Value = Job; }
                else
                { DBConnection.cmd.Parameters["@Job"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@Salary"].IsNullable = true;
                if (Salary !=  null)
                { DBConnection.cmd.Parameters["@Salary"].Value = Salary; }
                else
                { DBConnection.cmd.Parameters["@Salary"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@SourceOFSalary"].IsNullable = true;
                if (SourceOFSalary !=  null)
                { DBConnection.cmd.Parameters["@SourceOFSalary"].Value = SourceOFSalary; }
                else
                { DBConnection.cmd.Parameters["@SourceOFSalary"].Value = DBNull.Value; }
                #endregion

                #region Living Situation
                DBConnection.cmd.Parameters["@HousingCase"].Value = HousingCase;
                DBConnection.cmd.Parameters["@TypeHousing"].Value = TypeHousing;                
                DBConnection.cmd.Parameters["@Transportation"].Value = Transportation;                
                DBConnection.cmd.Parameters["@TCase"].Value = TCase;

                DBConnection.cmd.Parameters["@LSComment"].IsNullable = true;
                if (LSComment !=  null)
                { DBConnection.cmd.Parameters["@LSComment"].Value = LSComment; }
                else
                { DBConnection.cmd.Parameters["@LSComment"].Value = DBNull.Value; }
                #endregion

                #region Health Status
                DBConnection.cmd.Parameters["@ChronicDisease"].Value = ChronicDisease;

                DBConnection.cmd.Parameters["@HSComment"].IsNullable = true;
                if (HSComment !=  null)
                { DBConnection.cmd.Parameters["@HSComment"].Value = HSComment; }
                else
                { DBConnection.cmd.Parameters["@HSComment"].Value = DBNull.Value; }
                #endregion

                #region Address
                DBConnection.cmd.Parameters["@City"].IsNullable = true;
                if (City !=  null)
                { DBConnection.cmd.Parameters["@City"].Value = City; }
                else
                { DBConnection.cmd.Parameters["@City"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@Municipality"].IsNullable = true;
                if (Municipality !=  null)
                { DBConnection.cmd.Parameters["@Municipality"].Value = Municipality; }
                else
                { DBConnection.cmd.Parameters["@Municipality"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@Locality"].IsNullable = true;
                if (Locality !=  null)
                { DBConnection.cmd.Parameters["@Locality"].Value = Locality; }
                else
                { DBConnection.cmd.Parameters["@Locality"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@Street"].IsNullable = true;
                if (Street !=  null)
                { DBConnection.cmd.Parameters["@Street"].Value = HSComment; }
                else
                { DBConnection.cmd.Parameters["@Street"].Value = DBNull.Value; }

                DBConnection.cmd.Parameters["@NearestMosque"].IsNullable = true;
                if (NearestMosque !=  null)
                { DBConnection.cmd.Parameters["@NearestMosque"].Value = NearestMosque; }
                else
                { DBConnection.cmd.Parameters["@NearestMosque"].Value = DBNull.Value; }
                #endregion

                #region phone
                DBConnection.cmd.Parameters["@DialCode"].IsNullable = true;
                if (DialCode != null)
                { DBConnection.cmd.Parameters["@DialCode"].Value = DialCode; }
                else
                { DBConnection.cmd.Parameters["@DialCode"].Value = DBNull.Value; }


                DBConnection.cmd.Parameters["@Number"].IsNullable = true;
                if (Number != null)
                { DBConnection.cmd.Parameters["@Number"].Value = Number; }
                else
                { DBConnection.cmd.Parameters["@Number"].Value = DBNull.Value; }
                #endregion

                DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

                DBConnection.cmd.ExecuteNonQuery();

                succ = (int)DBConnection.cmd.Parameters["@Success"].Value;
                
                
                // It Was Stored in Database
                if (succ == 1)
                {
                    MessageBox.Show("تم تسجيل المحتاج بنجاح", "", MessageBoxButton.OK, MessageBoxImage.None,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // Indigent Already exists
                else if (succ == 2)
                {
                    MessageBox.Show("الرقم الوطني موجود مسبقا", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                // It is not Stored in Database
                else
                {
                    MessageBox.Show("لم يتم تسجيل المحتاج الرجاء التاكد من البيانات", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("لم يتم تسجيل المحتاج الرجاء التاكد من الاتصال بالسيرفر" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

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
            SDate = DateTime.Now;
            RequestStatus = 0;
            FName = "";
            MName = "";
            GName = "";
            LName = "";
            MotherName = "";
            BirthDate = null;
            PlaceOfBirth = "";
            TypeAssistance = "";
            SocialStatus = 0;
            Nationality = "";
            BrochureFamilyNO = "";
            BFDate = null;
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
            Transportation = false;
            TCase = 0;
            LSComment = "";
            ChronicDisease = false;
            HSComment = "";
            Gender = false;
        }
        #endregion

        #region Cancel
        private void CancelExecute()
        {
            mainWindowVM.ZeroThickness();
            CurrentPage.Content = null;
        }
        #endregion

        #endregion

        #region Construct
        public OpenAccountPoorViewModel(UserControl CP, MainWindowViewModel mainWindowVM_)
        {
            CurrentPage = CP;
            mainWindowVM = mainWindowVM_;


            SDate = DateTime.Now;
            RequestStatus = 0;
            DialCode = "218";

            OpenAccountPoorDatabaseCommand = new DelegateCommand(OpenAccountPoorDatabaseExecute, OpenAccountPoorDatabaseCanExecute);
            ResetCommand = new DelegateCommand(ResetExecute);
            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
