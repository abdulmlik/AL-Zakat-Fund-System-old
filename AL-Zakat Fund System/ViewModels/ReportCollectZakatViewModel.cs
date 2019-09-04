using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Prism.Commands;
using AL_Zakat_Fund_System.Views.CrystalReport;
using AL_Zakat_Fund_System.Models;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace AL_Zakat_Fund_System.ViewModels
{
    class ReportCollectZakatViewModel : BindableBase
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
            ///hhhhh
            DataTable DTZakat = new DataTable();
            DTZakat.Columns.Add("NameMonth", typeof(string));
            DTZakat.Columns.Add("TotalZakat", typeof(decimal));
            DTZakat.Columns.Add("OfficeRevenue", typeof(decimal));
            DTZakat.Columns.Add("CollectorRevenue", typeof(decimal));
            DTZakat.Columns.Add("BankRevenue", typeof(decimal));


            //Set First Day of Month and Last Day of Month
            StartDate = new DateTime(StartDate.Value.Year, StartDate.Value.Month, 1);
            EndDate = new DateTime(EndDate.Value.Year, EndDate.Value.Month, DateTime.DaysInMonth(EndDate.Value.Year, EndDate.Value.Month));

            #region Get Data From DataBase
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            DBConnection.cmd.CommandText = "sp_ZakatReportBranch";

            DBConnection.cmd.Parameters.Add(new SqlParameter("@Branch", SqlDbType.Int));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
            //DBConnection.cmd.Parameters.Add(new SqlParameter("@nameBranch", SqlDbType.NVarChar,20));
            DBConnection.cmd.Parameters.Add(new SqlParameter("@Success", SqlDbType.Int));

            DBConnection.cmd.Parameters["@Branch"].Value = Properties.Settings.Default.Branch;
            DBConnection.cmd.Parameters["@StartDate"].Value = StartDate;
            DBConnection.cmd.Parameters["@EndDate"].Value = EndDate;

            //DBConnection.cmd.Parameters["@nameBranch"].Direction = ParameterDirection.Output;
            DBConnection.cmd.Parameters["@Success"].Direction = ParameterDirection.Output;


            ObservableCollection<ZakatTemp> list = new ObservableCollection<ZakatTemp>();
            ZakatTemp TZ;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();
                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TZ = new ZakatTemp();
                    TZ.SDate = DBConnection.reader.GetDateTime(0);
                    TZ.Amount = DBConnection.reader.GetDecimal(1);
                    TZ.Collector = DBConnection.reader.GetByte(2);
                    if (DBConnection.reader.IsDBNull(3)) { TZ.MigrationDate = null; }
                    else { TZ.MigrationDate = DBConnection.reader.GetDateTime(3); }

                    list.Add(TZ);
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
            // for start StartDate end EndDate increases 1 month
            for (DateTime? TStartDate = StartDate; TStartDate <= EndDate; TStartDate = TStartDate.Value.AddMonths(1))
            {
                //listTemp use instead of the list
                ObservableCollection<ZakatTemp> listTemp = new ObservableCollection<ZakatTemp>();
                //use to save the search result
                ObservableCollection<ZakatTemp> list2;
                listTemp.AddRange(list);

                // Name Month and year first col in report
                string NameMonth = "شهر " + TStartDate.Value.Month.ToString() + " سنة " + TStartDate.Value.Year.ToString();

                // new list and search <= is there zakat in this month, return zakat if true
                list2 = new ObservableCollection<ZakatTemp>(
                                        listTemp.Where(item =>
                                                    // zakat not Migration
                                                    (item.MigrationDate == null && item.SDate.Year == TStartDate.Value.Year && item.SDate.Month == TStartDate.Value.Month)
                                                    // zakat Migration
                                                    || (item.MigrationDate != null && item.MigrationDate.Value.Year == TStartDate.Value.Year && item.MigrationDate.Value.Month == TStartDate.Value.Month)
                                                    ).ToList<ZakatTemp>());
               

                // calculate total zakat
                decimal OfficeRevenue = list2.Where(item2 => item2.Collector == 1).Sum(item2 => item2.Amount);
                decimal CollectorRevenue = list2.Where(item2 => item2.Collector == 0).Sum(item2 => item2.Amount);
                decimal BankRevenue = list2.Where(item2 => item2.Collector == 2).Sum(item2 => item2.Amount);
                decimal TotalZakat = OfficeRevenue + CollectorRevenue + BankRevenue;

                // add to DataSet to send to crystal report
                DTZakat.Rows.Add(NameMonth, TotalZakat, OfficeRevenue, CollectorRevenue, BankRevenue);
            }
            #endregion

            // Parameter for crystal report
            string PeriodReport = "خلال الفترة من " + StartDate.Value.ToString("yyyy-MM") + "   إلى " + EndDate.Value.ToString("yyyy-MM");
            // Parameter for crystal report
            string nameBranch = Properties.Settings.Default.nameBranch;

            CrystalCollectZakat cr = new CrystalCollectZakat();
            cr.Database.Tables["Zakat"].SetDataSource(DTZakat);

            cr.SetParameterValue("nameBranch", nameBranch);
            cr.SetParameterValue("Period", PeriodReport);

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
        public ReportCollectZakatViewModel(Window CW)
        {
            CurrentWindow = CW;

            ViewReportCommand = new DelegateCommand(ViewReportExecute, ViewReportCanExecute).ObservesProperty(() => StartDate).ObservesProperty(() => EndDate);
        }

        #endregion
    }
}
