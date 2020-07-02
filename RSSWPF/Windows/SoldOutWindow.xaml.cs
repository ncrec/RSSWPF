using Microsoft.EntityFrameworkCore;
using RSSWPF.Extentions;
using System.Linq;
using System.Windows;

namespace RSSWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для SoldOutWindow.xaml
    /// </summary>
    public partial class SoldOutWindow : Window
    {
        public SoldOutWindow()
        {
            InitializeComponent();
            RefreshGrid();
        }
        private async void RefreshGrid()
        {
            await using var db = new DataContext();
            await db.Products.Include(p => p.Status).Where(p => p.StatusId == StatusConsts.SoldOut).LoadAsync();
            ProductsDataGrid.ItemsSource = db.Products.Local.ToBindingList();
        }
    }
}
