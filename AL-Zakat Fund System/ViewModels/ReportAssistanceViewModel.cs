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
            DTExpenses.Columns.Add("NameMonth", typeof(string));
            //
            DTExpenses.Columns.Add("CashAlfuqaraAndAlmasakin", typeof(decimal));
            DTExpenses.Columns.Add("CashAlgharimin", typeof(decimal));
            DTExpenses.Columns.Add("CashAbnAlsabil", typeof(decimal));
            DTExpenses.Columns.Add("CashAlmualafatQulubuhum", typeof(decimal));
            DTExpenses.Columns.Add("CashFiSabilAllah", typeof(decimal));
            DTExpenses.Columns.Add("CashCollectors", typeof(decimal));
            DTExpenses.Columns.Add("CashOffice", typeof(decimal));
            //
            DTExpenses.Columns.Add("InstrumentAlfuqaraAndAlmasakin", typeof(decimal));
            DTExpenses.Columns.Add("InstrumentAlgharimin", typeof(decimal));
            DTExpenses.Columns.Add("InstrumentAbnAlsabil", typeof(decimal));
            DTExpenses.Columns.Add("InstrumentAlmualafatQulubuhum", typeof(decimal));
            DTExpenses.Columns.Add("InstrumentFiSabilAllah", typeof(decimal));
            DTExpenses.Columns.Add("InstrumentCollectors", typeof(decimal));
            DTExpenses.Columns.Add("InstrumentOffice", typeof(decimal));
            //
            DTExpenses.Columns.Add("NumberAlfuqaraAndAlmasakin", typeof(int));
            DTExpenses.Columns.Add("NumberAlgharimin", typeof(int));
            DTExpenses.Columns.Add("NumberAbnAlsabil", typeof(int));
            DTExpenses.Columns.Add("NumberAlmualafatQulubuhum", typeof(int));
            DTExpenses.Columns.Add("NumberFiSabilAllah", typeof(int));
            DTExpenses.Columns.Add("NumberCollectors", typeof(int));
            DTExpenses.Columns.Add("NumberOffice", typeof(int));


            //Set First Day of Month and Last Day of Month
            StartDate = new DateTime(StartDate.Value.Year, StartDate.Value.Month, 1);
            EndDate = new DateTime(EndDate.Value.Year, EndDate.Value.Month, DateTime.DaysInMonth(EndDate.Value.Year, EndDate.Value.Month));

            #region Get Data From DataBase
            DBConnection.cmd.CommandType = CommandType.StoredProcedure;
            if(Properties.Settings.Default.nameBranch == Properties.Settings.Default.nameOffice)
            {
                DBConnection.cmd.CommandText = "sp_ExpensesReportBranch";
                DBConnection.cmd.Parameters.Add(new SqlParameter("@Branch", SqlDbType.Int));
            }
            else
            {
                DBConnection.cmd.CommandText = "sp_ExpensesReportOffice";
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


            ObservableCollection<AuthorizeExpenditureTemp> list = new ObservableCollection<AuthorizeExpenditureTemp>();
            AuthorizeExpenditureTemp TE;

            try
            {
                list.Clear();

                DBConnection.OpenConnection();
                DBConnection.reader = DBConnection.cmd.ExecuteReader();

                while (DBConnection.reader.Read())
                {
                    TE = new AuthorizeExpenditureTemp();
                    TE.CategoryPoor = DBConnection.reader.GetByte(0);
                    TE.SDate = DBConnection.reader.GetDateTime(1);
                    TE.Amount = DBConnection.reader.GetDecimal(2);
                    TE.InstrumentNO = DBConnection.reader.GetBoolean(3);
                    if (DBConnection.reader.IsDBNull(4))
                    { TE.Record_id = null; }
                    else
                    { TE.Record_id = DBConnection.reader.GetInt64(4); }
                    
                    list.Add(TE);
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
                ObservableCollection<AuthorizeExpenditureTemp> listTemp = new ObservableCollection<AuthorizeExpenditureTemp>();
                //use to save the search result
                ObservableCollection<AuthorizeExpenditureTemp> list2;
                listTemp.AddRange(list);

                // Name Month and year first col in report
                string NameMonth = "شهر " + TStartDate.Value.Month.ToString() + " سنة " + TStartDate.Value.Year.ToString();

                // new list and search <= is there zakat in this month, return zakat if true
                list2 = new ObservableCollection<AuthorizeExpenditureTemp>(
                                        listTemp.Where(item => (item.SDate.Year == TStartDate.Value.Year && item.SDate.Month == TStartDate.Value.Month)
                                                            ).ToList<AuthorizeExpenditureTemp>());

                // calculate the 
                // add to DataSet to send to crystal report
                DTExpenses.Rows.Add(NameMonth
                                    //InstrumentNO when true => Cash
                                    , list2.Where(item2 => item2.InstrumentNO && item2.CategoryPoor == 0).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => item2.InstrumentNO && item2.CategoryPoor == 3).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => item2.InstrumentNO && item2.CategoryPoor == 5).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => item2.InstrumentNO && item2.CategoryPoor == 1).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => item2.InstrumentNO && item2.CategoryPoor == 4).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => item2.InstrumentNO && item2.CategoryPoor == 7).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => item2.InstrumentNO && item2.CategoryPoor == 6).Sum(item2 => item2.Amount)
                                    //InstrumentNO when false => Instrument
                                    , list2.Where(item2 => !item2.InstrumentNO && item2.CategoryPoor == 0).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => !item2.InstrumentNO && item2.CategoryPoor == 3).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => !item2.InstrumentNO && item2.CategoryPoor == 5).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => !item2.InstrumentNO && item2.CategoryPoor == 1).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => !item2.InstrumentNO && item2.CategoryPoor == 4).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => !item2.InstrumentNO && item2.CategoryPoor == 7).Sum(item2 => item2.Amount)
                                    , list2.Where(item2 => !item2.InstrumentNO && item2.CategoryPoor == 6).Sum(item2 => item2.Amount)
                                    //The number of beneficiaries  ,if beneficiary is null  generate new Record_id , 10000 The smallest number of Record_id in the DataBase
                                    , list2.Where(item2 => item2.CategoryPoor == 0).GroupBy(item => item.Record_id == null ? new Random().Next(0, 9999) : item.Record_id).Count()
                                    , list2.Where(item2 => item2.CategoryPoor == 3).GroupBy(item => item.Record_id == null ? new Random().Next(0, 9999) : item.Record_id).Count()
                                    , list2.Where(item2 => item2.CategoryPoor == 5).GroupBy(item => item.Record_id == null ? new Random().Next(0, 9999) : item.Record_id).Count()
                                    , list2.Where(item2 => item2.CategoryPoor == 1).GroupBy(item => item.Record_id == null ? new Random().Next(0, 9999) : item.Record_id).Count()
                                    , list2.Where(item2 => item2.CategoryPoor == 4).GroupBy(item => item.Record_id == null ? new Random().Next(0, 9999) : item.Record_id).Count()
                                    , list2.Where(item2 => item2.CategoryPoor == 7).GroupBy(item => item.Record_id == null ? new Random().Next(0, 9999) : item.Record_id).Count()
                                    , list2.Where(item2 => item2.CategoryPoor == 6).GroupBy(item => item.Record_id == null ? new Random().Next(0, 9999) : item.Record_id).Count()
                                    );
            }
            #endregion

            // Parameter for crystal report
            string PeriodReport = "خلال الفترة من " + StartDate.Value.ToString("yyyy-MM") + "   إلى " + EndDate.Value.ToString("yyyy-MM");
            // Parameter for crystal report
            string nameOffice = Properties.Settings.Default.nameOffice;

            CrystalExpenses cr = new CrystalExpenses();
            cr.Database.Tables["Expenses"].SetDataSource(DTExpenses);

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
        public ReportAssistanceViewModel(Window CW)
        {
            CurrentWindow = CW;

            ViewReportCommand = new DelegateCommand(ViewReportExecute, ViewReportCanExecute).ObservesProperty(() => StartDate).ObservesProperty(() => EndDate);
        }

        #endregion
    }
}
