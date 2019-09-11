using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using AL_Zakat_Fund_System.Views;
using Prism.Commands;
using AL_Zakat_Fund_System.Views.CrystalReport;
using System.Collections.ObjectModel;
using AL_Zakat_Fund_System.Models;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ReportApplicantViewModel : BindableBase
    {
        #region private Member

        Window CurrentWindow;

        private string _Ssn;

        private CrystalDecisions.CrystalReports.Engine.ReportDocument _MyReportSource;

        #endregion

        #region private Function

        #endregion

        #region public properties

        public string Ssn
        {
            get { return _Ssn; }
            set { SetProperty(ref _Ssn, value); }
        }
        public CrystalDecisions.CrystalReports.Engine.ReportDocument MyReportSource
        {
            get { return _MyReportSource; }
            set { SetProperty(ref _MyReportSource, value); }
        }


        #endregion

        #region Delegate Command

        public DelegateCommand ViewReportCommand { get; set; }

        #endregion

        #region Execute and CanExecute Functions

        #region View Report
        
        private void ViewReportExecute()
        {
            #region DataTable DTApplicant
            DataTable DTApplicant = new DataTable();
            DTApplicant.Columns.Add("Ssn", typeof(long));
            DTApplicant.Columns.Add("SDate", typeof(string));
            DTApplicant.Columns.Add("RequestStatus", typeof(string));
            DTApplicant.Columns.Add("Name", typeof(string));
            DTApplicant.Columns.Add("Phone", typeof(string));
            DTApplicant.Columns.Add("SocialStatus", typeof(string));
            DTApplicant.Columns.Add("Nationality", typeof(string));
            DTApplicant.Columns.Add("Gender", typeof(string));
            DTApplicant.Columns.Add("BirthDate", typeof(string));
            DTApplicant.Columns.Add("NumberOfChildren", typeof(string));
            DTApplicant.Columns.Add("Job", typeof(string));
            DTApplicant.Columns.Add("Salary", typeof(string));
            DTApplicant.Columns.Add("SourceOFSalary", typeof(string));
            DTApplicant.Columns.Add("Address", typeof(string));
            DTApplicant.Columns.Add("Street", typeof(string));
            DTApplicant.Columns.Add("NearestMosque", typeof(string));
            DTApplicant.Columns.Add("ChronicDisease", typeof(string));
            DTApplicant.Columns.Add("HSComment", typeof(string));
            DTApplicant.Columns.Add("HousingCase", typeof(string));
            DTApplicant.Columns.Add("TypeHousing", typeof(string));
            DTApplicant.Columns.Add("Transportation", typeof(string));
            DTApplicant.Columns.Add("TCase", typeof(string));
            //22
            DTApplicant.Columns.Add("RecordID", typeof(long));
            DTApplicant.Columns.Add("RDate", typeof(string));
            DTApplicant.Columns.Add("RStatus", typeof(string));
            //
            DTApplicant.Columns.Add("CommitteeDecisionNO", typeof(long));
            DTApplicant.Columns.Add("CategoryPoor", typeof(string));
            DTApplicant.Columns.Add("TypeAssistance", typeof(string));
            DTApplicant.Columns.Add("Amount", typeof(decimal));
            DTApplicant.Columns.Add("CDDate", typeof(string));
            DTApplicant.Columns.Add("InstrumentNO", typeof(string));
            DTApplicant.Columns.Add("Comment", typeof(string));
            #endregion

            #region Get Data From DataBase
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_IndigentReport";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Ssn", SqlDbType.BigInt));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));
            

            DBConnection.cmd.Parameters["@Ssn"].Value = long.Parse(Ssn);
            
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;

            int succ = 0;

            try
            {
                DBConnection.OpenConnection();

                DBConnection.cmd.ExecuteNonQuery();
                succ = (int)DBConnection.cmd.Parameters["@Success"].Value;

                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    #region set data in data teable
                    DataRow DR = DTApplicant.NewRow();

                    DR["Ssn"] = DBConnection.reader.GetInt64(0);
                    DR["SDate"] = DBConnection.reader.GetString(1);
                    DR["RequestStatus"] = DBConnection.reader.GetString(2);
                    DR["Name"] = DBConnection.reader.GetString(3);
                    DR["Phone"] = DBConnection.reader.GetString(4);
                    DR["SocialStatus"] = DBConnection.reader.GetString(5);
                    DR["Nationality"] = DBConnection.reader.GetString(6);
                    DR["Gender"] = DBConnection.reader.GetString(7);
                    DR["BirthDate"] = DBConnection.reader.GetString(8);
                    DR["NumberOfChildren"] = DBConnection.reader.GetString(9);
                    DR["Job"] = DBConnection.reader.GetString(10);
                    DR["Salary"] = DBConnection.reader.GetString(11);
                    DR["SourceOFSalary"] = DBConnection.reader.GetString(12);
                    DR["ChronicDisease"] = DBConnection.reader.GetString(13);
                    DR["HSComment"] = DBConnection.reader.GetString(14);
                    DR["Address"] = DBConnection.reader.GetString(15);
                    DR["Street"] = DBConnection.reader.GetString(16);
                    DR["NearestMosque"] = DBConnection.reader.GetString(17);
                    DR["HousingCase"] = DBConnection.reader.GetString(18);
                    DR["TypeHousing"] = DBConnection.reader.GetString(19);
                    DR["Transportation"] = DBConnection.reader.GetString(20);
                    DR["TCase"] = DBConnection.reader.GetString(21);
                    // null
                    if (DBConnection.reader.IsDBNull(22))
                    {
                        DR["RecordID"] = DBNull.Value;
                        DR["RDate"] = DBNull.Value;
                        DR["RStatus"] = DBNull.Value;
                        DR["CommitteeDecisionNO"] = DBNull.Value;
                        DR["CategoryPoor"] = DBNull.Value;
                        DR["TypeAssistance"] = DBNull.Value;
                        DR["Amount"] = DBNull.Value;
                        DR["CDDate"] = DBNull.Value;
                        DR["InstrumentNO"] = DBNull.Value;
                        DR["Comment"] = DBNull.Value;
                    }
                    else
                    {
                        DR["RecordID"] = DBConnection.reader.GetInt64(22);
                        DR["RDate"] = DBConnection.reader.GetString(23);
                        DR["RStatus"] = DBConnection.reader.GetString(24);

                        if (DBConnection.reader.IsDBNull(25))
                        {
                            DR["CommitteeDecisionNO"] = DBNull.Value;
                            DR["CategoryPoor"] = DBNull.Value;
                            DR["TypeAssistance"] = DBNull.Value;
                            DR["Amount"] = DBNull.Value;
                            DR["CDDate"] = DBNull.Value;
                            DR["InstrumentNO"] = DBNull.Value;
                            DR["Comment"] = DBNull.Value; 
                        }
                        else
                        {
                            DR["CommitteeDecisionNO"] = DBConnection.reader.GetInt64(25);
                            DR["CategoryPoor"] = DBConnection.reader.GetString(26);
                            DR["TypeAssistance"] = DBConnection.reader.GetString(27);
                            DR["Amount"] = DBConnection.reader.GetDecimal(28);
                            DR["CDDate"] = DBConnection.reader.GetString(29);
                            DR["InstrumentNO"] = DBConnection.reader.GetString(30);
                            DR["Comment"] = DBConnection.reader.GetString(31);
                        }
                    }
                    
                    //

                    DTApplicant.Rows.Add(DR);
                    #endregion
                }

                if (succ == 2)
                {
                    MessageBox.Show("الرقم الوطني غير موجودة", "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    return;
                }
                else if (succ == 0)
                {
                    throw new Exception("خطا في الاجراء المخزن");
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("خطا في جلب البيانات" + Environment.NewLine + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error,
                                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            finally
            {
                DBConnection.CloseConnection();
            }
            #endregion


            // Parameter for crystal report
            string nameOffice = Properties.Settings.Default.nameOffice;

            CrystalApplicant cr = new CrystalApplicant();
            cr.Database.Tables["Applicant"].SetDataSource(DTApplicant);

            cr.SetParameterValue("namePlace", nameOffice);
            if (Properties.Settings.Default.nameBranch == nameOffice)
            { cr.SetParameterValue("Place", "مكتب");  }
            else
            {  cr.SetParameterValue("Place", "وحدة"); }

            MyReportSource = cr;
        }

        private bool ViewReportCanExecute()
        {
            if (string.IsNullOrEmpty(Ssn) || string.IsNullOrWhiteSpace(Ssn))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Cancel
        private void CancelExecute()
        {
            CurrentWindow.Close();// close window
        }
        #endregion

        #endregion

        #region Construct
        public ReportApplicantViewModel(Window CW)
        {
            CurrentWindow = CW;

            ViewReportCommand = new DelegateCommand(ViewReportExecute, ViewReportCanExecute).ObservesProperty(() => Ssn);
        }

        #endregion
    }
}
