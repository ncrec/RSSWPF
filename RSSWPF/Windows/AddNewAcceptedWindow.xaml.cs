using RSSWPF.Extentions;
using RSSWPF.Models;
using System;
using System.Windows;

namespace RSSWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewAcceptedWindow.xaml
    /// </summary>
    public partial class AddNewAcceptedWindow : Window
    {
        private readonly AcceptedWindow _acceptedWindow;
        public AddNewAcceptedWindow(AcceptedWindow acceptedWindow)
        {
            InitializeComponent();
            _acceptedWindow = acceptedWindow;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProduct = new Product
                {
                    Id = new Guid(),
                    Name = NameTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    StatusId = StatusConsts.Accepted
                };
                var history = new ChangeStatusHistory
                {
                    Id = new Guid(),
                    ProductId = newProduct.Id,
                    SetOn = DateTime.Today,
                    StatusFromId = StatusConsts.Created,
                    StatusToId = StatusConsts.Accepted
                };
                await using var context = new DataContext();
                await context.Products.AddAsync(newProduct);
                await context.ChangeStatusHistories.AddAsync(history);
                context.SaveChanges();
                _acceptedWindow.RefreshGrid();
                MessageBox.Show("Продукт добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                //logging ex
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
