using RSSWPF.Windows;
using System.Windows;

namespace RSSWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AcceptedButton_Click(object sender, RoutedEventArgs e)
        { 
            new AcceptedWindow().Show();
        }

        private void SoldOutButton_Click(object sender, RoutedEventArgs e)
        {
            new SoldOutWindow().Show();
        }

        private void ToTheWarehouseButton_Click(object sender, RoutedEventArgs e)
        {
            new ToTheWarehouseWindow().Show();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
        }
    }
}
