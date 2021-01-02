﻿using System;
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

namespace VSTUApp.View {
    /// <summary>
    /// Логика взаимодействия для aboutProgrammPage.xaml
    /// </summary>
    public partial class aboutProgrammPage : UserControl {
        public aboutProgrammPage() {
            InitializeComponent();
        }

        /// <summary>
        /// закрытие страницы "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onPreviousPage_Click(object sender, RoutedEventArgs e) {
            MainWindow.controlPopup(MainWindow.Page.headerContentControl, false);
        }
    }
}
