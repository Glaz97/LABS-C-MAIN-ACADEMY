using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ProjectWPFAirline
{
    public partial class MainWindow : Window
    {
        private static BaseRepository BaseRepository = new BaseRepository();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = BaseRepository.LoadAirflightsData();
        }

        private void Airoport_Click(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = BaseRepository.LoadAirflightsData();
        }

        private void Passengers_Click(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = BaseRepository.LoadPassengersData();
        }

        private void Prices_Click(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = BaseRepository.LoadPriceListData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = (IEnumerable)BaseRepository.DeleteCurrentElement(DataBaseGrid.CurrentItem);
        }

        private void DataBaseGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit && e.Column is DataGridBoundColumn column)
            {
                BaseRepository.MarkCurrentItem(e.Row.Item, e.Row.GetIndex());
            }
        }

        private void DataBaseGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            var DataGridElement = sender as DataGrid;

            var ModifiedElement = BaseRepository.GetCurrentModifedElement(DataGridElement);

            try
            {
                BaseRepository.UpdateDbInfo(ModifiedElement, DataGridElement.SelectedIndex);
                LogTextBox.Text = "Data was successfully updated!";
            }
            catch (InvalidCastException d)
            {
                LogTextBox.Text = "Data updating is failed! Check the entered data! " + d.Message;
            }
        }

        private void AiroportSearch_Click(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = (IEnumerable)BaseRepository.FindAiroportInfoElements(SearchTextBox.Text);
        }

        private void PassengersSearch_Click(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = (IEnumerable)BaseRepository.FindPassengersInfoElements(SearchTextBox.Text);
        }

        private void PriceSearch_Click(object sender, RoutedEventArgs e)
        {
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = (IEnumerable)BaseRepository.FindPriceListInfoElements(SearchTextBox.Text);
        }
    }
}
