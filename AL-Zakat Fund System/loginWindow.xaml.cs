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
using System.Windows.Shapes;
using AL_Zakat_Fund_System.ViewModels;
using AL_Zakat_Fund_System.Models;

namespace AL_Zakat_Fund_System
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
            this.DataContext = new loginWindowViewModel(this);
            //DBConnection.OpenConnection();
            //DBConnection.CloseConnection();
        }
    }
}
