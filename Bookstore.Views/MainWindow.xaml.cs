using Bookstore.ViewModel;
using FirebirdSql.Data.FirebirdClient;
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

namespace Bookstore.Views
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _mainViewModel = new ViewModelMain();
            DataContext = _mainViewModel;
            await LoadData();
        }

        private async Task<bool> LoadData()
        {
            try
            {
                await _mainViewModel.LoadAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }        

        private void New_Button_Click(object sender, RoutedEventArgs e)
        {            
            var bookWindow = new BookWindow();
            var bookVM = new ViewModelBook();
            bookWindow.DataContext = bookVM;
            bookVM.EntityId = null;
            bookVM.Load();            
            bookWindow.ShowDialog();
        }

        private ViewModelMain _mainViewModel;
    }
}
