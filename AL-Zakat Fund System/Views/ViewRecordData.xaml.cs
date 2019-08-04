using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AL_Zakat_Fund_System.ViewModels;

namespace AL_Zakat_Fund_System.Views
{
    /// <summary>
    /// Interaction logic for ViewRecordData.xaml
    /// </summary>
    public partial class ViewRecordData : UserControl
    {
        public ViewRecordData()
        {
            InitializeComponent();
            this.DataContext = new ViewRecordDataViewModel(this);
        }
    }
}
