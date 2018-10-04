using System.Windows;

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

    }
}
