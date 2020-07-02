using Microsoft.EntityFrameworkCore;
using RSSWPF.Extentions;
using RSSWPF.Models;
using System;
using System.Linq;
using System.Windows;

namespace RSSWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для ToTheWarehouseWindow.xaml
    /// </summary>
    public partial class ToTheWarehouseWindow : Window
    {
        public ToTheWarehouseWindow()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var changingProduct = (Product)ProductsDataGrid.SelectedItem;
                await using var context = new DataContext();
                var updateProduct = await context.Products.FindAsync(changingProduct.Id);
                var history = await context.ChangeStatusHistories.Where(b => b.ProductId == updateProduct.Id).FirstAsync();
                history.SetOn = DateTime.Today;
                history.StatusFromId = history.StatusToId;
                history.StatusToId = StatusConsts.SoldOut;
                updateProduct.StatusId = StatusConsts.SoldOut;
                await context.SaveChangesAsync();
                RefreshGrid();
                MessageBox.Show("Продано успешно");
            }
            catch (Exception ex)
            {
                //logging ex
                MessageBox.Show("Произошла ошибка");
            }
            
        }

        private async void RefreshGrid()
        {
            await using var db = new DataContext();
            await db.Products.Include(p => p.Status).Where(p => p.StatusId == StatusConsts.ToTheWarehouse).LoadAsync();
            ProductsDataGrid.ItemsSource = db.Products.Local.ToBindingList();
        }
    }
}
