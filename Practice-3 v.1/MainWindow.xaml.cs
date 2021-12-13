using Microsoft.Win32;
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
using LibArray;
using Lib_13;

namespace Practice_3_v._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private MyArray _myArray = new MyArray(3, 3);

        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            amount.Clear();
            _myArray.Fill();
            dataGrid.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            amount.Clear();
            _myArray.Clear();
            dataGrid.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void FindQuantity_Click(object sender, RoutedEventArgs e)
        {
            amount.Text = _myArray.CountOfNumbers();
        }

        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.DefaultExt = ".txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Импорт массива";

                if (openFileDialog.ShowDialog() == true)
                {
                    _myArray.Import(openFileDialog.FileName);
                }
                dataGrid.ItemsSource = _myArray.ToDataTable().DefaultView;
                amount.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }
        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.Title = "Экспорт массива";

                if (saveFileDialog.ShowDialog() == true)
                {
                    _myArray.Export(saveFileDialog.FileName);
                }
                dataGrid.ItemsSource = null;
                amount.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Золотарев М. А. ИСП-34.", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
