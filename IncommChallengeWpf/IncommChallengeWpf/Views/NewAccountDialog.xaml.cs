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
using System.Windows.Shapes;
using IncommChallengeWpf.ViewModels;

namespace IncommChallengeWpf.Views
{
    /// <summary>
    /// Interaction logic for NewAccountDialog.xaml
    /// </summary>
    public partial class NewAccountDialog : Window
    {
        public NewAccountDialog()
        {
            InitializeComponent();
            this.DataContext = new NewAccountViewModel();
        }

        private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
