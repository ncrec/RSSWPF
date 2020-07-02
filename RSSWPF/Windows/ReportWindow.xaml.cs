using RSSWPF.Extentions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RSSWPF.Windows
{

    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            FillComboBox();
            RefreshGrid();
        }

        private async void RefreshGrid()
        {

            await using var db = new DataContext();

            var query = db.Products.Join(db.ChangeStatusHistories,
                  p => p.Id,
                  t => t.ProductId,
                  (p, t) => new { p.Name, p.Price, p.StatusId,p.Status, t.SetOn,t.StatusFrom, t.StatusFromId });

            var filter = FilterComboBox.SelectedItem;
            if (filter != null)
            {
                switch (filter.ToString())
                {
                    case StatusConsts.AcceptedStr:
                        query = query.Where(p => p.StatusId == StatusConsts.Accepted);
                        break;
                    case StatusConsts.SoldOutStr:
                        query = query.Where(p => p.StatusId == StatusConsts.SoldOut);
                        break;
                    case StatusConsts.ToTheWarehouseStr:
                        query = query.Where(p => p.StatusId == StatusConsts.ToTheWarehouse);
                        break;
                    default: break;
                }
                
            }
            var dateFrom = DateFromPicker.SelectedDate;
            if (dateFrom != null)
                query = query.Where(t => t.SetOn >= dateFrom);
            var dateTo = DateToPicker.SelectedDate;
            if (dateTo != null)
                query = query.Where(t => t.SetOn <= dateTo);
            var data   = query.ToList();
            TotalSumTextBox.Text = data?.Count == 0 ? "0" : data.Sum(p => p.Price).ToString(CultureInfo.InvariantCulture); 
            ProductsDataGrid.ItemsSource = data;
        }

        private void FillComboBox()
        {
            FilterComboBox.Items.Add(StatusConsts.All);
            FilterComboBox.Items.Add(StatusConsts.SoldOutStr);
            FilterComboBox.Items.Add(StatusConsts.AcceptedStr);
            FilterComboBox.Items.Add(StatusConsts.ToTheWarehouseStr);
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshGrid();
        }

        private void FilterComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshGrid();
        }

        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            RefreshGrid();
        }
    }
}
