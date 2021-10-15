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

namespace form_dedmo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> a = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            a.Add("a");
            a.Add("b");
            combobox.Items.Add("a");
            combobox.Items.Add("b");
        }

        private void changetext_Click(object sender, RoutedEventArgs e)
        {
            txtblock.Text = txtbox1.Text;
            txtblock.Text = txtbox1.Text + combobox.Text;
            txtbox1.Clear();
        }
    }
}
