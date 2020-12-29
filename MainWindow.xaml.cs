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
using VSTUApp.View;

namespace VSTUApp {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            //установка шрифта для всего приложения
            Style = (Style)FindResource(typeof(Window));
        }
        /// <summary>
        /// главная страница приложения
        /// </summary>
        private mainPage mPage = new mainPage();

        /// <summary>
        /// Загрузка главного окна при запуске приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            mainContentControl.Content = mPage;
        }
    }
}
