﻿using Bookstore.ViewModel;
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
using System.Windows.Shapes;

namespace Bookstore.Views
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        public BookWindow(ViewModelBook viewModelBook)
        {
            InitializeComponent();
            _viewModelBook = viewModelBook;
            DataContext = _viewModelBook;
        }

        private ViewModelBook _viewModelBook;
    }
}
