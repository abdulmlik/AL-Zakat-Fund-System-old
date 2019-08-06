using System.Windows;
using AL_Zakat_Fund_System.ViewModels;
using System.Windows.Media;
using System.Windows.Controls;

namespace AL_Zakat_Fund_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }
    }
}
