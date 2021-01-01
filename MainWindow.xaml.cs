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

            //главная страница
            Page=this;
        }
        /// <summary>
        /// ссылка на главную страницу
        /// </summary>
        public static MainWindow Page;

        /// <summary>
        /// главная страница приложения
        /// </summary>
        public static mainPage mPage = new mainPage();

        ///// <summary>
        ///// страница выбора дисциплины
        ///// </summary>
        //public static choiceDisciplinePage cDPape = new choiceDisciplinePage();

        /// <summary>
        /// Загрузка главного окна при запуске приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            mainContentControl.Content = mPage;
        }

        /// <summary>
        /// управление состоянием попапа, первый параметр - ссылка на попап, второй параметр - состояние (true - открыть, false - закрыть)
        /// </summary>
        /// <param name="popup"></param>
        /// <param name="status"></param>
        public static void controlPopup(Grid popup, bool status) {
            popup.IsEnabled = status;
            popup.Opacity = status ? 1 : 0;
            popup.IsHitTestVisible = status ? true : false;
        }
    }
}
