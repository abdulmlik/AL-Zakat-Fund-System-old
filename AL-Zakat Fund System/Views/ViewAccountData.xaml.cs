﻿using System;
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
    /// Interaction logic for ViewAccountData.xaml
    /// </summary>
    public partial class ViewAccountData : UserControl
    {
        public ViewAccountData()
        {
            InitializeComponent();
            this.DataContext = new ViewAccountDataViewModel(this);
        }
    }
}
