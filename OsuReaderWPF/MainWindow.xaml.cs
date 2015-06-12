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
using OsuReaderWPF.Helpers;
using OsuReaderWPF.Repositories;
using OsuReaderWPF.Models;
namespace OsuReaderWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txbPad.Text = TestPaths.Heroes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Beatmap test = new Beatmap(txbPad.Text);
            txbOutput.Text = test.ToOsu();
            
        }
    }
}
