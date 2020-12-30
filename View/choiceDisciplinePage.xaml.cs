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
    }
}
