using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для theoryPage.xaml
    /// </summary>
    public partial class theoryPage : UserControl {
        public theoryPage() {
            InitializeComponent();
        }

        /// <summary>
        /// добавление поля для ввода текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTextButton_Click(object sender, RoutedEventArgs e) {
            mainInfoTheme.Children.Add(new TextBox());
        }

        /// <summary>
        /// закрытие окна редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closePopup_Click(object sender, RoutedEventArgs e) {
            MainWindow.controlPopup(fakePopup, false);
        }

        /// <summary>
        /// выход из теории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onPreviousPage_Click(object sender, RoutedEventArgs e) {
            MainWindow.Page.headerContentControl.Content = new choiceDisciplinePage(null, true);
        }

        /// <summary>
        /// выход из шапки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeTheory_Click(object sender, RoutedEventArgs e) {
            MainWindow.controlPopup(MainWindow.Page.headerContentControl, false);
        }

        /// <summary>
        /// добавление изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addImageButton_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            if ((bool)openFileDialog.ShowDialog()) {
                Label label = new Label();
                label.Tag = openFileDialog.FileName;
                label.MaxWidth = 650;

                Bitmap image = new Bitmap(openFileDialog.FileName);
                if (image.Width > nameTheme.ActualWidth) {
                    label.Width = nameTheme.ActualWidth;
                }

                mainInfoTheme.Children.Add(label);
            }
        }

        /// <summary>
        /// удаление поля для ввода текста и изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteElement_Click(object sender, RoutedEventArgs e) {
            if ((sender as Button).Tag.ToString()=="text")
                mainInfoTheme.Children.Remove((sender as Button).TemplatedParent as TextBox);
            else
                mainInfoTheme.Children.Remove((sender as Button).TemplatedParent as Label);
        }
    }
}
