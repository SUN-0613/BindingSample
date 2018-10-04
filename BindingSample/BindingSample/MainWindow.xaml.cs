using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BindingSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// ViewModel
        /// </summary>
        MainWindowViewModel _ViewModel;

        /// <summary>
        /// new
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();

            _ViewModel = new MainWindowViewModel();
            this.DataContext = _ViewModel;

        }

        /// <summary>
        /// ボタンクリック
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ViewModel.Calc();
        }

        /// <summary>
        /// TextBox.GotFocus
        /// </summary>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            this.Dispatcher.InvokeAsync(() =>
            {
                Task.Delay(0);
                ((TextBox)sender).SelectAll();
            });

        }

    }
}
