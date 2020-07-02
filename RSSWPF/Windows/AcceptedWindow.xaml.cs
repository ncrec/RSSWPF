using Microsoft.EntityFrameworkCore;
using RSSWPF.Extentions;
using System.Linq;
using System.Windows;

namespace RSSWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для AcceptedWindow.xaml
    /// </summary>
    public partial class AcceptedWindow : Window
    {
        public AcceptedWindow()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddNewAcceptedWindow(this).Show();
        }

        internal async void RefreshGrid()
        {
            await using var db = new DataContext();
            await db.Products.Include(p => p.Status).Where(p => p.StatusId == StatusConsts.Accepted).LoadAsync();
            ProductsDataGrid.ItemsSource = db.Products.Local.ToBindingList();
        }
    }
}
