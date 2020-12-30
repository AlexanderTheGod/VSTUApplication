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
using System.Text.RegularExpressions;

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
                    passwordPlace.Visibility = Visibility.Collapsed;
                } else {
                    group.Visibility = Visibility.Visible;
                    passwordPlace.Visibility = Visibility.Collapsed;
                }
            } else {
                if (cb2.IsChecked == true) {
                    cb1.IsChecked = false;
                    passwordPlace.Visibility = Visibility.Visible;
                    group.Visibility = Visibility.Collapsed;
                } else {
                    group.Visibility = Visibility.Visible;
                    passwordPlace.Visibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// "НАЧАТЬ ТЕСТИРОВАНИЕ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startTest_Click(object sender, RoutedEventArgs e) {
            MainWindow.Page.mainContentControl.Content = new choiceDisciplinePage("toStart");
        }

        /// <summary>
        /// "РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЙ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkResults_Click(object sender, RoutedEventArgs e) {
            MainWindow.Page.mainContentControl.Content = new choiceDisciplinePage("toResults");
        }

        /// <summary>
        /// "СОЗДАТЬ ТЕСТ/ЗАДАНИЕ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTest_Click(object sender, RoutedEventArgs e) {
            MainWindow.Page.mainContentControl.Content = new choiceDisciplinePage("toCreate");
        }

        private static string editorPassword = "12345";
        /// <summary>
        /// переменная для валидации
        /// </summary>
        private static bool saveDataFlag = true;
        /// <summary>
        /// переменная для валидации
        /// </summary>
        private static bool isCurrentData = false;
        /// <summary>
        /// проверка введенности данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void saveData_Click(object sender, RoutedEventArgs e) {
            if (saveDataFlag == true) {
                saveDataFlag = false;

                isCurrentData = false;
                if (!(bool)cb1.IsChecked && !(bool)cb2.IsChecked) {
                    if (lastName.Text != "" && lastName.Text != "Фамилия" &&
                        firstName.Text != "" && firstName.Text != "Имя" &&
                        secondName.Text != "" && secondName.Text != "Отчество" &&
                        group.Text != "" && group.Text != "Группа") {
                        Regex regFIO = new Regex("^([А-Я]|[A-Z])([а-я]|[a-z])+$");
                        Regex regGroup = new Regex("^[А-ЯA-Z 0-9\\-]*$");//"^([А-Я]|[A-Z]){2,}(\\-| )?\\d{1,2}\\-\\d{2}$"
                        if (regFIO.IsMatch(lastName.Text) &&
                            regFIO.IsMatch(firstName.Text) &&
                            regFIO.IsMatch(secondName.Text) &&
                            regGroup.IsMatch(group.Text)) {
                            MainWindow.Page.currentRecord.Content = lastName.Text + " " + firstName.Text + " " + secondName.Text + " " + group.Text;
                            isCurrentData = true;
                        }
                    }
                } else if ((bool)cb2.IsChecked) {
                    if (lastName.Text != "" && lastName.Text != "Фамилия" &&
                        firstName.Text != "" && firstName.Text != "Имя" &&
                        secondName.Text != "" && secondName.Text != "Отчество" &&
                        password.Password != "") {
                        Regex regFIO = new Regex("^([А-Я]|[A-Z])([а-я]|[a-z])+$");
                        if (regFIO.IsMatch(lastName.Text) &&
                            regFIO.IsMatch(firstName.Text) &&
                            regFIO.IsMatch(secondName.Text) &&
                            password.Password == editorPassword) {
                            MainWindow.Page.currentRecord.Content = "<РЕДАКТОР>";
                            isCurrentData = true;
                        }
                    }
                } else {
                    if (lastName.Text != "" && lastName.Text != "Фамилия" &&
                        firstName.Text != "" && firstName.Text != "Имя" &&
                        secondName.Text != "" && secondName.Text != "Отчество") {
                        Regex regFIO = new Regex("^([А-Я]|[A-Z])([а-я]|[a-z])+$");
                        if (regFIO.IsMatch(lastName.Text) &&
                            regFIO.IsMatch(firstName.Text) &&
                            regFIO.IsMatch(secondName.Text)) {
                            MainWindow.Page.currentRecord.Content = lastName.Text + " " + firstName.Text + " " + secondName.Text;
                            isCurrentData = true;
                        }
                    }
                }

                if (isCurrentData == true) {
                    DataPopupText.Content = "ДАННЫЕ СОХРАНЕНЫ";


                } else {
                    DataPopupText.Content = "ДАННЫЕ НЕ СОХРАНЕННЫ";
                    MainWindow.Page.currentRecord.Content = "*Учетная запись";
                }
                DataPopupText.Background = isCurrentData == true ? SpecialColor.green() : SpecialColor.red();
                DataPopup.IsOpen = true;
                await Task.Delay(2000);
                DataPopup.IsOpen = false;

                saveDataFlag = true;
            }
        }

        /// <summary>
        /// валидация полей фамилии, имени, отчества
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {
            string input = (sender as TextBox).Text;
            if (!Regex.IsMatch(input, "^([А-Я]|[A-Z]){1}(([а-я]|[a-z]){1,})?$")) {
                if (input.Length != 0)
                    (sender as TextBox).Text = textBeforeChange;
                (sender as TextBox).SelectionStart = selectionBeforeChange;
                (sender as TextBox).SelectionLength = selectionLengthBeforeChange;
            }
        }
        /// <summary>
        /// валидация поля группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged2(object sender, TextChangedEventArgs e) {
            string input = (sender as TextBox).Text;
            if (!Regex.IsMatch(input, "(^[А-ЯA-Z 0-9\\-]*$|Группа)")) {
                if (input.Length != 0)
                    (sender as TextBox).Text = textBeforeChange;
                (sender as TextBox).SelectionStart = selectionBeforeChange;
                (sender as TextBox).SelectionLength = selectionLengthBeforeChange;
            }

        }

        /// <summary>
        /// поле для проверки введенности данных
        /// </summary>
        private string textBeforeChange;
        /// <summary>
        /// поле для проверки введенности данных
        /// </summary>
        private int selectionBeforeChange;
        /// <summary>
        /// поле для проверки введенности данных
        /// </summary>
        private int selectionLengthBeforeChange;
        /// <summary>
        /// считывание данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e) {
            textBeforeChange = (sender as TextBox).Text;
            selectionBeforeChange = (sender as TextBox).SelectionStart;
            selectionLengthBeforeChange = (sender as TextBox).SelectionLength;
        }

        /// <summary>
        /// получение фокуса у поля пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void password_GotFocus(object sender, RoutedEventArgs e) {
            passwordLabel.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// потеря фокуса у поля пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void password_LostFocus(object sender, RoutedEventArgs e) {
            if(password.Password.Length==0)
                passwordLabel.Visibility = Visibility.Visible;
        }
    }
}
