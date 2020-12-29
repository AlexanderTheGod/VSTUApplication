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
using VSTUApp;

namespace VSTUApp.View {
    /// <summary>
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
    public partial class mainPage : UserControl {
        public mainPage() {
            InitializeComponent();

            //плэсхолдеры
            Placeholder.add(lastName, "Фамилия");
            Placeholder.add(firstName, "Имя");
            Placeholder.add(secondName, "Отчество");
            Placeholder.add(group, "Группа");
        }

        /// <summary>
        /// выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// событие при нажатии на чекбокс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e) {
            CheckBox curCb = (sender as CheckBox);
            if (curCb.Name == "cb1") {
                if (cb1.IsChecked == true) {
                    cb2.IsChecked = false;
                    group.Visibility = Visibility.Collapsed;
                } else {
                    group.Visibility = Visibility.Visible;
                    Placeholder.add(group, "Группа");
                }
            } else {
                if (cb2.IsChecked == true) {
                    cb1.IsChecked = false;
                    Placeholder.add(group, "Пароль");
                    group.Visibility = Visibility.Visible;
                } else {
                    Placeholder.add(group, "Группа");
                }
            }
        }
    }
}
