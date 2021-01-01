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

namespace VSTUApp.View {
    /// <summary>
    /// Логика взаимодействия для choiceDisciplinePage.xaml
    /// </summary>
    public partial class choiceDisciplinePage : UserControl {
        public choiceDisciplinePage(string way) {
            InitializeComponent();

            //определение следующей страницы
            goTo = way; 
        }
        /// <summary>
        /// определение следующей страницы
        /// </summary>
        private static string goTo;

        /// <summary>
        /// возврат на страницу назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onPreviousPage_Click(object sender, RoutedEventArgs e) {
            if (goTo == "toStart" || goTo == "toResults" || goTo == "toCreate") {
                MainWindow.Page.mainContentControl.Content = MainWindow.mPage;
            } 
        }

        /// <summary>
        /// выбор вкладки "ВУЗ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UNI_Click(object sender, RoutedEventArgs e) {
            EGE.Background = SpecialColor.mainBack();
            EGE.Foreground = SpecialColor.mainBlue();
            EGE.IsEnabled = true;
            UNI.Background = SpecialColor.mainBlue();
            UNI.Foreground = SpecialColor.white();
            UNI.IsEnabled = false;
        }

        /// <summary>
        /// выбор вкладки "ЕГЭ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EGE_Click(object sender, RoutedEventArgs e) {
            UNI.Background = SpecialColor.mainBack();
            UNI.Foreground = SpecialColor.mainBlue();
            UNI.IsEnabled = true;
            EGE.Background = SpecialColor.mainBlue();
            EGE.Foreground = SpecialColor.white();
            EGE.IsEnabled = false;
        }

        /// <summary>
        /// кнопка "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e) {
            confirmData.Content = "Добавить";
            MainWindow.controlPopup(fakePopup, true);
        }

        /// <summary>
        /// закрытие попапа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closePopup_Click(object sender, RoutedEventArgs e) {
            MainWindow.controlPopup(fakePopup, false);
        }

        /// <summary>
        /// создание новой дисциплины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmData_Click(object sender, RoutedEventArgs e) {
            if (confirmData.Content.ToString() == "Добавить") {
                Button button = new Button();
                button.Style = listDisciplines.Resources["mainButtonStyle"] as Style;
                button.Content = nameOfNewDiscipline.Text;
                listDisciplines.Children.Add(button);
                MainWindow.controlPopup(fakePopup, false);
            } else {
                editableDiscipline.Content = nameOfNewDiscipline.Text;
                editableDiscipline = null;
                foreach (Button button in listDisciplines.Children) {
                    button.Style = listDisciplines.Resources["mainButtonStyle"] as Style;
                    button.Click -= editMe;
                }
                editButton.Content = "Редактировать";
                addButton.IsEnabled = removeButton.IsEnabled = headerDisciplines.IsEnabled = true;
                addButton.Opacity = removeButton.Opacity = headerDisciplines.Opacity = 1;
                MainWindow.controlPopup(fakePopup, false);
            }
        }

        /// <summary>
        /// кнопка "Редактировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, RoutedEventArgs e) {
            if (editButton.Content.ToString() == "Редактировать") {
                addButton.IsEnabled = removeButton.IsEnabled = headerDisciplines.IsEnabled = false;
                addButton.Opacity = removeButton.Opacity= headerDisciplines.Opacity = 0.3;
                editButton.Content = "Отмена";
                foreach (Button button in listDisciplines.Children) {
                    button.Style = listDisciplines.Resources["editButtonStyle"] as Style;
                    button.Click += editMe;
                }
            } else {
                editButton.Content = "Редактировать";
                foreach (Button button in listDisciplines.Children) {
                    button.Style = listDisciplines.Resources["mainButtonStyle"] as Style;
                    button.Click -= editMe;
                }
                addButton.IsEnabled = removeButton.IsEnabled = headerDisciplines.IsEnabled = true;
                addButton.Opacity = removeButton.Opacity = headerDisciplines.Opacity = 1;
            }
        }

        private Button editableDiscipline = null;
        /// <summary>
        /// редактирование элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editMe(object sender, RoutedEventArgs e) {
            confirmData.Content = "Редактировать";
            editableDiscipline = sender as Button;
            MainWindow.controlPopup(fakePopup, true);
        }

        /// <summary>
        /// кнопка "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, RoutedEventArgs e) {
            if (removeButton.Content.ToString() == "Удалить") {
                addButton.IsEnabled = editButton.IsEnabled = headerDisciplines.IsEnabled = false;
                addButton.Opacity = editButton.Opacity = headerDisciplines.Opacity = 0.3;
                removeButton.Content = "Отмена";
                foreach (Button button in listDisciplines.Children) {
                    button.Style = listDisciplines.Resources["removeButtonStyle"] as Style;
                    button.Click += removeMe;
                }
            } else {
                removeButton.Content = "Удалить";
                foreach (Button button in listDisciplines.Children) {
                    button.Style = listDisciplines.Resources["mainButtonStyle"] as Style;
                    button.Click -= removeMe;
                }
                addButton.IsEnabled = editButton.IsEnabled = headerDisciplines.IsEnabled = true;
                addButton.Opacity = editButton.Opacity = headerDisciplines.Opacity = 1;
            }
        }
        /// <summary>
        /// удаление элемента 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeMe(object sender, RoutedEventArgs e) {
            listDisciplines.Children.Remove(sender as Button);
            foreach (Button button in listDisciplines.Children) {
                button.Style = listDisciplines.Resources["mainButtonStyle"] as Style;
                button.Click -= removeMe;
            }
            addButton.IsEnabled = editButton.IsEnabled = headerDisciplines.IsEnabled = true;
            addButton.Opacity = editButton.Opacity = headerDisciplines.Opacity = 1;
            removeButton.Content = "Удалить";
        }
    }
}
