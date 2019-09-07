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
    class ReportSocialResearchViewModel : BindableBase
    {
        #region private Member

        Window CurrentWindow;

        private DateTime? _StartDate;
        private DateTime? _EndDate;

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
            DataTable DTExpenses = new DataTable();
            DTExpenses.Columns.Add("EmpType", typeof(string));
            DTExpenses.Columns.Add("Name", typeof(string));
            //
            DTExpenses.Columns.Add("NearCompletedFiles", typeof(int));
            DTExpenses.Columns.Add("FarCompletedFiles", typeof(int));
            DTExpenses.Columns.Add("FileRefNotCompletedFiles", typeof(int));
            DTExpenses.Columns.Add("InProcedureNotCompletedFiles", typeof(int));

            #region Get Data From DataBase
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            if(Properties.Settings.Default.nameBranch == Properties.Settings.Default.nameOffice)
            {
                DBConnection.cmd.CommandText = "sp_SocialResearchReportBranch";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Branch", SqlDbType.Int));
            }
            else
            {
                DBConnection.cmd.CommandText = "sp_SocialResearchReportOffice";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Office", SqlDbType.Int));
            }

            
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
            DBConnection.cmd.Parameters["@StartDate"].Value = StartDate;
            DBConnection.cmd.Parameters["@EndDate"].Value = EndDate;
            
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;


            ObservableCollection<Follow_upTemp> list = new ObservableCollection<Follow_upTemp>();
            Follow_upTemp TF;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();
                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TF = new Follow_upTemp();
                    TF.FStatus = DBConnection.reader.GetByte(0);
                    TF.Distance = DBConnection.reader.GetByte(1);
                    TF.FullName = DBConnection.reader.GetString(2);
                    TF.Degree = DBConnection.reader.GetByte(3);
                    
                    list.Add(TF);
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
            // Group By name Employee
            var listTemp = list.GroupBy(item => item.FullName);

            foreach (var item in listTemp)//var = ObservableCollection<Follow_upTemp>
            {
                string Degree;
                if ((int)item.First().Degree == -1)
                {
                    Degree = "عقد";
                }
                else if ((int)item.First().Degree == -2)
                {
                    Degree = "متعاون";
                }
                else
                {
                    Degree = "موظف";
                }
                // calculate the 
                // add to DataSet to send to crystal report
                DTExpenses.Rows.Add(Degree
                                    , item.Key //name Employee
                                    , item.Where(item2 => item2.FStatus == 2 && item2.Distance == 0).Count()
                                    , item.Where(item2 => item2.FStatus == 2 && item2.Distance == 1).Count()
                                    , item.Where(item2 => item2.FStatus == 1).Count()
                                    , item.Where(item2 => item2.FStatus == 0).Count()
                                    );

            }

            

            #endregion

            // Parameter for crystal report
            string PeriodReport = "خلال الفترة من " + StartDate.Value.ToString("yyyy-MM-dd") + "   إلى " + EndDate.Value.ToString("yyyy-MM-dd");
            // Parameter for crystal report
            string nameOffice = Properties.Settings.Default.nameOffice;

            CrystalSocialResearch cr = new CrystalSocialResearch();
            cr.Database.Tables["SocialResearch"].SetDataSource(DTExpenses);

            cr.SetParameterValue("namePlace", nameOffice);
            cr.SetParameterValue("Period", PeriodReport);
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
        public ReportSocialResearchViewModel(Window CW)
        {
            CurrentWindow = CW;

            ViewReportCommand = new DelegateCommand(ViewReportExecute, ViewReportCanExecute).ObservesProperty(() => StartDate).ObservesProperty(() => EndDate);
        }

        #endregion
    }
}
