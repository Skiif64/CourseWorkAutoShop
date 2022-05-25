using Shop.View.Views;
using System.Windows;

namespace Shop.View
{   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new DocumentView();
            window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new VehicleRequestView();
            window.ShowDialog();
        }
    }
}
