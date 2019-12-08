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
    class ReportAssistanceViewModel : BindableBase
    {
        #region private Member

        Window CurrentWindow;

        private DateTime? _StartDate;
        private DateTime? _EndDate;

        private string _TypeAssistance;

        private CrystalDecisions.CrystalReports.Engine.ReportDocument _MyReportSource;

        #endregion

        #region private Function

        #endregion

        #region public properties

        public DateTime? StartDate
        {
            get { return _StartDate; }
            set { SetProperty(ref _StartDate, value); }
        }
        public DateTime? EndDate
        {
            get { return _EndDate; }
            set { SetProperty(ref _EndDate, value); }
        }
        public string TypeAssistance
        {
            get { return _TypeAssistance; }
            set { SetProperty(ref _TypeAssistance, value); }
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
            DataTable DTAssistance = new DataTable();
            DTAssistance.Columns.Add("FileNumber", typeof(Int32));
            DTAssistance.Columns.Add("Name", typeof(string));
            DTAssistance.Columns.Add("Ssn", typeof(string));
            DTAssistance.Columns.Add("NumberOfFamily", typeof(Int32));
            DTAssistance.Columns.Add("Phone", typeof(string));

            string typeAssistance = "";//use in name report

            #region Get Data From DataBase
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            if(Properties.Settings.Default.nameBranch == Properties.Settings.Default.nameOffice)
            {
                DBConnection.cmd.CommandText = "sp_AssistanceReportBranch";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Branch", SqlDbType.Int));
            }
            else
            {
                DBConnection.cmd.CommandText = "sp_AssistanceReportOffice";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office", SqlDbType.Int));
            }

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Assistance", SqlDbType.NVarChar,40));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            if (Properties.Settings.Default.nameBranch == Properties.Settings.Default.nameOffice)
            {
                DBConnection.cmd.Parameters["@Branch"].Value = Properties.Settings.Default.Branch;
            }
            else
            {
                DBConnection.cmd.Parameters["@Office"].Value = Properties.Settings.Default.Office;
            }
            //string nameAssistance;
            
            switch (TypeAssistance)
            {
                case "شهرية":
                    DBConnection.cmd.Parameters["@Assistance"].Value = "شهرية";
                    typeAssistance = "تقرير الإعانات الشهرية";
                    break;
                case "علاج":
                    DBConnection.cmd.Parameters["@Assistance"].Value = "علاج";
                    typeAssistance = "تقرير إعانات العلاج";
                    break;
                case "زواج":
                    DBConnection.cmd.Parameters["@Assistance"].Value = "زواج";
                    typeAssistance = "تقرير إعانات الزواج";
                    break;
                case "بناء":
                    DBConnection.cmd.Parameters["@Assistance"].Value = "بناء";
                    typeAssistance = "تقرير إعانات البناء";
                    break;
                case "سداد ديون":
                    DBConnection.cmd.Parameters["@Assistance"].Value = "سداد ديون";
                    typeAssistance = "تقرير إعانات سداد الديون";
                    break;
                default:
                    DBConnection.cmd.Parameters["@Assistance"].Value = "null";
                    typeAssistance = "تقرير إعانات اخرى";
                    break;
            }
            //DBConnection.cmd.Parameters["@Assistance"].Value = nameAssistance;
            DBConnection.cmd.Parameters["@StartDate"].Value = StartDate;
            DBConnection.cmd.Parameters["@EndDate"].Value = EndDate;
           
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;


            ObservableCollection<Assistance> list = new ObservableCollection<Assistance>();

            try
            {
                list.Clear();

                DBConnection.OpenConnection();
                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    // add to DataSet to send to crystal report
                    DTAssistance.Rows.Add(DBConnection.reader.GetInt32(0)
                                        , DBConnection.reader.GetString(1)
                                        , DBConnection.reader.GetInt64(2).ToString()
                                        , Int32.Parse(DBConnection.reader.GetString(3))
                                        , DBConnection.reader.GetString(4)
                                        );
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

            #region Data Analysis
            #endregion

            // Parameter for crystal report
            string PeriodReport = "خلال الفترة من " + StartDate.Value.ToString("yyyy-MM-dd") + "   إلى " + EndDate.Value.ToString("yyyy-MM-dd");
            // Parameter for crystal report
            string nameOffice = Properties.Settings.Default.nameOffice;

            

            CrystalAssistance cr = new CrystalAssistance();
            cr.Database.Tables["Assistance"].SetDataSource(DTAssistance);

            cr.SetParameterValue("namePlace", nameOffice);
            cr.SetParameterValue("Period", PeriodReport);
            cr.SetParameterValue("typeAssistance", typeAssistance);///////////////////
            if (Properties.Settings.Default.nameBranch == nameOffice)
            { cr.SetParameterValue("Place", "مكتب");  }
            else
            {  cr.SetParameterValue("Place", "وحدة"); }

            MyReportSource = cr;
        }

        private bool ViewReportCanExecute()
        {
            if (StartDate != null && EndDate >= StartDate)
            {
                return true;
            }
            return false;
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
        public ReportAssistanceViewModel(Window CW)
        {
            CurrentWindow = CW;
            
            TypeAssistance = "شهرية";// default شهرية

            ViewReportCommand = new DelegateCommand(ViewReportExecute, ViewReportCanExecute).ObservesProperty(() => StartDate).ObservesProperty(() => EndDate);
        }

        #endregion
    }
}
