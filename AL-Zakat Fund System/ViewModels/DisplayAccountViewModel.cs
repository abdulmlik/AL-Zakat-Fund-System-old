using AL_Zakat_Fund_System.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AL_Zakat_Fund_System.ViewModels
{
    class DisplayAccountViewModel : Indigent
    {
        #region private Member
        private Window CurrentWindow;

        #endregion

        #region private function

        #region Get Account
        private void GetAccount()
        {
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_displayIndigent2";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@ID"].Value = long.Parse(Ssn);
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            try
            {

                DBConnection.OpenConnection();

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                DBConnection.reader.Read();

                #region read data
                SDate = DBConnection.reader.GetDateTime(1);
                RequestStatus2 = DBConnection.reader.GetString(2);
                FName = DBConnection.reader.GetString(3);
                MName = DBConnection.reader.GetString(4);
                GName = DBConnection.reader.GetString(5);
                LName = DBConnection.reader.GetString(6);
                MotherName = DBConnection.reader.GetString(7);
                DialCode = DBConnection.reader.GetString(8);
                Number = DBConnection.reader.GetString(9);
                TypeAssistance = DBConnection.reader.GetString(10);
                SocialStatus2 = DBConnection.reader.GetString(11);
                Nationality = DBConnection.reader.GetString(12);
                PersonalCardNO = DBConnection.reader.GetString(13);
                PassportNO = DBConnection.reader.GetString(14);
                Email = DBConnection.reader.GetString(15);
                Gender2 = DBConnection.reader.GetString(16);

                //Address
                City = DBConnection.reader.GetString(29);
                Municipality = DBConnection.reader.GetString(30);
                Locality = DBConnection.reader.GetString(31);
                Street = DBConnection.reader.GetString(32);
                NearestMosque = DBConnection.reader.GetString(33);

                //Brochure Family
                BrochureFamilyNO = DBConnection.reader.GetString(17);

                if (DBConnection.reader.IsDBNull(18)) { BFDate = null; }
                else { BFDate = DBConnection.reader.GetDateTime(18); }

                BFPlace = DBConnection.reader.GetString(19);
                FamilyPaperNO = DBConnection.reader.GetString(20);

                if (DBConnection.reader.IsDBNull(21)) { BirthDate = null; }
                else { BirthDate = DBConnection.reader.GetDateTime(21); }

                PlaceOfBirth = DBConnection.reader.GetString(22);
                NumberOfChildren = DBConnection.reader.GetString(23);

                //job
                Job = DBConnection.reader.GetString(24);
                Salary = DBConnection.reader.GetString(25);
                SourceOFSalary = DBConnection.reader.GetString(26);

                //Living Situation
                HousingCase2 = DBConnection.reader.GetString(34);
                TypeHousing2 = DBConnection.reader.GetString(35);
                Transportation2 = DBConnection.reader.GetString(36);
                TCase2 = DBConnection.reader.GetString(37);
                LSComment = DBConnection.reader.GetString(38);

                //Health Status
                ChronicDisease2 = DBConnection.reader.GetString(27);
                HSComment = DBConnection.reader.GetString(28);

                //
                Scribe_ssn2 = DBConnection.reader.GetString(39);
                Office_no2 = DBConnection.reader.GetString(40);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا في جلب البيانات" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            finally
            {
                DBConnection.CloseConnection();
            }
        }
        #endregion

        #endregion

        #region public properties
        #endregion

        #region Delegate Command 

        public DelegateCommand CancelCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region Cancel
        private void CancelExecute()
        {
            CurrentWindow.Close();
        }
        #endregion

        #endregion

        #region Construct
        public DisplayAccountViewModel(Window CW, string ssn)
        {
            CurrentWindow = CW;
            Ssn = ssn;

            GetAccount();// ues Ssn

            CancelCommand = new DelegateCommand(CancelExecute);
        }

        #endregion
    }
}
