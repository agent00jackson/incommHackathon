using IncommChallengeWpf.ViewModels;
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
using Microsoft.Maps.MapControl.WPF;

namespace IncommChallengeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            viewModel.NewPushpin += OnNewPushpin;
        }

        public void OnNewPushpin(object sender, EventArgs e)
        {
            myMap.Children.Clear();
            foreach(var p in viewModel.Pushpins)
            {
                myMap.Children.Add(p);
            }
        }
    }
}
